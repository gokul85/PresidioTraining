CREATE DATABASE VideoStore;

USE VideoStore;

--Categories Table
CREATE TABLE CATEGORIES(
	category_id INT PRIMARY KEY,
	category_name VARCHAR(50)
);

--Movies Table
CREATE TABLE MOVIES(
	movie_id INT PRIMARY KEY,
	title VARCHAR(50),
	movie_format VARCHAR(3) CHECK(movie_format IN ('VHS','VCD','DVD')),
	category INT NOT NULL,
	CONSTRAINT fk_movies_category FOREIGN KEY (category) REFERENCES CATEGORIES(category_id)
);

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
