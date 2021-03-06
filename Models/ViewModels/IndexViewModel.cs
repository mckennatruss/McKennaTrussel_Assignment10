using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKennaTrussel_Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string TeamName { get; set; }
    }
}
