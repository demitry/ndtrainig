
SELECT * FROM university.dbo.Students;
select * from dbo.Students;

USE university
SELECT * FROM Students

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Year]
  FROM [university].[dbo].[Students]


CREATE DATABASE usersdb
USE usersdb;


-- Возможна ситуация, что у нас уже есть файл базы данных, который, к примеру, создан на другом компьютере. 
-- Файл базы данных представляет файл с расширением mdf, и этот файл в принципе мы можем переносить. 
-- Однако даже если мы скопируем его компьютер с установленным MS SQL Server, просто так скопированная база данных на сервере не появится.
--  Для этого необходимо выполнить прикрепление базы данных к серверу. В этом случае применяется выражение:
CREATE DATABASE название_базы_данных
ON PRIMARY(FILENAME='путь_к_файлу_mdf_на_локальном_компьютере')
FOR ATTACH;


-- https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks
-- https://github.com/Microsoft/sql-server-samples
-- https://github.com/Microsoft/sql-server-samples.git


-- Удаление базы данных
-- Для удаления базы данных применяется команда DROP DATABASE, которая имеет следующий синтаксис:
-- DROP DATABASE database_name1 [, database_name2]...
-- После команды через запятую мы можем перечислить все удаляемые базы данных. Например, удаление базы данных contactsdb:
DROP DATABASE contactsdb


-- www.apexsql.com


INSERT INTO Products VALUES ('iPhone 4', 'Apple', 3, 36000);
INSERT INTO Products VALUES ('iPhone 6S', 'Apple', 2, 41000);
INSERT INTO Products VALUES ('iPhone 7', 'Apple', 5, 52000);
INSERT INTO Products VALUES ('Galaxy S8', 'Samsung', 2, 46000);
INSERT INTO Products VALUES ('Galaxy S8 Plus', 'Samsung', 1, 56000);
INSERT INTO Products VALUES ('Mi6', 'Xiaomi', 5, 28000);
INSERT INTO Products VALUES ('OnePlus 5', 'OnePlus', 6, 38000);

-- Найдем среднюю цену товаров из базы данных:
SELECT AVG(Price) AS Average_Price FROM Products

-- Для поиска среднего значения в качестве выражения в функцию передается столбец Price. Для получаемого значения устанавливается псевдоним Average_Price, хотя можно его и не устанавливать.

SELECT AVG(Price) FROM Products
WHERE Manufacturer='Apple'

-- Функция Count вычисляет количество строк в выборке. 
-- Есть две формы этой функции. Первая форма COUNT(*) подсчитывает число строк в выборке:
SELECT COUNT(*) FROM Products

-- Вторая форма функции вычисляет количество строк по определенному столбцу, 
-- при этом строки со значениями NULL игнорируются:

SELECT COUNT(Manufacturer) FROM Products

-- Функции Min и Max возвращают соответственно минимальное и максимальное значение по столбцу. Например, найдем минимальную цену среди товаров:

SELECT MIN(Price) FROM Products
-- Поиск максимальной цены:

SELECT MAX(Price) FROM Products

-- Функция Sum вычисляет сумму значений столбца. Например, подсчитаем общее количество товаров:
SELECT SUM(ProductCount) FROM Products


-- Также вместо имени столбца может передаваться вычисляемое выражение. 
-- Например, найдем общую стоимость всех имеющихся товаров:
SELECT SUM(ProductCount * Price) FROM Products


SELECT COUNT(*) AS ProdCount,
       SUM(ProductCount) AS TotalCount,
       MIN(Price) AS MinPrice,
       MAX(Price) AS MaxPrice,
       AVG(Price) AS AvgPrice
FROM Products




SELECT Manufacturer, COUNT(*) AS ModelsCount
FROM Products
GROUP BY Manufacturer

SELECT Manufacturer, ProductCount, COUNT(*) AS ModelsCount
FROM Products
GROUP BY Manufacturer, ProductCount


SELECT Manufacturer, COUNT(*) AS ModelsCount
FROM Products
WHERE Price > 30000
GROUP BY Manufacturer
ORDER BY ModelsCount DESC


-- Фильтрация групп. HAVING
-- Оператор HAVING определяет, какие группы будут включены в выходной результат, то есть выполняет фильтрацию групп.
-- Применение HAVING во многом аналогично применению WHERE. Только есть WHERE применяется к фильтрации строк, то HAVING используется для фильтрации групп.

