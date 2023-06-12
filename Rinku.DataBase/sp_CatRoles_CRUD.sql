use Rinku
go
create procedure sp_CatRoles_CRUD
	@opc int = 0,  @Id int, @Role as varchar(15)='', @Deactivated bit=0
as
begin
	/**********************************************************
	*Created By: Theo Loeffelmann Ibarra
	*Date: 2023-06-11
	*Descroption: Procedure to actions CRUD to CatRoles
	**************************************************************/
	if @opc = 1
	begin 
		insert into CatRoles values (@Role, @Deactivated)
		select @id=@@IDENTITY 
		select * from CatRoles 
		where RoleId = @Id
	end
	if @opc = 2
	begin
		update CatRoles
			set [Role]= @Role, Deactivated= @Deactivated
		where RoleId = @Id

		select * from CatRoles where RoleId = @Id

	end
	if @opc = 3
	begin
		delete CatRoles
		where RoleId = @Id
	end
	if @opc = 4
	begin
		if @Role <> ''
		begin
			select * from CatRoles where  [role] like '%'+ @role +'%'
		end 
		else if  @Id <> 0
		begin
			select * from CatRoles where RoleId = @Id
		end
		else
		begin
			select * from CatRoles
		end 
	end 
end
