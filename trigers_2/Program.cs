using System.Runtime.Intrinsics.X86;

USE SportShop;
GO

CREATE TABLE EmployeeArchive (
    ArchiveID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Position NVARCHAR(50),
    HireDate DATE,
    Gender CHAR(1),
    Salary DECIMAL(10,2),
    FiredDate DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_MergeProductOnInsert
ON Products
INSTEAD OF INSERT
AS
BEGIN
    MERGE Products AS target
    USING inserted AS source
    ON target.Name = source.Name AND target.Category = source.Category AND target.Manufacturer = source.Manufacturer AND target.CostPrice = source.CostPrice AND target.SalePrice = source.SalePrice
    WHEN MATCHED THEN
        UPDATE SET Quantity = target.Quantity + source.Quantity
    WHEN NOT MATCHED THEN
        INSERT (Name, Category, Quantity, CostPrice, Manufacturer, SalePrice)
        VALUES (source.Name, source.Category, source.Quantity, source.CostPrice, source.Manufacturer, source.SalePrice);
END;

CREATE TRIGGER trg_ArchiveFiredEmployee
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    INSERT INTO EmployeeArchive (FullName, Position, HireDate, Gender, Salary)
    SELECT FullName, Position, HireDate, Gender, Salary
    FROM deleted;
DELETE FROM Employees WHERE EmployeeID IN (SELECT EmployeeID FROM deleted);
END;

CREATE TRIGGER trg_LimitSellers
ON Employees
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted WHERE Position = 'Продавець'
    )
    BEGIN
        IF (
            (SELECT COUNT(*) FROM Employees WHERE Position = 'Продавець') >= 6
        )
        BEGIN
            RAISERROR('Перевищено кількість продавців', 16, 1);
RETURN;
END
END
    INSERT INTO Employees (FullName, Position, HireDate, Gender, Salary)
    SELECT FullName, Position, HireDate, Gender, Salary FROM inserted;
END;

USE MusicCollection;
GO

CREATE TABLE AlbumArchive (
    ArchiveID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100),
    Artist NVARCHAR(100),
    ReleaseDate DATE,
    Style NVARCHAR(100),
    Publisher NVARCHAR(100),
    ArchivedDate DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_PreventDuplicateAlbum
ON Discs
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN Discs d ON d.Title = i.Title AND d.Artist = i.Artist
    )
    BEGIN
        RAISERROR('Такий альбом уже є в колекції', 16, 1);
RETURN;
END
INSERT INTO Discs (Title, Artist, ReleaseDate, Style, Publisher)
    SELECT Title, Artist, ReleaseDate, Style, Publisher FROM inserted;
END;

CREATE TRIGGER trg_PreventBeatlesDelete
ON Discs
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM deleted WHERE Artist = 'The Beatles'
    )
    BEGIN
        RAISERROR('Не можна видаляти диски групи The Beatles', 16, 1);
RETURN;
END
DELETE FROM Discs WHERE DiscID IN (SELECT DiscID FROM deleted);
END;

CREATE TRIGGER trg_ArchiveDeletedDisc
ON Discs
AFTER DELETE
AS
BEGIN
    INSERT INTO AlbumArchive (Title, Artist, ReleaseDate, Style, Publisher)
    SELECT Title, Artist, ReleaseDate, Style, Publisher FROM deleted;
END;

CREATE TRIGGER trg_BlockDarkPowerPop
ON Discs
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Style = 'Dark Power Pop')
    BEGIN
        RAISERROR('Стиль Dark Power Pop заборонений', 16, 1);
RETURN;
END
INSERT INTO Discs (Title, Artist, ReleaseDate, Style, Publisher)
    SELECT Title, Artist, ReleaseDate, Style, Publisher FROM inserted;
END;

USE SalesDB;
GO

CREATE TABLE BuyerDuplicates (
    DuplicateID INT PRIMARY KEY IDENTITY,
    NewFullName NVARCHAR(100),
    MatchedLastName NVARCHAR(100),
    InsertDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE PurchaseHistory (
    HistoryID INT PRIMARY KEY IDENTITY,
    BuyerID INT,
    SellerID INT,
    ProductName NVARCHAR(100),
    Price DECIMAL(10,2),
    SaleDate DATETIME
);

CREATE TRIGGER trg_CheckBuyerDuplicates
ON Buyers
AFTER INSERT
AS
BEGIN
    INSERT INTO BuyerDuplicates (NewFullName, MatchedLastName)
    SELECT i.FullName, b.FullName
    FROM inserted i
    JOIN Buyers b ON RIGHT(i.FullName, CHARINDEX(' ', REVERSE(i.FullName)) - 1) = RIGHT(b.FullName, CHARINDEX(' ', REVERSE(b.FullName)) - 1)
    WHERE b.BuyerID != i.BuyerID;
END;

CREATE TRIGGER trg_ArchiveBuyerHistory
ON Buyers
INSTEAD OF DELETE
AS
BEGIN
    INSERT INTO PurchaseHistory (BuyerID, SellerID, ProductName, Price, SaleDate)
    SELECT s.BuyerID, s.SellerID, s.ProductName, s.Price, s.SaleDate
    FROM Sales s
    JOIN deleted d ON s.BuyerID = d.BuyerID;
DELETE FROM Buyers WHERE BuyerID IN (SELECT BuyerID FROM deleted);
END;

CREATE TRIGGER trg_PreventSellerIsAlsoBuyer
ON Sellers
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN Buyers b ON i.FullName = b.FullName
    )
    BEGIN
        RAISERROR('Цей продавець уже є покупцем', 16, 1);
RETURN;
END
INSERT INTO Sellers (FullName, Email, Phone)
    SELECT FullName, Email, Phone FROM inserted;
END;

CREATE TRIGGER trg_PreventBuyerIsAlsoSeller
ON Buyers
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN Sellers s ON i.FullName = s.FullName
    )
    BEGIN
        RAISERROR('Цей покупець уже є продавцем', 16, 1);
RETURN;
END
INSERT INTO Buyers (FullName, Email, Phone)
    SELECT FullName, Email, Phone FROM inserted;
END;

CREATE TRIGGER trg_BlockSpecificProducts
ON Sales
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted
        WHERE ProductName IN ('яблука', 'груші', 'сливи', 'кінза')
    )
    BEGIN
        RAISERROR('Продаж цього товару заборонено', 16, 1);
RETURN;
END
INSERT INTO Sales (BuyerID, SellerID, ProductName, Price, SaleDate)
    SELECT BuyerID, SellerID, ProductName, Price, SaleDate FROM inserted;
END;
