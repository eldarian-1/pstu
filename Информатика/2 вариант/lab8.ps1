$files = Get-ChildItem "D:\Lester\Политех\Master\Информатика\2 вариант" -r
$files = $files | sort -descending -property length
$files = $files | select -first 2 name, Length
$files