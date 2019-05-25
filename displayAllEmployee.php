<html>
<body bgcolor="FAEBD7">
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">
<br>
<form>
<?php
	include("DBConnection.php");
	$query = "select * from employee_registration";
	$result = mysqli_query($db, $query);
	
	echo "<table border='2' align='center' cellpadding='5' cellspacing = '5'>
	<tr>
		<th>employeeId</th> 
		<th>employeeName</th>
		<th>employeeAddress</th>
		<th>employeeContact</th>
		<th>employeeEmail</th>
		<th>employee_reg_date</th>
	</tr>";

	while($row = mysqli_fetch_array($result))
	{
		echo "<tr>";
		echo "<td>" . $row['employeeId'] . "</td>";
		echo "<td>" . $row['employeeName'] . "</td>";
		echo "<td>" . $row['employeeAddress'] . "</td>";
		echo "<td>" . $row['employeeContact'] . "</td>";
		echo "<td>" . $row['employeeEmail'] . "</td>";
		echo "<td>" . $row['employee_reg_date'] . "</td>";
		echo "</tr>";
	}
	echo "</table>";

	mysqli_close($db);
?>
</form>
</body>
</html>
