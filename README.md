
# Projeto BDO

Um projeto MVC desenvolvido utilizando ASP.NET, Entity framework identity e BootStrap 5.




## Documentação

Para roda em sua maquina é preciso ter instalado o .NET framework 8, que você pode está baixando neste link: [https://dotnet.microsoft.com/en-us/download]. 

Foi configurado para rodar localmente com banco de dados sqlite, no caso basta apenas utilizar comandos os comandos no terminal e realizar o update:

dotnet ef migrations add "Nome-Migracao" 
dotnet ef database update.


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

