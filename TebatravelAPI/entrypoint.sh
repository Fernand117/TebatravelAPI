#!/bin/bash
echo "Esperando a que PostgreSQL esté disponible..."
until dotnet ef database update; do
    >&2 echo "PostgreSQL no está listo - esperando..."
    sleep 5
done

>&2 echo "PostgreSQL está listo - iniciando aplicación"
exec dotnet TebatravelAPI.dll