using System;
using System.IO;

namespace ProjetoMatrizMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            int opc;
            string[,] matriz = new string[2, 3];

            do
            {
                Console.Clear();
                Console.WriteLine("++++++++menu++++++++");
                Console.WriteLine("0 - sair");
                Console.WriteLine("1 - cadastrar Nomes");
                Console.WriteLine("2 - Imprimir todos os nomes");
                Console.WriteLine("3 - Imprimir nomes de uma coluna");
                Console.WriteLine("4 - Imprimir nomes de uma coluna");
                Console.WriteLine("5 - Buscar um nome");
                Console.WriteLine("6 - Escolha uma linha para ordenar os nomes");
                Console.WriteLine("7 - Gravar em arquivo");
                Console.WriteLine("8 - ler arquivo");
                opc = int.Parse(Console.ReadLine());

                if (opc >= 9 || opc < 0)
                {
                    Console.WriteLine("digite uma opcao valida");
                }
                else
                {

                    switch (opc)
                    {
                        case 0:
                            Console.WriteLine("PROGRAMA ENCERRADO");
                            break;

                        case 1:
                            Push(matriz);
                            break;

                        case 2:
                            Console.Clear();
                            Print(matriz);
                            Console.WriteLine("pressione a tecla ESC para voltar ao menu");
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.Clear();
                            PrintLine(matriz);
                            Console.WriteLine("pressione a tecla ESC para voltar ao menu");
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.Clear();
                            PrintColuna(matriz);
                            Console.WriteLine("pressione a tecla ESC para voltar ao menu");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            Buscar(matriz);
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.Clear();
                            Ordem(matriz);

                            Console.WriteLine("pressione a tecla ESC para voltar ao menu");
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            GravarArquivo(matriz);

                            break;

                        case 8:
                            Console.Clear();
                            LerArquivo(matriz);
                            break;

                    }
                }

            } while (opc != 0);

        }

        public static void Push(string[,] matriz)
        {

            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    Console.WriteLine("digite o nome que sera inserido na posicao [{0}] [{1}] da matriz", linha, coluna);
                    matriz[linha, coluna] = Console.ReadLine();
                }
            }
        }

        public static void Print(string[,] matriz)
        {

            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    if (matriz[linha, coluna] == null)
                    {
                        Console.WriteLine("matriz vazia");
                    }
                    else
                    {
                        Console.WriteLine("{0} = [{1}] [{2}]", matriz[linha, coluna], linha, coluna);
                    }
                }
            }
            Console.WriteLine("impressao completa concluida");
        }

        public static void PrintLine(string[,] matriz)
        {
            int coluna = 0;
            Console.WriteLine("informe o numero da linha que deseja imprimir(de 0 a 2)");
            int numeroLinha = int.Parse(Console.ReadLine());
            if (matriz[numeroLinha, coluna] == null)
            {
                Console.WriteLine("matriz vazia");
            }
            else
            {
                for (coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    Console.WriteLine(matriz[numeroLinha, coluna]);
                }
            }
            Console.WriteLine("impressao da linha selecionada concluida");
        }

        public static void PrintColuna(string[,] matriz)
        {
            int linha = 0;
            Console.WriteLine("informe o numero da coluna que deseja imprimir(de 0 a 3)");
            int numeroColuna = int.Parse(Console.ReadLine());
            if (matriz[linha, numeroColuna] == null)
            {
                Console.WriteLine("matriz vazia");
            }
            else
            {
                for (linha = 0; linha < matriz.GetLength(0); linha++)
                {
                    Console.WriteLine(matriz[linha, numeroColuna]);
                }
            }
            Console.WriteLine("impressao da coluna selecionada concluida");
        }

        public static void Buscar(string[,] matriz)
        {
            string nome;
            int cont = 0;

            Console.WriteLine("qual o nome para pesquisa?");
            nome = Console.ReadLine().ToLower();

            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    if (matriz[linha, coluna].ToUpper() == nome.ToUpper())
                    {
                        Console.WriteLine("{0} = [{1}] [{2}]", matriz[linha, coluna], linha, coluna);
                        cont++;
                    }
                }
            }
            if (cont == 0)
            {
                Console.WriteLine("Nome nao encontrado");
            }
        }

        public static void Ordem(string[,] matriz)
        {
            Console.WriteLine("informe a linha que recebera a ordenaçao");
            int numeroLinha = int.Parse(Console.ReadLine());

            for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
            {
                for (int coluna1 = coluna + 1; coluna1 < matriz.GetLength(1); coluna1++)
                {
                    if (String.Compare(matriz[numeroLinha, coluna].ToUpper(), matriz[numeroLinha, coluna1]) > 0)
                    {
                        string aux;
                        aux = matriz[numeroLinha, coluna1];
                        matriz[numeroLinha, coluna1] = matriz[numeroLinha, coluna];
                        matriz[numeroLinha, coluna] = aux;
                    }
                }
            }
        }

        public static void GravarArquivo(string[,] matriz)
        {
            try
            {
                StreamWriter sw = new StreamWriter("c:\\TesteMatriz\\Matriz.txt");

                for (int linha = 0; linha < matriz.GetLength(0); linha++)
                {
                    for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                    {
                        sw.WriteLine("{0} = [{1}] [{2}]",matriz[linha, coluna], linha, coluna);
                    }
                }
                
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }
            Console.ReadKey();
        }

        public static void LerArquivo(string[,] matriz)
        {
            String l;
            try
            {
                StreamReader sr = new StreamReader("c:\\TesteMatriz\\Matriz.txt");
                l = sr.ReadLine();
                while (l != null)
                {
                    for (int linha = 0; linha < matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                        {
                            matriz[linha, coluna] = l;
                            l = sr.ReadLine();
                        }
                    }
                }
                sr.Close();
                Console.WriteLine("fim da leitura do arquivo");
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o bloco de comandos sem erros");
            }
            Console.ReadKey();
        }
    }
}
