USE master;
GO

IF DB_ID('compteBanquaire') IS NULL
	CREATE DATABASE compteBanquaire;
GO

USE compteBanquaire;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='compte' AND xtype='U')
	CREATE TABLE compte(
		compteId uniqueIdentifier PRIMARY KEY,
		type VARCHAR(150) NOT NULL,
		transactions VARCHAR(150) NOT NULL, 
		CONSTRAINT FK_transaction FOREIGN KEY (transactions) REFERENCES transactions(transactionId)
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='transactions' AND xtype='U')
	CREATE TABLE transactions(
		transactionId int PRIMARY KEY,
		type VARCHAR(150) NOT NULL,
		date DATE NOT NULL,
		montant DECIMAL NOT NULL
);
