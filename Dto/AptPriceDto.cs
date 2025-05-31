using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    public class AptPriceDto : AptPriceBaseDto
    {
        public AptPriceDto() { }
        public int dealAmt { get; set; }
        public int prevDealAmt { get; set; }
        public String prevDealDate { get; set; }
        public String cnclDealType { get; set; }
        public String cnclDealDate { get; set; }
        public String dealType { get; set; }
        public String dealLoc { get; set; }
        public int newHighestPrice { get; set; }
    }
}
