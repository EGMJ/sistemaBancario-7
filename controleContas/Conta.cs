using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    class Conta
    {
        private int _agencia;
        public static decimal SaldoInicialGeral { get; private set; }

        public static decimal MaiorSaldoInicial { get; private set; }

        public static decimal ContaMaiorSaldoInicial { get; private set; }

        public long Numero { get; private set; }
        public decimal Saldo { get; private set; }

        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Numero  de agencia Inválido para conta!");
                else
                    _agencia = value;

            }
        }

        public Cliente Titular { get; set; }


        public Conta(long numero, decimal saldo, Cliente titular, int agencia)
        {
            if (saldo < 10m)
                throw new ArgumentException("O saldo informado é menor que o valor minimo exigido (10)");
            else
            {
                Agencia = agencia; 
                Numero = numero;
                Saldo = saldo;
                Titular = titular;
                SaldoInicialGeral += saldo;


                if (saldo > MaiorSaldoInicial)
                {
                    MaiorSaldoInicial = saldo;
                    ContaMaiorSaldoInicial = numero;
                }
            }  
        }

        public Conta()
        {

        }

        public void Deposito(decimal valor)
        {
            if (valor > 0)
                Saldo += valor;

        }

        public decimal Sacar(decimal valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Saldo -= 0.1m;
                return Saldo;
            }
            else
                throw new ArgumentException($"Saldo insuficiente. Seu saldo: {Saldo}");
        }

        public void Transferir(decimal saldoConta1, decimal saldoConta2, decimal valor, int loopin, out int loopout)
        {
            if (valor > 0)
            {
                if (saldoConta1 >= valor || loopin != 0)
                {
                    if (loopin == 0)
                    {
                        saldoConta1 -= valor;
                        SubstituirSaldo(saldoConta1);
                    }

                    if (loopin != 0)
                    {

                        saldoConta2 += valor;
                        SubstituirSaldo(saldoConta2);
                    }
                }
                else
                    throw new ArgumentException($"Saldo insuficiente. Seu saldo: {Saldo}");

                loopin += 1;
                loopout = loopin;
            }
            else
            {
                throw new ArgumentException("Não é possível realizar transferência com valor inferior a 1");
                loopout = 2;
            }
        }

        public decimal SubstituirSaldo(decimal valor)
        {
            Saldo = valor;
            return Saldo;
        }

        public void BonificacoConta()
        {
            Saldo += 5.00m;
        }
    }
}
