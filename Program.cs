using System;
using System.Collections.Generic;

namespace Simula_ao_de_transferencias
{
    class Program
    {
        static List<Contas> listcontas = new List<Contas>();

        static void Main(string[] args)
        {
            string  OpçaoUsuario = ObterOpçaoUsuario();
            
            while(OpçaoUsuario.ToUpper() !="X")
            {
                switch(OpçaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;                   
                    case "4":
                        Sacar();
                        break;                  
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Emprestimo();
                        break;
                    case "7":
                        debug();
                        break;                    
                    case "C":
                        Console.Clear();
                        break;                
                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }
                OpçaoUsuario = ObterOpçaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar o programa!!!");
            
            
    }
        private static void Emprestimo()
        {
            System.Console.WriteLine("AVISO !!!");
            System.Console.WriteLine("SE DESEJAR EFETUAR O EMPRESTIMO NÃO PODERÁ SACAR NEM TRANSFERIR ATÉ SER PAGA A DIVÍDA PENDENTE");
            System.Console.WriteLine("DESEJA MESMO CONTINUAR? X-SIM | Z-NAO");
                string escolha2 = Console.ReadLine().ToUpper();
                    if(escolha2 == "X")
                    {
                        System.Console.WriteLine("Digite o número da conta:");
                        int indiceconta = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Digite o valor do Empréstimo:");
                        double valorEmprestimo = double.Parse(Console.ReadLine());
                        listcontas[indiceconta].Emprestimo(valorEmprestimo: valorEmprestimo);
                    }
        }

        private static void debug()
        {
            System.Console.WriteLine("DEBUG DE VALOR NEGATIVO NO SALDO! CREDITO -> SALDO");
            System.Console.WriteLine("Informe o número da conta:");
                int indiceconta = int.Parse(Console.ReadLine());
                listcontas[indiceconta].debug();

        }

        private static void Depositar()
        {
            System.Console.WriteLine("Digite o número da conta:");
                int indiceconta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser depositado");
                double ValorDepositado = double.Parse(Console.ReadLine());

            listcontas[indiceconta].Depositar(ValorDepositado);
            
        }

        private static void Sacar()
        {
            System.Console.WriteLine("Digite o número da conta:");
            int indiceconta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser sacado:");
            double valorsacado = double.Parse(Console.ReadLine());

            listcontas[indiceconta].Sacar(valorsacado);
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Deseja fazer transferencia para outro banco via PIX?");
            System.Console.WriteLine("X-SIM | Z-NAO");
            string escolha=Console.ReadLine().ToUpper();
                if(escolha=="X")
                {
                    
                    System.Console.WriteLine("Digite o número da conta Origem");
                        int contaOrigemt = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Digite o valor a ser transferido:");
                        double valorPassado = double.Parse(Console.ReadLine());
                    System.Console.WriteLine("Digite o PIX da conta destino:");
                        var PIX = Console.ReadLine();
                    System.Console.WriteLine("O valor a ser transferido será de {0}, deseja confirmar? X-SIM", valorPassado);
                        string escolha1 = Console.ReadLine().ToUpper();
                        if (escolha1=="X")
                        {
                        listcontas[contaOrigemt].TransferirPix(valorPassado);
                    return;
                        } 
                        else return;
                }

            System.Console.WriteLine("Digite o número da conta de origem:");
                int contaOrigem = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o número da conta de destino:");
                int ContaDestino = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser transferido:");
                double valorTransferido = double.Parse(Console.ReadLine());

            listcontas[contaOrigem].Transferir(valorTransferido,listcontas[ContaDestino]);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar Contas");
                if(listcontas.Count == 0)
                {
                    System.Console.WriteLine("Nenhuma conta cadastrada.");
                    return;
                }

                for (int i=0; i<listcontas.Count; i++)
                {
                    Contas contas = listcontas[i];
                    System.Console.WriteLine("#{0} - ", i);
                    System.Console.WriteLine(contas);   
                }
        }
        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir Nova Conta");

            System.Console.WriteLine("Digite 1 para Conta Física e 2 para Conta Jurídica:");
                int entradaUsuario = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Nome do Cliente:");
                string entradaNome = Console.ReadLine();
            
            System.Console.WriteLine("Digite o Saldo inicial:");
                double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Credito:");
                double entradaCredito = double.Parse(Console.ReadLine());

                double saldoDevedor=0;

            Contas NovaConta = new Contas(tipoconta:(tipoconta.Tipoconta)entradaUsuario,saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome,devedor: saldoDevedor);
                listcontas.Add(NovaConta);
        }

        private static string ObterOpçaoUsuario()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Informe a opção desejada:");
        
        System.Console.WriteLine("1- Listar contas");
        System.Console.WriteLine("2- Inserir nova conta");
        System.Console.WriteLine("3- Transferir");
        System.Console.WriteLine("4- Sacar");
        System.Console.WriteLine("5- Depositar");
        System.Console.WriteLine("6- Emprestimo");
        System.Console.WriteLine("7- Debugar saldo negativo");
        System.Console.WriteLine("C- Limpar tela");
        System.Console.WriteLine("X- Sair");
        
        string OpçaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return OpçaoUsuario;
    }
}

}
