
CREATE TABLE Customers (
    CustomerId INTEGER PRIMARY KEY,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    PhoneNumber TEXT NOT NULL
);

CREATE TABLE Accounts (
    AccountId INTEGER PRIMARY KEY,
    CustomerId INTEGER NOT NULL,
    Status TEXT NOT NULL,
    Balance REAL NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);
