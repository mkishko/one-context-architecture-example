#!/bin/bash

CONTAINER_NAME=mysql-courier

if [ "$(docker ps -a -q -f name=$CONTAINER_NAME)" ]; then
    docker rm -f $CONTAINER_NAME
fi

docker run -d \
  --name $CONTAINER_NAME \
  -e MYSQL_ROOT_PASSWORD=courier \
  -e MYSQL_DATABASE=courier \
  -e MYSQL_USER=courier \
  -e MYSQL_PASSWORD=courier \
  -p 3306:3306 \
  mysql:8.0

  sleep 5

  dotnet ef database update --startup-project OneContextExample.Api --project OneContextExample.Infrastructure
