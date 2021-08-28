using System;
using System.IO;
using System.Text;

namespace ExercicioStream
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarDiretorio();
            CriarArquivo();
            LerArquivo();

            static void CriarDiretorio()
            {
                DirectoryInfo di = new DirectoryInfo(@"c:\PastaFapen");
                try
                {
                    if (di.Exists)
                    {
                        Console.WriteLine("Diretório já existente.");
                    }
                    else
                    {
                        di.Create();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao excluir diretório: {0}", e.ToString());
                }
                finally
                {
                    Console.WriteLine("Nome do diretório: " + di.FullName);
                }
            }

            static void CriarArquivo()
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(@"C:\PastaFapen\AulaFapen.txt"))
                    {
                        writer.WriteLine("Estamos utilizando a classe StreamWriter para escrever esse código!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "  " + ex.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Finalizou a escrita");
                }
            }

            static void LerArquivo()
            {
                string arquivo = @"C:\PastaFapen\AulaFapen.txt";
                StringBuilder sb = new StringBuilder();
                if (File.Exists(arquivo))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(arquivo))
                        {
                            String linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                sb.AppendLine(linha);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Abaixo segue o texto do arquivo:");
                        Console.WriteLine("");
                        Console.WriteLine(sb.ToString());
                        Console.WriteLine("Operação finalizada!");
                    }
                }
                else
                {
                    Console.WriteLine(" O arquivo " + arquivo + " não foi localizado !");
                }
            }
        }
    }
}
