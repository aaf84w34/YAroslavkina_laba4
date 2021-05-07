using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfUrlConverter.Model;

namespace Converter.Repozit
{
    public interface Interface
    {
        Task<Curs> GetCurs();

        Task<Curs> GetCurs(DateTime? date);
    }
}
