/*declare @a int;
declare @x int;
declare @y int
declare @z int
set @x = 1;
while @x < (select count(distinct [Employee].EmployeeID) from [Employee])+1
begin
	set @a = (select JobID from Employee where EmployeeID = @x)
	set @y = (select count(*) from((select EntitlementID from [Employee Benefits] where EmployeeID = @x) except 
(select EntitlementID from [Job Benefits] where JobID =  (select JobID from Employee where EmployeeID = @x)))temp)
	set @z = (select count(*) from (select EntitlementID from [Job Benefits] where JobID = (select JobID from Employee where EmployeeID = @x) except (select EntitlementID from [Employee Benefits] where EmployeeID = @x))temp)	
	if @y > 0 or @z > 0
		update Employee
		set Anomoly = 1
		where EmployeeID = @x
	else
		update Employee
		set Anomoly = 0
		where EmployeeID = @x
	set @x = @x + 1 
	end*/

	Select distinct(Sector) from Jobs
