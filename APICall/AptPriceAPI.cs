using AptPrice_DataCenter.Const;
using AptPrice_DataCenter.Dto;
using AptPrice_DataCenter.Util;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AptPrice_DataCenter.APICall
{
    internal class AptPriceAPI
    {
        public List<AptPriceDto> AptPriceCall(string MCode, string MYearMon, out string MResultMsg)
        {
            MResultMsg = string.Empty;
            AptPriceDto aDto;
            List<AptPriceDto> aList = new List<AptPriceDto>();
            XmlDocument aXmlDoc = new XmlDocument();
            var aUrl = string.Format(PrivateConsts.APT_PRICE_API_URL, MCode, MYearMon);
            aXmlDoc.Load(aUrl);
            var resultCode = aXmlDoc.SelectSingleNode("//response/header/resultCode")?.InnerText.Trim();
            var resultMsg = aXmlDoc.SelectSingleNode("//response/header/resultMsg")?.InnerText.Trim();
            
            if (resultCode != "000")
            {
                MResultMsg = "API 호출 실패: " + resultMsg;
                return aList;
            }

            XmlNodeList aNodeList = aXmlDoc.SelectNodes("//item");
            foreach (XmlNode aNode in aNodeList)
            {
                aDto = new AptPriceDto();
                aDto.sigunguCode = aNode["sggCd"]?.InnerText;
                aDto.areaCode = aDto.sigunguCode.Substring(0, 2);
                aDto.sidoCode = aDto.sigunguCode.Substring(0, 4);
                aDto.aptDong = aNode["aptDong"]?.InnerText;
                aDto.aptName = aNode["aptNm"]?.InnerText;
                aDto.buildYear = CommonFunc.GetIntValue(aNode["buildYear"]?.InnerText);
                aDto.dealAmt = CommonFunc.GetIntValue(aNode["dealAmount"]?.InnerText);
                aDto.dealYear = aNode["dealYear"]?.InnerText;
                aDto.dealMon = aNode["dealMonth"]?.InnerText.PadLeft(2, '0');
                aDto.dealDay = aNode["dealDay"]?.InnerText.PadLeft(2, '0');
                aDto.dealGbn = aNode["dealingGbn"]?.InnerText;
                aDto.dealDate = $"{aDto.dealYear}-{aDto.dealMon}-{aDto.dealDay}";
                aDto.estateAgentSggNm = aNode["estateAgentSggNm"]?.InnerText;
                aDto.useArea = CommonFunc.GetFloatValue(aNode["excluUseAr"]?.InnerText);
                if (aDto.useArea < 59) { aDto.useAreaType = "UA01"; }
                else if (aDto.useArea >= 59 && aDto.useArea < 60) { aDto.useAreaType = "UA02"; }
                else if (aDto.useArea >= 60 && aDto.useArea < 84) { aDto.useAreaType = "UA03"; }
                else if (aDto.useArea >= 84 && aDto.useArea < 85) { aDto.useAreaType = "UA04"; }
                else if (aDto.useArea >= 85 && aDto.useArea < 102) { aDto.useAreaType = "UA05"; }
                else if (aDto.useArea >= 102 && aDto.useArea <= 135) { aDto.useAreaType = "UA06"; }
                else { aDto.useAreaType = "UA07"; }

                aDto.useAreaInt = (int)aDto.useArea;
                aDto.floor = CommonFunc.GetIntValue(aNode["floor"]?.InnerText);
                aDto.jibun = aNode["jibun"]?.InnerText;
                aDto.landLeaseholdGbn = aNode["landLeaseholdGbn"]?.InnerText;
                aDto.rgstDate = aNode["rgstDate"]?.InnerText;                   
                aDto.buyerGbn = aNode["buyerGbn"]?.InnerText;
                aDto.salerGbn = aNode["slerGbn"]?.InnerText;
                aDto.cnclDealDate = aNode["cdealDay"]?.InnerText;
                aDto.cnclDealType = aNode["cdealType"]?.InnerText;
                aDto.umdName = aNode["umdNm"]?.InnerText;
                aList.Add(aDto);
            }
            return aList;
        }
    }
}
