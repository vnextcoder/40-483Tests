
CREATE TABLE Customers
(
	CustomerID CHAR(5) CONSTRAINT CID_PK PRIMARY KEY,
	CompanyName VARCHAR(50) CONSTRAINT CmpName_NN NOT NULL CONSTRAINT CmpName_UQ UNIQUE,
	ContactPerson VARCHAR(50) CONSTRAINT ContactPerson_NN NOT NULL,
	Phone VARCHAR(20) CONSTRAINT Phone_NN NOT NULL,
	Email VARCHAR(100) CONSTRAINT Email_NN NOT NULL CONSTRAINT Email_UQ UNIQUE,
	WebSiteURL VARCHAR(100) CONSTRAINT WebSiteURL_UQ UNIQUE		
)

INSERT INTO Customers VALUES ('DL','Dell Limited','Scott','(+91) 1209873456','helpdesk@dell.com','http://www.dell.co.in')

INSERT INTO Customers VALUES ('BSL','Birlasoft Limited','Shan Bala','(+91) 1209873765','helpdesk@birlasoft.com','http://www.birlasoft.com')

INSERT INTO Customers VALUES ('AIL','Accenture India Limited','Allen','(+91) 1209872345','helpdesk@accenture.com',null)

INSERT INTO Customers  VALUES ('WL','Wipro Limited','Azeem Premji','(+91) 1209872345','helpdesk@wipro.com','http://www.wipro.com')

INSERT INTO Customers  VALUES ('FB','Facebook','Mark Zuckerberg','(+91) 1209872323','helpdesk@facebook.com','http://www.facebook.com')

CREATE TABLE Products
(
	ProductID CHAR(20) CONSTRAINT PID_PK PRIMARY KEY,
	ProductName VARCHAR(100) CONSTRAINT PName_NN NOT NULL CONSTRAINT PName_UQ UNIQUE,
	UnitPrice SMALLMONEY CONSTRAINT Price_NN NOT NULL CONSTRAINT Price_CK CHECK (UnitPrice>100),
	LincensesInHand INT CONSTRAINT LIH_NN NOT NULL,
	ReorderLevel SMALLINT CONSTRAINT ROL_DF DEFAULT 500		
)		

INSERT INTO Products VALUES ('SS2005','SQL Server 2005',5000,20000,default)
INSERT INTO Products VALUES ('SS2008','SQL Server 2008',5000,20000,1000)
INSERT INTO Products VALUES ('VS2008','Visual Studio 2008',10000,25000,900)
INSERT INTO Products VALUES ('VS2010','Visual Studio 2010',15000,30000,1000)

CREATE TABLE Orders
(
	OrderID BIGINT CONSTRAINT OID_PK PRIMARY KEY IDENTITY (1,1),
	OrderDate SMALLDATETIME CONSTRAINT ODate_NN NOT NULL CONSTRAINT ODate_CK CHECK(OrderDate<=GetDate()),
	ShippingDate SMALLDATETIME CONSTRAINT SDate_NN NOT NULL,
	ProductID CHAR(20) CONSTRAINT PID_NN NOT NULL CONSTRAINT PID_FrK FOREIGN KEY REFERENCES Products(ProductID),
	CustomerID CHAR(5) CONSTRAINT CID_NN NOT NULL CONSTRAINT CID_Frk FOREIGN KEY REFERENCES Customers(CustomerID),				
	Quantity INT CONSTRAINT Qty_NN NOT NULL CONSTRAINT Qty_DF DEFAULT 50,
	Amount MONEY,	
	--Table Level Check Constraint	
	CONSTRAINT SDate_CK CHECK(ShippingDate>=OrderDate)	
)

CREATE FUNCTION GetAmount
	(
		@ProductID CHAR(20),
		@Quantity INT
	)
