﻿USE master;
IF EXISTS (
	SELECT * 
	FROM sys.databases 
	WHERE name = N'LuxuryDB'
) BEGIN 
	DROP DATABASE LuxuryDB
END;
CREATE DATABASE LuxuryDB;

USE LuxuryDB;
CREATE TABLE Category (
  IDCate INT NOT NULL,
  Name NVARCHAR(40) NOT NULL,
  PRIMARY KEY (IDCate)
);
CREATE TABLE HairServices (
  IDSvc INT NOT NULL,
  Name NVARCHAR(MAX) NOT NULL,
  Price FLOAT NOT NULL,
  IDCate INT NOT NULL,
  PRIMARY KEY (IDSvc),
  FOREIGN KEY (IDCate) REFERENCES Category(IDCate)
);
--This table will be used in future (or NOT)
CREATE TABLE SalaryPts (
  IDPts INT NOT NULL,
  Points FLOAT NOT NULL,
  Note NVARCHAR(MAX),
  PRIMARY KEY (IDPts)
);
CREATE TABLE Staff (
  IDStaff INT NOT NULL,
  FName NVARCHAR(40) NOT NULL,
  LName NVARCHAR(20) NOT NULL,
  DoB DATE,
  Phone CHAR(20) NOT NULL,
  Address NVARCHAR(MAX) NOT NULL,
  CurrentSalary FLOAT NOT NULL,
  PRIMARY KEY (IDStaff)
);
CREATE TABLE Orders (
  IDOrder INT NOT NULL,
  DateOrder DATE NOT NULL,
  IDStaff INT NOT NULL,
  PRIMARY KEY (IDOrder),
  FOREIGN KEY (IDStaff) REFERENCES Staff(IDStaff)
);
CREATE TABLE Roles (
  IDRole INT NOT NULL,
  Name NVARCHAR(30) NOT NULL,
  PRIMARY KEY (IDRole)
);
INSERT INTO Roles VALUES(0, N'Admin');
INSERT INTO Roles VALUES(1, N'Chủ tiệm');
INSERT INTO Roles VALUES(2, N'Nhân viên');
CREATE TABLE MakeSteps (
  IDSteps INT NOT NULL,
  Steps NVARCHAR(MAX) NOT NULL,
  IDSvc INT,
  PRIMARY KEY (IDSteps),
  FOREIGN KEY (IDSvc) REFERENCES HairServices(IDSvc)
);
CREATE TABLE Salary (
  DateReceived DATETIME NOT NULL,
  FinalSalary FLOAT NOT NULL,
  IDPts INT NOT NULL,
  IDStaff INT NOT NULL,
  PRIMARY KEY (IDPts, IDStaff),
  FOREIGN KEY (IDPts) REFERENCES SalaryPts(IDPts),
  FOREIGN KEY (IDStaff) REFERENCES Staff(IDStaff)
);
CREATE TABLE OrderDetails (
  TotalPrice FLOAT NOT NULL,
  IDSvc INT NOT NULL,
  IDOrder INT NOT NULL,
  PRIMARY KEY (IDSvc, IDOrder),
  FOREIGN KEY (IDSvc) REFERENCES HairServices(IDSvc),
  FOREIGN KEY (IDOrder) REFERENCES Orders(IDOrder)
);
CREATE TABLE Account (
  UserName CHAR(30) NOT NULL,
  Password VARCHAR(MAX) NOT NULL,
  --HashPassword VARCHAR(64) NOT NULL,
  IDRole INT NOT NULL,
  IDStaff INT NOT NULL,
  PRIMARY KEY (UserName),
  FOREIGN KEY (IDRole) REFERENCES Roles(IDRole),
  FOREIGN KEY (IDStaff) REFERENCES Staff(IDStaff)
);
CREATE TABLE Logs(
	IdLog INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Status INT NOT NULL,
	Message NVARCHAR(MAX) NOT NULL,
	-- Result: 0 = False, 1 = True
	Result BIT NOT NULL
);