using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    internal class StatSigunguDto: StatBaseDto
    {
        public string sigunguCode { get; set; } // 시군구 코드
        public string sigunguName { get; set; } // 시군구 이름
    }
}
