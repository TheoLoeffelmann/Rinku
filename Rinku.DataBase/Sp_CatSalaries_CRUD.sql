use Rinku
go
create procedure sp_CatSalaries_CRUD
	@opc int = 0,  @Id int, @Salary decimal(5,2)=0.00 , @Bonus decimal(3,2)=0.00, @Deactivated bit=0, @RoleId int=0
as
begin
	/**********************************************************
	*Created By: Theo Loeffelmann Ibarra
	*Date: 2023-06-11
	*Descroption: Procedure to actions CRUD CatSalaries
	**************************************************************/
	if @opc = 1
	begin 
		insert into CatSalaries values (@Salary, @Bonus, @Deactivated, @RoleId)
		select @id = @@IDENTITY
		select * from CatSalaries 
		where SalaryId = @Id
	end
	if @opc = 2
	begin
		update CatSalaries
			set Salary= @Salary, Bonus = @Bonus, Deactivated = @Deactivated, RoleId = @RoleId
		where SalaryId = @Id

		select * from CatSalaries where SalaryId = @Id

	end
	if @opc = 3
	begin
		delete CatSalaries
		where SalaryId = @Id
	end
	if @opc = 4
	begin
		if  @Id <> 0
		begin
			select * from CatSalaries where SalaryId = @Id
		end
		else
		begin
			select * from CatSalaries
		end 
	end 
end