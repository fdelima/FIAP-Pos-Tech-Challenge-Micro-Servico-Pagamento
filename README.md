# FIAP-Pos-Tech-Challenge
Tech Challenge é o projeto da fase que englobará os conhecimentos obtidos em todas as disciplinas da fase. Esta é uma atividade que, em princípio, deve ser desenvolvida em grupo. Importante atentar-se ao prazo de entrega, pois trata-se de uma atividade obrigatória, uma vez que vale 90% da nota de todas as disciplinas da fase. 

## Como executar no visual studio 2022
* Certifique-se que o docker desktop esteja em execução
* Abra a solução (FIAP-Pos-Tech-Challenge.sln) com o visual studio 2022
* Start visual studio na opção docker-compose conforme imagem abaixo:
![image](Documentacao/VS-2022-play-docker-compose.png)

## Como executar manualmente no windows
* Certifique-se que o docker desktop esteja em execução
* Após o clone do projeto abra a pasta "Docker" no prompt de comando conforme imagem abaixo:
![image](Documentacao/Abrir-Terminal.png)
* Excute o commando abaixo:
```
docker compose up
```
# Navegação
* Documentação 
    * [https://localhost:8087/api-docs](https://localhost:8087/api-docs/index.html)
    * [http://localhost:8086/api-docs](http://localhost:8086/api-docs/index.html) 
* Swagger
    * [https://localhost:8087/swagger](https://localhost:8087/swagger/index.html)
    * [http://localhost:8086/swagger](http://localhost:8086/swagger/index.html) 


#
# Entregáveis FASE 3: [Wiki](https://github.com/fdelima/FIAP-Pos-Tech-Challenge/wiki)

Dando continuidade ao desenvolvimento do software para a lanchonete, 
teremos as seguintes melhorias e alterações: 
1. Implementar um API Gateway e um function serverless para 
autenticar o cliente
    - a) Integrar ao sistema de autenticação para identificar o cliente. 
        - Azure-AD-B2C

2. Implementar as melhores práticas de CI/CD para a aplicação, 
segregando os códigos em repositórios, por exemplo: 
- a) 1 repositório para o Lambda. 
    - [FIAP-Pos-Tech-Challenge-Function](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Function)

- b) 1 repositório para sua infra Kubernetes com Terraform.                     
    - [FIAP-Pos-Tech-Challenge-Infra-K8s](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-K8s)

- c) 1 repositório para sua infra banco de dados gerenciáveis 
com Terraform. 
    - [FIAP-Pos-Tech-Challenge-Infra-Bd](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-Bd)

