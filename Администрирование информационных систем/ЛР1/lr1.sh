#!/bin/bash

byte="([1-9]?[0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])"
ip="(${byte}\.){3}${byte}"
m32="([1-2]?[1-9]|[1-3][0-2])"
mip="${byte}(\.${byte}){0,3}"
ms32="\/$m32"
msip="\/$mip"

if echo "$1" | grep -Eq "^${ip}$"; then

	b=$(echo "$1" | grep -Eo ^$byte)
	m=32
	if [ $b -ge 0 ] && [ $b -le 127 ]; then
		m=8
	elif [ $b -ge 128 ] && [ $b -le 181 ]; then
		m=16
	elif [ $b -ge 182 ] && [ $b -le 255 ]; then
		m=24
	fi
	echo "$1/$m"

elif echo "$1" | grep -Eq "^${ip}${ms32}$"; then

	m=$(echo "$1" | grep -Eq "${ms32}$" | grep -Eo "$m32$")
	echo "$1"

elif echo "$1" | grep -Eq "^${ip}${msip}$"; then

	arr=$(echo "$1" | grep -Eo $msip | grep -Eo $mip | grep -Eo $byte)
	caps=(128 64 32 16 8 4 2 1)
	m=0
	for a in $arr; do
		for i in ${caps[@]}; do
			if [ $a -eq 0 ]; then
				break
			elif [ $i -eq 1 ]; then
				m=$((m + 1))
				break
			else
				a=$((a % i))
				m=$((m + 1))
			fi
		done
	done
	echo "$(echo "$1" | grep -Eo ^$ip)/$m"

else
	echo "Некорректный ввод!"
fi