-- Например, найдем все группы товаров по производителям, для которых определено более 1 модели:
SELECT Manufacturer, COUNT(*) AS ModelsCount
FROM Products
GROUP BY Manufacturer
HAVING COUNT(*) > 1

--При этом в одной команде мы можем использовать выражения WHERE и HAVING:

SELECT Manufacturer, COUNT(*) AS ModelsCount
FROM Products
WHERE Price * ProductCount > 80000
GROUP BY Manufacturer
HAVING COUNT(*) > 1


-- То есть в данном случае сначала фильтруются строки: выбираются те товары, общая стоимость которых больше 80000. Затем выбранные товары группируются по производителям. И далее фильтруются сами группы - выбираются те группы, которые содержат больше 1 модели.
-- Если при этом необходимо провести сортировку, то выражение ORDER BY идет после выражения HAVING:
SELECT Manufacturer, COUNT(*) AS Models, SUM(ProductCount) AS Units
FROM Products
WHERE Price * ProductCount > 80000
GROUP BY Manufacturer
HAVING SUM(ProductCount) > 2
ORDER BY Units DESC

    
-- Дополнительно к стандартным операторам GROUP BY и HAVING
-- SQL Server поддерживает еще четыре специальных расширения для группировки данных: 
-- ROLLUP, CUBE, GROUPING SETS и OVER.



-- Оператор ROLLUP добавляет суммирующую строку в результирующий набор:
SELECT Manufacturer, COUNT(*) AS Models, SUM(ProductCount) AS Units
FROM Products
GROUP BY Manufacturer WITH ROLLUP
-- Apple	4	13
-- ......
-- NULL	8	27 -<< ---- 

SELECT Manufacturer, COUNT(*) AS Models, SUM(ProductCount) AS Units
FROM Products
GROUP BY ROLLUP(Manufacturer)
-- ???? 'ROLLUP' is not a recognized built-in function name.

-- При группировке по нескольким критериям ROLLUP будет создавать суммирующую строку для каждой из подгрупп:

SELECT Manufacturer, COUNT(*) AS Models, SUM(ProductCount) AS Units
FROM Products
GROUP BY Manufacturer, ProductCount WITH ROLLUP


--При группировке по нескольким критериям ROLLUP будет создавать суммирующую строку для каждой из подгрупп:
-- Аааааа! Мне кажется, это очнь опасно!!!
--https://metanit.com/sql/sqlserver/5.3.php
SELECT Manufacturer, COUNT(*) AS Models, SUM(ProductCount) AS Units
FROM Products
GROUP BY Manufacturer, ProductCount WITH ROLLUP




--CUBE
--CUBE похож на ROLLUP за тем исключением, что CUBE добавляет суммирующие строки для каждой комбинации групп.
SELECT Manufacturer, COUNT(*) AS Models, SUM(ProductCount) AS Units
FROM Products
GROUP BY Manufacturer, ProductCount WITH CUBE
-- бред какой-то! почему все в конец добавляется ?

-- Оператор GROUPING SETS аналогично ROLLUP и CUBE добавляет суммирующую строку для групп. Но при этом он не включает сами группам:
SELECT Manufacturer, COUNT(*) AS Models, ProductCount
FROM Products
GROUP BY GROUPING SETS(Manufacturer, ProductCount);

-- Incorrect syntax near 'SETS'.


--типа задали вопрос, как третий по размеру вывести
-- SELECT * FROM (
--   SELECT
--     ROW_NUMBER() OVER (ORDER BY key ASC) AS rownumber,
--     columns
--   FROM tablename
-- ) AS foo
-- WHERE rownumber = n


WITH myTableWithRows AS (
    SELECT (ROW_NUMBER() OVER (ORDER BY dbo.Products.Price)) as row,*
    FROM dbo.Products)
SELECT * FROM myTableWithRows WHERE row = 3



WITH wcte AS (
SELECT *,RowNumber() OVER (ORDER BY ID) Rno
FROM YourTABLE
) SELECT * FROM wcte WHERE rno BETWEEN 5 AND 10

SELECT * FROM
(
	SELECT TOP 5 * 
	FROM
	(
		SELECT TOP 10 *
		FROM TableName
		ORDER BY ID ASC
	 ) t ORDER BY ID DESC
)t2 ORDER BY ID


-- Query cost: 14% (Atif)
;WITH wcte AS (
	SELECT *, row_number() OVER (ORDER BY ContactID) rno
	FROM Person.Contact)
