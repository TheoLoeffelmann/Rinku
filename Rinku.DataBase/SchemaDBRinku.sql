create database Rinku
go
use Rinku
go
create table CatRoles (RoleId int constraint pk_roles primary key identity, [Role] varchar(15), Deactivated bit default 0)

create table Employees (EmployeeId int constraint pk_Employees primary key identity (1000, 1), Employee varchar(100), Deactivated bit default 0, 
RoleId int constraint fk_Employees_CatRoles foreign key references CatRoles(RoleId))

create table Deliveries (DeliveryId int constraint pk_Deliveries primary key identity, Delivery int, 
	SatartPeriod datetime default dateadd(day, 1, eomonth(getdate(), -1)), EndPeriod datetime default EOMONTH(getdate()), Deactivated bit default 0,
		EmployeeId int constraint fk_Deliveries_Employees foreign key references Employees(EmployeeId))

create table CatSalaries(SalaryId int constraint pk_CatSalaries primary key identity, Salary decimal(5,2), Bonus decimal(3, 2), Deactivated bit default 0, 
	RoleId int constraint fk_Salaries_CatRoles foreign key references CatRoles(RoleId))

create table Payments(PaymentId int constraint pk_Payments primary key identity, TotalHours int , TotalPaymetDelivers Decimal(10,2), TotalPaymentBounus decimal(10,2),
	QuantityWithHoldings decimal(10,2), TotaltWithholdings decimal(10, 2), TotalPaymentsGroceryVouchers decimal(10,2), TotalSalary decimal(10,2), TotalPayment decimal(10,2), Deactivated bit default 0,
	DeliveryId int constraint fk_Payments_Deliveries foreign key references Deliveries(DeliveryId),
	EmployeeId int constraint fk_Payments_Employees foreign key references Employees(EmployeeId))
