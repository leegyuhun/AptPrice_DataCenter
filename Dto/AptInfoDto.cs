using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Dto
{
    public class AptInfoDto
    {
        public string aptCode { get; set; }
        public string areaCode { get; set; }
        public string sidoCode { get; set; }
        public string sigunguCode { get; set; }
        public string aptName { get; set; }
        public string as1 { get; set; }
        public string as2 { get; set; }
        public string as3 { get; set; }
        public string aptAddr { get; set; }
        public string saleType { get; set; }
        public string heatType { get; set; }
        public int dongCnt { get; set; }
        public int daCnt { get; set; }
        public string bCompanyName { get; set; } //시공사
        public string aCompanyName { get; set; } //시행사
        public string aptType { get; set; } //단지 분류
        public string aptRoadAddr { get; set; } //도로명 주소
        public string hoCnt { get; set; } //호수
        public string useAplyDate { get; set; } //사용승인일
        public string useAplyYar { get; set; } //사용승인년도
        public int mpArea60 { get; set; } //전용면적 60㎡ 이하
        public int mpArea85 { get; set; } //전용면적 60㎡ 초과 ~ 85㎡ 이하
        public int mpArea135 { get; set; } //전용면적 85㎡ 초과 ~ 135㎡ 이하
        public int mpArea136 { get; set; } //전용면적 135㎡ 초과

        private float bigMpRate { get; set; } //대형평형 비율(국민평수 초과)
        public int parkCntUp { get; set; } //주차대수
        public int parkCntDn { get; set; } //주차대수(지하)
        public float parkRate { get; set; }
        public string busDist { get; set; } //버스정류장거리
        public string subLine { get; set; } //지하철노선
        public string subName { get; set; } //지하철역명
        public string subDist { get; set; } //지하철역거리
        public string welfFclt { get; set; } //자체시설
        public string convFclt { get; set; } //편의시설
        public string educFclt { get; set; } //교육시설
        public string bjdCode { get; set; } //법정동코드

    }
}
