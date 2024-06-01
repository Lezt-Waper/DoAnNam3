USE Database_DAN3


INSERT INTO CATEGORY (Id, CategoryName)
VALUES 
	('El', 'Electronic'),
	('Co', 'Cosmetic'),
	('Cl', 'Clothing');

INSERT INTO Good(Id, CategoryId, Name, Price, Quantity)
VALUES 
	('L', 'El', 'Laptop', 30, 300),
	('P', 'El', 'Phone', 40, 300),
	('S', 'Co', 'Serum', 20, 300),
	('M', 'Co', 'Marcara', 60, 300),
	('D', 'Cl', 'Dress', 90, 300),
	('Pa', 'Cl', 'Pant', 100, 300);
	
