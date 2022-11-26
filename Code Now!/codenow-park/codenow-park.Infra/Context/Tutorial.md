# Tutorial DotNet Core Migrations

# Abrir o Terminal
	No Visual Studio -> Exibir/Terminal
## Instalar o EF-Tools
	Instalar uma única vez após a instalação do Visual Studio ou VSCode
	dotnet tool install --global dotnet-ef

## Criar o Migration a partir do Context
	Abrir o Terminal em View\Terminal
	Entrar na pasta do projeto principal (MVC)
	digitar o comando: dotnet ef migrations add InicialDB

## Atualizar o Banco de Dados
	No Terminal, digite: dotnet ef database update