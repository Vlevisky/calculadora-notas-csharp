using System.Globalization;

internal class Program
{
    private const double MEDIA_APROVACAO = 7.0;
    private const double MEDIA_RECUPERACAO = 5.0;
    private const int QUANTIDADE_NOTAS = 3;
    private const double NOTA_MINIMA = 0.0;
    private const double NOTA_MAXIMA = 10.0;

    private static string nomeAluno = string.Empty;
    private static readonly double[] notas = new double[QUANTIDADE_NOTAS];
    private static int quantidadeNotas;

    private static void Main()
    {
        int opcao;

        do
        {
            ExibirMenu();
            opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;
                case 2:
                    LancarNotas();
                    break;
                case 3:
                    CalcularMedia();
                    break;
                case 4:
                    Console.WriteLine("Programa encerrado.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha uma opção de 1 a 4.");
                    break;
            }
        } while (opcao != 4);
    }

    private static void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Calculadora de Notas ===");
        Console.WriteLine("1 - Cadastrar aluno");
        Console.WriteLine("2 - Lançar notas");
        Console.WriteLine("3 - Calcular média");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    private static int LerOpcao()
    {
        while (true)
        {
            string entrada = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entrada, out int opcao))
            {
                return opcao;
            }

            Console.Write("Entrada inválida. Digite um número de 1 a 4: ");
        }
    }

    private static void CadastrarAluno()
    {
        while (true)
        {
            Console.Write("Digite o nome do aluno: ");
            string entrada = (Console.ReadLine() ?? string.Empty).Trim();

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                nomeAluno = entrada;
                quantidadeNotas = 0;
                Console.WriteLine($"Aluno {nomeAluno} cadastrado. Lance as notas para continuar.");
                return;
            }

            Console.WriteLine("Nome inválido. O nome do aluno não pode ficar vazio.");
        }
    }

    private static void LancarNotas()
    {
        if (string.IsNullOrEmpty(nomeAluno))
        {
            Console.WriteLine("Cadastre um aluno antes de lançar as notas.");
            return;
        }

        quantidadeNotas = 0;
        while (quantidadeNotas < QUANTIDADE_NOTAS)
        {
            Console.Write($"Digite a nota {quantidadeNotas + 1} (de {NOTA_MINIMA} a {NOTA_MAXIMA}): ");
            string entrada = (Console.ReadLine() ?? string.Empty).Trim().Replace(',', '.');

            bool notaValida = double.TryParse(
                entrada,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out double nota);

            if (!notaValida || nota < NOTA_MINIMA || nota > NOTA_MAXIMA)
            {
                Console.WriteLine($"Nota inválida. Digite um número entre {NOTA_MINIMA} e {NOTA_MAXIMA}.");
                continue;
            }

            notas[quantidadeNotas] = nota;
            quantidadeNotas++;
        }

        Console.WriteLine($"As {QUANTIDADE_NOTAS} notas de {nomeAluno} foram cadastradas.");
    }

    private static void CalcularMedia()
    {
        if (string.IsNullOrEmpty(nomeAluno))
        {
            Console.WriteLine("Cadastre um aluno antes de calcular a média.");
            return;
        }

        if (quantidadeNotas < QUANTIDADE_NOTAS)
        {
            Console.WriteLine("Lance as três notas antes de calcular a média.");
            return;
        }

        double somaNotas = 0;
        for (int indice = 0; indice < QUANTIDADE_NOTAS; indice++)
        {
            somaNotas += notas[indice];
        }

        double media = somaNotas / QUANTIDADE_NOTAS;
        Console.WriteLine($"Média de {nomeAluno}: {media:F1}");
        ExibirSituacao(media);
    }

    private static void ExibirSituacao(double media)
    {
        if (media >= MEDIA_APROVACAO)
        {
            Console.WriteLine("Situação: Aprovado");
        }
        else if (media >= MEDIA_RECUPERACAO)
        {
            Console.WriteLine("Situação: Recuperação");
        }
        else
        {
            Console.WriteLine("Situação: Reprovado");
        }
    }
}