CREATE TABLE People (
  id INT,
  address VARCHAR(50),
  email VARCHAR(50),
  password VARCHAR(50),
  name VARCHAR(30),
  city VARCHAR(50),
  date_of_birth DATETIME,
  CONSTRAINT people_pk PRIMARY KEY(id)
);

CREATE TABLE Orders(
	id_order INT, 
	id_user INT, 
	product CHAR(30),
	total_price DECIMAL,
	CONSTRAINT orders_pk PRIMARY KEY(id_order),
	CONSTRAINT orders_fk FOREIGN KEY (id_user) REFERENCES People(id)
);

CREATE INDEX idx0 ON People(id);

CREATE INDEX idx2 ON Orders(id_order);


INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (1,'PrimjerAdrese1', 'peroperic@gmail.com', '1k23123','Pero','Osijek','11-10-2000');
INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (2,'PrimjerAdrese2', 'duroduric@gmail.com', 'Golf123','Djuro','Zagreb','11-9-2001');
INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (3,'PrimjerAdrese3', 'matemilosevic@yahoo.com', 'sifra0303','Mate','Rijeka','11-8-2002');
INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (4,'PrimjerAdrese4', 'kataperkovic@yahoo.com', 'kolac123','Kata','Split','11-7-2003');
INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (5,'PrimjerAdrese5', 'ivanivankovic@gmail.com', 'nemamsifru321','Ivan','Dubrovnik','11-6-2004');
INSERT INTO People (id, address,email, password, name, city,date_of_birth) VALUES (6,'PrimjerAdrese6', 'ilijailic@gmail.com', 'monitor4251','Ilija','Nasice','11-5-2005');
INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (7,'PrimjerAdrese7','markomarkic@gmail.com', 'passwad','Marko','Pozega','11-4-2006');
INSERT INTO People (id, address,email, password, name, city,date_of_birth) VALUES (8,'PrimjerAdrese8', 'pericapericic@yahoo.com', 'nekasifranez','Perica','Varazdin','11-3-2007');
INSERT INTO People (id, address, email, password, name, city,date_of_birth) VALUES (9,'PrimjerAdrese9', 'matomatic@gmail.com', 'tipkovnicapassword','Mato','Virovitica','11-2-2008');

INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('1', (SELECT id from People WHERE email = 'peroperic@gmail.com'), 'Hamburger',45.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('2', (SELECT id from People WHERE email = 'duroduric@gmail.com'), 'Pizza',65.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('3', (SELECT id from People WHERE email = 'matemilosevic@yahoo.com'), 'Cevapi',29.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('4', (SELECT id from People WHERE email = 'kataperkovic@yahoo.com'), 'Sopska salata',14.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('5', (SELECT id from People WHERE email = 'ivanivankovic@gmail.com'), 'Pohani Sir',35.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('6', (SELECT id from People WHERE email = 'ilijailic@gmail.com'), 'Kebab',18.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('7', (SELECT id from People WHERE email = 'markomarkic@gmail.com'), 'Kebab',18.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('8', (SELECT id from People WHERE email = 'pericapericic@yahoo.com'), 'Pohani Sir',35.99);
INSERT INTO Orders (id_order, id_user, product, total_price) VALUES ('9', (SELECT id from People WHERE email = 'matomatic@gmail.com'), 'Sopska salata',14.99);

/*Prikaz tablica*/
SELECT * FROM People;
SELECT * FROM Orders;

UPDATE Orders
SET product = 'Mali Hamburger'
WHERE id_order=1;

DELETE FROM Orders WHERE id_order=9;
DELETE FROM People;

/*Math(count,avg)*/
SELECT AVG(total_price)
FROM Orders;

SELECT COUNT(id_user)
FROM Orders;

/*ALTER TABLE*/
ALTER TABLE People ADD password VARCHAR(30);

ALTER TABLE People DROP COLUMN password; 

ALTER TABLE People ALTER COLUMN password CHAR(50); 

/*ORDER BY*/
SELECT email
FROM People
ORDER BY email DESC;

/*GROUP BY*/
SELECT COUNT(id_order), Product
FROM Orders
GROUP BY Product
ORDER BY COUNT(id_order) ASC;

/*HAVING*/
SELECT COUNT(id_order), Product
FROM Orders
GROUP BY Product
HAVING COUNT(id_order) > 1
ORDER BY COUNT(id_order) DESC;