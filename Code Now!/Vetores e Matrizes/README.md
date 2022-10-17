<h1>Vetores e Matrizes<h1>
    <h2>O que são vetores?</h2>
        <p>Vetores são estruturas de dados onde podemos guardar um(recomenda-se a partir de dois) ou mais dados numa mesma declaração</p>
        <p>Para entender melhor vamos nos atentar as propriedades do vetor</p>
        <h3>Propriedades de um Vetor</h3>
        <p>Um mesmo vetor tem tamanho máximo de posições que variam de acordo com a possibilidade de memória RAM disónível na máquina</p>
        <p>O número de posições de um vetor é chamado de tamanho ou cumprimento</p>
        <p>Um vetor possui um tipo, logo só aceita armazenar dados do mesmo tipo</p>
        <p>Cientificamente falando, um vetor não armazena nada, mas ela é um ponteiro para locais de memória, ou seja, ela contém informações aonde cada item de sua posição está armazenada na memória RAM, logo quando uma de suas posiões é chamada ou atribuida ele retorna a localização dela</p>
        <h2>Como Criar um Vetor</h2>
        <p>Podemos separar a declaração em duas partes, a declaração do vetor, e a atribuição de seu tamanho ou cumprimento</p>
        <h3>Declação do vetor</h3>
        <p>Aqui informamos ao computador que tipo de dado vamos criar e que tipo de estrutura. Nesse caso a estrutura é um vetor.</p>
        <p>Para a máquina entender que estamos falando que queremos criar um vetor, utilizados [] após a declaração de tipo</p>
        
    '''c#
            int[] vetorDeInteiros;
            decimal[] vetorDeDecimais;
            double[] vetorDeDouble;
            string[] vetorDeString;
            bool[] vetorDeBooleanos;
    '''
       
        <p>Após a declaração como feita acima, precisamos atribuir a criação do vetor, ou seja, pedir para o Sistema Operacional alocar memória para a quantidade de dados que vamos armazenar neste vetor</p>
        <h3>Atribuição do Vetor</h3>
        <p>Usamos o comando New para informar a alocação de memória para a estrutura de dados, neste caso é um vetor então após usar o New nós chamados o tipo da estrutura, que é um vetor, então o tamanho do nosso vetor</p>
        <p>No exemplo abaixo estamos usando como exemplo 10 como tamanho</p>
        <code>
            int[] vetorDeInteiros = new int[10];
            decimal[] vetorDeDecimais = new decimal[10];
            double[] vetorDeDouble = new double[10];
            string[] vetorDeString = new double[10];
            bool[] vetorDeBooleanos = new bool[10];
        </code>
    <h2>Como criar uma Matriz</h2>
        <h3>Declação do vetor</h3>
            <p>Podemos informalmente dizer que um vetor para a linguagem C#, é uma Matriz com uma dimensão, uma matriz unitária. Embora conceitualmente não seja, mas podemos pensar assim</p>
            <p>Logo para criar uma matriz é semelhante a um vetor, a diferença é que informamos o número de dimensões dessa matriz. Usamos uma vírgula dentro do dos colchetes: [,] para dividir o vetor em duas dimensões ou mais. Para [,,], para quatro [,,,]</p>
            <code>
                int[,,] matrizDeInteirosComTresDimensoes;
                decimal[,] matrizDeDecimaisComDuasDimensoes;
                double[,,,] matrizDeDoubleComQuatroDimensoes;
                string[,,,,] matrizDeStringComCincoDimensoes;
                bool[,] matrizDeBooleanosComDuasDimensoes;
            </code>
         
        <h3>Atribuição da Matriz</h3>
            <p>Usamos o comando New para informar a alocação de memória de cada uma das dimensões da matriz e usamos a chamada da estrutura. int[10,10] seria a atribuição de uma matriz de duas dimensões com 10 de tamamho em cada uma das dimensões</p>
            <code>
                int[,,] matrizDeInteirosComTresDimensoes = new int[10,10,10];
                decimal[,] matrizDeDecimaisComDuasDimensoes = new decimal[10,5];
                double[,,,] matrizDeDoubleComQuatroDimensoes = new double[10,10,5,5];
                string[,,,,] matrizDeStringComCincoDimensoes = new string[10,10,10,5,5];
                bool[,] matrizDeBooleanosComDuasDimensoes = new bool[5,5];
            </code>