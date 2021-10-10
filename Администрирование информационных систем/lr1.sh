#!/bin/bash

echo $1 > t0.txt

byte="([1-9]?[0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])"
ip="(${byte}\.){3}${byte}"
m32="([1-2]?[1-9]|[1-3][0-2])"
mip="${byte}(\.${byte}){1,3}"
ms32="\/$m32"
msip="\/$mip"

rg1="^${ip}$"
rg2="^${ip}${ms32}$"
rg3="^${ip}${msip}$"

grep -E $rg1 t0.txt > t1.txt
grep -E $rg2 t0.txt > t2.txt
grep -E $rg3 t0.txt > t3.txt

if grep -Eq $rg1 t0.txt; then

    grep -Eo ^$byte t0.txt > t1.txt
    b=$(cat t1.txt)
    m=32
    if [ $b -ge 0 ] && [ $b -le 127 ]; then
        m=8
    elif [ $b -ge 128 ] && [ $b -le 181 ]; then
        m=16
    elif [ $b -ge 182 ] && [ $b -le 255 ]; then
        m=24
    fi
    echo "$(cat t0.txt)/$m"


elif grep -Eq $rg2 t0.txt; then

    m=$(cat t2.txt | grep -Eo $ms32 | grep -Eo $m32)
    echo "$(cat t0.txt)"

elif grep -Eq $rg3 t0.txt; then

    echo "Найдено rg3: $(cat t3.txt)"
    GREPPED=$(cat t3.txt | grep -Eo $msip | grep -Eo $mip | grep -Eo $byte)
    for a in $GREPPED; do
        echo $a
    done

else
    echo "файл пуст"
fi

rm t0.txt t1.txt t2.txt t3.txt