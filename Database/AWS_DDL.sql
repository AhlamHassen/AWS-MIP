-- Create the Customers table
CREATE TABLE Customers (
    CustomerID int PRIMARY KEY,
    FirstName varchar(50),
    LastName varchar(50),
    Email varchar(100),
    Phone varchar(20),
    Address varchar(200)
);

-- Create the Accounts table
CREATE TABLE Accounts (
    AccountID int PRIMARY KEY,
    CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID),
    AccountType varchar(50),
    Balance decimal(18, 2)
);

-- Create the Investments table
CREATE TABLE Investments (
    InvestmentID int PRIMARY KEY,
    AccountID int FOREIGN KEY REFERENCES Accounts(AccountID),
    InvestmentType varchar(50),
    InvestmentAmount decimal(18, 2),
    InvestmentDate datetime
);
