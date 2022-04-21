using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pratica4.Service
{
    public class PessoaService
    {
        List<Pessoa> listaComPessoa = new List<Pessoa>();

        public void AdicionaPessoa(String nome, DateTime data, double altura, string cpf)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("Nome informado é Nulo ou vazio, execute novamente!.", "");
            }

            if (data > DateTime.Now)
            {
                throw new FormatException("A data inserira esta é maior que a data atual!");
            }

            String padraoAltura = "[0-9][,][0-9][0-9]";
            if (!Regex.IsMatch(altura.ToString(), padraoAltura))
            {
                throw new ArgumentNullException("O formato da altura informada esta incorreta\nInserir seguindo o padrão N.NN >>", altura.ToString());
            }

            String padraoCPF = "[0-9][0-9][0-9][.][0-9][0-9][0-9][.][0-9][0-9][0-9][-][0-9][0-9]";
            if ((cpf.Length != 11 && cpf.Length !=14))
            {
                throw new FormatException("A regra do CPF não foi atendida!");
            }
            else if(cpf.Length == 14  && !Regex.IsMatch(cpf, padraoCPF))
            {
                throw new FormatException("A regra do CPF não foi atendida!");
            }            
            else if (cpf.Length == 11 && !IsNumber(cpf))
            {
                throw new FormatException("A regra do CPF não foi atendida!");
            }

            listaComPessoa.Add(new Pessoa(nome, data, altura, cpf));
            //return listaComPessoa;
        }

        private bool IsNumber(String cpf)
        {
            long numero;
            return Int64.TryParse(cpf, out numero);
        }

        public static int CalculaIdade(DateTime dataNascimento)
        {
            TimeSpan diferenca = DateTime.Now.Subtract(dataNascimento);
            return diferenca.Days / 365;
        }

        public string removerPessoa(string cpf)
        {

            for (int i = 0; i < listaComPessoa.Count; i++)
            {
                if (listaComPessoa[i].CPF == cpf)
                {
                    listaComPessoa.RemoveAt(i);
                    return $"A pessoa com CPF <<{cpf}>> foi removida!";
                }
            }
            return $"O CPF <<{cpf}>> não foi indentificado!";
        }

        public override string ToString()
        {
            string dadosPessoas = "";

            foreach (Pessoa p in listaComPessoa)
            {
                dadosPessoas += p.ToString() + "\n";
            }
            return dadosPessoas;
        }

        public string RealizaBusca(string busca)
        {
            string resultadoDaBusca = "";
            if (!listaComPessoa.Any())
            {
                throw new NullReferenceException("Não existe objetos do tipo pessoa referenciados!");
            }
            foreach(Pessoa pessoa in listaComPessoa)
            {
                if (pessoa.ToString().ToUpper().IndexOf(busca.ToUpper()) != -1)
                {
                    resultadoDaBusca += pessoa.ToString() + "\n";
                }
            }
            return resultadoDaBusca != "" ? resultadoDaBusca : "Não encontrado!";
        }

    }
}
