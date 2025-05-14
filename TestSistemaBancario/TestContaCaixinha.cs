using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSistemaBancario
{
    [TestClass]
    public class TestContaCaixinha
    {
        [TestMethod]
        public void TestContaCaixinhaHerdaConta()
        {
            decimal saldoInicial = 1000;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);
            Assert.IsTrue(typeof(Conta).IsAssignableFrom(caixinha.GetType()));
        }

        [TestMethod]
        public void TestDeposito()
        {
            decimal saldoInicial = 1000;
            decimal valorDeposito = 100;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);
            caixinha.Depositar(valorDeposito);
            Assert.AreEqual(caixinha.Saldo, 1101);
        }

        [TestMethod]
        public void TestSaque()
        {
            decimal saldoInicial = 1000;
            decimal saque = 105;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);
            caixinha.Sacar(saque);
            Assert.AreEqual(caixinha.Saldo, 890);
        }

        [TestMethod]
        public void TestDepositarValorInferiorAUm()
        {
            decimal saldoInicial = 1000;
            decimal valorDeposito = 0.9m;
            ContaCaixinha caixinha = new ContaCaixinha(saldoInicial);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => caixinha.Depositar(valorDeposito));
        }
    }
}
