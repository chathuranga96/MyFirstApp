<html>
<body>
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">
<br>
<h2> Delete Employee</h2>

<body bgcolor="FAEBD7">
<table border=2>
	<tr>
		<th>Employee ID</th>
		<th>Employee Name</th>
		<th>Employee Address</th>
		<th>Employee Contact</th>
		<th>Employee Email</th>
		<th>Employee RegDate</th>
	</tr>
	<?php
			include("DBConnection.php");
			
			$sql = "select * from employee_registration";
			$records = mysqli_query($db, $sql) or die(mysqli_error());
			
			while($row = mysqli_fetch_array($records))
			{
				echo "<tr>";
				echo "<td>".$row['employeeId']."</td>";
				echo "<td>".$row['employeeName']."</td>";
				echo "<td>".$row['employeeAddress']."</td>";
				echo "<td>".$row['employeeContact']."</td>";
				echo "<td>".$row['employeeEmail']."</td>";
				echo "<td>".$row['employee_reg_date']."</td>";
				echo "<td><a href = deleteEmployeephp.php?employeeId=".$row['employeeId'].">Delete</a></td>";
			}
	?>
</table>
	<br>
</body>
</html>