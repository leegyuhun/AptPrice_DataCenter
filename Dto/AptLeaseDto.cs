using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    public class AptLeaseDto : AptPriceBaseDto
    {
        public int befDeposit { get; set; }
        public int deposit { get; set; }
        public int befMonthlyRent { get; set; }
        public int monthlyRent { get; set; }
    }
}
