<?php
$servername = "localhost";
$username = "root";
$password = "NEWPASSWORD";
$dbname = "lost_relics";
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";
//Add user part
$sql = "INSERT INTO `users` (`username`, `password`) VALUES ('test2','test2')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }
$conn->close();

?>