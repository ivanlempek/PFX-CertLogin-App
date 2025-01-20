# Aplicativo de Login com Certificado Digital (.pfx)

Este é um aplicativo **console** feito com **C# / .NET 8** que realiza login em um serviço através de um **Certificado Digital** no formato **.pfx**.

## Pré-requisitos

- **.NET 8** (ou superior) instalado.
- Arquivo do seu **Certificado Digital A1** (`.pfx`) e **senha** correspondente.

## Como Usar

1. **Baixe** ou **clone** o repositório e abra a pasta do projeto.
2. **Compile** e **execute** o aplicativo (via Visual Studio ou comando `dotnet run`).
3. No **console**, será exibida uma opção para **login via Certificado Digital**.
4. **Informe** o **caminho** completo do arquivo `.pfx`.
5. **Informe** a **senha** do certificado quando solicitado.
6. O sistema fará a requisição ao serviço utilizando o certificado, e exibirá no console se o login foi bem-sucedido.

## Observações

- Certifique-se de que o **caminho** para o `.pfx` e a **senha** estejam corretos.
  
---
