-- https://metanit.com/sql/sqlserver/11.1.php
Хранимые процедуры
Создание и выполнение процедур

/*
Нередко операция с данными представляет набор инструкций, которые необходимо выполнить в определенной последовательности. Например, при добавлении покупке товара необходимо внести данные в таблицу заказов. Однако перед этим надо проверить, а есть ли покупаемый товар в наличии. Возможно, при этом понадобится проверить еще ряд дополнительных условий. То есть фактически процесс покупки товара охватывает несколько действий, которые должны выполняться в определенной последовательности. И в этом случае более оптимально будет инкапсулировать все эти действия в один объект - хранимую процедуру (stored procedure).

То есть по сути хранимые процедуры представляет набор инструкций, которые выполняются как единое целое. Тем самым хранимые процедуры позволяют упростить комплексные операции и вынести их в единый объект. Изменится процесс покупки товара, соответственно достаточно будет изменить код процедуры. То есть процедура также упрощает управление кодом.

Также хранимые процедуры позволяют ограничить доступ к данным в таблицах и тем самым уменьшить вероятность преднамеренных или неосознанных нежелательных действий в отношении этих данных.

И еще один важный аспект - производительность. Хранимые процедуры обычно выполняются быстрее, чем обычные SQL-инструкции. Все потому что код процедур компилируется один раз при первом ее запуске, а затем сохраняется в скомпилированной форме.

Для создания хранимой процедуры применяется команда CREATE PROCEDURE или CREATE PROC.

Таким образом, хранимая процедура имеет три ключевых особенности: упрощение кода, безопасность и производительность.

Например, пусть в базе данных есть таблица, которая хранит данные о товарах:
*/

-- Создадим хранимую процедуру для извлечения данных из этой таблицы:

USE productsdb;
GO

CREATE PROCEDURE ProductSummary AS
SELECT ProductName AS Product, Manufacturer, Price
FROM Products

/* SQL Error (111): 'CREATE/ALTER PROCEDURE' must be the first statement in a query batch. */
/* SQL Error (2714): There is already an object named 'ProductSummary' in the database. */

Поскольку команда CREATE PROCEDURE должна вызываться в отдельном пакете, то после команды USE, которая устанавливает текущую базу данных, используется команда GO для определения нового пакета.

После имени процедуры должно идти ключевое слово AS.

Для отделения тела процедуры от остальной части скрипта код процедуры нередко помещается в блок BEGIN...END:


USE productsdb;
GO

CREATE PROCEDURE ProductSummary AS
BEGIN
    SELECT ProductName AS Product, Manufacturer, Price
    FROM Products
END;

-- После добавления процедуры мы ее можем увидеть в узле базы данных в SQL Server Management Studio 
--  в подузле Programmability -> Stored Procedures

EXEC ProductSummary;
DROP PROCEDURE ProductSummary
DROP PROCEDURE "dbo"."ProductSummary";
/* SQL Error (3701): Cannot drop the procedure 'dbo.ProductSummary', because it does not exist or you do not have permission. */


-- https://metanit.com/sql/sqlserver/11.2.php
Параметры в процедурах

USE productsdb;
CREATE TABLE Products
(
    Id INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(30) NOT NULL,
    Manufacturer NVARCHAR(20) NOT NULL,
    ProductCount INT DEFAULT 0,
    Price MONEY NOT NULL
);


USE productsdb;
GO
CREATE PROCEDURE AddProduct
    @name NVARCHAR(20),
    @manufacturer NVARCHAR(20),
    @count INT,
    @price MONEY
AS
INSERT INTO Products(ProductName, Manufacturer, ProductCount, Price) 
VALUES(@name, @manufacturer, @count, @price)

После названия процедуры идет список входных параметров, которые определяются также как и переменные
 - название начинается с символа @, а после названия идет тип переменной. 
 И с помощью команды INSERT значения этих параметров будут передаваться в таблицу Products.

Используем эту процедуру:

USE productsdb;
 
DECLARE @prodName NVARCHAR(20), @company NVARCHAR(20);
DECLARE @prodCount INT, @price MONEY;
SET @prodName = 'Galaxy C7';
SET @company = 'Samsung';
SET @price = 22000;
SET @prodCount = 5;
 
EXEC AddProduct @prodName, @company, @prodCount, @price
 
SELECT * FROM Products

/* SQL Error (137): Must declare the scalar variable "@prodName". */ 


