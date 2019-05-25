<html>
<body bgcolor="FAEBD7">
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">
<br>
<center><h2> Mark Attendance  </h2>
<form>
<?php
	include("DBConnection.php");
	$query = "select * from employee_registration";
	$result = mysqli_query($db, $query);

	echo "<table border='2' align='center' cellpadding='5' cellspacing = '5'>
	<tr>
		<th>Employee ID</th>
		<th>Employee Name</th>
		<th>Mark</th>
	</tr>";
	$count=0;
	foreach($result as $row)
	{
		$count=$count+1;
		echo '<tr>
				<td>'.$row['employeeId'].'</td>
				<td>'.$row['employeeName'].'</td>
				<td>
					<input type="checkbox" />
				</td>
				
			</tr>';
	}
	
?>
<th>
	<td colspan="3"></td>
	<td><button type="button">Select All</button>
	</td>
	</th>

</center>
</form>
</body>
</html>
