$c = 0
$text = get-content "f.txt"
foreach($line in $text) {
    $a = $line -as[int]
    if($a -lt 0) {
        $c=$c+1
    }
}
$c
pause