# Vetores e Matrizes

<!--ts-->
* [Vetores](#Vetores)
    * [Propriedade de Vetores](#VetoresPropriedades)
    * [Declaração de um Vetor](#VetoresDeclaracao)
    * [Atribuição de um Vetor](#VetoresAtribuicao)
* [Matrizes](#Matrizes)
    * [Propriedade de Matrizes](#MatrizesPropriedades)
    * [Declaração de uma Matriz](#MatrizDeclaracao)
    * [Atribuição de uma Matriz](#MatrizAtribuicao)
<!--te-->

# Vetores

O que são vetores? 
Vetores são estruturas de dados onde podemos guardar um(recomenda-se a partir de dois) ou mais dados numa mesma declaração 
Para entender melhor vamos se atentat as propriedades do vetor 
Propriedades de um Vetor 
Um mesmo vetor tem tamanho máximo de posições que variam de acordo com a possibilidade de memória RAM disónível na máquina 
O número de posições de um vetor é chamado de tamanho ou cumprimento 
Um vetor possui um tipo, logo só aceita armazenar dados do mesmo tipo 
Cientificamente falando, um vetor não armazena nada, mas ela é um ponteiro para locais de memória, ou seja, ela contém informações aonde cada item de sua está armazenada na memória RAM, logo quando uma de suas posiões é chamada ou atribuida ele retorna a localização dela 
    
 Como Criar um Vetor 
 Podemos separar a declaração em duas partes, a declaração do vetor, e a atribuição de seu tamanho ou cumprimento 
Declação do vetor 
Aqui informamos ao computador que tipo de dado vamos criar e que tipo de estrutura. Nesse caso a estrutura é um vetor. 
Para a máquina entender que estamos falando que queremos criar um vetor, utilizados [] após a declaração de tipo 
         
            int[] vetorDeInteiros;
            decimal[] vetorDeDecimais;
            double[] vetorDeDouble;
            string[] vetorDeString;
            bool[] vetorDeBooleanos;
         
Após a declaração como feita acima, precisamos atribuir a criação do vetor, ou seja, pedir para o Sistema Operacional alocar memória para a quantidade de dados que vamos armazenar neste vetor 
Atribuição do Vetor 
Usamos o comando New para informar a alocação de memória para a estrutura de dados, neste caso é um vetor então após usar o New nós chamados o tipo da estrutura, que é um vetor, então o tamanho do nosso vetor 
No exemplo abaixo estamos usando como exemplo 10 como tamanho 
         
            int[] vetorDeInteiros = new int[10];
            decimal[] vetorDeDecimais = new decimal[10];
            double[] vetorDeDouble = new double[10];
            string[] vetorDeString = new double[10];
            bool[] vetorDeBooleanos = new bool[10];
         
Como criar uma Matriz 
Declação do vetor 
Podemos informalmente dizer que um vetor para a linguagem C#, é uma Matriz com uma dimensão, uma matriz unitária. Embora conceitualmente não seja, mas podemos pensar assim 
Logo para criar uma matriz é semelhante a um vetor, a diferença é que informamos o número de dimensões dessa matriz. Usamos uma vírgula dentro do dos colchetes: [,] para dividir o vetor em duas dimensões ou mais. Para [,,], para quatro [,,,] 
             
                int[,,] matrizDeInteirosComTresDimensoes;
                decimal[,] matrizDeDecimaisComDuasDimensoes;
                double[,,,] matrizDeDoubleComQuatroDimensoes;
                string[,,,,] matrizDeStringComCincoDimensoes;
                bool[,] matrizDeBooleanosComDuasDimensoes;
             
         
Atribuição da Matriz 
Usamos o comando New para informar a alocação de memória de cada uma das dimensões da matriz e usamos a chamada da estrutura. int[10,10] seria a atribuição de uma matriz de duas dimensões com 10 de tamamho em cada uma das dimensões 
             
                int[,,] matrizDeInteirosComTresDimensoes = new int[10,10,10];
                decimal[,] matrizDeDecimaisComDuasDimensoes = new decimal[10,5];
                double[,,,] matrizDeDoubleComQuatroDimensoes = new double[10,10,5,5];
                string[,,,,] matrizDeStringComCincoDimensoes = new string[10,10,10,5,5];
                bool[,] matrizDeBooleanosComDuasDimensoes = new bool[5,5];
             
