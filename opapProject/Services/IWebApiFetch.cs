using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opapProject.Services
{
    public interface IWebApiFetch
    {
        Task<string> WebApiFetchAsync(string path);
    }
}
