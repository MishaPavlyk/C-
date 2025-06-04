BEGIN TRANSACTION

-- Create Users table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
)

-- Create Rooms table
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY,
    RoomName NVARCHAR(100) NOT NULL,
    Capacity INT NOT NULL,
    Location NVARCHAR(100),
    IsAvailable BIT DEFAULT 1
)

-- Create Bookings table
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    RoomID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Confirmed',
    CONSTRAINT FK_Booking_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Booking_Room FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
    CONSTRAINT CK_Booking_Time CHECK (EndTime > StartTime)
)

-- Create Payments table
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY,
    BookingID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentStatus NVARCHAR(50) DEFAULT 'Pending',
    CONSTRAINT FK_Payment_Booking FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
)

-- Create unique index to prevent booking conflicts
CREATE UNIQUE INDEX IX_Room_Booking_Conflict ON Bookings(RoomID, StartTime, EndTime)
WHERE 1 = 1

-- Insert sample users
INSERT INTO Users (UserName, Email) VALUES 
('Іван Петренко', 'ivan@example.com'),
('Олена Ковальчук', 'olena@example.com')

-- Insert sample rooms
INSERT INTO Rooms (RoomName, Capacity, Location) VALUES 
('Зала А', 50, '1st Floor'),
('Зала B', 30, '2nd Floor')

-- Insert a booking with conflict check
INSERT INTO Bookings (UserID, RoomID, StartTime, EndTime)
SELECT 1, 1, '2025-06-05 10:00:00', '2025-06-05 12:00:00'
WHERE NOT EXISTS (
    SELECT 1 FROM Bookings
    WHERE RoomID = 1 AND (
        ('2025-06-05 10:00:00' < EndTime AND '2025-06-05 12:00:00' > StartTime)
    )
)

-- Insert a payment for the booking
INSERT INTO Payments (BookingID, Amount)
SELECT SCOPE_IDENTITY(), 100.00

COMMIT