using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library;
using System.Threading.Tasks;

namespace Library.Services
{
    interface IRequest
    {
        Task<Tresult> GetAsync<Tresult>(string uri);
        Task<int> PostAsync<Tresult>(string uri, Tresult data);
        Task<int> PutAsync<Tresult>(string uri, Tresult data);
        Task<int> DeleteAsync<Tresult>(string uri);




    }
}
