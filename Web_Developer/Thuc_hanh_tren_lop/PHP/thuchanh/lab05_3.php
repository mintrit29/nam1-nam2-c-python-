<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8" />
<title>Powers of</title>
</head>

<body>
<?php
echo "<p>Here's an example of sorting an array<p>";

$list = array("a" => 8, "h" => 43, "r" => 6, "i" => 2, "l" => 1, "r" => 9);
$slist = $list;
$klist = $list;

var_dump($list);

echo "<p>Sorted by Value:<p>";
sort($slist);
var_dump($slist);

echo "<p>Sorted by key:<p>"; ksort ($klist); var_dump($klist);
?>
</body>
</html>