use Rinku
go
create procedure sp_Deliveries_CRUD
	@opc int = 0,  @Id int, @Delivery int=0, @StartPeriod datetime, @EndPeriod datetime, @Deactivated bit=0, @EmployeeId int
as
begin
	/**********************************************************
	*Created By: Theo Loeffelmann Ibarra
	*Date: 2023-06-11
	*Descroption: Procedure to actions CRUD Deliveries
	**************************************************************/
	if @opc = 1
	begin 
		insert into Deliveries values (@Delivery, @StartPeriod, @EndPeriod, @DEactivated, @EmployeeId )
		select @id = @@IDENTITY
		select * from Deliveries 
		where DeliveryId = @Id
	end
	if @opc = 2
	begin
		update Deliveries
			set Delivery= @Delivery, SatartPeriod = @StartPeriod,  EndPeriod= @EndPeriod, Deactivated = @Deactivated, EmployeeId = @EmployeeId
		where DeliveryId = @Id

		select * from Deliveries where DeliveryId = @Id

	end
	if @opc = 3
	begin
		update Deliveries
			set  Deactivated = 1
		where DeliveryId = @Id
		select * from Deliveries where DeliveryId = @Id
	end
	if @opc = 4
	begin
		if  @Id <> 0
		begin
			select * from Deliveries where DeliveryId = @Id
		end
		else
		begin
			select * from Deliveries
		end 
	end 
end
