#!/bin/bash

cnt_name='oracle'
cnt_exst=$(docker ps | grep $cnt_name)

if ! [[ $cnt_exst ]]; then
    echo "Container ($cnt_name) doesn't exist."
    exit 1
fi

get_health() { docker inspect -f '{{ .State.Health.Status }}' $cnt_name; }
h_status=$(get_health)

if [[ "$h_status" == "starting" ]]; then
    echo -n "Waiting to Attach"
    until [[ "$(get_health)" != "starting" ]]; do
        echo -n "."
        sleep 5
    done
    echo -e "\nAttached!"
    h_status=$(get_health)
fi

echo "Container is $h_status."

if [[ "$h_status" == "unhealthy" ]]; then
    curr_dir="$(dirname "$0")"
    bash "$curr_dir/prune-db.sh"
    exit 1
elif [[ "$h_status" == "healthy" ]]; then
    src_orcl='/home/oracle/.bashrc'
    sql_user='sys/Oradoc_db1 as sysdba'
    sql_scrp='/Schema/Scripts/MASTER'
    winpty docker exec -it $cnt_name bash -c "source $src_orcl; sqlplus $sql_user @$sql_scrp"
    exit 0
fi
