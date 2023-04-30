-- Insert data into the Customers table
INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address)
VALUES 
    (1, 'John', 'Doe', 'john.doe@example.com', '555-1234', '123 Main St'),
    (2, 'Jane', 'Smith', 'jane.smith@example.com', '555-5678', '456 Elm St'),
    (3, 'Bob', 'Johnson', 'bob.johnson@example.com', '555-9012', '789 Oak St');

-- Insert data into the Accounts table
INSERT INTO Accounts (AccountID, CustomerID, AccountType, Balance)
VALUES 
    (1, 1, 'Savings', 10000.00),
    (2, 1, 'Investment', 50000.00),
    (3, 2, 'Savings', 7500.00),
    (4, 3, 'Checking', 2500.00),
    (5, 3, 'Investment', 100000.00);

-- Insert data into the Investments table
INSERT INTO Investments (InvestmentID, AccountID, InvestmentType, InvestmentAmount, InvestmentDate)
VALUES 
    (1, 2, 'Stocks', 10000.00, '2022-01-01'),
    (2, 2, 'Bonds', 25000.00, '2022-02-15'),
    (3, 5, 'Mutual Funds', 50000.00, '2022-03-31');
