using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    class Banco
    {
        public int Numero { get; set; }
        public string Nome { get; set; }

        public List<Agencia> Agencias { get; set; }

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