RETURNS MONEY
AS
BEGIN
DECLARE @Amount MONEY --Variable at Function Level
	IF ((SELECT Count(*) FROM Products WHERE ProductID=@ProductID)=1)
	BEGIN
		DECLARE @Price MONEY --Varaible at IF Block level
		SELECT @Price=UnitPrice FROM Products WHERE ProductID=@ProductID
		SET @Amount=@Quantity*@Price			
	END
	
	ELSE		
	BEGIN
		SET @Amount=0
	END
RETURN @Amount
END

INSERT INTO Orders VALUES ('1/1/2001','1/2/2001','VS2010','BSL',400,dbo.GetAmount('VS2010',400))
INSERT INTO Orders VALUES ('2/1/2001','2/5/2001','SS2005','AIL',400,dbo.GetAmount('SS2005',400))
INSERT INTO Orders VALUES ('1/1/2001','1/2/2001','VS2008','DL',400,dbo.GetAmount('VS2008',400))

CREATE PROCEDURE USP_AddCustomer
	@CusotmerID CHAR(5),
	@CompanyName VARCHAR(50),
	@ContactPerson VARCHAR(50),
	@Phone VARCHAR(25),
	@Email VARCHAR(100),
	@WebSiteURL VARCHAR(100)
AS
	INSERT INTO Customers VALUES 
		(
			@CusotmerID,
			@CompanyName,
			@ContactPerson,
			@Phone,
			@Email,
			@WebSiteURL
		)
PRINT 'New customer is added'


CREATE PROC USP_PlaceOrder
	@ODate SMALLDATETIME,
	@SDate SMALLDATETIME,
	@PID CHAR(15),
	@CID CHAR(5),
	@Qty INT,
	@Msg VARCHAR(100) OUTPUT
AS
	IF (SELECT Count(*) FROM Products WHERE ProductID=@PID)=1 AND (SELECT Count(*) FROM Customers WHERE CustomerID=@CID)=1
	BEGIN
		DECLARE @LIH INT
		SELECT @LIH=LincensesInHand FROM Products WHERE ProductID=@PID
		IF (@LIH>@Qty)
		BEGIN
			INSERT INTO Orders (OrderDate,ShippingDate,ProductID,CustomerID,Quantity,Amount) VALUES(@ODate,@SDate,@PID,@CID,@Qty,dbo.GetAmount(@PID,@Qty))
			UPDATE Products SET LincensesInHand=LincensesInHand-@Qty WHERE ProductID=@PID
			--PRINT 'Order Placed Successfully'
			SET @Msg='Order Placed Successfully'		
		END
		ELSE
			--PRINT 'Insufficient Licenses for the requested product'
			SET @Msg='Insufficient Licenses for the requested product'
	END
	
	ELSE
	--PRINT 'ProductID or CustomerID does not exists
	SET @Msg='ProductID or CustomerID does not exists'






---View based on Join using Customers, Products and Orders.
Create View OrderDetails
as 
select orderid, OrderDate, O.CustomerID, CompanyName,
O.ProductID, ProductName, UnitPrice, Quantity, dbo.GetAmount(O.ProductID, O.Quantity) 
as Amt
from 
	orders O inner join customers C
	On O.CustomerID=C.CustomerID
	INNER Join Products P
	on O.ProductID=P.ProductID

select * from OrderDetails



Alter procedure USP_OrderDetails
@CustomerID Varchar(20)=NULL
as 
if @CustomerID is null
begin
	select @CustomerID=''
end
select * from orderdetails
where customerid like '%' + @CustomerID + '%'



alter procedure USP_OrderDetails2
@CustomerID Varchar(20)=''
as 
if @CustomerID = ''
begin
	select @CustomerID=''
end
select * from orderdetails
where customerid like '%' + @CustomerID + '%'


USP_OrderDetails2 'AIL'



Create procedure USP_OrderDetailsMulti
@CustomerID Varchar(20)=''
as 
if @CustomerID = ''
begin
	select @CustomerID=''
end
select * from orderdetails
where customerid like '%' + @CustomerID + '%'

select * from Customers
where customerid like '%' + @CustomerID + '%'
