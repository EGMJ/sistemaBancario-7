using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace controleContas
{
    class Cliente
    {
        private string _nome;
        private string _cpf;
        private int _anoNascimento;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentException("Nome Inválido!");
                else
                    _nome = value;

            }
        }



        public Cliente()
        {
            
        }
        public List<Conta> Contas { get; set; }
        public string Cpf
        {
            get
            {
                return _cpf;
            }
            set
            {
                if (value.Length != 11)
                {
                    throw new FormatException();
                }
                else
                {
                    _cpf = value;
                }
            }
        }
        public int AnoNascimento
        {
            get
            {
                return _anoNascimento;
            }
            set
            {
                if (2020 - value <= 18)
                {
                    throw new ArgumentException("Não é possível criar conta para menores de idade!");
                }
                else
                {
                    _anoNascimento = value;
                }
            }
        }
    }
}
