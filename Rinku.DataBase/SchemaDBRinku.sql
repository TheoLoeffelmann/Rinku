create database Rinku
go
use Rinku
go

create table CatRoles (RoleId int constraint pk_roles primary key identity, [Role] varchar(15))

create table Employees (EmployeeId int constraint pk_Employees primary key identity (1000, 1), Employee varchar(100), 
RoleId int constraint fk_Employees_CatRoles foreign key references CatRoles(RoleId))

create table Deliveries (DeliveryId int constraint pk_Deliveries primary key identity, Delivery int, SatartPeriod varchar(10), EndPeriod varchar(10),
		EmployeeId int constraint fk_Deliveries_Employees foreign key references Employees(EmployeeId))

create table Salaries(SalaryId int constraint pk_Salaries primary key identity, Salary decimal(5,2), Bonus decimal(3, 2), 
RoleId int constraint fk_Salaries_CatRoles foreign key references CatRoles(RoleId))

create table Payments(PaymentId int constraint pk_Payments primary key identity, TotalHours int, TotalPaymetDelivers Decimal(5,2), 
	TotalPaymentBounus decimal(5,2),TotaltWithHoldings decimal(5, 2), TotalPaymentsGroceryVouchers decimal(5,2), TotalSalary decimal(6,2),
	DeliveryId int constraint fk_Payments_Deliveries foreign key references Deliveries(DeliveryId),
	EmployeeId int constraint fk_Payments_Employees foreign key references Employees(EmployeeId))
