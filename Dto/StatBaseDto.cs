using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    internal class StatBaseDto
    {
        public int seq { get; set; }
        public string dealYear { get; set; }
        public string dealMon { get; set; }
        public string dealYYMM { get; set; } // YYYYMM 형식
        public string useAreaType { get; set; }
        public int minPrice { get; set; } // 최저가
        public int avgPrice { get; set; } // 평균가
        public int maxPrice { get; set; }
        public int totalCount { get; set; } // 거래건수
        public int newHighestCount { get; set; } // 신규 최고가 거래건수
        public float newHighestRate { get; set; } // 신규 최고가 거래비율
    }
}
