#!/bin/bash

echo $1 > t0.txt

byte="([1-9]?[0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])"
ip="(${byte}\.){3}${byte}"
m32="([1-2]?[1-9]|[1-3][0-2])"
mip="${byte}(\.${byte}){1,3}"

rg1="^${ip}\/${mip}$"
rg2="^${ip}\/${m32}$"
rg3="^${ip}$"

grep -E $rg1 t0.txt > t1.txt
grep -E $rg2 t0.txt > t2.txt
grep -E $rg3 t0.txt > t3.txt

if grep -E $rg1 t0.txt; then

    echo "Найдено rg1: $(cat t1.txt)"
    echo "Порт: $(cat t1.txt | grep -Ew $mip)"

elif grep -E $rg2 t0.txt; then

    echo "Найдено rg2: $(cat t2.txt)"
    echo "Порт: $(cat t1.txt | grep -Eo $m32)"

elif grep -E $rg3 t0.txt; then

    echo "Найдено rg3: $(cat t3.txt)"

else
    echo "файл пуст"
fi

rm t0.txt t1.txt t2.txt t3.txt