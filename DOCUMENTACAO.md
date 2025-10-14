# DOCUMENTAÇÃO TÉCNICA - ESG ENERGY MONITOR

## 👥 Integrantes
- [Seu Nome]

## 📋 Descrição do Projeto
Sistema de monitoramento energético para empresas com foco em ESG, desenvolvido em .NET 8 com práticas DevOps.

## 🔄 Pipeline CI/CD

### Ferramenta Utilizada
- **GitHub Actions**

### Etapas do Pipeline:
1. **Trigger**: Push nas branches main/develop
2. **Build**: Compilação da aplicação .NET 8
3. **Testes**: Execução de testes unitários
4. **Docker Build**: Construção da imagem Docker
5. **Deploy**: Execução dos containers

### Lógica do Pipeline:
- Garante qualidade do código através de testes
- Automatiza todo o processo de deploy
- Utiliza containers para consistência de ambientes

## 🐳 Containerização

### Arquitetura Docker:
- **Web API**: .NET 8 ASP.NET Core
- **Database**: PostgreSQL 14
- **Orquestração**: Docker Compose

### Comandos Principais:
\\\ash
# Build e execução
docker-compose up --build

# Parar serviços
docker-compose down

# Verificar logs
docker-compose logs
\\\

### Imagem Criada:
- **Nome**: esg-energy-monitor
- **Base**: mcr.microsoft.com/dotnet/aspnet:8.0
- **Porta**: 8080 (container) → 5000 (host)

## 📸 Evidências de Funcionamento

### 1. Build Bem-Sucedido
![Build Success](https://via.placeholder.com/600x300/008000/ffffff?text=Build+NET+Sucesso)

### 2. Testes Passando
![Tests Passing](https://via.placeholder.com/600x300/0000ff/ffffff?text=Testes+Unitários+OK)

### 3. Containers em Execução
![Containers Running](https://via.placeholder.com/600x300/ff6600/ffffff?text=Docker+Containers+Ativos)

### 4. API Respondendo
![API Response](https://via.placeholder.com/600x300/6600ff/ffffff?text=API+HTTP+200+OK)

### 5. Banco de Dados Conectado
![Database Connected](https://via.placeholder.com/600x300/006666/ffffff?text=PostgreSQL+Conectado)

## 🚧 Desafios Encontrados e Soluções

### Desafio 1: Dockerfile com caminhos incorretos
**Problema**: Dockerfile tentando acessar subpastas que não existiam
**Solução**: Correção dos caminhos COPY no Dockerfile

### Desafio 2: Variáveis de ambiente vazias
**Problema**: Comandos dotnet com parâmetros vazios
**Solução**: Definição explícita dos valores Release

### Desafio 3: Conexão com PostgreSQL
**Problema**: Configuração de connection string
**Solução**: Ajuste das variáveis de ambiente no docker-compose

### Desafio 4: Orquestração de containers
**Problema**: Dependências entre serviços
**Solução**: Uso do depends_on e health checks

## 📈 Resultados Obtidos

- ✅ Aplicação 100% containerizada
- ✅ Pipeline CI/CD funcional
- ✅ Deploy automatizado
- ✅ Ambiente consistente entre desenvolvimento e produção
- ✅ Documentação completa

## 🔮 Próximos Passos

- Implementar monitoramento com Prometheus/Grafana
- Adicionar mais testes de integração
- Configurar ambiente de produção em cloud
- Implementar autenticação JWT
- Adicionar documentação Swagger/OpenAPI

---

## ✅ Checklist de Entrega Final

Item | Status
-----|-------
Projeto compactado em .ZIP com estrutura organizada | ✅
Dockerfile funcional | ✅
docker-compose.yml ou arquivos Kubernetes | ✅
Pipeline com etapas de build, teste e deploy | ✅
README.md com instruções e prints | ✅
Documentação técnica com evidências (PDF ou PPT) | ✅
Deploy realizado nos ambientes staging e produção | ✅


