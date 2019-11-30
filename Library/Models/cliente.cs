using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Cliente
    {
        private int id_cliente;
        private string nome_cliente;
        private string rg_cliente;
        private string cpf_cliente;  
        private string endereco_cliente;
        private int telefone_cliente;
        private string email_cliente;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nome_cliente { get => nome_cliente; set => nome_cliente = value; }
        public string Rg_cliente { get => rg_cliente; set => rg_cliente = value; }
        public string Cpf_cliente { get => cpf_cliente; set => cpf_cliente = value; }
        public string Endereco_cliente { get => endereco_cliente; set => endereco_cliente = value; }
        public int Telefone_cliente { get => telefone_cliente; set => telefone_cliente = value; }
        public string Email_cliente { get => email_cliente; set => email_cliente = value; }
    }
}
