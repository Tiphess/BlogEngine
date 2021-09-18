CREATE DATABASE BlogEngine;
GO

USE BlogEngine;
GO

CREATE TABLE dbo.Category (
	id uniqueIdentifier PRIMARY KEY,
	title nvarchar(255) NOT NULL,
	CONSTRAINT Unique_Category_title UNIQUE (title)
);
GO

CREATE TABLE dbo.Post (
	id uniqueIdentifier PRIMARY KEY,
	title nvarchar(255) NOT NULL,
	publicationDate datetime NOT NULL,
	content nvarchar(max) NOT NULL,
	categoryId uniqueIdentifier NOT NULL,
	CONSTRAINT FK_Post_category FOREIGN KEY (categoryId) REFERENCES dbo.Category (id),
	CONSTRAINT Unique_Post_title UNIQUE (title)
);