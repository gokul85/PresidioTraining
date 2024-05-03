use pubs;

--  1) Print the storeid and number of orders for the store
SELECT  stores.stor_id 'Store ID', COUNT(*) 'Number of Orders' FROM stores JOIN sales ON sales.stor_id = stores.stor_id GROUP BY stores.stor_id;

--  2) Print the numebr of orders for every title
SELECT titles.title, COUNT(*) 'Orders' FROM sales JOIN titles ON sales.title_id = titles.title_id GROUP BY titles.title;

--  3) Print the publisher name and book name
SELECT publishers.pub_name 'Publisher', titles.title 'Title' FROM publishers JOIN titles ON titles.pub_id = publishers.pub_id;

--  4) Print the author full name for all the authors
SELECT au_id 'Author ID', au_fname + ' ' + au_lname 'Author Full Name' FROM authors;

--  5) Print the price or every book with tax (price+price*12.36/100)
SELECT title 'Title', price+price*12.36/100 'Price (incl tax)' FROM titles;

--  6) Print the author name, title name
SELECT A.au_fname + ' ' + A.au_lname 'Author', T.title 'Title' FROM authors A 
JOIN titleauthor TA ON TA.au_id = A.au_id
JOIN titles T ON TA.title_id = T.title_id;

--  7) Print the author name, title name and the publisher name
SELECT A.au_fname + ' ' + A.au_lname 'Author', T.title 'Title', P.pub_name 'Publisher' FROM authors A
JOIN titleauthor TA ON TA.au_id = A.au_id
JOIN titles T ON TA.title_id = T.title_id
JOIN publishers P ON P.pub_id = T.pub_id;


--  8) Print the average price of books pulished by every publicher
SELECT P.pub_name 'Publisher', AVG(price) 'Average title price'  FROM titles T JOIN publishers P ON P.pub_id = T.pub_id GROUP BY P.pub_name;

--  9) Print the books published by 'Marjorie'
SELECT *  FROM titles T WHERE pub_id IN (SELECT pub_id FROM publishers WHERE pub_name = 'Marjorie');

--  10) Print the order numbers of books published by 'New Moon Books'
SELECT ord_num 'Order numbers' FROM sales
JOIN titles ON titles.title_id = sales.title_id
JOIN publishers ON publishers.pub_id = titles.pub_id
WHERE publishers.pub_name = 'New Moon Books';

--  11) Print the number of orders for every publisher
SELECT pub_name 'Publishers', COUNT(*) 'Orders' FROM publishers P
JOIN titles T ON T.pub_id = P.pub_id
JOIN sales S ON S.title_id = T.title_id
GROUP BY pub_name;


--  12) Print the order number , book name, quantity, price and the total price for all orders
SELECT ord_num 'Order', T.title 'Book',  qty 'Quantity', price 'Price' FROM sales S 
JOIN titles T ON T.title_id = S.title_id; 

SELECT ord_num 'Order Number',  SUM(price) 'Total Price' FROM sales S JOIN titles t ON t.title_id = S.title_id GROUP BY S.ord_num ORDER BY S.ord_num;

--  13) Print he total order quantity fro every book
SELECT t.title_id 'Title', SUM(qty) 'Quantity' FROM sales s
JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title_id;


--  14) Print the total ordervalue for every book
SELECT t.title_id 'Title', SUM(qty) 'Quantity' FROM sales s
JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title_id; 

--15) Print the orders that are for the books published by the publisher for which 'Paolo' works for
SELECT ord_num 'Order', SUM(qty * price) 'Total Order value' FROM sales s JOIN titles t ON t.title_id = s.title_id GROUP BY ord_num;
