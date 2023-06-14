use Rinku
go
alter procedure sp_Payments_CRUD
	@opc int = 0,  @Id int, @TotalHours int, @TotalPaymentDelivers decimal(10,2), @TotalPaymentBounus decimal(10,2),
	@QuantityWithHoldings decimal(10,2), @TotalWithholdings decimal(10,2), @TotalPaymentGroceryVouchers decimal(10,2), @TotalSalary decimal(10,2), 
	@TotalPayment decimal(10,2), @Deactivated bit=0, @DeliveryId int, @EmployeeId int
as
begin
	/**********************************************************
	*Created By: Theo Loeffelmann Ibarra
	*Date: 2023-06-11
	*Description: Procedure to actions CRUD Payments
	**************************************************************/
	--agregar
	if @opc = 1
	begin 
		insert into Payments values 
				(@TotalHours, @TotalPaymentDelivers, @TotalPaymentBounus, @QuantityWithHoldings, @TotalWithholdings, 
				 @TotalPaymentGroceryVouchers, @TotalSalary, @TotalPayment,  @Deactivated, @DeliveryId, @EmployeeId)

		select @id = @@IDENTITY
		select * from Payments 
		where PaymentId = @Id
	end
	--actualizar
	if @opc = 2
	begin
		update Payments
			set TotalHours = @TotalHours, TotalPaymetDelivers = @TotalPaymentDelivers, TotalPaymentBounus = @TotalPaymentBounus, 
			QuantityWithHoldings = @QuantityWithHoldings, TotaltWithholdings = @TotalWithholdings, TotalPaymentsGroceryVouchers = @TotalPaymentGroceryVouchers,
			TotalSalary = @TotalSalary, TotalPayment = @TotalPayment, Deactivated= @Deactivated, DeliveryId = @DeliveryId, EmployeeId = @EmployeeId
		where PaymentId = @Id

		select * from Payments where PaymentId = @Id

	end
	--eliminar
	if @opc = 3
	begin
		update Payments
			set  Deactivated= 1
		where PaymentId = @Id

		select * from Payments where PaymentId = @Id
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
go