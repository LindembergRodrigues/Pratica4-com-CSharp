using Pratica4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pratica4
{
    public class Pessoa
    {
        public String Nome { get; }
        public DateTime DataNascimento { get; }
        public  double Altura { get; }
        public string CPF { get; } 

        public Pessoa(string nome, DateTime data, double altura, string cpf)
        {
            Nome = nome;
            DataNascimento = data;
            Altura = altura;
            CPF = cpf;
        }

        public override string ToString()
        {
            return $"Seu nome é {Nome}, nasceu em {DataNascimento.ToString("d")}," +
                $" mede {Altura.ToString().Replace(",", ".")}m, " +
                $" {PessoaService.CalculaIdade(DataNascimento)} anos " +
                $"e seu CPF é {CPF}.";
        }
    }
}
