# Minimol_Shooter_Test

O primeiro passo foi identificar os principais problemas e estruturas existentes no projeto. Me pareceu um twin sticks shooter simples com muito espaço para adição e modificação de features. Como o teste parecia muito aberto, em seguida achei importante criar um lista rápida de tarefas para serem feitas e features para serem adicionadas. Procurei pacotes gratuitos para os assets do projeto:

 * Usei primariamente as coisas do Kay Lousberg (https://kaylousberg.itch.io/) que funcionam bem sem animações ou implementação de IK, que eu senti que fugia do escopo do projeto;
 * Para partículas, usei o pacote "Cartoon FX Remaster Free" do Jean Moreno (https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-free-109565);
 * Para UI, usei ícones das sprite sheets de shikashipx (https://shikashipx.itch.io/shikashis-fantasy-icons-pack) e BDragon1727 (https://bdragon1727.itch.io/basic-pixel-health-bar-and-scroll-bar);

Em termos dos problemas de performace no projeto, o principal culpado foi a chamada de "FindObjectOfType" sendo feita em todo Update, na linha 11 de EnemyController. Coloquei a chamada no Start para corrigir o problema e em seguida criei uma interface básica, contador de placar e implementei o spawn de inimigos em circulo, de raio configurável, em volta do jogador, para implementar o loop básico de jogo. Vale apontar também que o outro problema de performace do projeto era a ausência do uso de Object Pool para os projéteis e para os inimigos, mas este problema foi corrigido mais tarde.

O próximo passo foi refatorar o código para termos componentes reutilizavéis para os personagens. Mudei o sistema de movimentação para utilizar a NavMesh, dei a possibilidade do jogador de usar outras armas e configurei as colisões para os inimigos matarem o player ao encostar nele, mas impedir o fogo amigo entre eles. 

Agora sim, chegou o momento de implementar uma Object Pool para melhorar o desempenho do jogo. Fiz algo bem genérico para usar com inimigos, projéteis e partículas, e mais qualquer outra coisa que eu achasse necessário. A última coisa implementada foi uma Health Bar para retorno visual para o jogador saber quanta vida ele tem disponível e por fim eu configurei diferentes personagens e armas para o player escolher.
