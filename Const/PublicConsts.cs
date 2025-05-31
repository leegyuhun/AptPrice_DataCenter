using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Const
{
    public static class PublicConsts
    {
        public static readonly ReadOnlyCollection<string> SIDO_CODES = new ReadOnlyCollection<string>(new string[]
        {
            "11", // 서울특별시
            "26", // 부산광역시
            "27", // 대구광역시
            "28", // 인천광역시
            "29", // 광주광역시
            "30", // 대전광역시
            "31", // 울산광역시
            "36", // 세종특별자치시
            "41", // 경기도
            "42", // 강원도
            "43", // 충청북도
            "44", // 충청남도
            "45", // 전라북도
            "46", // 전라남도
            "47", // 경상북도
            "48", // 경상남도
            "50"  // 제주특별자치도
        });

        public static readonly ReadOnlyCollection<string> SIGUNGU_CODES = new ReadOnlyCollection<string>(new string[]
        {
            "11110", "11140", "11170", "11200", "11215", "11230", "11260", "11290", "11305", "11320",
            "11350", "11380", "11410", "11440", "11470", "11500", "11530", "11545", "11560", "11590",
            "11620", "11650", "11680", "11710", "11740", "41430", "41410", "41131", "41133", "41135",
            "41171", "41173", "41461", "41463", "41465", "41111", "41113", "41115", "41117", "41150",
            "41190", "41210", "41220", "41250", "41271", "41273", "41281", "41285", "41287", "41290",
            "41310", "41360", "41370", "41390", "41450", "41480", "41500", "41550", "41570", "41590",
            "41610", "41630", "41650", "41670", "41800", "41820", "41830", "28110", "28140", "28177",
            "28185", "28200", "28237", "28245", "28260", "28710", "28720"
        });
    }
}
