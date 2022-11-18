CREATE DATABASE MindBoxBD
USE MindBoxBD

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='Products' AND xtype='U')
	BEGIN
    CREATE TABLE Products (
        Id INT CONSTRAINT PK_Product_Id PRIMARY KEY IDENTITY,
		Name NVARCHAR(256) NULL
    );

	SET IDENTITY_INSERT Products ON

	INSERT INTO Products (Id, Name) VALUES
	(1, 'Caesar'),
	(2, 'Sendai'),
	(3, 'Poke'),
	(4, 'Rolls'),
	(5, 'Ramen'),
	(6, 'Kang'),
	(7, 'Juice');
	
	SET IDENTITY_INSERT Products OFF
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='Categories' AND xtype='U')
	BEGIN
	CREATE TABLE Categories (
	Id INT CONSTRAINT PK_Category_Id PRIMARY KEY IDENTITY,
	Name NVARCHAR(256) NULL
	);

	SET IDENTITY_INSERT Categories ON

	INSERT INTO Categories (Id, Name) VALUES
	(1, 'Salad'),
	(2, 'Popular'),
	(3, 'Snacks'),
	(4, 'Soup'),
	(5, 'Sushi');

	SET IDENTITY_INSERT Categories OFF
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='ProductCategories' AND xtype='U')
	BEGIN
	CREATE TABLE ProductCategories (
	ProductId INT NOT NULL,
	CategoryId INT NOT NULL,
	CONSTRAINT PK_ProductCategories PRIMARY KEY (ProductId, CategoryId),
	CONSTRAINT FK_ProductCategories_Product_Id FOREIGN KEY (ProductId) REFERENCES Products (Id) ON DELETE CASCADE,
	CONSTRAINT FK_ProductCategories_Category_Id FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE CASCADE
	);

	INSERT INTO ProductCategories (ProductId, CategoryId) VALUES
	(1, 1),
	(1, 2),
	(2, 1),
	(3, 2),
	(3, 3),
	(4, 3),
	(5, 2),
	(5, 4),
	(6, 4),
	(6, 2);
END


SELECT 
pr.Name AS Product,
ct.Name As Category
FROM  Products pr
	LEFT JOIN ProductCategories pc
	ON pc.ProductId = pr.Id
	LEFT JOIN Categories ct
	ON pc.CategoryId = ct.Id
