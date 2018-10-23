<?php
$mysqli = new mysqli("localhost", "mandisst_ranch", "C@tt1e", "mandisst_cattle");
if ($mysqli->connect_errno) {
    echo "Failed to connect to MySQL: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
}
//echo $mysqli->host_info . "\n";

$mysqli = new mysqli("127.0.0.1", "mandisst_ranch", "C@tt1e", "mandisst_cattle", 3306);
if ($mysqli->connect_errno) {
    echo "Failed to connect to MySQL: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
}

//echo $mysqli->host_info . "\n";

//Setup our query
$query = "SELECT * FROM Cattle";

//Run the Query
$result = $mysqli->query($query);

echo "<table border='1'>";

$result->data_seek(0);
while ($row = $result->fetch_assoc()) {
    echo "<tr><td>" . $row['TagNumber'] . "</td><td>" . $row['Name'] . "</td></tr>";
}

echo "</table>";
?>