use carstore

CREATE  TABLE Persons (
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

/*Create stored procedures*/

/*Create*/
GO
CREATE OR ALTER PROCEDURE [dbo].[sp_GetOrdersCount]
AS
BEGIN 
	select count(*) from Orders
END
GO
CREATE OR ALTER PROCEDURE [dbo].[sp_GetPersonsCount]
AS
BEGIN 
	select count(*) from Persons
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_InsertOrder]
    @OrderDate Datetime,
    @CarID int,
	@PersonID int
AS
BEGIN TRY
    INSERT INTO Orders(OrderDate,CarID,PersonID)
    VALUES (@OrderDate,@CarID,@PersonID)
END TRY
BEGIN CATCH
RAISERROR ( 50001,15,1)
END CATCH

GO

CREATE OR ALTER PROCEDURE [dbo].[sp_InsertPerson]
	@FirstName varchar(50),
	@LastName  varchar(50),
	@Phone varchar(50)
AS
	INSERT INTO Persons(FirstName,LastName,Phone)
	VALUES(@FirstName,@LastName,@Phone)
GO
/*Read*/
CREATE OR ALTER PROCEDURE [dbo].[sp_GetOrder]
	@id int
AS
	Select * From Orders
	WHERE (OrderID=@id);
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetPerson]
	@id int
AS
	Select * From Persons
	WHERE (PersonID=@id);
GO
/*Update*/
CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateOrder]
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

CREATE OR ALTER PROCEDURE [dbo].[sp_UpdatePerson]
	@id int,
	@FirstName varchar(50),
	@LastName  varchar(50),
	@Phone varchar(50)
AS
BEGIN
	UPDATE Persons
SET FirstName=@FirstName,
	LastName=@LastName,
	Phone=@Phone
	WHERE (PersonID=@id);
END;
GO
/*Delete*/
CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteOrder]
	@id int
AS
BEGIN
	DELETE FROM Orders
	WHERE (OrderID=@id);
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_DeletePerson]
	@id int
AS
BEGIN
	DELETE FROM Persons
	WHERE (PersonID=@id);
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[sp_GetOrders]
	@page int,
	@pageSize INT,
	@sortColumn varchar(50)
AS
BEGIN
	DECLARE @offset int
	IF (@page=0)
		BEGIN
		  SET @offset = @page
		END
	 ELSE 
      BEGIN
        SET @offset = (@page-1)*@PageSize
      END
	  IF (@sortColumn='@CarID')
		BEGIN
			Select * From Orders
			ORDER BY CarID
			OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;	
		END
		else IF (@sortColumn='@OrderDate')
		BEGIN
			Select * From Orders
			ORDER BY OrderDate
			OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;	
		END
		else 
		BEGIN
			Select * From Orders
			ORDER BY PersonID
			OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;	
		END
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetPersons]
	@page int,
	@pageSize INT,
	@sortColumn varchar(50)
AS
BEGIN
	DECLARE @offset int

	IF (@page=0)
		BEGIN
		  SET @offset = @page
		END
	 ELSE 
      BEGIN
        SET @offset = (@page-1)*@PageSize
      END
	  if(@sortColumn='@FirstName')
		begin
		Select * From Persons
			ORDER BY FirstName
			OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;	
		end
		Else if(@sortColumn='@LastName')
		begin
		Select * From Persons
			ORDER BY FirstName
			OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;	
		end
			Else 
		begin
		Select * From Persons
			ORDER BY PersonID
			OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;	
		end
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetInitialsList]
	@id int
AS
BEGIN
	select CONCAT(Persons.FirstName,' ', Persons.LastName) from Persons;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllPersons]
AS
BEGIN
	SELECT * FROM Persons;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_FindPersons]
@pattern varchar(max)
AS
BEGIN
	SELECT * FROM Persons
	where CONCAT(Persons.FirstName,Persons.LastName) LIKE '%'+@pattern+'%';
END
/*Exceptions*/
EXEC sp_addmessage
    @msgnum = 50001, 
    @severity = 15, 
    @msgtext = 'You cannot add order for non exestiong user';