#!/bin/bash 

#while (true); do
    d=$(date +%F-%H-%M) #YYYY-MM-dd HH:mm
    tar -cjvf "$1-$d.tar.gz" $1
    sleep 1
#done