USE pubs;

--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
CREATE PROCEDURE proc_GetBooksByAuthor
    @AuthorFName VARCHAR(50)
AS
BEGIN
    SELECT t.title 'Title', p.pub_name 'Publisher Name'
    FROM titles t
	JOIN titleauthor ta ON t.title_id = ta.title_id
    JOIN authors a ON ta.au_id = a.au_id
    JOIN publishers p ON t.pub_id = p.pub_id
    WHERE a.au_fname = @AuthorFName;
END;

EXECUTE proc_GetBooksByAuthor 'Marjorie';


--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
CREATE PROCEDURE proc_GetTitlesSoldByEmployee
    @EmployeeFName VARCHAR(50)
AS
BEGIN
    SELECT e.fname + ' ' + e.lname 'Employee', title 'Title', t.price 'Price', s.qty 'Quantity', t.price * s.qty 'Total Cost'
	FROM sales s
	JOIN titles t ON s.title_id = t.title_id
	JOIN publishers p ON p.pub_id = t.pub_id
	JOIN employee e ON e.pub_id = p.pub_id
	WHERE e.fname = @EmployeeFName
END

EXECUTE proc_GetTitlesSoldByEmployee 'Paolo';

-- 3) Create a query that will print all names from authors and employees
SELECT au_fname
FROM authors
UNION
SELECT fname
FROM employee;


-- 4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
-- print first 5 orders after sorting them based on the price of order
SELECT TOP 5
    t.title,
    p.pub_name,
    a.au_fname + ' ' + a.au_lname 'AuthorFullName',
    s.qty,
    (t.price * s.qty) AS TotalPrice
FROM Sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id
JOIN titleauthor ta ON t.title_id = ta.title_id
JOIN authors a ON ta.au_id = a.au_id
ORDER BY TotalPrice DESC;
