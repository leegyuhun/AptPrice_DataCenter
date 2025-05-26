using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    public class AptPriceDto
    {
        public AptPriceDto() { }

        public int seq { get; set; }
        public string areaCode { get; set; }
        public string sidoCode { get; set; }
        public string sigunguCode { get; set; }
        public string aptCode { get; set; }
        public string serialNumber { get; set; }
        public string dealYear { get; set; }
        public string dealMon { get; set; }
        public string dealDay { get; set; }
        public string dealDate { get; set; }
        public string aptName { get; set; }
        public float useArea { get; set; }
        public int useAreaInt { get; set; }
        public string useAreaType { get; set; } // 전용, 공급, 대지
        public int dealAmt { get; set; }
        public int prevDealAmt { get; set; }
        public String prevDealDate { get; set; }
        public int prevLeaseAmt { get; set; }
        public String prevLeaseDate { get; set; }
        public int mostHighestAmt { get; set; }
        public int mostLowestAmt { get; set; }
        public int diffAmt { get; set; }
        public float diffRate { get; set; }
        public int floor { get; set; }
        public String buildYear { get; set; }
        public String roadName { get; set; }
        public String roadNameCode { get; set; }
        public String roadNameBonbun { get; set; }
        public String roadNameBubun { get; set; }
        public String roadNameSigungu { get; set; }
        public String roadNameSeq { get; set; }
        public String landDong { get; set; }
        public String landCode { get; set; }
        public String landBonbun { get; set; }
        public String landBubun { get; set; }
        public String landSigungu { get; set; }
        public String jibun { get; set; }
        public String regnCode { get; set; }
        public String cnclDealType { get; set; }
        public String cnclDealDate { get; set; }
        public String dealType { get; set; }
        public String dealLoc { get; set; }
        public int newHighestPrice { get; set; }
    }
}
