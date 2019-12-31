# CannonLord-3D
CannonLord da Blue Pixel mas em 3D

1. Como executar - dentro da pasta builds, executar o arquivo CannonLord.exe
Utiliza o mouse para atirar nas caixas que aparecerão durante o jogo.

2. Como foi organizado o código - dentro do projeto eu tentei separar o máximo em funções e comentei a maioria do código, o player foi feito de forma separada e não depende de nenhum recurso no jogo, temos um game manager que controla tudo o que acontece, os inimigos são invocados pelas rotas que contém waypoints indicando o caminho que eles irão fazer, essas rotas estão dentro de um objeto Wave que pode conter uma ou mais rotas, esse objeto é invocado pelo manager. Fiz dessa forma para que o jogo seja fácil de se expandir caso necessário

3. Pontos Adicionais: 
 - Histórico de commits e repositório: https://github.com/davibarberini/CannonLord-3D
 - Código organizado e modularizado
 - Export para web: https://simmer.io/@Davizote/~2789cb33-df59-3839-4d83-5c788606362a
 - Variedade de inimigos, mudanças nos atributos do player.
 - Sistema de waves e leveis, mudando assim a dificuldade do inimigo e uma loja onde o player pode melhorar os atributos do canhão, save dos dados em arquivo.


