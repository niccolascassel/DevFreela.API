# DevFreela

Projeto desenvolvido durante o curso ***Formação ASP.NET Core*** do **Método .NET Direto ao Ponto**.

Ao longo do curso foram apresentadas diversas ferramentas e tecnologias que foram aplicadas na API que foi desenvolvidas. As principais são:

- Swagger
- Clean Architecture com as camadas Core, Infrastructure, Application e API
- Entity Framework Core
- Dapper 
- CQRS
- MediatR
- JWT (Json Web Token)
- xUnit para a execução de testes unitários

A API desenvolvida é o backend de uma aplicação monitoramento/gerenciamento de projetos. As funções implementdas na API foram:

- Criação, exclusão e atualização de informações e status de projetos;
- Adição de comentários em projetos;
- Criação e login de usuários;

## Swagger

O Swagger é um framework composto por diversas ferramentas que, independente da linguagem, auxilia a descrição, consumo e visualização de serviços de uma API REST. Através dessa ferramenta é possível executar os métodos implementados nos controllers da API assim como obter uma documentação completa da API.

![image](https://user-images.githubusercontent.com/10198200/154869673-9ce591c0-5379-4381-b65e-fe12ccf6c8c8.png)

---
## Clean Architecture

***Clean Architecture*** é uma arquitetura de software proposta por Robert Cecil Martin (ou Uncle Bob, como é mais conhecido) que tem por objetivo padronizar e organizar o código desenvolvido, favorecer a sua reusabilidade, assim como independência de tecnologia. Também conhecida como ***Onion Architecture***, ess aqarquititura trabalha bem com DDD, devido a ser centrada no domínio, onde o seu acoplamento direcionado preza que o núcleo não dependa de nada, de forma a conseguirmos inclusive testá-lo isoladamente.

![image](https://codersopinion.com/images/posts/clean-architecture/clean-architecture.png)

---

## Entity Framework Core

O Entity Framework é uma ferramenta ORM (Object-relational mapping) que permite ao desenvolvedor trabalhar com dados relacionais na forma de objetos específicos do domínio. O Entity permite que façamos um mapeamento dos elementos de nossa base de dados para os elementos de nossa aplicação orientada a objetos. O uso de ORMs (Object-Relational Mappers) auxilia na produtividade e o Entity Framework é um dos melhores frameworks neste quesito.

![image](https://www.entityframeworktutorial.net/images/efcore/save-data-in-disconnected-scenario.png)

---

## Dapper

O Dapper é um ORM (Object Relational Mapping) voltado para o desenvolvimento .NET, onde seu principal objetivo é melhorar o desempenho das consultas ao banco de dados. Ele não conta com toda a gama de um ORM mais facilita muito o desenvolvimento de aplicações com melhor desempenho. O Dapper trabalha com o conceito de Extension methods, onde ele implementa um método de extensão da classe de conexão do banco, onde ao fazer a consulta ao banco de dados o mesmo vai fazer o mapeamento do retorno do Data Reader para o Modelo de dados.

![image](https://miro.medium.com/max/1238/1*mkkQBCy1DoRvkjAzxO0cug.png)

--- 

## CQRS

**C**ommand **Q**uery **R**esponsibility **S**egregation, ou **CQRS**, é um padrão de arquitetura de desenvolvimento de software que resume a separar a leitura e a escrita em dois modelos: query e command, uma para leitura e outra para escrita de dados, respectivamente.

![image](https://i.stack.imgur.com/paThD.png)

- **Query model**: responsável pela leitura dos dados do BD e pela atualização da interface gráfica.
- **Command model**: responsável pela escrita de dados no BD e pela validação dos dados. Sua interação com a interface gráfica é somente receber os dados a serem escritos.

---

## MediatR

O Mediator é um padrão de projeto Comportamental criado pelo GoF, que nos ajuda a garantir um baixo acoplamento entre os objetos de nossa aplicação. Ele permite que um objeto se comunique com outros sem saber suas estruturas. Em outras palavras podemos dizer que o Mediator Pattern gerencia as interações de diferentes objetos. Através de uma classe mediadora, centraliza todas as interações entre os objetos, visando diminuir o acoplamento e a dependência entre eles. Desta forma, neste padrão, os objetos não conversam diretamente entre eles, toda comunicação precisa passar pela classe mediadora.

![image](https://res.cloudinary.com/practicaldev/image/fetch/s--pS-OO2TY--/c_imagga_scale,f_auto,fl_progressive,h_420,q_auto,w_1000/https://dev-to-uploads.s3.amazonaws.com/i/hhglhn9qp4u31yx5dmj3.png)

---

## Json Web Token - JWT

JWT (JSON Web Token) é um método RCT 7519 padrão da indústria para realizar autenticação entre duas partes por meio de um token assinado que autentica uma requisição web. Esse token é um código em Base64 que armazena objetos JSON com os dados que permitem a autenticação da requisição. 

![image](https://user-images.githubusercontent.com/10198200/154870355-650bb873-8557-4693-b57a-26e5e4001d2e.png)
