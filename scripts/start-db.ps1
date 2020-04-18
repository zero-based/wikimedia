$container_name = "oracle"
$is_existing = docker ps -a | grep $container_name
$is_running = docker ps | grep $container_name

if ($is_running) {
    Write-Host("Already Running") -foregroundcolor green
    exit 0
}
elseif ($is_existing) {
    docker start $container_name
}
else {
    Write-Host("Building Contianer") -foregroundcolor green
    docker-compose run -d --service-ports --name $container_name db
}

$interval = 5
$timeout = 200
$user_name = "zerobased"
$password = "zerobased"
$sql_script_path = "/Schema/Scripts/MASTER.sql"

Write-Host "Waiting for Container" -NoNewLine -foregroundcolor green
for ($i = 0; $i -le $timeout * $interval; $i++) {
    Start-Sleep $interval
    Write-Host "."  -NoNewLine -foregroundcolor green 
    $health_status = docker inspect --format='{{.State.Health.Status}}' $container_name

    if ($health_status -eq "healthy") {
        Write-Output("`a")
        Write-Host "Container is Healthy"  -foregroundcolor green
        if ($is_existing) {
            docker exec -it $container_name bash -c "source /home/oracle/.bashrc; sqlplus $user_name/$password@ORCLCDB"
        }
        else {
            docker exec -it $container_name bash -c "source /home/oracle/.bashrc; sqlplus sys as sysdba @$sql_script_path"
        }
        exit 0
    }
    elseif ($health_status -eq "unhealthy") {
        Write-Output("`a")
        Write-Host "Container is Unhealthy" -foregroundcolor red
        exit 1
    }
}