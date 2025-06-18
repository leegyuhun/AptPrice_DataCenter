using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    internal class StatAreaDto: StatBaseDto
    {
        public string areaCode { get; set; } // 지역 코드
        public string areaName { get; set; } // 지역 이름
    }
}
