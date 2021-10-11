#!/bin/bash 

while (true); do
    bash common.sh "$1"
    if [ $? -eq 1 ] ; then
        exit 1
    fi
    sleep 300
done