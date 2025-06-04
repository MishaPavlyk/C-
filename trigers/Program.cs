CREATE DATABASE SportShop;
GO

USE SportShop;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Category NVARCHAR(50),
    Quantity INT,
    CostPrice DECIMAL(10,2),
    Manufacturer NVARCHAR(100),
    SalePrice DECIMAL(10,2)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Position NVARCHAR(50),
    HireDate DATE,
    Gender CHAR(1),
    Salary DECIMAL(10,2)
);

CREATE TABLE Clients (
    ClientID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Gender CHAR(1),
    DiscountPercent INT DEFAULT 0,
    SubscribedToMailing BIT DEFAULT 0
);

CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    SalePrice DECIMAL(10,2),
    Quantity INT,
    SaleDate DATETIME DEFAULT GETDATE(),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    ClientID INT NULL FOREIGN KEY REFERENCES Clients(ClientID)
);

CREATE TABLE OrderHistory (
    HistoryID INT PRIMARY KEY IDENTITY,
    SaleID INT,
    ProductID INT,
    SalePrice DECIMAL(10,2),
    Quantity INT,
    SaleDate DATETIME,
    EmployeeID INT,
    ClientID INT
);

CREATE TABLE ArchiveProducts (
    ArchiveID INT PRIMARY KEY IDENTITY,
    ProductID INT,
    Name NVARCHAR(100),
    Category NVARCHAR(50),
    Manufacturer NVARCHAR(100),
    ArchivedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE LastItem (
    LastItemID INT PRIMARY KEY IDENTITY,
    ProductID INT,
    Name NVARCHAR(100),
    NotedDate DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_InsertHistory
ON Sales
AFTER INSERT
AS
BEGIN
    INSERT INTO OrderHistory (SaleID, ProductID, SalePrice, Quantity, SaleDate, EmployeeID, ClientID)
    SELECT i.SaleID, i.ProductID, i.SalePrice, i.Quantity, i.SaleDate, i.EmployeeID, i.ClientID
    FROM inserted i;
END;

CREATE TRIGGER trg_ArchiveProduct
ON Sales
AFTER INSERT
AS
BEGIN
    UPDATE Products
    SET Quantity = Quantity - i.Quantity
    FROM Products p
    JOIN inserted i ON p.ProductID = i.ProductID;

INSERT INTO ArchiveProducts (ProductID, Name, Category, Manufacturer)
    SELECT p.ProductID, p.Name, p.Category, p.Manufacturer
    FROM inserted i
    JOIN Products p ON i.ProductID = p.ProductID
    WHERE p.Quantity = 0;
END;

CREATE TRIGGER trg_PreventDuplicateClients
ON Clients
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Clients c
        JOIN inserted i ON c.FullName = i.FullName AND c.Email = i.Email
    )
    BEGIN
        RAISERROR('Client with same name and email already exists.', 16, 1);
RETURN;
END
INSERT INTO Clients (FullName, Email, Phone, Gender, DiscountPercent, SubscribedToMailing)
    SELECT FullName, Email, Phone, Gender, DiscountPercent, SubscribedToMailing FROM inserted;
END;

CREATE TRIGGER trg_PreventClientDelete
ON Clients
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('Deletion of clients is not allowed.', 16, 1);
END;

CREATE TRIGGER trg_PreventOldEmployeeDelete
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM deleted WHERE HireDate < '2015-01-01'
    )
    BEGIN
        RAISERROR('Cannot delete employees hired before 2015.', 16, 1);
RETURN;
END
DELETE FROM Employees WHERE EmployeeID IN (SELECT EmployeeID FROM deleted);
END;

CREATE TRIGGER trg_UpdateClientDiscount
ON Sales
AFTER INSERT
AS
BEGIN
    UPDATE c
    SET DiscountPercent = 15
    FROM Clients c
    WHERE EXISTS (
        SELECT 1 FROM inserted i
        WHERE i.ClientID = c.ClientID
        GROUP BY i.ClientID
        HAVING SUM(i.SalePrice * i.Quantity) + 
               ISNULL((SELECT SUM(SalePrice * Quantity) FROM Sales s WHERE s.ClientID = i.ClientID), 0) > 50000
    );
END;

CREATE TRIGGER trg_BlockBadManufacturer
ON Products
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Manufacturer = 'Спорт, сонце і штанга')
    BEGIN
        RAISERROR('Products from this manufacturer are not allowed.', 16, 1);
RETURN;
END
INSERT INTO Products (Name, Category, Quantity, CostPrice, Manufacturer, SalePrice)
    SELECT Name, Category, Quantity, CostPrice, Manufacturer, SalePrice FROM inserted;
END;

CREATE TRIGGER trg_LastItem
ON Sales
AFTER INSERT
AS
BEGIN
    INSERT INTO LastItem (ProductID, Name)
    SELECT p.ProductID, p.Name
    FROM inserted i
    JOIN Products p ON i.ProductID = p.ProductID
    WHERE p.Quantity = 1;
END;
