                using System;
                using System.Collections.Generic;

                class Program
                {
                    static void Main()
                    {
                        List<string> produtos = new List<string>();
                        List<double> precos = new List<double>();
                        List<string> itensPedido = new List<string>();
                        List<double> valoresPedido = new List<double>();

                        Console.WriteLine("===CADASTRO DE PRODUTOS===");

                        // Cadastro de produtos
                        string continuar = "s";
                        while (continuar.ToLower() == "s")
                        {
                            Console.Write("Digite o nome do produto: ");
                            string nome = Console.ReadLine();

                            Console.Write("Digite o preço do produto: ");
                            if (double.TryParse(Console.ReadLine(), out double preco))
                            {
                                produtos.Add(nome);
                                precos.Add(preco);
                                Console.WriteLine("Produto cadastrado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Preço inválido!");
                                continue;
                            }

                            Console.Write("Deseja cadastrar outro produto? (s/n): ");
                            continuar = Console.ReadLine();
                        }

                        // Pedido
                        double total = 0;
                        while (true)
                        {
                            Console.WriteLine("\n===LISTA DE PRODUTOS===");
                            for (int i = 0; i < produtos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {produtos[i]} (R${precos[i]:F2})");
                            }
                            Console.WriteLine($"{produtos.Count + 1} - Finalizar pedido");

                            Console.Write("Escolha o produto pelo número: ");
                            if (int.TryParse(Console.ReadLine(), out int opcao))
                            {
                                if (opcao >= 1 && opcao <= produtos.Count)
                                {
                                    Console.Write("Digite a quantidade: ");
                                    if (int.TryParse(Console.ReadLine(), out int qtd) && qtd > 0)
                                    {
                                        double subtotal = precos[opcao - 1] * qtd;
                                        total += subtotal;
                                        itensPedido.Add($"{qtd} x {produtos[opcao - 1]}");
                                        valoresPedido.Add(subtotal);

                                        Console.WriteLine($"Adicionado: {qtd}x{produtos[opcao - 1]} (R${subtotal:F2})");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quantidade inválida!");
                                    }
                                }
                                else if (opcao == produtos.Count + 1)
                                {
                                    Console.WriteLine("\nPedido finalizado!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opção inválida!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida!");
                            }
                        }

        // Resumo do pedido
        Console.WriteLine("\n===RESUMO DO PEDIDO===");
        for (int i = 0; i < itensPedido.Count; i++)
        {
            Console.WriteLine($"{itensPedido[i]} - R${valoresPedido[i]:F2}");
        }
        Console.WriteLine($"Total a pagar: R${total:F2}");
        Console.WriteLine("=======================");
        Console.WriteLine("Obrigado pela preferência!");
    }
}
