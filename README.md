## Requisitos

.NET 8, SQL Server 2022

## Configuração da Connection String

Antes de rodar a API, edite o arquivo "appsettings.json" e configure sua própria connection string:

```
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```

## Migrations

O projeto já contem uma migration, então basta executa-la no banco. Abrir o package manager console e executar o comando:
Update-Database
