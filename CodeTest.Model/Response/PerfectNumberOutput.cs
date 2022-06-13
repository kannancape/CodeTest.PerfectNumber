using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Model.Response
{
    public class PerfectNumberOutput
    {
 
        public int PerfectNumberValue { get; set; }
        public PerfectNumberOutput(int perfectNumberValue)
        { 
            this.PerfectNumberValue = perfectNumberValue;
        
        }
    }
}
