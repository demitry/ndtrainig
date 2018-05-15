


USE master
GO
xp_readerrorlog 0, 1, N'Server is listening on', 'any', NULL, NULL, N'asc' 
GO

USE MASTER
GO
xp_readerrorlog 0, 1, N'Server is listening on'
GO

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


-- Подзапросы в SELECT
--В выражении SELECT мы можем вводить подзапросы четырьмя способами:
--Использовать в условии в выражении WHERE
--Использовать в условии в выражении HAVING
--Использовать в качестве таблицы для выборки в выражении FROM
--Использовать в качестве спецификации столбца в выражении SELECT

--Рассмотрим некоторые из этих случаев. Например, получим все товары, у которых цена выше средней:
SELECT * FROM Products
WHERE Price > (SELECT AVG(Price) FROM Products)

-- Или выберем всех покупателей из таблицы Customers, у которых нет заказов в таблице Orders:
SELECT * FROM CUSTOMERS
WHERE Id NOT IN (SELECT CustomerId FROM Orders)

/*Хотя в данном случае подзапросы прекрасно справляются со своей задачей, 
стоит отметить, что это не самый эффективный способ для извлечения данных из других таблиц, 
так как в рамках T-SQL для сведения данных из разных таблиц можно использовать оператор JOIN, 
который рассматривается в следующей теме.
*/

--Получение набора значений
--При использовании в операторах сравнения подзапросы должны возвращать одно скалярное значение. 
-- Но иногда возникает необходимость получить набор значений. 
-- Чтобы при использовании в операторах сравнения подзапрос мог возвращать набор значений, перед ним необходимо использовать один из операторов: ALL, SOME или ANY.
--При использовании ключевого слова ALL условие в операции сравнения должно быть верно для всех значений, которые возвращаются подзапросом. 
-- Например, найдем все товары, цена которых меньше чем у любого товара фирмы Apple:

SELECT * FROM Products
WHERE Price < ALL(SELECT Price FROM Products WHERE Manufacturer='Apple')
-- Если бы мы в данном случае опустили бы ключевое слово ALL, то мы бы столкнулись с ошибкой.

/*
Допустим, если подзапрос возвращает значения vl1, val2 и val3, то условие фильтрации фактически было бы аналогично объединению этих значений через оператор AND:
WHERE Price < val1 AND Price < val2 AND Price < val3
В тоже время подобный запрос гораздо проще переписать другим образом:
*/
SELECT * FROM Products
WHERE Price < (SELECT MIN(Price) FROM Products WHERE Manufacturer='Apple')

--При применении ключевых слов ANY и SOME условие в операции сравнения должно быть истинным для хотя бы одного из значений, возвращаемых подзапросом. По действию оба этих оператора аналогичны, поэтому можно применять любое из них. Например, в следующем случае получим товары, которые стоят меньше самого дорого товара компании Apple:

SELECT * FROM Products
WHERE Price < ANY(SELECT Price FROM Products WHERE Manufacturer='Apple')
--И также стоит отметить, что данный запрос можно сделать проще, переписав следующим образом:

SELECT * FROM Products
WHERE Price < (SELECT MAX(Price) FROM Products WHERE Manufacturer='Apple')


-- Подзапрос как спецификация столбца
-- Результат подзапроса может представлять отдельный столбец в выборке. 
-- Например, выберем все заказы и добавим к ним информацию о названии товара:

SELECT * FROM dbo.Orders o;
SELECT *, 
(SELECT ProductName FROM Products WHERE Id=Orders.ProductId) AS Product 
FROM Orders


-- Подзапросы в команде INSERT
-- В команде INSERT подзапросы могут применяться для определения значения, которое вставляется в один из столбцов:

