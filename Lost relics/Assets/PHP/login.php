<?php
$servername = "localhost";
$username = "root";
$password = "NEWPASSWORD";
$dbname = "lost_relics";

//Login user
$loginUsername = $_POST["loginUsername"];
$loginPassword = $_POST["loginPassword"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";
//Add user part
$sql = "SELECT password, username FROM users WHERE username = '". $loginUsername . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) 
{
    // output data of each row
    while($row = $result->fetch_assoc()) 
    {
      if ($row["password"] == $loginPassword)
      {
        echo "Login success ". $row["username"] . "<br>";
      }
      else 
        echo "wrong password";
    }
} 
else {
    echo "no username";
}

$conn->close();

?>