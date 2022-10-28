using EtudoClasse;

List<Pessoa> listaDePessoas = new List<Pessoa>();

int numeroPessoas = int.Parse(Console.ReadLine());

for(int i=0; i < numeroPessoas; i++)
{
    Console.WriteLine("Insira o Nome da Pessoa: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Insira a Idade da Pessoa: ");
    int idade = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira o Sexo da Pessoa(M ou F): ");
    char sexo = char.Parse(Console.ReadLine());

    Pessoa novaPessoa = new Pessoa(nome, idade, sexo);

    Console.WriteLine("Nova Pessoa Cadastrada com sucesso!!!\n");

    listaDePessoas.Add(novaPessoa);
}


for (int i = 0; i < listaDePessoas.Count(); i++)
{
    Pessoa usuario = listaDePessoas[i];
    Console.WriteLine($"Usuario {i + 1}: - Nome:{usuario.getNome()} Idade: {usuario.getIdade()} " +
        $"Sexo: {usuario.getSexo()}\n");
}

Console.WriteLine("Acabou o programa");