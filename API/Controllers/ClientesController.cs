using API.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly ConsumidorRepositorio _consumidorRepositorio;

        public ClientesController()
        {
            _consumidorRepositorio = new ConsumidorRepositorio();
           
        }
        // GET: api/Clientes

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _consumidorRepositorio.GetAll();
           //new string[] { "value1", "value2" };
        }

        // GET: api/Clientes/5
        [HttpGet]
        public Cliente GetbyId(int id)
        {
            return _consumidorRepositorio.GetById(id);
            //return "value";
        }

        // POST: api/Clientes
        [HttpPost()]
        public int Post([FromBody]Cliente c)
        {
            return _consumidorRepositorio.Insert(c);

        }
        [HttpPut()]

        // PUT: api/Clientes/5
        public int Put(int id, [FromBody]Cliente c)
        {
            return _consumidorRepositorio.Update(c);
        }

        // DELETE: api/Clientes/5
        [HttpDelete]
        public int Delete(int id)
        {
            return _consumidorRepositorio.Delete(id);
        }
    }
}
