using CodeTest.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.BL.Interface
{
    public interface IModelService
    {
        List<PerfectNumberOutput> GetPerfectNumber(int startNo, int endNo);
    }
}
