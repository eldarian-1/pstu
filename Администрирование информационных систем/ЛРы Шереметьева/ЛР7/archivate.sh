 #!/bin/bash

current_dir=$(pwd)
cd ~

name="$1_$(date +%H_%M_%S)"
files=$(ls ~ | grep -Eoi "([a-zа-я0-9_]|-)*.txt")

mkdir "$name"

for i in $files;
do
    cp "$i" "$name/"
done

tar -cvf "$name.tar" "$name"
rm -R "$name"
cd "$current_dir"