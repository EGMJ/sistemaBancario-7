using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    class Banco
    {
        private int _numero;
        private string _nome;
        public int Numero {
            get
            {
                return _numero;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Numero de banco Inválido!");
                else
                    _numero = value;

            }
        }
        public string Nome {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentException("Nome de banco Inválido!");
                else
                    _nome = value;

            }
        }

        public List<Agencia> Agencias { get; private set; }

        public Banco()
        {

            Agencias = new List<Agencia>();
        }

        public void AddAgencias(Agencia agencia)
        {
            Agencias.Add(agencia);
        }
    }
}
