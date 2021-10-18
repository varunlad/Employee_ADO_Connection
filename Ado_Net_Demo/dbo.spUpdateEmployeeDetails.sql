CREATE PROCEDURE dbo.spUpdateEmployeeDetails
	@Name varchar(50),
	@Salary bigint,
	@Department varchar(50)
AS
BEGIN
	update employee_payRoll set Salary=@Salary where Name=@Name and Department=@Department;
END;