-- Subqueries are not allowed in this context. Only scalar expressions are allowed.
--INSERT INTO Orders (ProductId, CustomerId, CreatedAt, ProductCount, Price)
--VALUES
--( 
--    (SELECT Id FROM Products WHERE ProductName='Galaxy S8'), 
--    (SELECT Id FROM Customers WHERE FirstName='Tom'),
--    '2017-07-11',  
--    2, 
--    (SELECT Price FROM Products WHERE ProductName='Galaxy S8')
--)
INSERT INTO Orders (ProductId, CustomerId, CreatedAt, ProductCount, Price)
SELECT
    (SELECT Id FROM Products WHERE ProductName='Galaxy S8'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-11',  
    2, 
    (SELECT Price FROM Products WHERE ProductName='Galaxy S8');


--Подзапросы в команде UPDATE

--В команде UPDATE подзапросы могут применяться:
--В качестве устанавливаемого значения после оператора SET
--Как часть условия в выражении WHERE
--Так, увеличим количество купленных товаров на 2 в тех заказах, где покупатель Тоm:

UPDATE Orders
SET ProductCount = ProductCount + 2
WHERE CustomerId=(SELECT Id FROM Customers WHERE FirstName='Tom')

--Или установим для заказа цену товара, полученную в результате подзапроса:
UPDATE Orders
SET Price = (SELECT Price FROM Products WHERE Id=Orders.ProductId) + 2000
WHERE Id=1


-- Подзапросы в команде UPDATE
-- В команде UPDATE подзапросы могут применяться:
-- 
-- В качестве устанавливаемого значения после оператора SET
-- 
-- Как часть условия в выражении WHERE
-- 
-- Так, увеличим количество купленных товаров на 2 в тех заказах, где покупатель Тоm:
-- 

select * from Orders;

UPDATE Orders
SET ProductCount = ProductCount + 2
WHERE CustomerId=(SELECT Id FROM Customers WHERE FirstName='Tom');

-- Или установим для заказа цену товара, полученную в результате подзапроса:
UPDATE Orders
SET Price = (SELECT Price FROM Products WHERE Id=Orders.ProductId) + 2000
WHERE Id=1

-- Подзапросы в команде DELETE
-- В команде DELETE подзапросы также применяются как часть условия. Так, удалим все заказы на Galaxy S8, которые сделал Bob:
-- 

use productsdb;

DELETE FROM Orders
WHERE ProductId=(SELECT Id FROM Products WHERE ProductName='Galaxy S8')
AND CustomerId=(SELECT Id FROM Customers WHERE FirstName='Bob')


-- Оператор EXISTS
-- Оператор EXISTS позволяет проверить, возвращает ли подзапрос какое-либо значение. Как правило, этот оператор используется для индикации того, что какая-либо строка удовлетворяет условию. То есть фактически оператор EXISTS не возвращает строки, а лишь указывает, что в базе данных есть как минимум одна строка, которые соответствует данному запросу. Поскольку возвращения набора строк не происходит, то подзапросы с подобным оператором выполняются довольно быстро.
-- Применение оператора имеет следующий формальный синтаксис:
-- WHERE [NOT] EXISTS (подзапрос)
-- Например, найдем всех покупателей из таблицы Customer, которые делали заказы:
-- 
SELECT *
FROM Customers
WHERE EXISTS (SELECT * FROM Orders 
                  WHERE Orders.CustomerId = Customers.Id)



-- Другой пример - найдем все товары из таблицы Products, на которые не было заказов в таблице Orders:
SELECT * FROM Products
WHERE NOT EXISTS (SELECT * FROM Orders WHERE Products.Id = Orders.ProductId);

-- Но поскольку при применении EXISTS не происходит выборка строк, то его использование более оптимально и эффективно, чем использование оператора IN.


-- Глава 7. Соединение таблиц
SELECT * FROM Orders;

SELECT * FROM Customers;
	
SELECT * FROM Orders, Customers

-- При такой выборке для каждая строка из таблицы Orders будет совмещаться с каждой строкой из таблицы Customers. 
-- !!! То есть, получится перекрестное соединение. Например, в Orders три строки, а в Customers то же три строки, значит мы получим 3 * 3 = 9 строк:

-- То есть в данном случае мы получаем прямое (декартово) произведение двух групп. Но вряд ли это тот результат, который хотелось бы видеть. Тем более каждый заказ из Orders связан с конкретным покупателем из Customers, а не со всеми возможными покупателями.

-- Чтобы решить задачу, необходимо использовать выражение WHERE и фильтровать строки при условии, что поле CustomerId из Orders соответствует полю Id из Customers:

SELECT * FROM Orders, Customers WHERE Orders.CustomerId = Customers.Id

-- Теперь объединим данные по трем таблицам Orders, Customers и Proucts. То есть получим все заказы и добавим информацию по клиенту и связанному товару:
SELECT Customers.FirstName, Products.ProductName, Orders.CreatedAt 
FROM Orders, Customers, Products
WHERE Orders.CustomerId = Customers.Id AND Orders.ProductId=Products.Id;

-- Поскольку надо соединить три таблицы, то применяются как минимум два условия. Ключевой таблицей остается Orders, из которой извлекаются все заказы, а затем к ней подсоединяется данные по клиенту по условию Orders.CustomerId = Customers.Id и данные по товару по условию Orders.ProductId=Products.Id

-- Поскольку в данном случае названия таблиц сильно увеличивают код, то мы его можем сократить за счет использования псевдонимов таблиц:

SELECT C.FirstName, P.ProductName, O.CreatedAt 
FROM Orders AS O, Customers AS C, Products AS P
WHERE O.CustomerId = C.Id AND O.ProductId=P.Id

-- Если необходимо при использовании псевдонима выбрать все столбцы из определенной таблицы, то можно использовать звездочку:

SELECT C.FirstName, P.ProductName, O.*
FROM Orders AS O, Customers AS C, Products AS P
WHERE O.CustomerId = C.Id AND O.ProductId=P.Id

-- https://metanit.com/sql/sqlserver/7.2.php

SELECT Orders.CreatedAt, Orders.ProductCount from Orders;

SELECT Orders.CreatedAt, Orders.ProductCount, Products.ProductName 
FROM Orders
JOIN Products ON Products.Id = Orders.ProductId

-- Поскольку таблицы могут содержать столбцы с одинаковыми названиями, то при указании столбцов для выборки указывается их полное имя вместе с именем таблицы, например, "Orders.ProductCount".

-- Также используя псевдонимы, мы можем сократить код:
SELECT O.CreatedAt, O.ProductCount, P.ProductName 
FROM Orders AS O
JOIN Products AS P
ON P.Id = O.ProductId

-- Подобным образом мы можем присоединять и другие таблицы. Например, добавим к заказу информацию о покупателе из таблицы Customers:
SELECT Orders.CreatedAt, Customers.FirstName, Products.ProductName
FROM Orders
JOIN Products ON Products.Id = Orders.ProductId 
JOIN Customers ON Customers.Id = Orders.CustomerId

-- Благодаря соединению таблиц мы можем использовать их столбцы для фильтрации выборки или ее сортировки:

SELECT Orders.CreatedAt, Customers.FirstName, Products.ProductName, Products.Price
FROM Orders
JOIN Products ON Products.Id = Orders.ProductId
JOIN Customers ON Customers.Id=Orders.CustomerId
WHERE Products.Price < 45000
ORDER BY Customers.FirstName


-- Условия после ключевого слова ON могут быть более сложными по составу:

SELECT Orders.CreatedAt, Customers.FirstName, Products.ProductName 
FROM Orders
JOIN Products ON Products.Id = Orders.ProductId AND Products.Manufacturer='Apple'
JOIN Customers ON Customers.Id=Orders.CustomerId
ORDER BY Customers.FirstName

-- В данном случае выбираем все заказы на товары, производителем которых является Apple.

-- NB!!!
-- При использовании оператора JOIN следует учитывать, что процесс соединения таблиц может быть ресурсоемким,
-- поэтому следует соединять только те таблицы, данные из которых действительно необходимы. 
-- Чем больше таблиц соединяется, тем больше снижается производительность.

-- OUTER JOIN
-- https://metanit.com/sql/sqlserver/7.3.php

SELECT FirstName, CreatedAt, ProductCount, Price, ProductId 
FROM Orders LEFT JOIN Customers 
ON Orders.CustomerId = Customers.Id

/* По вышеприведенному результату может показаться, что левостороннее соединение аналогично INNER Join, но это не так. 
 
 Inner Join объединяет строки из дух таблиц при соответствии условию. Если одна из таблиц содержит строки,
 которые не соответствуют этому условию, то данные строки не включаются в выходную выборку. 
 
 Left Join выбирает все строки первой таблицы и затем присоединяет к ним строки правой таблицы.
 К примеру, возьмем таблицу Customers и добавим к покупателям информацию об их заказах:
*/

-- INNER JOIN
SELECT FirstName, CreatedAt, ProductCount, Price 
FROM Customers JOIN Orders 
ON Orders.CustomerId = Customers.Id
 
-- LEFT JOIN
SELECT FirstName, CreatedAt, ProductCount, Price 
FROM Customers LEFT JOIN Orders 
ON Orders.CustomerId = Customers.Id
-- Тут будет еще включено - Sam NULL NULL NULL

-- Изменим в примере выше тип соединения на правостороннее:
SELECT FirstName, CreatedAt, ProductCount, Price, ProductId 
FROM Orders RIGHT JOIN Customers 
ON Orders.CustomerId = Customers.Id

-- Поскольку один из покупателей из таблицы Customers не имеет связанных заказов из Orders, то соответствующие столбцы, которые берутся из Orders, будут иметь значение NULL.

-- Используем левостороннее соединение для добавления к заказам информации о пользователях и товарах:

SELECT Customers.FirstName, Orders.CreatedAt, 
       Products.ProductName, Products.Manufacturer
FROM Orders 
LEFT JOIN Customers ON Orders.CustomerId = Customers.Id
LEFT JOIN Products ON Orders.ProductId = Products.Id

-- И также можно применять более комплексные условия с фильтрацией и сортировкой. Например, выберем все заказы с информацией о клиентах и товарах по тем товарам, у которых цена меньше 45000, и отсортируем по дате заказа:
SELECT Customers.FirstName, Orders.CreatedAt, 
       Products.ProductName, Products.Manufacturer
FROM Orders 
LEFT JOIN Customers ON Orders.CustomerId = Customers.Id
LEFT JOIN Products ON Orders.ProductId = Products.Id
WHERE Products.Price < 45000
ORDER BY Orders.CreatedAt

-- Или выберем всех пользователей из Customers, у которых нет заказов в таблице Orders:

SELECT FirstName FROM Customers
LEFT JOIN Orders ON Customers.Id = Orders.CustomerId
WHERE Orders.CustomerId IS NULL

-- Также можно комбинировать Inner Join и Outer Join:
SELECT Customers.FirstName, Orders.CreatedAt, 
       Products.ProductName, Products.Manufacturer
FROM Orders 
JOIN Products ON Orders.ProductId = Products.Id AND Products.Price < 45000
LEFT JOIN Customers ON Orders.CustomerId = Customers.Id
ORDER BY Orders.CreatedAt

--Вначале по условию к таблице Orders через Inner Join присоединяется связанная информация из Products, затем через Outer Join добавляется информация из таблицы Customers.

--Cross Join
-- Cross Join или перекрестное соединение создает набор строк, где каждая строка из одной таблицы соединяется с каждой строкой из второй таблицы. 
-- Например, соединим таблицу заказов Orders и таблицу покупателей Customers:

SELECT * FROM Orders CROSS JOIN Customers;

-- Если в таблице Orders 3 строки, а в таблице Customers то же тBENCHMARKри строки, то в результате перекрестного соединения создается 3 * 3 = 9 строк вне зависимости, связаны ли данные строки или нет.
-- При неявном перекрестном соединении можно опустить оператор CROSS JOIN и просто перечислить все получаемые таблицы:

SELECT * FROM Orders, Customers;

-- https://metanit.com/sql/sqlserver/7.4.php
-- Группировка в соединениях
