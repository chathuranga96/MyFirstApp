<!DOCTYPE HTML>
<html>
<body bgcolor="FAEBD7">
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">

<center>
<h2>Employee Registration</h2>
<form action="addemployeephp.php" method="post">
<table>
	<tr>
	
		<td> Employee ID :</td>
		<td><input type="text" name="employeeId" size="52"/></td>
	</tr>
	<tr>
	
		<td> Employee Name :</td>
		<td><input type="text" name="employeeName" size="52"/></td>
	</tr>
	<tr>
	
		<td> Employee Address :</td>
		<td><input type="text" name="employeeAddress" size="52"/></td>
	</tr>
	<tr>
	
		<td> Employee Contact :</td>
		<td><input type="text" name="employeeContact" size="52"/></td>
	</tr>
	<tr>
	
		<td> Employee Email :</td>
		<td><input type="text" name="employeeEmail" size="52"/></td>
	</tr>
	<tr>
	
		<td> Employee_reg_date :</td>
		<td><input type="text" name="employee_reg_date" size="52"/></td>
	</tr>
	<tr><td>
		<input type="submit" value="Register" >
		<input type="reset" value="Refresh">
	</td></tr>
</table>
</form>
</body>
</center>
</html>