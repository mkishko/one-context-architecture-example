#!/bin/bash

CONTAINER_NAME=pg-courier

if [ "$(docker ps -a -q -f name=$CONTAINER_NAME)" ]; then
    docker rm -f $CONTAINER_NAME
fi

docker run -d \
  --name $CONTAINER_NAME \
  -e POSTGRES_USER=courier \
  -e POSTGRES_PASSWORD=courier \
  -e POSTGRES_DB=courier \
  -p 5432:5432 \
  postgres:latest

  sleep 5

  dotnet ef database update --startup-project OneContextExample.Api --project OneContextExample.Infrastructure
