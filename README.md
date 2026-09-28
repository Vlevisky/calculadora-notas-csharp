# Calculadora de Notas

**Aluno:** Davi Correa Paiao  
**RM:** 560438

Aplicação de console feita em C# para cadastrar um aluno, registrar três notas e consultar a média e a situação final.

## Como funciona

O menu permite cadastrar o aluno, lançar as notas, calcular a média ou encerrar o programa. As notas precisam estar entre 0 e 10. Entradas inválidas são recusadas e solicitadas novamente.

A média é calculada somando as três notas e dividindo o resultado por três. A situação é definida assim:

- Média a partir de 7: Aprovado
- Média a partir de 5 e abaixo de 7: Recuperação
- Média abaixo de 5: Reprovado

## Organização do código

- `CadastrarAluno()` guarda o nome informado.
- `LancarNotas()` valida e salva as notas no array.
- `CalcularMedia()` calcula e mostra a média.
- `ExibirSituacao()` informa o resultado do aluno.
- O `Main()` mantém o menu ativo até a opção de sair.

## Executar

Com o .NET 8 instalado, rode na pasta do projeto:

```bash
dotnet run
```