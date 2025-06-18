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
        public String estateAgentSggNm { get; set; } // 중개사소재지
        public string rgstDate { get; set; } // 등기일자
        public string aptDong { get; set; } // 아파트 동명
        public String dealGbn { get; set; } // 중개거래/직거래
        public string salerGbn { get; set; } // 매도자 구분 (개인/법인/공공기관/기타)
        public string buyerGbn { get; set; } // 매수자 구분 (개인/법인/공공기관/기타)
        public string landLeaseholdGbn { get; set; } // 토지임대부 아파트 여부 (Y/N)
        public int newHighestPrice { get; set; }
    }
}
