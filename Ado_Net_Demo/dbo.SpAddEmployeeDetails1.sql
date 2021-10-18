CREATE PROCEDURE dbo.SpAddEmployeeDetails1
	@Name varchar(50),
	@Salary bigint,
	@Basepay bigint,
	@StartDate varchar(50),
	@Gender char(1),
	@Phone bigint,
	@Address varchar(50),
	@Department varchar(50),
	@TaxablePay bigint
AS
BEGIN
 insert into employee_payRoll(Name,Salary,Start_Date,Gender,Phone,Department,Address,BasicPay,TaxablePay) values(@Name,@Salary,@StartDate,@Gender,@Phone,@Department,@Address,@Salary,@TaxablePay);
 END;