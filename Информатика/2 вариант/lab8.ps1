$files = Get-ChildItem "D:\Lester\�������\Master\�����������\2 �������" -r
$files = $files | sort -descending -property length
$files = $files | select -first 2 name, Length
$files