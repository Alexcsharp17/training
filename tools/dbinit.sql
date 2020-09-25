use carstore

CREATE TABLE Persons (
    PersonID int NOT NULL IDENTITY(1,1),
	FirstName varchar(255) NOT NULL,
    LastName varchar(255) NOT NULL,
	Phone varchar(255) NOT NULL,
    PRIMARY KEY (Personid)
);

CREATE TABLE Orders (
    OrderID int NOT NULL IDENTITY(1,1),
	OrderDate  DATETIME,
	CarID int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
);

INSERT INTO Persons (FirstName, LastName,  Phone)
VALUES ('John', 'Smith', '1-01-90');

INSERT INTO Persons (FirstName, LastName,  Phone)
VALUES ('Bob', 'Dylan', '1-01-90');

INSERT INTO Persons (FirstName, LastName,  Phone)
VALUES ('Fredy', 'Mercury', '1-01-90');

INSERT INTO Persons (FirstName, LastName,  Phone)
VALUES ('Chester', 'Benington', '1-01-90');

INSERT INTO Persons (FirstName, LastName,  Phone)
VALUES ('Bob', 'Marley', '1-01-90');

INSERT INTO Orders (OrderDate, CarID, PersonID)
VALUES ('9/15/2020', 1, 2);

INSERT INTO Orders (OrderDate, CarID, PersonID)
VALUES ('9/16/2020', 2, 4);

INSERT INTO Orders (OrderDate, CarID, PersonID)
VALUES ('9/16/2020', 1, 3);

INSERT INTO Orders (OrderDate, CarID, PersonID)
VALUES ('9/19/2020', 5, 4);


/*Create stored procedures*/

/*Create*/
go
CREATE PROCEDURE [dbo].[sp_InsertOrder]
    @OrderDate Datetime,
    @CarID int,
	@PersonID int
AS
    INSERT INTO Orders(OrderDate,CarID,PersonID)
    VALUES (@OrderDate,@CarID,@PersonID)
  

GO

CREATE PROCEDURE [dbo].[sp_InsertPerson]
	@FirstName varchar(50),
	@LastName  varchar(50),
	@Phone varchar(50)
AS
	INSERT INTO Persons(FirstName,LastName,Phone)
	VALUES(@FirstName,@LastName,@Phone)
GO
/*Read*/
CREATE PROCEDURE [dbo].[sp_GetOrder]
	@id int
AS
	Select * From Orders
	WHERE (OrderID=@id);
GO

CREATE PROCEDURE [dbo].[sp_GetUser]
	@id int
AS
	Select * From Persons
	WHERE (PersonID=@id);
GO
/*Update*/
CREATE PROCEDURE [dbo].[sp_UpdateOrder]
	@id int,
	@OrderDate Datetime,
    @CarID int,
	@PersonID int
AS
BEGIN
	UPDATE Orders
SET OrderDate=@OrderDate,
	CarID=@CarID,
	PersonID=@PersonID	
	WHERE (OrderID=@id);
END;
GO

CREATE PROCEDURE [dbo].[sp_UpdatePerson]
	@id int,
	@FirstName varchar(50),
	@LastName  varchar(50),
	@Phone varchar(50)
AS
BEGIN
	UPDATE Persons
SET FirstName=@FirstName,
	LastName=@LastName,
	@Phone=@Phone
	WHERE (PersonID=@id);
END;
GO
/*Delete*/
CREATE PROCEDURE [dbo].[sp_DeleteOrder]
	@id int
AS
BEGIN
	DELETE FROM Orders
	WHERE (OrderID=@id);
END;
GO

CREATE PROCEDURE [dbo].[sp_DeletePerson]
	@id int
AS
BEGIN
	DELETE FROM Persons
	WHERE (PersonID=@id);
END;
GO