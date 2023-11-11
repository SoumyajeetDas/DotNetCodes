create proc getProcEmp
as
Begin
select Name , Gender from Emp
End

exec getProcEmp

create proc getProcEmpParam
@Gender varchar(20)
as
Begin
select name,gender from Emp where Gender = @Gender
End

exec getProcEmpParam 'Male'


create proc outProcEmp
@Gender varchar(10),
@name varchar(10) out
as
Begin
 set @name = 'Soumya'
End

declare @name as varchar(10)
exec outProcEmp 'Male' ,@name output
print @name
drop proc outProcEmp

select * from Emp


create proc Procwithout
@Gender varchar(10),
@count int output
as 
Begin
select @count = COUNT(Id) from Emp where Gender = @Gender
End
--drop proc Procwithout
declare @ncount int 
exec Procwithout 'Male' ,@ncount out
select @ncount