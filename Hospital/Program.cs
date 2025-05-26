--Створення бази даних
CREATE DATABASE Hospital;
GO

-- Використання бази даних
USE Hospital;
GO

-- Таблиця: Departments(Відділення)
CREATE TABLE Departments (
    ID INT IDENTITY PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Financing MONEY NOT NULL CHECK (Financing >= 0) DEFAULT 0,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (LEN(Name) > 0)
);
GO

-- Таблиця: Diseases(Захворювання)
CREATE TABLE Diseases (
    ID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (LEN(Name) > 0),
    Severity INT NOT NULL CHECK (Severity >= 1) DEFAULT 1
);
GO

-- Таблиця: Doctors(Лікарі)
CREATE TABLE Doctors (
    ID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL CHECK (LEN(Name) > 0),
    Surname NVARCHAR(MAX) NOT NULL CHECK (LEN(Surname) > 0),
    Phone CHAR(10) NOT NULL,
    Salary MONEY NOT NULL CHECK (Salary > 0)
);
GO

-- Таблиця: Examinations(Обстеження)
CREATE TABLE Examinations (
    ID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (LEN(Name) > 0),
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
    StartTime TIME NOT NULL CHECK (StartTime >= '08:00' AND StartTime <= '18:00'),
    EndTime TIME NOT NULL,
    CHECK (EndTime > StartTime)
);
GO
