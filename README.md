
<h2>🌱 Projeto - ESG Energy Monitor<hr>

<h3>Sistema de monitoramento energético desenvolvido em .NET 8 com arquitetura, containerização e pipeline CI/CD profissional no Azure.</h3>

<strong>
🔄 Pipeline CI/CD - Azure Configurado<br>

<h5>Status do Pipeline:</h5></strong>
 ✅ CI/CD Básico: Implementado e funcionando<br>
 ✅ Azure Integration: Configurado e validado<br>
 ✅ Multi-ambiente: Staging + Production configurados<br>
 ✅ Deploy Cloud: Configuração credenciais Azure<br>

<br>

<strong>🏗 Arquitetura Implementada:</strong>

text
GitHub Actions → Azure Container Registry → Azure App Service
     │                      │                      │
 Build & Test        Image Storage        Deployment Targets
     │                      │                      │
  dev branch   →    monitoracr12345    →  energy-monitor-staging
  main branch  →    energy-monitor-app  →  energy-monitor-prod


<strong>📊 Ambientes de Deploy:</strong>
Ambiente	Branch	Trigger	Status
Staging	dev	Push automático	✅ Configurado
Production	main	Push com aprovação	✅ Configurado


<strong>🐳 Execução Local</strong>
Pré-requisitos
Docker
Docker Compose


Execução com Docker (Recomendado)

bash
<h2># 1. Navegue para a pasta do projeto</h2>
cd Web.Service.Cap7

<h2># 2. Execute o docker-compose</h2>
docker-compose up --build

<h2># 3. Acesse a aplicação</h2>
<p>Execução com .NET CLI </p>
bash
cd Web.Service.Cap7<br>
dotnet run

<h2># Acesse: http://localhost:5122</h2>

Serviços disponíveis localmente:<br>
API: http://localhost:5000 (Docker)<br> 
http://localhost:5122 (.NET)<br>
Swagger UI: http://localhost:5122/swagger/index.html<br>
PostgreSQL: localhost:5432 <br>
Banco de dados: esg_db<br>


Recursos Azure Configurados:
Container Registry: monitoracr12345
App Service Staging: energy-monitor-staging
App Service Production: energy-monitor-prod
Resource Group: ESG-RG


<strong>🔧 Configuração do CI/CD</strong><br>
Workflow GitHub Actions:<br>
yaml<br>
name: 🚀 CI/CD Dockerizado - Azure App Services<br>
on:<br>
  push:<br>
    branches: [dev, main]<br>
  workflow_dispatch:<br>

jobs:<br>
  build-and-push:    # Build e push para ACR<br>
  deploy-staging:    # Deploy automático para staging (branch dev)<br>
  deploy-production: # Deploy manual para produção (branch main)<br>

<strong>🐳 Containerização</strong><br>
Dockerfile<br>
dockerfile<br>
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base<br>
USER app<br>
WORKDIR /app<br>
EXPOSE 80<br>
EXPOSE 443<br>

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build<br>
WORKDIR /src<br>
COPY ["Web.Service.Cap7.csproj", "."]<br>
RUN dotnet restore "Web.Service.Cap7.csproj"<br>
COPY . .<br>
RUN dotnet build "Web.Service.Cap7.csproj" -c Release -o /app/build<br>

FROM build AS publish<br>
RUN dotnet publish "Web.Service.Cap7.csproj" -c Release -o /app/publish /p:UseAppHost=false<br>

FROM base AS final<br>
WORKDIR /app<br>
COPY --from=publish /app/publish .<br>
ENTRYPOINT ["dotnet", "Web.Service.Cap7.dll"]<br>
Docker Compose<br>
yaml<br>
services:<br>
  webapi:<br>
    build: .<br>
    container_name: energy-monitor-app<br>
    ports:<br>
      - "5000:80"<br>
    environment:<br>
      - ASPNETCORE_ENVIRONMENT=Development<br>
      - ConnectionStrings__DefaultConnection=Host=db;Database=esg_db;Username=postgres;Password=postgres123;<br>
    depends_on:<br>
      - db<br>

  db:<br>
    image: postgres:14-alpine<br>
    container_name: energy-monitor-db<br>
    environment:<br>
      POSTGRES_USER: postgres<br>
      POSTGRES_PASSWORD: postgres123<br>
      POSTGRES_DB: esg_db<br>
    ports:<br>
      - "5432:5432"<br>
    volumes:<br>
      - postgres-data:/var/lib/postgresql/data<br>

<h2>📸 Evidências de Funcionamento</h2></br>

✅ Pipeline CI/CD Executado com Sucesso<br>
https://github.com/AlvaroNrs/Web.Service.Cap7/blob/dev/images/build_sucess.jpeg<br>
Workflow executando com sucesso no GitHub Actions<br>

✅ Build Docker Funcionando/<br>
https://github.com/AlvaroNrs/Web.Service.Cap7/blob/dev/images/build_log.jpeg.</br>
Logs mostrando build Docker e .NET bem-sucedidos<br>

✅ Containerização<br>
https://github.com/AlvaroNrs/Web.Service.Cap7/blob/dev/images/docker_image.png</br>
Imagem Docker construída e funcionando localmente<br>


✅ Produção: <br>
Staging: https://via.placeholder.com/800x400/375A7F/ffffff?text=Azure+Resources+Configured  colar imagem aki</br>
Production: https://via.placeholder.com/800x400/375A7F/ffffff?text=Azure+Resources+Configured colar imagem aki</br>
Recursos Azure configurados e prontos para deploy</br>



<h2>🛠 Tecnologias Utilizadas</br></h2>

Backend</br>
.NET 8</br>
ASP.NET Core Web API</br>
Entity Framework Core</br>
PostgreSQL</br>
AutoMapper</br>
FluentValidation</br>
MediatR</br>

DevOps & Cloud</br>
Docker & Docker Compose</br>
GitHub Actions (CI/CD)</br>
Azure Container Registry (ACR)</br>
Azure App Service (Deploy)</br>

Arquitetura</br>
Clean Architecture</br>
CQRS Pattern</br>
Repository Pattern</br>
Unit of Work</br>

<h2>Checklist de Entrega</br></h2>

Implementado e Funcionando:</br>

- ✅ Projeto compactado em .ZIP com estrutura organizada</br>
- ✅ Dockerfile funcional</br>
- ✅ docker-compose.yml para orquestração</br>
- ✅ Pipeline CI/CD com GitHub Actions</br>
- ✅ README.md com instruções completas</br>
- ✅ Documentação técnica com evidências</br>
- ✅ Deploy CONFIGURADO para Staging e Production</br>
- ✅ Pipeline executado com SUCESSO no GitHub Actions</br>
- ✅ Estratégia de branches (dev → staging, main → production) teste Ambas</br>
- ✅ Multi-ambiente configurado</br>
- ✅ Integração Azure configurada</br>


Infraestrutura: Microsoft Azure + GitHub Actions</br>
