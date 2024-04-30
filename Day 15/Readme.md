# Question 1 Shop Schema
```
CREATE DATABASE ShopQuestion;

USE ShopQuestion;
```

```
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
```
3) All customers details have to present
```
--Customers Table
CREATE TABLE CUSTOMERS(
	customer_id INT PRIMARY KEY,
	customer_name VARCHAR(50),
	customer_phone VARCHAR(10)
);
```
1) One product can be supplied by many suppliers
2) One supplier can supply many products
```
--Product Suppliers Table for many to many relationship
CREATE TABLE PRODUCT_SUPPLIERS(
	product_id INT NOT NULL,
	supplier_id INT NOT NULL,
	CONSTRAINT fk_ps_productid FOREIGN KEY (product_id) REFERENCES PRODUCTS(product_id),
	CONSTRAINT fk_ps_supplierid FOREIGN KEY (supplier_id) REFERENCES SUPPLIERS(supplier_id),
);
```
4) A customer can buy more than one product in every purchase
```
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
```
5) Bill for every purchase has to be stored
```
--Bills Table
CREATE TABLE BILLS(
	bill_id INT PRIMARY KEY,
	purchase_id INT,
	bill_amount DECIMAL(10,2),
	bill_date DATETIME,
	CONSTRAINT fk_bill_purchaseid FOREIGN KEY (purchase_id) REFERENCES PURCHASES(purchase_id),
);
```


# Question 2 Movie Rental Store
```
CREATE DATABASE VideoStore;

USE VideoStore;
```
Each movie belongs to one of a given set of categories (action, adventure, comedy, ... )
```
--Categories Table
CREATE TABLE CATEGORIES(
	category_id INT PRIMARY KEY,
	category_name VARCHAR(50)
);
```
Each movie in the store has a title and is identified by a unique movie number.
A movie can be in VHS, VCD, or DVD format. **CHECK() verify this condition**
Each member may provide a favorite movie category (used for marketing purposes).
```
--Movies Table
CREATE TABLE MOVIES(
	movie_id INT PRIMARY KEY,
	title VARCHAR(50),
	movie_format VARCHAR(3) CHECK(movie_format IN ('VHS','VCD','DVD')),
	category INT NOT NULL,
	CONSTRAINT fk_movies_category FOREIGN KEY (category) REFERENCES CATEGORIES(category_id)
);
```
The store has a name and a (unique) [UNIQUE Constraint] phone number for each member.
There are two types of members: 
o	Golden Members:
o	Bronze Members:

A member may have a number of dependents (with known names).

I have included the dependent as a member type and and store the original member id in the master_member_id attribute
Bcz If I have a specific table then it is difficult to store the detail in rental thing so that difficlut to the count check
```
--Members Table
CREATE TABLE MEMBERS(
    member_id INT PRIMARY KEY,
    member_name VARCHAR(50),
    phone VARCHAR(10) UNIQUE NOT NULL,
    favorite_category INT NOT NULL,
    member_type VARCHAR(10) CHECK(member_type IN ('Golden','Bronze','Dependent')),
    master_member_id INT,
    CONSTRAINT fk_members_category FOREIGN KEY (favorite_category) REFERENCES CATEGORIES(category_id),
    CONSTRAINT fk_members_master_member FOREIGN KEY (master_member_id) REFERENCES MEMBERS(member_id)
);
```
```
--Rental Table
CREATE TABLE RENTALS(
    rental_id INT PRIMARY KEY,
    member_id INT NOT NULL,
    movie_id INT NOT NULL,
    rental_date DATETIME,
    return_date DATETIME,
    CONSTRAINT fk_rental_memberid FOREIGN KEY (member_id) REFERENCES MEMBERS(member_id),
    CONSTRAINT fk_rental_movieid FOREIGN KEY (movie_id) REFERENCES MOVIES(movie_id)
);
```
To make that verify trigger is created which will initiated after the INSERT of Rental happened and it checks for the count of 
the rental happened by that member or dependent and based on that it will decide to hold the record or delete(rollback) and we need to add the error message there to find the errors
```
--Trigger to verify the rental count
CREATE TRIGGER trg_rental_count_check
ON RENTALS
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN MEMBERS M ON i.member_id = M.member_id
        WHERE i.return_date IS NULL AND M.member_type IN ('Bronze', 'Dependent')
        GROUP BY i.member_id
        HAVING COUNT(*) > 1
    )
    BEGIN
        ROLLBACK TRANSACTION;
    END
END;
```
