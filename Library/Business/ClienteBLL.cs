using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class ClienteBLL
    {
        public static int Insert(Cliente c)
        {
            return ClienteDAL.Insert(c);
        }

        public static int Update(Cliente c)
        {
            return ClienteDAL.Update(c);
        }

        public static int Delete(int id)
        {
            return ClienteDAL.Delete(id);
        }

        public static List<Cliente> GetAll()
        {
            return ClienteDAL.GetAll();
        }

        public static Cliente GetById(int idCliente)
        {
            return ClienteDAL.GetById(idCliente);
        }
    }
}
