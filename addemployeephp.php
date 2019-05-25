<html>
<body bgcolor="FAEBD7">
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">
<?php
	include("DBConnection.php");
 
	$employeeId=$_POST["employeeId"];
	$employeeName=$_POST["employeeName"];
	$employeeAddress=$_POST["employeeAddress"];
	$employeeContact=$_POST["employeeContact"];
	$employeeEmail=$_POST["employeeEmail"];
	$employee_reg_date=$_POST["employee_reg_date"];
 
	$query = "INSERT INTO employee_registration (employeeId, employeeName, employeeAddress, employeeContact, employeeEmail, employee_reg_date)
		values ('$employeeId', '$employeeName', '$employeeAddress', '$employeeContact', '$employeeEmail', '$employee_reg_date')";
	$result = mysqli_query($db,$query);
?> 
Successful 
</body>
</html>