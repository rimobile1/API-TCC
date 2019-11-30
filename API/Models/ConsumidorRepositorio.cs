using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ConsumidorRepositorio : IRepositorio<Cliente>
    {
        public int Delete(int id)
        {
            return ClienteBLL.Delete(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return ClienteBLL.GetAll();
        }

        public Cliente GetById(int? id)
        {
            return ClienteBLL.GetById(id.Value);
        }

        public int Insert(Cliente item)
        {
            return ClienteBLL.Insert(item);
        }

        public int Update(Cliente item)
        {
            return ClienteBLL.Update(item);
        }
    }
  }