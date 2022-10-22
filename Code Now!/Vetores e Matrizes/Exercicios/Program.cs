//EXERCIOS DE VETORES

int[] exercicio01(int[] vetor)
{
    /* Faça um programa que imprima os elementos de
       um vetor. Você pode usar este vetor com os 
       seguintes dados: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 */

   if(vetor.Length==0) return null;

    for (int i = 0; i < vetor.Length; i++)
    {
        Console.Write(vetor[i]);
    }

    return vetor;
}

int[] exercicio02(int[] vetor)
{
    /*Faça um programa que imprima os elementos de um vetor de 
     * trás pra frente. Você pode usar este 
     * vetor com os
     * seguintes dados: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 */
    if (vetor.Length == 0) return null;

    for(int i=vetor.Length-1; i>=0; i--)
    {
        Console.Write(vetor[i]);
    }

    return vetor;
}

int[] exercicio03(int[] vetor1, int[]novoVetor)
{
    /*Faça um programa que Copie os elementos de um vetor 
    para outro vetor.O Primeiro vetor pode 
    conter os seguintes dados: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 
    O segundo vetor de fazer uma cópia desse vetor. */

    if (vetor1.Length == 0) return null;

    novoVetor = new int[vetor1.Length];

    for (int i=0; i<vetor1.Length; i++)
    {
        novoVetor[i] = vetor1[i];
      
    }

    return novoVetor;
}

int[] exercicio04(int[] vetor1, int[] novoVetor)
{
    /*Faça um programa que Copie os elementos de um vetor para outro 
     vetor de forma inversa. O Primeiro 
     vetor pode conter os seguintes        
    ados: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 O 
    segundo vetor de fazer uma cópia inversa deste vetor.           */

    if (vetor1.Length == 0) return null;

    for(int i=vetor1.Length; i>=0; i--)
    {
        novoVetor[i] = vetor1[i];
    }

    return novoVetor;

}

int exercicio05(int[] vetor)
{
    /*Faça um programa que retorne o tamanho de um vetor(sem usar a função Length);*/
    if (vetor.Length == 0) return 0;

    int contador = 0;

    for(int i=0; i<vetor.Length; i++)
    {
        contador++;
    }

    return contador;
}

int[] exercicio06(int[] vetor1, int[] vetor2, int[] novoVetor)
{
    //Faça um prgrama que pegue dois vetores de inteiros e crie um terceiro vetor que é a soma dos outros dois

    if (vetor1.Length == 0 || vetor2.Length == 0) return null;

    if (vetor1.Length >= vetor2.Length)
    {
        novoVetor = new int[vetor1.Length];
        for (int i = 0; i < novoVetor.Length; i++)
        {
            novoVetor[i] = vetor1[i] = vetor2[i];
        }

        for (int i = vetor1.Length - 1; i < vetor1.Length; i++)
        {
            novoVetor[i] = vetor1[i];
        }

        return novoVetor;
    }
    else
    {
        novoVetor = new int[vetor2.Length];
        for (int i = 0; i < novoVetor.Length; i++)
        {
            novoVetor[i] = vetor1[i] = vetor2[i];
        }

        for (int i = vetor2.Length - 1; i < vetor2.Length; i++)
        {
            novoVetor[i] = vetor2[i];
        }

        return novoVetor;
    }
}

int[] exercicio07(int[] vetor, int[] vetorImpar)
{
    //Faça um programa que pegue um vetor de inteiros e crie um novo vetor com apenas os números ímpares.
    if (vetor.Length == 0) return null;

    int contador = 0;
    for(int i=0; i<vetor.Length; i++)
    {
        if(vetor[i]%2!=0)
        {
            contador++;
        }
    }

    vetorImpar = new int[contador];

    for (int i = 0; i < vetorImpar.Length; i++)
    {
        if (vetor[i] % 2 != 0)
        {
            vetorImpar[i] = vetor[i];
        }
    }

    return vetorImpar;
}

int[] exercicio08(int[] vetor, int[] vetorPar)
{
    //Faça um programa que pegue um vetor de inteiros e crie um novo vetor com apenas os números pares.
    if (vetor.Length == 0) return null;

    int contador = 0;
    for (int i = 0; i < vetor.Length; i++)
    {
        if (vetor[i] % 2 == 0)
        {
            contador++;
        }
    }

    vetorPar = new int[contador];

    for (int i = 0; i < vetorPar.Length; i++)
    {
        if (vetor[i] % 2 == 0)
        {
            vetorPar[i] = vetor[i];
        }
    }

    return vetorPar;
}

decimal exercicio09(int[] vetor)
{
    //Faça um programa que retorne a média dos números de um vetor de inteiros.
    if (vetor.Length == 0) return 0;

    int soma = 0;

    for(int i=0; i<vetor.Length; i++)
    {
        soma = soma + vetor[i];
    }

    decimal media = soma / vetor.Length;

    return media;
}

int exercio10(int[] vetor)
{
    //Faça um programa que retorne o maior elemento de um vetor de inteiros
    int maiorNumero = vetor[0];
    for(int i=1; i < vetor.Length; i++)
    {
        if (vetor[i] > maiorNumero) maiorNumero = vetor[i];
    }

    return maiorNumero;
}

int exercio11(int[] vetor)
{
    //Faça um programa que retorne o menor elemento de um vetor de inteiros.
    int maiorNumero = vetor[0];
    for (int i = 1; i < vetor.Length; i++)
    {
        if (vetor[i] < maiorNumero) maiorNumero = vetor[i];
    }

    return maiorNumero;
}

int exercicio12(int[] vetor, int numero)
{
    //Faça um programa que dado um valor, ele conta o número de ocorrências deste valor dentro de um vetor.
    if (vetor.Length == 0) return 0;

    int contador = 0;
    for(int i=0; i<vetor.Length; i++)
    {
        if (numero == vetor[i])
        {
            contador++;
        }
    }

    return contador;
}

