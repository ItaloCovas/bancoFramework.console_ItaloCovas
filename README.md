Meu primeiro projeto PDI(bancoframework.console) - c#

# Script BD

Primeiro instalar a imagem do Docker que usei para o banco de dados SQL Server:

```
	sudo docker pull mcr.microsoft.com/mssql/server:2022-latest

```

Depois, criar o container:

```
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=BancoFramework123#" \
   -p 1433:1433 --name sqlBancoFrame --hostname sqlBancoFrame \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest 
 ```


 Depois, entrar no container:

 ```
   sudo docker exec -it sqlBancoFrame "bash"
 ```

 Depois, se conectar ao banco:

 ```
	/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "BancoFramework123#"

 ```


 Agora, criaremos o banco de dados (temos que executar o GO depois dos comandos para serem de fato executados para o banco):

 ```
	CREATE DATABASE BancoFramework;
	GO

	USE BancoFramework;
	GO

	CREATE TABLE dbo.Cliente (Id INT NOT NULL, Nome VARCHAR(30) NOT NULL, CPF VARCHAR(11) NOT NULL, Saldo FLOAT NOT NULL, CONSTRAINT PK_Pessoa PRIMARY KEY CLUSTERED (Id ASC));
	GO
 ```
 