SELECT * FROM wcte 
WHERE rno BETWEEN 5 AND 10

-- Query cost: 19% (Tharindu)
SELECT  top 5 * 
FROM Person.Contact
WHERE ContactID NOT IN (SELECT TOP 5 ContactID FROM Person.Contact ORDER BY ContactID)
ORDER BY ContactID

-- Query cost: 67% (Manoj-Mandal)
SELECT * FROM (
	SELECT TOP 5 * 
	FROM (
		SELECT TOP 10 *
		FROM Person.Contact
		ORDER BY ContactID ASC
	 ) t ORDER BY ContactID DESC
)t2 ORDER BY ContactID


-- Hi there,
-- Thank you for all, I did try some of the methods mentioned above. Especially I use the method suggested by Uri Dimant in a stored procedure. But I want to know whther can I do this in a single query without using any sub queries.
-- Because in the mySQL we can do this by the following,
-- SELECT * FROM Table1 ORDER BY Price LIMIT 10 OFFSET 20
-- Here I can get the records from 21st to 30th....
-- Do we have LIMIT and OFFSET keywords in SQL Server ? I think no ... 





-- Выполнение подзапросов
-- https://metanit.com/sql/sqlserver/6.1.php

USE productsdb;

CREATE TABLE Products
(
    Id INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(30) NOT NULL,
    Manufacturer NVARCHAR(20) NOT NULL,
    ProductCount INT DEFAULT 0,
    Price MONEY NOT NULL
);

CREATE TABLE Customers
(
    Id INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(30) NOT NULL
);

CREATE TABLE Orders
(
    Id INT IDENTITY PRIMARY KEY,
    ProductId INT NOT NULL REFERENCES Products(Id) ON DELETE CASCADE,
    CustomerId INT NOT NULL REFERENCES Customers(Id) ON DELETE CASCADE,
    CreatedAt DATETIME NOT NULL,
    ProductCount INT DEFAULT 1,
    Price MONEY NOT NULL
);
-- Таблица Orders содержит ссылки на две другие таблицы через поля ProductId и CustomerId.
-- Добавим в таблицы некоторые данные:

/*
INSERT INTO Products VALUES ('iPhone 6', 'Apple', 2, 36000),
('iPhone 6S', 'Apple', 2, 41000),
('iPhone 7', 'Apple', 5, 52000),
('Galaxy S8', 'Samsung', 2, 46000),
('Galaxy S8 Plus', 'Samsung', 1, 56000),
('Mi 5X', 'Xiaomi', 2, 26000),
('OnePlus 5', 'OnePlus', 6, 38000)
 */
INSERT INTO Products VALUES ('iPhone 6', 'Apple', 2, 36000);
INSERT INTO Products VALUES ('iPhone 6S', 'Apple', 2, 41000);
INSERT INTO Products VALUES ('iPhone 7', 'Apple', 5, 52000);
INSERT INTO Products VALUES ('Galaxy S8', 'Samsung', 2, 46000);
INSERT INTO Products VALUES ('Galaxy S8 Plus', 'Samsung', 1, 56000);
INSERT INTO Products VALUES ('Mi 5X', 'Xiaomi', 2, 26000);
INSERT INTO Products VALUES ('OnePlus 5', 'OnePlus', 6, 38000);

INSERT INTO Customers VALUES ('Tom');
INSERT INTO Customers VALUES ('Bob');
INSERT INTO Customers VALUES ('Sam');

