using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    using System;

    public class Conta
    {
        public string Titular { get; set; }
        public double Saldo { get; protected set; }

        public Conta(string titular, double saldoInicial = 0)
        {
            Titular = titular;
            Saldo = saldoInicial;
         }

        public virtual void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de R${valor:F2} realizado.");
            }
            else
            {
                Console.WriteLine("Valor de depósito inválido.");
            }
        }

        public virtual void Sacar(double valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R${valor:F2} realizado.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente ou valor inválido.");
            }
        }

        public void MostrarSaldo()
        {
            Console.WriteLine($"Saldo atual: R${MostrarSaldo:F2}");
        }
    }

    public class ContaCaixinha : Conta
    {
        public ContaCaixinha(string titular, double saldoInicial = 0)
            : base(titular, saldoInicial)
        {
        }

        public override void Depositar(double valor)
        {
            if (valor >= 1.00)
            {
                base.Depositar(valor);
                Saldo += 1.00;
                Console.WriteLine("Bônus de R$1,00 adicionado ao saldo.");
            }
            else
            {
                Console.WriteLine("Depósitos inferiores a R$1,00 não são permitidos.");
            }
        }

        public override void Sacar(double valor)
        {
            double total = valor + 5.00; 

            if (valor > 0 && total <= Saldo)
            {
                Saldo -= total;
                Console.WriteLine($"Saque de R${valor:F2} realizado com taxa de R$5,00.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque com taxa.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ContaCaixinha conta = new ContaCaixinha("João", 100);
            conta.MostrarSaldo();

            conta.Depositar(50);
            conta.MostrarSaldo();

            conta.Sacar(30);
            conta.MostrarSaldo();

            conta.Depositar(0.5); 
            conta.MostrarSaldo();
        }
    }
