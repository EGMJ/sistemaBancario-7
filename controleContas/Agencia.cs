using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    class Agencia
    {
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }

        public string NomeBanco { get; set; }

        public List<Conta> Contas { get; set; }

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
