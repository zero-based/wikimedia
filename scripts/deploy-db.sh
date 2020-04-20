#!/bin/bash

cnt_name='oracle'

echo -n "Waiting"
until [[ "$h_status" == "healthy" || "$h_status" == "unhealthy" ]]; do
    h_status=$(docker inspect -f '{{ .State.Health.Status }}' $cnt_name)
    echo -n "."
    sleep 5
done

echo "Container is $h_status."
if [[ "$h_status" == "unhealthy" ]]; then
    bash ./prune-db.sh
    exit 1
elif [[ "$h_status" == "healthy" ]]; then
    src_orcl='/home/oracle/.bashrc'
    sql_user='sys/Oradoc_db1 as sysdba'
    sql_scrp='/Schema/Scripts/MASTER'
    winpty docker exec -it $cnt_name bash -c "source $src_orcl; sqlplus $sql_user @$sql_scrp"
    exit 0
fi