INSERT INTO Orders 
VALUES
( 
    (SELECT Id FROM Products WHERE ProductName='Galaxy S8'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-11',  
    2, 
    (SELECT Price FROM Products WHERE ProductName='Galaxy S8')
),
( 
    (SELECT Id FROM Products WHERE ProductName='iPhone 6S'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-13',  
    1, 
    (SELECT Price FROM Products WHERE ProductName='iPhone 6S')
),
( 
    (SELECT Id FROM Products WHERE ProductName='iPhone 6S'), 
    (SELECT Id FROM Customers WHERE FirstName='Bob'),
    '2017-07-11',  
    1, 
    (SELECT Price FROM Products WHERE ProductName='iPhone 6S')
)

-- Subqueries are not allowed in this context. Only scalar expressions are allowed.
-- > I don't have a Microsoft SQL Server 2000 anymore, but this should also work, simply replace VALUES with SELECT and remove the brackets:
/*
insert into table_one (greeting_column, name_column)
SELECT  'hello', (select column_1 from table_to where name = 'bob')

For insert with subquery, you must not pass values, it have to be some thing like this:  !!!!

Hi, you hit one of the most annoying SQL limitation, the way to go around this is simple but tiring: 
you declare a variable, fill it with the value you want and the use that variable in your insert statement. 
Something like this:

DECLARE @foo int
SELECT TOP 1 @foo = ...
INSERT INTO Table1(x, y, z) VALUES (1, 2, @foo)
*/

/* PROBLEM: Subqueries are not allowed in this context. Only scalar expressions are allowed.*/
/* SOLUTION: simply replace VALUES with SELECT and remove the brackets:*/

INSERT INTO Orders
SELECT
    (SELECT Id FROM Products WHERE ProductName='Galaxy S8'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-11',  
    2, 
    (SELECT Price FROM Products WHERE ProductName='Galaxy S8');

INSERT INTO Orders
SELECT
    (SELECT Id FROM Products WHERE ProductName='iPhone 6S'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-13',  
    1, 
    (SELECT Price FROM Products WHERE ProductName='iPhone 6S');


INSERT INTO Orders
SELECT
    (SELECT Id FROM Products WHERE ProductName='iPhone 6S'), 
    (SELECT Id FROM Customers WHERE FirstName='Bob'),
    '2017-07-11',  
    1, 
    (SELECT Price FROM Products WHERE ProductName='iPhone 6S');


-- найдем товары из таблицы Products, которые имеют минимальную цену:
SELECT * FROM Products
WHERE Price = (SELECT MIN(Price) FROM Products)

-- Или найдем товары, цена которых выше средней:
SELECT * FROM Products
WHERE Price > (SELECT AVG(Price) FROM Products)


/*
Коррелирующие подзапросы
Подзапросы бывают коррелирующими и некоррелирующими. 
В примерах выше команды SELECT выполняли фактически один подзапрос для всей команды, 
например, подзапрос возвращает минимальную или среднюю цену, которая не изменится,
сколько бы мы строк не выбирали в основном запросе. 
То есть результат подзапроса не зависел от строк, которые выбираются в основном запросе. 
И такой подзапрос выполняется один раз для всего внешнего запроса.
Но также существуют коррелирующие подзапросы (correlated subquery), 
результаты которых зависят от строк, которые выбираются в основном запросе.
Например, выберем все заказы из таблицы Orders, добавив к ним информацию о товаре:
*/

SELECT  CreatedAt, 
        Price, 
        (SELECT ProductName 
		 FROM Products 
		 WHERE Products.Id = Orders.ProductId) 
		 AS Product
FROM Orders

/*Здесь для каждой строки из таблицы Orders будет выполняться подзапрос, 
результат которого зависит от столбца ProductId. 
И каждый подзапрос может возвращать различные данные.
Коррелирующий подзапрос может выполняться и для той же таблицы, к которой выполняется основной запрос.

Например, выберем из таблицы Products те товары, стоимость которых выше средней цены товаров для данного производителя:
*/
SELECT ProductName,
       Manufacturer,
       Price, 
        (SELECT AVG(Price) FROM Products AS SubProds 
         WHERE SubProds.Manufacturer=Prods.Manufacturer) AS AvgPrice
FROM Products AS Prods
WHERE Price > (SELECT AVG(Price) FROM Products AS SubProds WHERE SubProds.Manufacturer=Prods.Manufacturer)

/*
В данном случае определено два коррелирующих подзапроса. Первый подзапрос определяет спецификацию столбца AvgPrice. Он будет выполняться для каждой строки, извлекаемой из таблицы Products. В подзапрос передается производитель товара и на его основе выбирается средняя цена для товаров именно этого производителя. И так как производитель у товаров может отличаться, то и результат подзапроса в каждом случае также может отличаться.
Второй подзапрос аналогичен, только он используется для фильтрации извлекаемых из таблицы Products. И также он будет выполняться для каждой строки.
Чтобы избежать двойственности при фильтрации в подзапросе при сравнении производителей (SubProds.Manufacturer=Prods.Manufacturer) для внешней выборки установлен псевдоним Prods, а для выборки из подзапросов определен псевдоним SubProds.
Следует учитывать, что коррелирующие подзапросы выполняются для каждой отдельной строки выборки, то выполнение таких подзапросов может замедлять выполнение всего запроса в целом.
*/