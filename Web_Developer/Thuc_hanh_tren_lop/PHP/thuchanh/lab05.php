<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8" />
<title>Powers of</title>
</head>

<body>
<?php
//có thể thay đổi cơ số ($x) và số mũ tối đa ($n)
$x = 2;
$n = 10;
echo "<p>Ví dụ lũy thừa cơ số $x sử dụng vòng lặp</p>";
$val = 1;

for($i = 0; $i <= $n; $i++){
	print("<p>$x<sup>$i</sup> = $val.</p>");
	$val = $val * $x;
}

echo "<p>Đảo lại:</p>";
$counter = $n;
while($counter >= 0){
	print("<p>$val / $x = ");
	$val = $val / $x;
	$counter--;
	print($val);
	print("</p>");
}
?>
</body>
</html>