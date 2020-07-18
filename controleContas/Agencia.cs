using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    class Agencia
    {
        private int _numero;
        private string _nome;
        private string _telefone;
        private string _cep;
        public int Numero {
            get
            {
                return _numero;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Numero de agência Inválido!");
                else
                    _numero = value;

            }
        }
        public string Cep {
            get
            {
                return _cep;
            }
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentException("Numero do cep Inválido!");
                else
                    _cep = value;

            }
        }
        public string Telefone {
            get
            {
                return _telefone;
            }
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentException("Numero de telefone Inválido!");
                else
                    _telefone = value;

            }
        }

        public string NomeBanco
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentException("Nome de banco Inválido para agência!");
                else
                    _nome = value;

            }
        }

        public List<Conta> Contas { get; private set; }

        public Agencia()
        {
            Contas = new List<Conta>();
        }
        public void AddConta(Conta conta)
        {
            Contas.Add(conta);

        }

    }
}
