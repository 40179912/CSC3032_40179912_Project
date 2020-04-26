
/*Select distinct EntitlementID from Employee 
inner join [Employee Benefits] on Employee.EmployeeID = [Employee Benefits].EmployeeID
where Employee.EmployeeID = 1

Select distinct[Job Benefits].EntitlementID from Employee 
inner join Jobs on Employee.JobID = Jobs.JobID 
inner join [Job Benefits] on [Job Benefits].JobID = Jobs.JobID
where Employee.EmployeeID = 1*/


/*declare @x int;
declare @y int
set @x = 1;
while @x < (select count(distinct [Employee Benefits].EntitlementID) from [Employee Benefits])+1
begin
	set @y = (select count(*) from(select * from [Employee Benefits] where EmployeeID = @x except  select * from [Job Benefits])temp)
	if @y > 0
		update Employee
		set Anomoly = 1
		where EmployeeID = @x
	else
		update Employee
		set Anomoly = 0
		where EmployeeID = @x
	set @x = @x + 1
end

select * from Employee*/

SELECT * FROM Jobs INNER JOIN [Jobs] on Employee.JobID = [Jobs].JobID where Employee.JobID = Jobs.JobID