- d) 1 repositório para sua aplicação que é executada no 
Kubernetes. 
    - [FIAP-Pos-Tech-Challenge](https://github.com/fdelima/FIAP-Pos-Tech-Challenge)

3. Os repositórios devem fazer deploy automatizado na conta da 
nuvem utilizando actions. As branchs main/master devem ser 
protegidas, não permitindo commits direto. Sempre utilize pull 
request. 

- FIAP-Pos-Tech-Challenge-Api
    - Workflows
        - Docker Image api CI
            - [Workflow file](/.github/workflows/dotnet.yml)
            - [Action](https://github.com/fdelima/FIAP-Pos-Tech-Challenge/actions/runs/11095958117)
    - Branch protection rule ![image](Documentacao/FIAP-Pos-Tech-Challenge-Branch-protection-rule.png)
    
- FIAP-Pos-Tech-Challenge-Infra-Bd
    - Workflows
        - Terraform In Azure with User-assigned Managed Identity 
            - [Workflow file](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-Bd/blob/main/.github/workflows/deploy-terraform-infrastructure-in-azure.yml)
            - [Action criando recursos no azure](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-Bd/actions/runs/11037364521/job/30658045672)
        - Docker Image mssql-tools CI
            - [Workflow file](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-Bd/blob/main/.github/workflows/mssql-tools-docker-image.yml)
            - [Action](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-Bd/actions/runs/11096258209/job/30825884068)
    - Branch protection rule ![image](Documentacao/FIAP-Pos-Tech-Challenge-Infra-Bd-Branch-protection-rule.png)
    
- FIAP-Pos-Tech-Challenge-Function
    - Workflows
        - Terraform In Azure with User-assigned Managed Identity
            - [Workflow file](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Function/blob/main/.github/workflows/deploy-terraform-infrastructure-in-azure.yml)
            - [Action criando recursos no azure](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Function/actions/runs/10971260253/job/30466175006)
        - Build and deploy .NET Core application to Function App token-validation-function-app    
            - [Workflow file](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Function/blob/main/.github/workflows/build-deploy-token-validation-function-app.yml)
            - [Action](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Function/actions/runs/11096474790)
            
    - Branch protection rule ![image](Documentacao/FIAP-Pos-Tech-Challenge-Function-Branch-protection-rule.png)
    
- FIAP-Pos-Tech-Challenge-Infra-K8s
    - Workflows
        - Deploy Terraform In Azure with User-assigned Managed Identity
            - [Workflow file](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-K8s/blob/main/.github/workflows/deploy-terraform-infrastructure-in-azure.yml)
            - [Action criando recursos no azure](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-K8s/actions/runs/11084558667/job/30800002895)
        
        - Deploy APP TO AKS    
            - [Workflow file](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-K8s/blob/main/.github/workflows/deploy-azure-kubernetes-service.yml)
            - [Action](https://github.com/fdelima/FIAP-Pos-Tech-Challenge-Infra-K8s/actions/runs/11096616615/job/30826660641)

    - Branch protection rule ![image](Documentacao/FIAP-Pos-Tech-Challenge-Infra-K8s-Branch-protection-rule.png)

4. Melhorar a estrutura do banco de dados escolhido, documentar 
seguindo os padrões de modelagem de dados e justificar a escolha 
do banco de dados. 
    - Foram criados index para melhora da performance do banco de dados.
    - O SQL Server é amplamente reconhecido por sua confiabilidade, desempenho robusto e escalabilidade, tornando-o ideal para empresas que precisam gerenciar grandes volumes de dados com alta eficiência.
Os recursos de alta disponibilidade, como failover clustering e replicação, garantem continuidade de operações, e o suporte a transações ACID assegura a integridade e consistência dos dados.
Além disso, o SQL Server oferece uma arquitetura otimizada para consultas complexas e cargas pesadas, proporcionando respostas rápidas mesmo em cenários críticos. Outro diferencial do SQL Server é sua
integração nativa com o ecossistema Microsoft, como Power BI, Excel e Azure, facilitando a análise e visualização de dados. A segurança também é um ponto forte, com funcionalidades como criptografia,
controle granular de permissões e auditoria. Essa combinação de segurança avançada, desempenho e integração o torna uma solução confiável e eficiente para organizações que buscam um banco de dados robusto
e preparado para aplicações críticas. Com isso, o SQL Server se posiciona como uma solução confiável e eficiente para empresas que demandam alto desempenho, segurança e integração com sistemas de Business
Intelligence e análise de dados.

5. Você tem a liberdade para escolher qual a infra de nuvem desejar, 
mas terá de utilizar os serviços serverless: functions (AWS Lamba, 
Azure functions ou Google Functions, por exemplo), banco de 
dados gerenciáveis (AWS RDS, Banco de Dados do Azure ou 
Cloud SQL no GCP, por exemplo), sistema de autenticação (AWS 
Cognito, Microsoft AD ou Google Identity platform no GCP, por 
exemplo). 
- Escolhas realizadas
    - Cloud: Microsoft Azure
    - Function: Azure Function
    - Banco de dados: Microsoft SQL Server 2019
    - Sistema de autenticação: Azure AD B2C

Os artefatos de entrega são: - PDF com o link do repositório público ou com acesso dos docentes. Esse 
repositório deve conter todos os códigos (inclusive o Terraform e CI/CD actions).  - PDF com a URL de um vídeo com a explicação da infraestrutura utilizada 
na nuvem escolhida. Nesse vídeo, o(a) estudante deverá explicar qual a função 
do serviço e como ele foi montado.

=> [Link Video Youtube](https://youtu.be/vj1Oe8q_0IU)