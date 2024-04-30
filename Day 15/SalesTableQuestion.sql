CREATE DATABASE SalesQuestion;

USE SalesQuestion;

--Create EMP Table
CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    empname VARCHAR(50),
    salary DECIMAL(10, 2),
    deptname VARCHAR(50),
    bossno INT,
    CONSTRAINT fkemp_bossno FOREIGN KEY (bossno) REFERENCES EMP(empno)
);

--Create DEPARTMENT Table
CREATE TABLE DEPARTMENT(
	deptname VARCHAR(50) PRIMARY KEY,
	floor INT,
	phone VARCHAR(10),
	empno INT NOT NULL,
	CONSTRAINT fkdept_empno FOREIGN KEY (empno) REFERENCES EMP(empno)
);

--Create SALES Table
CREATE TABLE SALES(
	salesno INT PRIMARY KEY,
	saleqty INT,
	itemname VARCHAR(100) NOT NULL,
	deptname VARCHAR(50) NOT NULL,
	CONSTRAINT fksales_deptname FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname)
);

--Create ITEM Table
CREATE TABLE ITEM(
	itemname VARCHAR(100) PRIMARY KEY,
	itemtype VARCHAR(10),
	itemcolor VARCHAR(50)
);

--Adding constraint to EMP
ALTER TABLE EMP
ADD CONSTRAINT fkemp_deptname FOREIGN KEY (deptname) REFERENCES DEPARTMENT (deptname);

--Adding constraint to SALES
ALTER TABLE SALES
ADD CONSTRAINT fksales_itemname FOREIGN KEY (itemname) REFERENCES ITEM (itemname);


--Inserting the values to the EMP Table
INSERT INTO EMP(empno,empname,salary) VALUES (1,'Alice',75000);
INSERT INTO EMP(empno,empname,salary,bossno) VALUES 
(2,'Ned',45000,1),
(3,'Andrew',25000,2),
(4,'Clare',22000,2), 
(5,'Todd',38000,1),
(6,'Nancy',22000,5), 
(7,'Brier',43000,1), 
(8,'Sarah',56000,7), 
(9,'Sophile',35000,1), 
(10,'Sanjay',15000,3), 
(11,'Rita',15000,4), 
(12,'Gigi',16000,4), 
(13,'Maggie',11000,4),
(14,'Paul',15000,3),
(15,'James',15000,3),
(16,'Pat',15000,3), 
(17,'Mark',15000,3);

--Inserting Values to the DEPARTMENT
INSERT INTO DEPARTMENT (deptname, floor, phone, empno)
VALUES
('Management', 5, '34', 1),
('Books', 1, '81', 4),
('Clothes', 2, '24', 4),
('Equipment', 3, '57', 3),
('Furniture', 4, '14', 3),
('Navigation', 1, '41', 3),
('Recreation', 2, '29', 4),
('Accounting', 5, '35', 5),
('Purchasing', 5, '36', 7),
('Personnel', 5, '37', 9),
('Marketing', 5, '38', 2);

--Updating the EMP Table deptname(Due to Foreign key Conflict)
UPDATE EMP
SET deptname = 
    CASE empno
        WHEN 1 THEN 'Management'
        WHEN 2 THEN 'Marketing'
        WHEN 3 THEN 'Marketing'
        WHEN 4 THEN 'Marketing'
        WHEN 5 THEN 'Accounting'
        WHEN 6 THEN 'Accounting'
        WHEN 7 THEN 'Purchasing'
        WHEN 8 THEN 'Purchasing'
        WHEN 9 THEN 'Personnel'
        WHEN 10 THEN 'Navigation'
        WHEN 11 THEN 'Books'
        WHEN 12 THEN 'Clothes'
        WHEN 13 THEN 'Clothes'
        WHEN 14 THEN 'Equipment'
        WHEN 15 THEN 'Equipment'
        WHEN 16 THEN 'Furniture'
        WHEN 17 THEN 'Recreation'
END;

--Inserting the Item Table Values(Not to get conflict)
INSERT INTO ITEM (itemname, itemtype, itemcolor)
VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');

--Inserting the Sales Table Values
INSERT INTO SALES (salesno, saleqty, itemname, deptname)
VALUES
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(117, 1, 'Sextant', 'Equipment'),
(118, 1, 'Sextant', 'Recreation'),
(119, 1, 'Sextant', 'Furniture'),
(120, 1, 'Pocket Knife-Nile', 'Furniture'),
(121, 1, 'Exploring in 10 easy lessons', 'Books'),
(122, 1, 'How to win foreign friends', 'Books'),
(123, 1, 'Compass', 'Books'),
(124, 1, 'Pith Helmet', 'Books'),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation');

--Displaying All Tables
SELECT * FROM EMP;
SELECT * FROM DEPARTMENT;
SELECT * FROM SALES;
SELECT * FROM ITEM;