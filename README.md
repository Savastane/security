[![Integraçao Continua e Deploy](https://github.com/Savastane/security/actions/workflows/ci-cd.yaml/badge.svg)](https://github.com/Savastane/security/actions/workflows/ci-cd.yaml)



# security



Rodar Database

docker run -d   --name ravendb_security  -v /your/home:/var/lib/ravendb -v f:/raven/data:/opt/RavenDB/Server/RavenData  -e UNSECURED_ACCESS_ALLOWED=PublicNetwork  -e RAVEN_Setup_Mode=None -e PUBLIC_SERVER_URL=http://localhost:8080 -e RAVEN_License_Eula_Accepted=true -p 40000:8080 -p 38888:38888  ravendb/ravendb:latest

