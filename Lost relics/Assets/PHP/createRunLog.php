<?php
$servername = "sql6.freesqldatabase.com";
$username = "sql6700298";
$password = "nPnP4RUE52";
$dbname = "sql6700298";

//Content
$jsonContent = $_POST["json"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";
//Add user part
$sql = "INSERT INTO `run_log` (`playerCharacter`) VALUES ('". $jsonContent ."')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }
$conn->close();

?>