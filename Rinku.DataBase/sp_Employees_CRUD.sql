use Rinku
go
create procedure sp_Employees_CRUD
	@opc int = 0,  @Id int, @Employee as varchar(100)='', @Deactivated bit=0, @RoleId int=0
as
begin
	/**********************************************************
	*Created By: Theo Loeffelmann Ibarra
	*Date: 2023-06-11
	*Descroption: Procedure to actions CRUD Employees
	**************************************************************/
	--agregar
	if @opc = 1
	begin 
		insert into Employees values (@Employee, @Deactivated, @RoleId)

		select @id= @@IDENTITY
		select * from Employees 
		where EmployeeId= @Id
	end
	--actualizar
	if @opc = 2
	begin
		update Employees
			set Employee = @Employee, Deactivated= @Deactivated, RoleId = @RoleId
		where EmployeeId = @Id

		select * from Employees where EmployeeId = @Id

	end
	--eliminar
	if @opc = 3
	begin
		delete Employees
		where EmployeeId = @Id
	end
	--buscar
	if @opc = 4
	begin
	--por empleado
		if @Employee <> ''
		begin
			select * from Employees where  Employee like '%'+ @Employee +'%'
		end 
		--por id
		else if  @Id <> 0
		begin
			select * from Employees where EmployeeId = @Id
		end
		--todos los empleados
		else
		begin
			select * from Employees
		end 
	end 

end




