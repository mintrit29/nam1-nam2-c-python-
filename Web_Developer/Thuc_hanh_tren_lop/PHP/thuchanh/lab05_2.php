<!DOCTYPE html>
<html>
<head>
    <title>Bảng Cửu Chương</title>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
            margin: 20px 0;
        }
        table, th, td {
            border: 1px solid black;
            text-align: center;
            padding: 10px;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>

<h2>Bảng Cửu Chương từ 2 đến 10</h2>

<?php
echo "<table>";

echo "<tr>";
for ($i = 2; $i <= 10; $i++) {
    echo "<th>Bảng $i</th>";
}
echo "</tr>";

echo "<tr>";
for ($i = 2; $i <= 10; $i++) {
    echo "<td>";
    for ($j = 1; $j <= 10; $j++) {
        echo "$i x $j = " . $i * $j . "<br>";
    }
    echo "</td>";
}
echo "</tr>";

echo "</table>";
?>

</body>
</html>