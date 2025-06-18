using AptPrice_DataCenter.APICall;
using AptPrice_DataCenter.Const;
using AptPrice_DataCenter.Dto;
using AptPrice_DataCenter.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AptPrice_DataCenter.Const.PrivateConsts;

namespace AptPrice_DataCenter
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Logg(string MLog)
        {
           txtLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + MLog + Environment.NewLine);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            dtStr01.Format = DateTimePickerFormat.Custom;
            dtStr01.CustomFormat = "yyyy-MM";
            dtStr01.Value = DateTime.Now.AddMonths(-2);

            dtEnd01.Format = DateTimePickerFormat.Custom;
            dtEnd01.CustomFormat = "yyyy-MM";
            dtEnd01.Value = DateTime.Now;
            //List<AptPriceDto> aptPriceList;
            //AptPriceAPI aptPriceAPI = new AptPriceAPI();
            //aptPriceList = aptPriceAPI.AptPriceCall("11110", "202310");
            //using (var db = new DBHelper())
            //{
            //    try
            //    {
            //        Logg("DB 연결 성공");
            //        var dt = db.SelectQuery("select * from apt_price");
            //        Logg($"조회된 데이터 수: {dt.Rows.Count}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Logg("DB 연결 실패: " + ex.Message);
            //    }
            //}
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnDtStr01Dn_Click(object sender, EventArgs e)
        {
            if (cbxDt01Type.SelectedIndex == 0) { dtStr01.Value = dtStr01.Value.AddYears(-1); }
            else { dtStr01.Value = dtStr01.Value.AddMonths(-1); }
        }

        private void btnDtStr01Up_Click(object sender, EventArgs e)
        {
            if (cbxDt01Type.SelectedIndex == 0) { dtStr01.Value = dtStr01.Value.AddYears(1); }
            else { dtStr01.Value = dtStr01.Value.AddMonths(1); }
        }

        private void btnRun01_Click(object sender, EventArgs e)
        {
            Stopwatch aSw = new Stopwatch();
            aSw.Start();

            int aCount = 1;
            DateTime aDate = dtStr01.Value;
            var stdDt = aDate.ToString("yyyyMM");
            var stdDt2 = aDate;
            var strYear = int.Parse(dtStr01.Value.ToString("yyyy"));
            var endYear = int.Parse(dtEnd01.Value.ToString("yyyy"));

            #region
            //var stdYear = strYear;
            //while (stdYear <= endYear)
            //{
            //    aCount = 0;
            //    foreach (var code in PublicConsts.SIGUNGU_CODES)
            //    {
            //        lblRankUaTypeCount.Text = $"{stdYear} InsertRankUATypeSigungu ({aCount} / {PublicConsts.SIGUNGU_CODES.Count})";
            //        Application.DoEvents();
            //        InsertRankUATypeSigungu(code, stdYear);
            //        aCount++;
            //    }
            //    stdYear++;
            //}
            //if (chkShutDown.Checked)
            //{
            //    Process.Start(new ProcessStartInfo
            //    {
            //        FileName = "shutdown",
            //        Arguments = "/s /t 0",  // /s: 종료, /t 0: 0초 후 종료
            //        CreateNoWindow = true,
            //        UseShellExecute = false
            //    });
            //}
            //return;

            //if (GetAptPriceData("41430", stdDt))
            //{
            //    if (InsertStatBySigungu("41430", stdDt))
            //    {
            //        InsertStatByArea("41", stdDt);
            //    }
            //}
            //while (int.Parse(stdDt) <= int.Parse(dtEnd01.Value.ToString("yyyyMM")))
            //{
            //    foreach (var code in PublicConsts.SIGUNGU_CODES)
            //    {
            //        if (!InsertStatBySigungu(code, stdDt))
            //        {
            //            Logg($"InsertStatBySigungu fail: {code} / {stdDt}");
            //        }
            //    }
            //    foreach (var code in PublicConsts.SIDO_CODES)
            //    {
            //        Application.DoEvents();
            //        if (int.Parse(stdDt) > int.Parse(dtEnd01.Value.ToString("yyyyMM")))
            //            break;
            //        if (!InsertStatByArea(code, stdDt))
            //        {
            //            Logg($"InsertStatByArea fail: {code} / {stdDt}");
            //            return;
            //        }
            //    }
            //    stdDt2 = stdDt2.AddMonths(1);
            //    stdDt = stdDt2.ToString("yyyyMM");
            //}
            //return;
            #endregion

            bool result = true;
            
            //Logg($"기준일: {stdDt}");
            while (int.Parse(stdDt) <= int.Parse(dtEnd01.Value.ToString("yyyyMM")))
            {
                aCount = 1;
                foreach (var code in PublicConsts.SIGUNGU_CODES)
                {
                    lblSigunguCount.Text = $"{stdDt} sigunguCount ({aCount} / {PublicConsts.SIGUNGU_CODES.Count})";
                    Application.DoEvents();
                    if (GetAptPriceData(code, stdDt))
                    {
                        if (!InsertStatBySigungu(code, stdDt))
                        {
                            result = false;
                            Logg($"InsertStatBySigungu fail: {code} / {stdDt}");
                            return;
                        }
                    }
                    else
                    {
                        result = false;
                        Logg($"GetAptPriceData fail: {code} / {stdDt}");
                        return;
                    }
                    aCount++;
                }
                if (result)
                {
                    aCount = 1;
                    foreach (var code in PublicConsts.SIDO_CODES)
                    {
                        lblSidoCount.Text = $"{stdDt} sidoCount ({aCount} / {PublicConsts.SIDO_CODES.Count})";
                        Application.DoEvents();
                        if (int.Parse(stdDt) > int.Parse(dtEnd01.Value.ToString("yyyyMM")))
                            break;
                        if (!InsertStatByArea(code, stdDt))
                        {
                            Logg($"InsertStatByArea fail: {code} / {stdDt}");
                            result = false;
                            return;
                        }
                        aCount++;
                    }
                }
                stdDt2 = stdDt2.AddMonths(1);
                stdDt = stdDt2.ToString("yyyyMM");
            }
            var stdYear = strYear;
            while (stdYear <= endYear)
            {
                aCount = 0;
                foreach (var code in PublicConsts.SIGUNGU_CODES)
                {
                    lblRankUaTypeCount.Text = $"{stdYear} InsertRankUATypeSigungu ({aCount} / {PublicConsts.SIGUNGU_CODES.Count})";
                    Application.DoEvents();
                    InsertRankUATypeSigungu(code, stdYear);
                    aCount++;
                }
                stdYear++;
            }

            if (result)
            {
                if (!chkShutDown.Checked)
                    MessageBox.Show("모든 작업이 성공적으로 완료되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logg("모든 작업이 성공적으로 완료되었습니다.");
            }
            else
            {
                Logg("작업 중 오류가 발생했습니다. 로그를 확인하세요.");
            }
            aSw.Stop();
            CommonFunc.WriteLog($"Elapsed: {aSw.Elapsed}");

            if (chkShutDown.Checked)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "/s /t 0",  // /s: 종료, /t 0: 0초 후 종료
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
        }

        private bool GetAptPriceData(string sigunguCode, string stdDt)
        {
            bool result = false;
            string aResultMsg = string.Empty;
            AptPriceAPI aptPriceAPI = new AptPriceAPI();
            List<AptPriceDto> aptPriceList;
            try
            {
                aptPriceList = aptPriceAPI.AptPriceCall(sigunguCode, stdDt, out aResultMsg);
                if (!string.IsNullOrEmpty(aResultMsg))
                {
                    CommonFunc.WriteLog("API Error: " + aResultMsg);
                    Logg("API Result: " + aResultMsg);
                    return false; // API 호출 실패 시
                }
            }
            catch (Exception ex)
            {
                CommonFunc.WriteLog("API Error: " + ex.Message);
                Logg("API Error: " + ex.Message);
                return false;
            }
            if (aptPriceList == null || aptPriceList.Count == 0)
            {
                CommonFunc.WriteLog($"not exists data stdDt: {stdDt}, sigunguCode: {sigunguCode}, Count: {aptPriceList.Count}");
                return true;
            }

            using (var db = new DBHelper())
            {
                try
                {
                    var deleteSql = "DELETE FROM apt_price WHERE sigungu_code = @sigungu_code AND deal_year = @deal_year AND deal_mon = @deal_mon";
                    var deleteParam = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@sigungu_code", sigunguCode),
                        new NpgsqlParameter("@deal_year", stdDt.Substring(0, 4)),
                        new NpgsqlParameter("@deal_mon", stdDt.Substring(4, 2))
                    };
                    db.ExecuteQuery(deleteSql, deleteParam);

                    CommonFunc.WriteLog($"stdDt: {stdDt}, sigunguCode: {sigunguCode}, Count: {aptPriceList.Count}");
                    if (aptPriceList.Count > 0)
                    {
                        foreach (var apt in aptPriceList)
                        {
                            // 직전거래가 구하기
                            //var selectSql = "SELECT deal_date, deal_amt FROM apt_price "
                            //                + " WHERE sigungu_code = @sigungu_code AND use_area_type = @use_area_type "
                            //                + "   AND apt_name = @apt_name AND build_year = @build_year "
                            //                + "   AND deal_date < @deal_date"
                            //                + " ORDER BY deal_date DESC, deal_amt DESC "
                            //                + " LIMIT 1 ";
                            //var dt = db.SelectQuery(selectSql,
                            //    new NpgsqlParameter("@sigungu_code", apt.sigunguCode),
                            //    new NpgsqlParameter("@use_area_type", apt.useAreaType),
                            //    new NpgsqlParameter("@apt_name", apt.aptName),
                            //    new NpgsqlParameter("@build_year", apt.buildYear),
                            //    new NpgsqlParameter("@deal_date", apt.dealDate));
                            //if (dt.Rows.Count > 0)
                            //{
                            //    apt.prevDealAmt = Convert.ToInt32(dt.Rows[0]["deal_amt"]);
                            //    apt.prevDealDate = dt.Rows[0]["deal_date"].ToString();
                            //    apt.diffAmt = apt.dealAmt - apt.prevDealAmt;
                            //    apt.diffRate = (float)Math.Round((apt.diffAmt / (float)apt.prevDealAmt) * 100, 2);
                            //}
                            //else
                            //{
                            //    // 이전 거래가가 없을 경우
                            //    apt.prevDealAmt = 0;
                            //    apt.prevDealDate = "";
                            //    apt.diffAmt = 0;
                            //    apt.diffRate = 0;
                            //    apt.mostHighestAmt = 0;
                            //    apt.mostLowestAmt = 0;
                            //}
                            //// 신고가 구하기
                            //var selectSql2 = "SELECT deal_date, deal_amt FROM apt_price "
                            //                + " WHERE sigungu_code = @sigungu_code AND use_area_type = @use_area_type "
                            //                + "   AND apt_name = @apt_name AND build_year = @build_year "
                            //                + "   AND deal_date < @deal_date"
                            //                + " ORDER BY deal_amt DESC "
                            //                + " LIMIT 1 ";
                            //var dt2 = db.SelectQuery(selectSql2,
                            //    new NpgsqlParameter("@sigungu_code", apt.sigunguCode),
                            //    new NpgsqlParameter("@use_area_type", apt.useAreaType),
                            //    new NpgsqlParameter("@apt_name", apt.aptName),
                            //    new NpgsqlParameter("@build_year", apt.buildYear),
                            //    new NpgsqlParameter("@deal_date", apt.dealDate));
                            //if (dt2.Rows.Count > 0)
                            //{
                            //    var highestAmt = Convert.ToInt32(dt2.Rows[0]["deal_amt"]);
                            //    if (highestAmt < apt.dealAmt)
                            //    {
                            //        apt.mostHighestAmt = apt.dealAmt;
                            //        apt.newHighestPrice = 1; // 새로운 최고가
                            //    }
                            //    else
                            //    {
                            //        apt.mostHighestAmt = highestAmt;
                            //        apt.newHighestPrice = 0; // 새로운 최고가 아님
                            //    }
                            //}

                            var sql = "INSERT INTO apt_price (area_code, sido_code, sigungu_code "
                                    + ", deal_year, deal_mon, deal_day, deal_date "
                                    + ", apt_name, apt_dong, floor, build_year "
                                    + ", use_area, use_area_int, use_area_type "
                                    + ", deal_amt, prev_deal_amt, prev_deal_date "
                                    + ", diff_amt, diff_rate, most_highest_amt, most_lowest_amt, new_highest_price "
                                    + ", umd_name, jibun, regn_code "
                                    + ", estate_agent_sgg_nm, rgst_date "
                                    + ", deal_gbn, saler_gbn, buyer_gbn "
                                    + ", prev_lease_amt, prev_lease_date "
                                    + ", cncl_deal_type, cncl_deal_date, land_leasehold_gbn) "
                                    + "VALUES (@area_code, @sido_code, @sigungu_code "
                                    + ", @deal_year, @deal_mon, @deal_day, @deal_date "
                                    + ", @apt_name, @apt_dong, @floor, @build_year "
                                    + ", @use_area, @use_area_int, @use_area_type "
                                    + ", @deal_amt, @prev_deal_amt, @prev_deal_date "
                                    + ", @diff_amt, @diff_rate, @most_highest_amt, @most_lowest_amt, @new_highest_price "
                                    + ", @umd_name, @jibun, @regn_code "
                                    + ", @estate_agent_sgg_nm, @rgst_date "
                                    + ", @deal_gbn, @saler_gbn, @buyer_gbn "
                                    + ", @prev_lease_amt, @prev_lease_date "
                                    + ", @cncl_deal_type, @cncl_deal_date, @land_leasehold_gbn)";
                            var parameters = new NpgsqlParameter[]
                            {
                                new NpgsqlParameter("@area_code", apt.areaCode),
                                new NpgsqlParameter("@sido_code", apt.sidoCode),
                                new NpgsqlParameter("@sigungu_code", apt.sigunguCode),
                                new NpgsqlParameter("@deal_year", apt.dealYear),
                                new NpgsqlParameter("@deal_mon", apt.dealMon),
                                new NpgsqlParameter("@deal_day", apt.dealDay),
                                new NpgsqlParameter("@deal_date", apt.dealDate),
                                new NpgsqlParameter("@apt_name", apt.aptName),
                                new NpgsqlParameter("@apt_dong", apt.aptDong ?? ""),
                                new NpgsqlParameter("@floor", apt.floor),
                                new NpgsqlParameter("@build_year", apt.buildYear),
                                new NpgsqlParameter("@use_area", apt.useArea),
                                new NpgsqlParameter("@use_area_int", apt.useAreaInt),
                                new NpgsqlParameter("@use_area_type", apt.useAreaType ?? ""),
                                new NpgsqlParameter("@deal_amt", apt.dealAmt),
                                new NpgsqlParameter("@prev_deal_amt", apt.prevDealAmt),
                                new NpgsqlParameter("@prev_deal_date", apt.prevDealDate ?? ""),
                                new NpgsqlParameter("@diff_amt", apt.diffAmt),
                                new NpgsqlParameter("@diff_rate", apt.diffRate),
                                new NpgsqlParameter("@most_highest_amt", apt.mostHighestAmt),
                                new NpgsqlParameter("@most_lowest_amt", apt.mostLowestAmt),
                                new NpgsqlParameter("@new_highest_price", apt.newHighestPrice),
                                new NpgsqlParameter("@umd_name", apt.umdName ?? ""),
                                new NpgsqlParameter("@jibun", apt.jibun ?? ""),
                                new NpgsqlParameter("@regn_code", ""), // Assuming a constant region code                                
                                new NpgsqlParameter("@estate_agent_sgg_nm", apt.estateAgentSggNm ?? ""),
                                new NpgsqlParameter("@rgst_date", apt.rgstDate ?? ""),
                                new NpgsqlParameter("@deal_gbn", apt.dealGbn ?? ""),
                                new NpgsqlParameter("@saler_gbn", apt.salerGbn ?? ""),
                                new NpgsqlParameter("@buyer_gbn", apt.buyerGbn ?? ""),
                                new NpgsqlParameter("@prev_lease_amt", apt.prevLeaseAmt),
                                new NpgsqlParameter("@prev_lease_date", apt.prevLeaseDate ?? ""),
                                new NpgsqlParameter("@cncl_deal_type", apt.cnclDealType ?? ""),
                                new NpgsqlParameter("@cncl_deal_date", apt.cnclDealDate ?? ""),
                                new NpgsqlParameter("@land_leasehold_gbn", apt.landLeaseholdGbn ?? "")
                            };
                            db.ExecuteQuery(sql, parameters);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonFunc.WriteLog("GetAptPriceData Exception: " + ex.Message);
                    Logg("GetAptPriceData Exception: " + ex.Message);
                }
            }
            result = true;
            return result;
        }

        private bool InsertStatBySigungu(string sigunguCode, string stdDt)
        {
            bool result = false;
            string aYear = stdDt.Substring(0, 4);
            string aMonth = stdDt.Substring(4, 2);
            using (var db = new DBHelper())
            {
                try
                {
                    var deleteSql = "DELETE FROM stat_sigungu_yymm WHERE sigungu_code = @sigungu_code AND deal_yymm = @deal_year || '-' || @deal_mon; ";
                    var deleteParam = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@sigungu_code", sigunguCode),
                        new NpgsqlParameter("@deal_year", stdDt.Substring(0, 4)),
                        new NpgsqlParameter("@deal_mon", stdDt.Substring(4, 2))
                    };
                    db.ExecuteQuery(deleteSql, deleteParam);

                    // 시군구별 평형대별 통계
                    var sql = "INSERT INTO stat_sigungu_yymm (sigungu_code, sigungu_name, deal_year, deal_yymm, use_area_type, min_price, avg_price, max_price, total_count, new_highest_count, new_highest_rate) "
                            + "SELECT sigungu_code, get_area_name(sigungu_code), "
                            + "       MIN(deal_year) AS deal_year, "
                            + "       MIN(deal_year) || '-' || min(deal_mon) AS deal_yymm, use_area_type, "
                            + "       MIN(deal_amt) AS min_price, "
                            + "       AVG(deal_amt) AS avg_price, "
                            + "       MAX(deal_amt) AS max_price, "
                            + "       COUNT(*) AS total_count, "
                            + "       SUM(new_highest_price) AS new_highest_count, "
                            + "       (SUM(new_highest_price)::float / COUNT(*)) * 100 AS new_highest_rate "
                            + "FROM apt_price "
                            + "WHERE sigungu_code = @sigungu_code AND deal_year = @deal_year AND deal_mon = @deal_mon "
                            + "GROUP BY sigungu_code, use_area_type;";
                    var parameters = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@sigungu_code", sigunguCode),
                        new NpgsqlParameter("@deal_year", aYear),
                        new NpgsqlParameter("@deal_mon", aMonth)
                    };
                    db.ExecuteQuery(sql, parameters);
                    // 시군구별 전체평형 통계
                    sql = "INSERT INTO stat_sigungu_yymm (sigungu_code, sigungu_name, deal_year, deal_yymm, use_area_type, min_price, avg_price, max_price, total_count, new_highest_count, new_highest_rate) "
                            + "SELECT sigungu_code, get_area_name(sigungu_code), "
                            + "       MIN(deal_year) AS deal_year, "
                            + "       MIN(deal_year) || '-' || min(deal_mon) AS deal_yymm, 'UA00',"
                            + "       MIN(deal_amt) AS min_price, "
                            + "       AVG(deal_amt) AS avg_price, "
                            + "       MAX(deal_amt) AS max_price, "
                            + "       COUNT(*) AS total_count, "
                            + "       SUM(new_highest_price) AS new_highest_count, "
                            + "       (SUM(new_highest_price)::float / COUNT(*)) * 100 AS new_highest_rate "
                            + "FROM apt_price "
                            + "WHERE sigungu_code = @sigungu_code AND deal_year = @deal_year AND deal_mon = @deal_mon "
                            + "GROUP BY sigungu_code;";
                    parameters = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@sigungu_code", sigunguCode),
                        new NpgsqlParameter("@deal_year", aYear),
                        new NpgsqlParameter("@deal_mon", aMonth)
                    };
                    db.ExecuteQuery(sql, parameters);

                    result = true;
                }
                catch (Exception ex)
                {
                    CommonFunc.WriteLog("InsertStatBySigungu 오류 발생: " + ex.Message);
                    Logg("오류 발생: " + ex.Message);
                }
            }
            return result;
        }

        private bool InsertStatByArea(string areaCode, string stdDt)
        {
            bool result = false;
            string aYear = stdDt.Substring(0, 4);
            string aMonth = stdDt.Substring(4, 2);
            using (var db = new DBHelper())
            {
                try
                {
                    var deleteSql = "DELETE FROM stat_area_yymm WHERE area_code = @area_code AND deal_yymm = @deal_year || '-' || @deal_mon; ";
                    var deleteParam = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@area_code", areaCode),
                        new NpgsqlParameter("@deal_year", stdDt.Substring(0, 4)),
                        new NpgsqlParameter("@deal_mon", stdDt.Substring(4, 2))
                    };
                    db.ExecuteQuery(deleteSql, deleteParam);

                    // 시별 평형대별 통계
                    var sql = "INSERT INTO stat_area_yymm (area_code, area_name, deal_year, deal_yymm, use_area_type, min_price, avg_price, max_price, total_count, new_highest_count, new_highest_rate) "
                            + "SELECT area_code, get_area_name(area_code), "
                            + "       MIN(deal_year) AS deal_year, "
                            + "       MIN(deal_year) || '-' || min(deal_mon) AS deal_yymm, use_area_type, "
                            + "       MIN(deal_amt) AS min_price, "
                            + "       AVG(deal_amt) AS avg_price, "
                            + "       MAX(deal_amt) AS max_price, "
                            + "       COUNT(*) AS total_count, "
                            + "       SUM(new_highest_price) AS new_highest_count, "
                            + "       (SUM(new_highest_price)::float / COUNT(*)) * 100 AS new_highest_rate "
                            + "FROM apt_price "
                            + "WHERE area_code = @area_code AND deal_year = @deal_year AND deal_mon = @deal_mon "
                            + "GROUP BY area_code, use_area_type;";
                    var parameters = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@area_code", areaCode),
                        new NpgsqlParameter("@deal_year", aYear),
                        new NpgsqlParameter("@deal_mon", aMonth)
                    };
                    db.ExecuteQuery(sql, parameters);

                    // 시별 전체평형 통계
                    sql = "INSERT INTO stat_area_yymm (area_code, area_name, deal_year, deal_yymm, use_area_type, min_price, avg_price, max_price, total_count, new_highest_count, new_highest_rate) "
                            + "SELECT area_code, get_area_name(area_code),"
                            + "       MIN(deal_year) AS deal_year, "
                            + "       MIN(deal_year) || '-' || min(deal_mon) AS deal_yymm, 'UA00', "
                            + "       MIN(deal_amt) AS min_price, "
                            + "       AVG(deal_amt) AS avg_price, "
                            + "       MAX(deal_amt) AS max_price, "
                            + "       COUNT(*) AS total_count, "
                            + "       SUM(new_highest_price) AS new_highest_count, "
                            + "       (SUM(new_highest_price)::float / COUNT(*)) * 100 AS new_highest_rate "
                            + "FROM apt_price "
                            + "WHERE area_code = @area_code AND deal_year = @deal_year AND deal_mon = @deal_mon "
                            + "GROUP BY area_code;";
                    parameters = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@area_code", areaCode),
                        new NpgsqlParameter("@deal_year", aYear),
                        new NpgsqlParameter("@deal_mon", aMonth)
                    };
                    db.ExecuteQuery(sql, parameters);

                    result = true;
                }
                catch (Exception ex)
                {
                    CommonFunc.WriteLog("InsertStatByArea 오류 발생: " + ex.Message);
                    Logg("오류 발생: " + ex.Message);
                }
            }
            return result;
        }

        private bool InsertRankUATypeSigungu(string MCode, int MYear)
        {
            bool result = false;
            using (var db = new DBHelper())
            {
                try
                {
                    var deleteSql = "DELETE FROM rank_uatype_sigungu WHERE sigungu_code = @sigungu_code AND deal_year = @deal_year; ";
                    var deleteParam = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@sigungu_code", MCode),
                        new NpgsqlParameter("@deal_year", MYear.ToString())
                    };
                    db.ExecuteQuery(deleteSql, deleteParam);
                    string sql = string.Empty;
                    NpgsqlParameter[] parameters = null;

                    for (var ix = 1; ix <= 7; ix++)
                    {
                        var useAreaType = $"UA0{ix}";
                        // 시군구별 평형대별 통계
                        sql = "INSERT INTO rank_uatype_sigungu "
                                + "  (rank_type, deal_year, area_code, sigungu_code, sigungu_name"
                                + " , land_dong, apt_name , use_area_type, build_year, trade_count"
                                + " , min_amt, avg_amt, max_amt) "
                                + " SELECT 0, MIN(deal_year), MIN(area_code), MIN(sigungu_code), get_area_name(MIN(sigungu_code))"
                                + "     , umd_name, apt_name, MIN(use_area_type), MIN(build_year), COUNT(1)"
                                + "     , MIN(deal_amt), trunc(AVG(deal_amt), -2) as avg_amt, MAX(deal_amt) "
                                + " FROM apt_price "
                                + " WHERE use_area_type = @use_area_type AND sigungu_code = @sigungu_code AND deal_year = @deal_year "
                                + " GROUP BY sigungu_code, umd_name, apt_name"
                                + " ORDER BY avg_amt desc limit 20;";
                        parameters = new NpgsqlParameter[]
                        {
                            new NpgsqlParameter("@sigungu_code", MCode),
                            new NpgsqlParameter("@deal_year", MYear.ToString()),
                            new NpgsqlParameter("@use_area_type", useAreaType)
                        };
                        db.ExecuteQuery(sql, parameters);
                    }
                    // 시군구별 평형대별 통계
                    sql = "INSERT INTO rank_uatype_sigungu "
                            + "  (rank_type, deal_year, area_code, sigungu_code, sigungu_name"
                            + " , land_dong, apt_name , use_area_type, build_year, trade_count"
                            + " , min_amt, avg_amt, max_amt) "
                            + " SELECT 0, MIN(deal_year), MIN(area_code), MIN(sigungu_code), get_area_name(MIN(sigungu_code))"
                            + "     , umd_name, apt_name, 'UA00', MIN(build_year), COUNT(1)"
                            + "     , MIN(deal_amt), trunc(AVG(deal_amt), -2) as avg_amt, MAX(deal_amt) "
                            + " FROM apt_price "
                            + " WHERE sigungu_code = @sigungu_code AND deal_year = @deal_year "
                            + " GROUP BY sigungu_code, umd_name, apt_name "
                            + " ORDER BY avg_amt desc limit 20;";
                    parameters = new NpgsqlParameter[]
                    {
                            new NpgsqlParameter("@sigungu_code", MCode),
                            new NpgsqlParameter("@deal_year", MYear.ToString())
                    };
                    db.ExecuteQuery(sql, parameters);

                    for (var ix = 1; ix <= 7; ix++)
                    {
                        var useAreaType = $"UA0{ix}";
                        sql = "INSERT INTO rank_uatype_sigungu "
                                + "  (rank_type, deal_year, area_code, sigungu_code, sigungu_name"
                                + " , land_dong, apt_name , use_area_type, build_year, trade_count"
                                + " , min_amt, avg_amt, max_amt) "
                                + " SELECT 1, MIN(deal_year), MIN(area_code), MIN(sigungu_code), get_area_name(MIN(sigungu_code))"
                                + "     , umd_name, apt_name, MIN(use_area_type), MIN(build_year), COUNT(1) as trade_cnt"
                                + "     , MIN(deal_amt), trunc(AVG(deal_amt), -2) as avg_amt, MAX(deal_amt) "
                                + " FROM apt_price "
                                + " WHERE use_area_type = @use_area_type AND sigungu_code = @sigungu_code AND deal_year = @deal_year "
                                + " GROUP BY sigungu_code, umd_name, apt_name"
                                + " ORDER BY trade_cnt desc limit 20;";
                        parameters = new NpgsqlParameter[]
                        {
                            new NpgsqlParameter("@sigungu_code", MCode),
                            new NpgsqlParameter("@deal_year", MYear.ToString()),
                            new NpgsqlParameter("@use_area_type", useAreaType)
                        };
                        db.ExecuteQuery(sql, parameters);
                    }
                    sql = "INSERT INTO rank_uatype_sigungu "
                            + "  (rank_type, deal_year, area_code, sigungu_code, sigungu_name"
                            + " , land_dong, apt_name , use_area_type, build_year, trade_count"
                            + " , min_amt, avg_amt, max_amt) "
                            + " SELECT 1, MIN(deal_year), MIN(area_code), MIN(sigungu_code), get_area_name(MIN(sigungu_code))"
                            + "     , umd_name, apt_name, 'UA00', MIN(build_year), COUNT(1) as trade_cnt"
                            + "     , MIN(deal_amt), trunc(AVG(deal_amt), -2) as avg_amt, MAX(deal_amt) "
                            + " FROM apt_price "
                            + " WHERE sigungu_code = @sigungu_code AND deal_year = @deal_year "
                            + " GROUP BY sigungu_code, umd_name, apt_name"
                            + " ORDER BY trade_cnt desc limit 20;";
                    parameters = new NpgsqlParameter[]
                    {
                            new NpgsqlParameter("@sigungu_code", MCode),
                            new NpgsqlParameter("@deal_year", MYear.ToString())
                    };
                    db.ExecuteQuery(sql, parameters);
                    result = true;
                }
                catch (Exception ex)
                {
                    CommonFunc.WriteLog("InsertRankUAType Sigungu 오류 발생: " + ex.Message);
                }
            }
            return result;
        }

        private void btnDtEnd01Dn_Click(object sender, EventArgs e)
        {
            if (cbxDt01Type.SelectedIndex == 0) { dtEnd01.Value = dtEnd01.Value.AddYears(-1); }
            else { dtEnd01.Value = dtEnd01.Value.AddMonths(-1); }
        }

        private void btnDtEnd01Up_Click(object sender, EventArgs e)
        {
            if (cbxDt01Type.SelectedIndex == 0) { dtEnd01.Value = dtEnd01.Value.AddYears(1); }
            else { dtEnd01.Value = dtEnd01.Value.AddMonths(1); }
        }
    }
}
