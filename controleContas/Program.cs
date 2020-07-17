using System;
using System.Security.Cryptography.X509Certificates;

namespace controleContas
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            banco.Nome = "Itau";
            banco.Numero = 183;

            Agencia agencia = new Agencia();
            agencia.Cep = "27140367";
            agencia.Numero = 0003;
            agencia.Telefone = "4002-8922";
            agencia.NomeBanco = banco.Nome;
            banco.Agencias.Add(agencia);


            Cliente cliente2 = new Cliente();
            Cliente cliente3 = new Cliente();

            Conta conta2 = new Conta(199810, 28m, cliente2, agencia.Numero);
            agencia.Contas.Add(conta2);
            Conta conta3 = new Conta(400289, 22m, cliente3, agencia.Numero);
            agencia.Contas.Add(conta3);
            try
            {
                Console.WriteLine("informe seu nome: ");
                cliente2.Nome = Console.ReadLine();

                Console.WriteLine("informe seu CPF: ");
                cliente2.Cpf = Console.ReadLine();

                Console.WriteLine("informe o ano de seu nascimento: ");
                cliente2.AnoNascimento = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("O CPF deve possuir exatamente 11 digitos!");
                Environment.Exit(1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                try
                {
                    conta2.Titular = cliente2;

                    Console.WriteLine($"Saldo inicial da conta {conta2.Numero}: {conta2.Saldo}");
                    conta2.Deposito(1000);
                    Console.WriteLine($"Saldo Atual da Conta {conta2.Numero}: {conta2.Saldo:C2}");
                    conta2.Sacar(1000);
                    Console.WriteLine($"O titular da conta se chama {conta2.Titular.Nome}");

                    Console.WriteLine($"Saldo Atual da Conta {conta2.Numero}: {conta2.Saldo:C2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
                finally
                {
                    cliente3.Nome = "Fulano";
                    cliente3.Cpf = "17217217217";
                    cliente3.AnoNascimento = 1999;
                    
                    try
                    {
                        Console.WriteLine("informe o valor da transferência: ");
                        decimal valor = decimal.Parse(Console.ReadLine());
                        decimal saldoConta3 = conta3.Saldo;
                        decimal saldoConta2 = conta2.Saldo;
                        int loop = 0;
                        while (loop <= 1)
                        {
                            if (loop == 0)
                            {
                                conta3.Transferir(conta3.Saldo, conta2.Saldo, valor, loop, out int loopout);
                                loop = loopout;
                            }
                            if (loop != 0)
                            {
                                conta2.Transferir(conta3.Saldo, conta2.Saldo, valor, loop, out int loopout);
                                loop = loopout;
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        foreach (Agencia agencias in banco.Agencias)
                        {
                            Console.WriteLine($"A agência {agencias.Numero}, " +
                                $"Pertence ao banco {agencias.NomeBanco}, " +
                                $"Possui o CEP {agencias.Cep}" +
                                $" e o telefone para contato é {agencias.Telefone}");
                        }
                        foreach (Conta contas in agencia.Contas)
                        {
                            Console.WriteLine($"O titular da conta {contas.Agencia} {contas.Numero} é do títular {contas.Titular.Nome} e o saldo atual é {contas.Saldo}");
                        }
                        Console.WriteLine("Programa finalizado");
                    }
                }
            }


           /* Console.WriteLine($"A conta {conta1.Numero} pertence ao cliente {conta1.Titular.Nome}");

            decimal comparador = conta1.Saldo - conta2.Saldo;

            if (comparador > 0)
            {
                Console.WriteLine($"A conta que possui maior saldo é a conta de número {conta1.Numero}");
            }
            else if (comparador < 0)
            {
                Console.WriteLine($"A conta que possui maior saldo é a conta de número {conta2.Numero}");
            }
            else if (comparador == 0)
            {
                Console.WriteLine($"As contas de número {conta2.Numero}, {conta1.Numero} possuem o mesmo saldo!");
            }

            Console.WriteLine($"O saldo inicial geral é de: {Conta.SaldoInicialGeral}"); */

          }
    }
}
