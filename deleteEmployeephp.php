<html>
<body bgcolor="FAEBD7">
<INPUT TYPE="button" VALUE="Back to previous page" onClick="history.go(-1);">
<?php
	include("DBConnection.php");
	$sql = "delete from employee_registration where employeeId = '$_GET[employeeId]'";
	
	if(mysqli_query($db, $sql))
		header ("refresh:1; url = deleteEmployee.php");
	else
		echo "Not Deleted";
?>
</body>
</html>