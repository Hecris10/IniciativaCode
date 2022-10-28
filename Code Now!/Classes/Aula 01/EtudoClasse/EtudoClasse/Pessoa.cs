using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtudoClasse
{
    public class Pessoa
    {
        //Atributos
        private string Nome;
        private int Idade;
        private char Sexo;
        private string Endereco;
        //Construtor
        public Pessoa(string Nome, int Idade, char Sexo)
        {
           this.Nome = Nome;
           this.Idade = Idade;
           this.Sexo = Sexo;
        }
        //Metodos
        public string getNome()
        {
            return this.Nome;
        }

        public int getIdade()
        {
            return this.Idade;
        }

        public char getSexo()
        {
            return this.Sexo;
        }

        public string getEndereco()
        {
            if (this.Endereco == "") return null;

            return this.Endereco;
        }

        public void setNome(String novoNome)
        {
            this.Nome = novoNome;
        }
        public void setIdade(int novaIdade)
        {
            this.Idade = novaIdade;
        }

        public void setSexo(char novoSexo)
        {
            this.setIdade(novoSexo);
        }

        public void setEndereco(string novoEndereco)
        {
            this.Endereco = novoEndereco;
        }
    }
}
