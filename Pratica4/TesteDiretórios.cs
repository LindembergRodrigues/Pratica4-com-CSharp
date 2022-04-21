using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratica4
{
    class TesteDiretórios
    {
        static String caminho = "C:\\Program Files";

        public static void Main5 (String [] args)
        {
            // para capturar as pastas do diretório, usamos o Directories
            // para capturar os arquivos do diretório, usamos o Files
            IEnumerable<string> listOfDirectories = Directory.EnumerateFiles(caminho);
            
            foreach(string directory in listOfDirectories)
            {
                Console.WriteLine(directory);
            }
        }
    }
}
