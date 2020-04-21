#!/bin/bash

cnt_name='oracle'

echo "Stopping container..."
docker stop $cnt_name

echo "Removing container..."
docker container rm $cnt_name

echo "Removing volume data..."
curr_dir="$(dirname "$0")"
rm -r "$curr_dir/../ORCL/"
