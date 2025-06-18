using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    internal class RankUATypeSigungu
    {
        public int seq { get; set; }
        public int rankType { get; set; } // 0: 금액, 1: 거래건수
        public int dealYear { get; set; } // 거래년도
        public string areaCode { get; set; } // 지역코드 (시도, 시군구)
        public string sigunguCode { get; set; } // 시군구 코드
        public string sigunguName { get; set; } // 시군구 이름
        public string landDong { get; set; } // 법정동 이름
        public string aptName { get; set; } // 아파트 이름
        public float useArea { get; set; } // 전용면적
        public int useAreaTruncated { get; set; } // 전용면적(소수점 절사)
        public string useAreaType { get; set; } // 전용면적 타입 (평, m2)
        public int buildYear { get; set; } // 건축년도
        public int tradeCount { get; set; } // 거래건수
        public int minAmt { get; set; } // 최소 거래금액
        public int avgAmt { get; set; } // 평균 거래금액
        public int maxAmt { get; set; } // 최대 거래금액
    }
}
