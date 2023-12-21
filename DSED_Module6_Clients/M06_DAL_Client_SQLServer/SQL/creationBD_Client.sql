USE master;
GO

IF DB_ID('client') IS NULL
	CREATE DATABASE client;
GO

USE client;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='client' AND xtype='U')
	CREATE TABLE client(
		clientSQLDTOId uniqueIdentifier PRIMARY KEY,
		prenom VARCHAR(150) NOT NULL,
		nom VARCHAR(150) NOT NULL,
		courriel VARCHAR(150) NOT NULL,
		numeroTelephone VARCHAR(150) NOT NULL
);

select * from client;