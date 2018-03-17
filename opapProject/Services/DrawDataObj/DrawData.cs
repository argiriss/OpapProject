using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opapProject.Services.DrawDataObj
{
    public class DrawData
    {
        public DateTime drawTime { get; set; }
        public int drawNo { get; set; }
        public List<int> results { get; set; }
    }
}
