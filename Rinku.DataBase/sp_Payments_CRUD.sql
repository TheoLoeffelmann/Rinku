use Rinku
go
create procedure sp_Payments_CRUD
	@opc int = 0,  @Id int, @TotalHours int, @TotalPaymentDelivers decimal(5,2), @TotalPaymentBounus decimal(5,2),
	@TotalWithholdings decimal(5,2), @TotalPaymentGroceryVouchers decimal(5,2), @TotalSalary decimal(6,2), @Deactivated bit=0, 
	@DeliveryId int, @EmployeeId int
as
begin
	/**********************************************************
	*Created By: Theo Loeffelmann Ibarra
	*Date: 2023-06-11
	*Descroption: Procedure to actions CRUD Payments
	**************************************************************/
	--agregar
	if @opc = 1
	begin 
		insert into Payments values 
				(@TotalHours, @TotalPaymentDelivers, @TotalPaymentBounus, @TotalWithholdings, 
				 @TotalPaymentGroceryVouchers, @TotalSalary,  @Deactivated, @DeliveryId, @EmployeeId)

		select @id = @@IDENTITY
		select * from Payments 
		where PaymentId = @Id
	end
	--actualizar
	if @opc = 2
	begin
		update Payments
			set TotalHours = @TotalHours, TotalPaymetDelivers = @TotalPaymentDelivers, TotalPaymentBounus = @TotalPaymentBounus,
			TotaltWithholdings = @TotalWithholdings, TotalPaymentsGroceryVouchers = @TotalPaymentGroceryVouchers,
			TotalSalary = @TotalSalary, Deactivated= @Deactivated, DeliveryId = @DeliveryId, EmployeeId = @EmployeeId
		where PaymentId = @Id

		select * from Payments where PaymentId = @Id

	end
	--eliminar
	if @opc = 3
	begin
		delete Payments
		where PaymentId = @Id
	end
	--buscar
	if @opc = 4
	begin
	
		--por id
		if  @Id <> 0
		begin
			select * from Payments where PaymentId = @Id
		end
		--todos los empleados
		else
		begin
			select * from Payments
		end 
	end 

end




