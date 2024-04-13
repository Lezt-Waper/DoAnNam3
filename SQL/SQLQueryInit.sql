USE Goods_DAN3

CREATE TABLE CATEGORY (
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL
);

CREATE TABLE GOOD (
	Id INT NOT NULL PRIMARY KEY,
	CategoryId INT NOT NULL,
	Name NVARCHAR(20) NOT NULL,
	Quantity INT NOT NULL
	CONSTRAINT FK_GOODS_CATEGORY FOREIGN KEY (CategoryId) REFERENCES CATEGORY (Id),
);

CREATE TABLE CLIENT (
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	Credit NVARCHAR(19) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
);

CREATE TABLE ORDERS (
	ClientId INT NOT NULL,
	GoodId INT NOT NULL,
	Quantity INT NOT NULL,
	PRIMARY KEY (ClientId, GoodId),
	CONSTRAINT FK_ORDERS_CLIENT FOREIGN KEY (ClientId) REFERENCES CLIENT (Id),
	CONSTRAINT FK_ORDERS_GOOD FOREIGN KEY (GoodId) REFERENCES GOOD (Id),
);



