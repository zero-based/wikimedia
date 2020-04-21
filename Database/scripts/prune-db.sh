#!/bin/bash

cnt_name='oracle'

echo "Removing oracle container"
docker stop $cnt_name
docker container rm $cnt_name

echo "Removing volume data"
rm -r ORCL/
