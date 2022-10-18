# Vetores e Matrizes

<!--ts-->
* [Vetores](#Vetores)
    * [Propriedades De Vetores](#Propriedades-de-Vetores)
    * [Como Criar Um Vetor](#Como-Criar-Um-Vetor)
        * [Declaração de Vetores](#Declaração-de-Vetores)
        * [Alocação de Vetores](#Alocação-de-Vetores)
        * [O Tamanho de um Vetor](#Tamanho-de-um-Vetor)
* [Matrizes](#Matrizes)
    * [Propriedade de Matrizes](#Propriedades-de-Matrizes)
    * [Como Criar Uma Matriz](#Como-Criar-Uma-Matriz)
        * [Declaração de Matrizes](#Declaração-de-Matrizes)
        * [Alocação de Matrizes](#Alocação-de-Matrizes)
* [Atribuição de Vetores e Matrizes](#Atribuição-De-Vetores-e-Matrizes)
    * [Atribuição de Vetores](#Atribuição-de-Vetores)
    * [Atribuição de Matrizes](#Atribuição-de-Matrizes)
* [Percorrer Vetores e Matrizes](#Percorrer-Vetores-e-Matrizes)
    * [Percorrendo Vetores](#Percorrendo-Vetores)
    * [Percorrendo Matrizes](#Percorrendo-Matrizes)
<!--te-->

# Vetores

O que são vetores? 
Vetores são estruturas de dados onde podemos guardar um(recomenda-se a partir de dois) ou mais dados numa mesma declaração 
Para entender melhor vamos se atentar as propriedades do vetor 
## Propriedades De Vetores
-Um mesmo vetor tem tamanho máximo de posições que variam de acordo com a possibilidade de memória RAM disónível na máquina 
-O número de posições de um vetor é chamado de tamanho ou cumprimento 
-Um vetor possui um tipo, logo só aceita armazenar dados do mesmo tipo 
-Cientificamente falando, um vetor não armazena nada, mas ela é um ponteiro para locais de memória, ou seja, ela contém informações aonde cada item de sua está armazenada na memória RAM, logo quando uma de suas posiões é chamada ou atribuida ele retorna a localização dela
-A primeira posição de um vetor é a posição 0, logo sempre que se referir a primeira posição de um vetor, deve se o usar o 0. Consulte mais a frente a sessão [atribuição de vetores](#Atribuição-de-Vetores) para entender como acessar as posições dos vetores.
    
## Como Criar um Vetor 
Podemos separar a declaração em duas partes, a declaração do vetor, e a alocação de seu tamanho ou cumprimento 
### Declaração de Vetores 
Aqui informamos ao computador que tipo de dado vamos criar e que tipo de estrutura. Nesse caso a estrutura é um vetor. 
Para a máquina entender que estamos falando que queremos criar um vetor, utilizados [] após a declaração de tipo 

```cs         
int[] vetorDeInteiros;
decimal[] vetorDeDecimais;
double[] vetorDeDouble;
string[] vetorDeString;
bool[] vetorDeBooleanos;
```
Após a declaração como feita acima, precisamos atribuir a criação do vetor, ou seja, pedir para o Sistema Operacional alocar memória para a quantidade de dados que vamos armazenar neste vetor 
### Alocação de Vetores

Usamos o comando New para informar a alocação de memória para a estrutura de dados, neste caso é um vetor então após usar o New nós chamados o tipo da estrutura, que é um vetor, então o tamanho do nosso vetor 
No exemplo abaixo estamos usando como exemplo 10 como tamanho 
```cs         
int[] vetorDeInteiros = new int[10];
decimal[] vetorDeDecimais = new decimal[10];
double[] vetorDeDouble = new double[10];
string[] vetorDeString = new double[10];
bool[] vetorBooleano = new bool[10];
```         
### Tamanho de um Vetor
    Existe uma função padrão em C# que se chama Length. Ela retorna o tamanho do vetor.
```cs
int[] vetorDeInteiros = new int[10];

Console.WriteLine(vetorDeInteiros.Length);
```
O output do código será 10 pois 10 é o tamanho do vetor

# Matrizes
Podemos informalmente dizer que um vetor para a linguagem C#, é uma Matriz com uma dimensão, uma matriz unitária. Embora conceitualmente não seja, mas podemos pensar assim.
## Propriedades de Matrizes
As propriedades das matrizes são semelhantes as propriedades dos vetores
## Como Criar Uma Matriz
Para criar uma matriz é semelhante a um vetor

### Declaração de Matrizes
É semelhante a declaração de vetores, a diferença é que informamos o número de dimensões dessa matriz. Usamos uma vírgula dentro do dos colchetes: [,] para dividir o vetor em duas dimensões ou mais. Para trÊs [,,], para quatro [,,,] 
```cs           
int[,,] matrizDeInteirosComTresDimensoes;
decimal[,] matrizDeDecimaisComDuasDimensoes;
double[,,,] matrizDeDoubleComQuatroDimensoes;
string[,,,,] matrizDeStringComCincoDimensoes;
bool[,] matrizDeBooleanosComDuasDimensoes;
```             
         
### Alocação de Matrizes
Usamos o comando New para informar a alocação de memória de cada uma das dimensões da matriz e usamos a chamada da estrutura. int[10,10] seria a  Alocação de uma matriz de duas dimensões com 10 de tamamho em cada uma das dimensões 
```cs
int[,,] matrizDeInteirosComTresDimensoes = new int[10,10,10];
decimal[,] matrizDeDecimaisComDuasDimensoes = new decimal[10,5];
double[,,,] matrizDeDoubleComQuatroDimensoes = new double[10,10,5,5];
string[,,,,] matrizDeStringComCincoDimensoes = new string[10,10,10,5,5];
bool[,] matrizDeBooleanosComDuasDimensoes = new bool[5,5];
```

# Atribuição de Vetores e Matrizes
Vamos falar sobre como atribuir dados aos vetores e as matrizes. Lembrando que usamos o operador = para atribuir valores.
## Atribuição de Vetores
Para atribuir valores a vetores é semelhante a atribuição de variáveis.
Para atribuir um valor a um vetor, além de atribuir chamando o nome do vetor, precisamos também indicar a posição. Lembrando que a posição inicial de um vetor é a zero 0.
Chama-se o nome do vetor e em seguida usa-se as chaves[] com o numero da posição dentro. Exemplos abaixo;
```cs
vetorDeInteiros[0] = 45;
vetorDeDecimais[150] = 76.5m;
vetorDeDouble[10] = 15.2;
vetorDeString[45] = "Hello World";
vetorBooleano[3] = true;
```

## Atribuição de Matrizes
Para atribuir valores a matrizes é semelhante, apenas usamos a virgua dentro dos colchetes[] para separas as coordenadas de cada uma das dimensões.
```cs
matrizDeInteirosDeDuasDimensoes[0,0] = 45;
matrizDeDecimaisDeTresDimensoes[1,4,3] = 65.4m;
matrizDeDoublesDeQuatroDimensoes[4,3,4] = 1745,4;
matrizDeStringDeCincoDimensoes[5,3,2,5] = "Hello World";
matrizBooleanaDeDuasDimensoes[4,9] = false;
```
# Percorrer Vetores e Matrizes
Para percorrer vetores e matrizes é preciso automatizar esse processo, principalmente quando temos um quantidade de posições gigantesca.
Para isso podemos usar controle de fluxos para percorrer o vetor ou a matriz.
## Percorrendo Vetores
No exemplo aqui usaremos um vetor de inteiros de tamamho 20
```cs
int[] vetorDeInteiros = new int[20];

//Usando um laço de repetição 'for' que começa com zero e se repete enquanto a variável i for menor que 20
//A variável i armazena a posição atual em que o vetor vai ser varrido, a cada icrementação de i, a posição do vetor atualiza pra próxima
//Em cada posição do vetor, é atribuido o valor de i+1 mais um, aqui estamos preenchendo o vetor com números de 1 a 20
for(int i=0; i<20 ;i++){
    vetorDeInteiros[i] = i+1;
}
```
Agora vamos imprimir na tela os dados do vetor
```cs
for(int i=0; i<20 ;i++){
    Console.Write(vetorDeInteiros[i]+" ");
}
```
O output desse código pode ser encontrado abaixo
```
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 
```

## Percorrendo Matrizes

Para percorrer Matrizes é semelhante a Vetores, porém para cada elemento do primeiro vetor, temos que percorrer outro vetor subsequente
Para cada item da linha, há uma coluna a ser percorredinda.
Usamos um for dentro do outro para percorrer.

QUANTOS FOR DEVEO USAR?
O número de dimensões da matriz é o número de Fors dentro do outro.

```cs
//Para uma matriz de duas dimensões
int[,] matriz = new Matriz[10,5];

for(int i=0; i<10 ; i++){
    for(int j=0; j<5; j++>){
        matriz[i,j] = j;
    }
}
```

```cs
//Para uma matriz de quatro dimensões
int[,] matriz = new Matriz[10,10,5,5];

for(int i=0; i<10 ; i++){
    for(int j=0; j<10; j++>){
       for(int k=0; k<5; k++){
        for(int l=0; l<10; l++){
            matriz[i,j,k,l] = l;
        }
       }
    }
}
```


