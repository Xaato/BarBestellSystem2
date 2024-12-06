#!/bin/sh
docker build -f Dockerfile -t barbestellsystem:latest .
docker run -p 7292:8080 barbestellsystem:latest