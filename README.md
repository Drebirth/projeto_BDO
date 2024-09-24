
# Projeto BDO

Um projeto MVC desenvolvido utilizando ASP.NET, Entity framework identity e BootStrap 5.




## Documentação

Para roda em sua maquina é preciso ter instalado o .NET framework 8, que você pode está baixando neste link: [https://dotnet.microsoft.com/en-us/download]. 

Necessário também ter  instalado o Microsoft SQL Manager Studio neste link: [https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms]
e SQL EXPRESS [https://www.microsoft.com/pt-br/download/details.aspx?id=101064#:~:text=Microsoft%20SQL%20Server%202019%20Express%20%C3%A9%20uma%20edi%C3%A7%C3%A3o%20gratuita%20e&msockid=2dd9114e0a1366d327f505220b446719]


## Inicializar localmente

Necessário clonar este projeto 

```bash
  git clone https://github.com/Drebirth/projeto_BDO.git
```

Para inicializar o projeto na IDE

```bash
  dotnet watch run
```

## Detalhes do projeto 
O projeto é composto de 6 classes, Login, Register, Personagem, Local, Item, Grind.

Para acessar a aplicação e utilizar as rotinas é necessário ter um login, do tipo login e senha, após o resgitro você pode adicionar spot e itens a estes spot para efetuar um grind, levando em consideração que o tempo grindado é em torno de 1 h, nele ficaria registros de grind em spots do jogo no decorrer da sua jornada para comparações, lembrando que o grind e personagem só aparecem para o usuário que fez a inclusão, mas os spots e itens aparecem para todos os usuários com login ativo.

