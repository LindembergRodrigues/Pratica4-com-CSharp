using Pratica4.Service;

namespace Pratica4
{
    public class Program
    {
        public static void Mai2n(string[] args)
        {
            Object[] i= new object[2];
            Console.WriteLine(i[0]);
            try
            {
                PessoaService ps = new PessoaService();
                while (true)
                {
                    Menu(ps);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Menu(PessoaService ps)
        {
            Console.Write("(C)adastrar pessoa: - " +
                "(L)istar pessoas: - " +
                "(R)emover pessoa: - " +
                "(B)uscar informação: - " +
                "(P)arar:\n\t\t>> ");
            string op = Console.ReadLine();

            switch (op.ToUpper())
            {
                case "C":
                    Cadastrar(ps);
                    break;
                case "R":
                    Console.Write("Informe o CPF da pessoa a ser removida: ");
                    string cpf = Console.ReadLine();
                    Remover(ps,cpf);
                    break;
                case "B":
                    Busca(ps);
                    break;
                case "P":
                    Environment.Exit(0);
                    break;
                case "L":
                    Console.WriteLine(ps.ToString());
                    break;
                default:
                    Console.WriteLine("Opção invalida, tente novamente!");
                    break;
            }
        }

        private static void Busca(PessoaService ps)
        {
            Console.Write("Informe o conteúdo a ser buscado: ");
            string conteudo = Console.ReadLine();
           
            Console.WriteLine(ps.RealizaBusca(conteudo));
            var ok = ps.RealizaBusca(conteudo);
            
            //dados.ForEach(p => dados.ToString());
        }

        private static void Remover(PessoaService ps, string cpf)
        {
            Console.WriteLine(ps.removerPessoa(cpf));
        }

        private static void Cadastrar(PessoaService ps)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            string dataNascimento = Console.ReadLine();
            Console.Write("altura: ");
            double altura = double.Parse(Console.ReadLine());
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            ps.AdicionaPessoa(nome, DateTime.Parse(dataNascimento), altura, cpf);
        }
    }
}