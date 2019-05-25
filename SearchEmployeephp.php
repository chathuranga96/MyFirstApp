<html>
<body bgcolor="FAEBD7">
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">
<br>
<table border="2" align="center" cellpadding="5" cellspacing="5">
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
	$set=$_REQUEST['Search'];
	if($set)
	{
		$show="select * from employee_registration where employeeId ='$set'";
		$result = mysqli_query($db,$show);
		while($rows=mysqli_fetch_array($result))
		{
			echo "<tr>";
			echo "<td>";
			echo $rows ["employeeId"];
			echo "</td>";
			echo "<td>";
			echo $rows["employeeName"];
			echo "</td>";
			echo "<td>";
			echo $rows["employeeAddress"];
			echo "</td>";
			echo "<td>";
			echo $rows["employeeContact"];
			echo "</td>";
			echo "<td>";
			echo $rows["employeeEmail"];
			echo "</td>";
			echo "<td>";
			echo $rows["employee_reg_date"];
			echo "</td>";
			echo "</tr>";
		}
	}else{
		echo "Invalid please enter the Employee no!";
	}

?>
</table>
</body>
</html>