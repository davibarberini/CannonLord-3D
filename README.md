# CannonLord-3D
CannonLord da Blue Pixel mas em 3D

1. Como executar - dentro da pasta builds, executar o arquivo CannonLord.exe
Utiliza o mouse para atirar nas caixas que aparecer�o durante o jogo.

2. Como foi organizado o c�digo - dentro do projeto eu tentei separar o m�ximo em fun��es e comentei a maioria do c�digo, o player foi feito de forma separada e n�o depende de nenhum recurso no jogo, temos um game manager que controla tudo o que acontece, os inimigos s�o invocados pelas rotas que cont�m waypoints indicando o caminho que eles ir�o fazer, essas rotas est�o dentro de um objeto Wave que pode conter uma ou mais rotas, esse objeto � invocado pelo manager. Fiz dessa forma para que o jogo seja f�cil de se expandir caso necess�rio

3. Pontos Adicionais: 
 - Hist�rico de commits e reposit�rio: https://github.com/davibarberini/CannonLord-3D
 - C�digo organizado e modularizado
 - Export para web: https://simmer.io/@Davizote/~2789cb33-df59-3839-4d83-5c788606362a
 - Variedade de inimigos, mudan�as nos atributos do player.
 - Sistema de waves e leveis, mudando assim a dificuldade do inimigo e uma loja onde o player pode melhorar os atributos do canh�o, save dos dados em arquivo.


