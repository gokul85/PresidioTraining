CREATE DATABASE ShopQuestion;

USE ShopQuestion;

--Products Table
CREATE TABLE PRODUCTS(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(50),
	price DECIMAL(10,2),
);

--Suppliers Table
CREATE TABLE SUPPLIERS(
	supplier_id INT PRIMARY KEY,
	supplier_name VARCHAR(50),
	supplier_phone VARCHAR(10)
);

--Customers Table
CREATE TABLE CUSTOMERS(
	customer_id INT PRIMARY KEY,
	customer_name VARCHAR(50),
	customer_phone VARCHAR(10)
);

--Product Suppliers Table for many to many relationship
CREATE TABLE PRODUCT_SUPPLIERS(
	product_id INT NOT NULL,
	supplier_id INT NOT NULL,
	CONSTRAINT fk_ps_productid FOREIGN KEY (product_id) REFERENCES PRODUCTS(product_id),
	CONSTRAINT fk_ps_supplierid FOREIGN KEY (supplier_id) REFERENCES SUPPLIERS(supplier_id),
);

--Purchase Table
CREATE TABLE PURCHASES(
	purchase_id INT PRIMARY KEY,
	customer_id INT NOT NULL,
	purchase_date DATETIME,
	total_amount DECIMAL(10,2),
	CONSTRAINT fk_pur_customerid FOREIGN KEY (customer_id) REFERENCES CUSTOMERS(customer_id)
);

--Purchase Item Table for many to many relationship
CREATE TABLE PURCHASE_ITEMS(
	purchase_id INT NOT NULL,
	product_id INT NOT NULL,
	quantity INT,
	priceperunit DECIMAL(10,2),
	CONSTRAINT fk_puritem_purchaseid FOREIGN KEY (purchase_id) REFERENCES PURCHASES(purchase_id),
	CONSTRAINT fk_puritem_productid FOREIGN KEY (product_id) REFERENCES PRODUCTS(product_id)
);

--Bills Table
CREATE TABLE BILLS(
	bill_id INT PRIMARY KEY,
	purchase_id INT,
	bill_amount DECIMAL(10,2),
	bill_date DATETIME,
	CONSTRAINT fk_bill_purchaseid FOREIGN KEY (purchase_id) REFERENCES PURCHASES(purchase_id),
);
