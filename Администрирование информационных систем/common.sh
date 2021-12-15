#!/bin/bash

cd "/home/eldarian/Рабочий стол/pstu/Администрирование информационных систем/"

if [ ! -d "$1" ]; then
    echo "$1 не существует либо не является каталогом"
    exit 1
fi

if echo "$1" | grep -Eq "^[\.\~]" ; then
    echo "$1 - относительный путь"
    exit 1
fi

dir_name=$(echo "$1" | grep -Eo "[0-9a-zA-ZА-Яа-я_]+\/?$" | grep -Eo "[0-9a-zA-ZА-Яа-я_]+")
current_date=$(date +%F-%H-%M) #YYYY-MM-dd HH:mm
out_file="$dir_name-$current_date.tar.gz"

archive_dir="/home/eldarian/Рабочий стол/archives/"
if [ ! -d "$archive_dir" ]; then
    mkdir "$archive_dir"
fi
cd "$archive_dir"

current_dir=$(pwd)
base_dir=$(echo "$1" | grep -Po "[0-9a-zA-ZА-Яа-я_\/ ]+(?=$dir_name\/?$)")

cd "$base_dir"
tar -czf "$out_file" "$dir_name"
mv "$out_file" "$archive_dir"
cd "$current_dir"

echo "$out_file успешно создан" 