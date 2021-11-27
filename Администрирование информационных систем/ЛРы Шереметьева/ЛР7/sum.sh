#!/bin/bash 

let res=$1+$2

echo "$1 + $2 = $res"

if [ $res -ge 0 ] ; then
    echo "Результат положителен"
else
    echo "Результат отрицателен"
fi