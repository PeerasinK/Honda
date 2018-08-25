﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using IMClass;
using System.Drawing;
using System.IO;
using System.Data;
using System.Collections;
using System.Text;

namespace HondaTraceabilitySystem
{
    public partial class MstItemMnt : System.Web.UI.Page
    {
        protected string g_user_id;
        protected int g_lang;
        protected string g_company_cd;
        protected string g_name;

        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie MyCookie;
            //try
            //{
            //    MyCookie = new HttpCookie("IMLastVisit");
            //    HttpCookieCollection MyCookieColl = Request.Cookies;
            //    MyCookie = MyCookieColl.Get("IMLastVisit");

            //    g_user_id = MyCookie.Values["USER_ID"];
            //    g_lang = int.Parse(MyCookie.Values["LANG"]);
            //    g_company_cd = MyCookie.Values["COMPANY_CD"];
            //    g_name = HttpUtility.UrlDecode(MyCookie.Values["NAME"]);
            //}
            //catch
            //{
            //    Response.Redirect("~/NotLoginErr.htm");
            //}
            // 検索画面追加[初期処理より処理の前に記述]
            //g_user_id = "admin-e";
            g_lang = 2;
            //g_name = "General manager (English)";
            //Add_Search();
            Page.Form.DefaultButton = cmdDisp.UniqueID;
            if (!IsPostBack)
            {
                //// 画面編集
                Init_Label();
                Init_Proc();
            }
            else
            {
                dgvItemWS_Data();
                dgvRoutine_Data();
                //dvgPurchase_Data();
                dgvPurPrice_Data();
                dgvStdPrice_Data();
            }

            lblMsg.Text = "";
        }

        /// <summary>
        /// 初期画面ラベル編集
        /// </summary>
        protected void Init_Label()
        {
            ShowPanel(pnlSUB2, true, 50, 50);
            //Dictionary dic = new Dictionary(g_user_id, g_lang);
            //dic.screen_id = "MstItemMnt_frmMain";
            //DataSet ds = dic.GetLabelOfScreenList();

            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        switch (row["CONTROL_ID"].ToString())
            //        {
            //            // ラベル
            //            case "flblTitle": flblTitle.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblITEM_NO": flblITEM_NO.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblITEM_DESC": flblITEM_DESC.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblITEM_DESC2": flblITEM_DESC2.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblDRAWING_NO": flblDRAWING_NO.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblCATG_CD": flblCATG_CD.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblSPEC_DESC": flblSPEC_DESC.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblREMARKS": flblREMARKS.Text = row["ITEM_DESC"].ToString(); break;
            //            case "flblITEM_TYPE": flblITEM_TYPE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblPO_STOP_FLAG": flblPO_STOP_FLAG.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            case "flblSCH_ID": flblSCH_ID.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblPO_TYPE": flblPO_TYPE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblITEM_UMSR": flblITEM_UMSR.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblREORDER_POINT": flblREORDER_POINT.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblAUTO_DISB_TYPE": flblAUTO_DISB_TYPE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblDEMAND_ROUD_TYPE": flblDEMAND_ROUD_TYPE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblDISB_LOT_SIZE": flblDISB_LOT_SIZE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblPUR_LOT_SIZE": flblPUR_LOT_SIZE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblPUR_LOT_SIZE": flblPUR_LOT_SIZE.Text = row["ITEM_DESC"].ToString(); break;  // 2015.08.13
            //            //case "flblDEMAND_PERIOD": flblDEMAND_PERIOD.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblSAFETY_STOCK_TYPE": flblSAFETY_STOCK_TYPE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblSAFETY_STOCK": flblSAFETY_STOCK.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblSAFETY_STOCK_RATIO": flblSAFETY_STOCK_RATIO.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblSAFETY_STOCK_DAYS": flblSAFETY_STOCK_DAYS.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblSS_CALC_CONDTN": flblSS_CALC_CONDTN.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblSS_INV_CONDTN": flblSS_INV_CONDTN.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblPLANT_LT": flblPLANT_LT.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblBACKWD_ALLOWANCE_DAYS": flblBACKWD_ALLOWANCE_DAYS.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblORDER_CONTROL_FLAG": flblORDER_CONTROL_FLAG.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblDISB_WHS": flblDISB_WHS.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblBOND_TYPE": flblBOND_TYPE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblLOCATION": flblLOCATION.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblITEM_ABC_CD": flblITEM_ABC_CD.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblEXP_DATE": flblEXP_DATE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblLOT_CNTL_FLAG": flblLOT_CNTL_FLAG.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblNEG_BAL_FLAG": flblNEG_BAL_FLAG.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblITEM_IMAGE": flblITEM_IMAGE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblITEM_IMAGE1": flblITEM_IMAGE1.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblASSY_IMAGE": flblASSY_IMAGE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblASSY_IMAGE1": flblASSY_IMAGE1.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblMIN_PUR_QTY": flblMIN_PUR_QTY.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblITEM_ADDN_ORDER_RATIO": flblITEM_ADDN_ORDER_RATIO.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblBOND_DISB_WHS": flblBOND_DISB_WHS.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblSUPPLY_TYPE": flblSUPPLY_TYPE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblWIP_TYPE": flblWIP_TYPE.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblPUR_PERIOD": flblPUR_PERIOD.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "flblDAY":  // IMV3 COMMENT OUT
            //            //    flblDay1.Text = row["ITEM_DESC"].ToString();
            //            //    flblDay2.Text = row["ITEM_DESC"].ToString();
            //            //    flbldate1.Text = row["ITEM_DESC"].ToString();
            //            //    flbldate2.Text = row["ITEM_DESC"].ToString();
            //            //    break;
            //            //
            //            //case "flblDATA_CHAR1": flblDATA_CHAR1.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR2": flblDATA_CHAR2.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR3": flblDATA_CHAR3.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR4": flblDATA_CHAR4.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR5": flblDATA_CHAR5.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR6": flblDATA_CHAR6.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR7": flblDATA_CHAR7.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR8": flblDATA_CHAR8.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR9": flblDATA_CHAR9.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_CHAR10": flblDATA_CHAR10.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM1": flblDATA_NUM1.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM2": flblDATA_NUM2.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM3": flblDATA_NUM3.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM4": flblDATA_NUM4.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM5": flblDATA_NUM5.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM6": flblDATA_NUM6.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM7": flblDATA_NUM7.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM8": flblDATA_NUM8.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM9": flblDATA_NUM9.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_NUM10": flblDATA_NUM10.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG1": flblDATA_FLAG1.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG2": flblDATA_FLAG2.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG3": flblDATA_FLAG3.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG4": flblDATA_FLAG4.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG5": flblDATA_FLAG5.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG6": flblDATA_FLAG6.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG7": flblDATA_FLAG7.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG8": flblDATA_FLAG8.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG9": flblDATA_FLAG9.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "flblDATA_FLAG10": flblDATA_FLAG10.Text = row["ITEM_DESC"].ToString(); break;
            //            //ADD UBIQ-LIU 2010/8/17
            //            //case "flblITEM_ADDN_RCV_RATIO": flblITEM_ADDN_RCV_RATIO.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //
            //            //case "btnITEM_IMAGE": btnITEM_IMAGE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "btnASSY_IMAGE": btnASSY_IMAGE.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "btnItemWS": btnItemWS.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "btnRoutine": btnRoutine.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "btnPurchase": btnPurchase.Text = row["ITEM_DESC"].ToString(); break;
            //            //case "btnPurPrice": btnPurPrice.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            //case "btnStdPrice": btnStdPrice.Text = row["ITEM_DESC"].ToString(); break;  // IMV3 COMMENT OUT
            //            // 
            //            //case "rdoITEM_TYPE_0": rdoITEM_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoITEM_TYPE_1": rdoITEM_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoITEM_TYPE_2": rdoITEM_TYPE.Items[2].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoITEM_TYPE_3": rdoITEM_TYPE.Items[3].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoITEM_TYPE_4": rdoITEM_TYPE.Items[4].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoITEM_TYPE_5": rdoITEM_TYPE.Items[5].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoITEM_TYPE_6": rdoITEM_TYPE.Items[6].Text = row["ITEM_DESC"].ToString(); break;
            //            //  // IMV3 COMMENT OUT 
            //            //case "rdoPO_STOP_FLAG_0": rdoPO_STOP_FLAG.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoPO_STOP_FLAG_1": rdoPO_STOP_FLAG.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //            //  // IMV3 COMMENT OUT
            //            //case "rdoPO_TYPE_0": rdoPO_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoPO_TYPE_1": rdoPO_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoPO_TYPE_2": rdoPO_TYPE.Items[2].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoPO_TYPE_3": rdoPO_TYPE.Items[3].Text = row["ITEM_DESC"].ToString(); break;
            //            //  // IMV3 COMMENT OUT
            //            //case "rdoAUTO_DISB_TYPE_0": rdoAUTO_DISB_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //            //case "rdoAUTO_DISB_TYPE_1": rdoAUTO_DISB_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //            case "dgvSearch_1": this.dgvSearch.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
            //            case "dgvSearch_2": this.dgvSearch.Columns[3].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoDEMAND_ROUD_TYPE_0": rdoDEMAND_ROUD_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoDEMAND_ROUD_TYPE_1": rdoDEMAND_ROUD_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoSAFETY_STOCK_TYPE_0": rdoSAFETY_STOCK_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoSAFETY_STOCK_TYPE_1": rdoSAFETY_STOCK_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoSS_CALC_CONDTN_0": rdoSS_CALC_CONDTN.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoSS_CALC_CONDTN_1": rdoSS_CALC_CONDTN.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoSS_INV_CONDTN_0": rdoSS_INV_CONDTN.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoSS_INV_CONDTN_1": rdoSS_INV_CONDTN.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoORDER_CONTROL_FLAG_0": rdoORDER_CONTROL_FLAG.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoORDER_CONTROL_FLAG_1": rdoORDER_CONTROL_FLAG.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoSUPPLY_TYPE_0": rdoSUPPLY_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoSUPPLY_TYPE_1": rdoSUPPLY_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoSUPPLY_TYPE_2": rdoSUPPLY_TYPE.Items[2].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoSUPPLY_TYPE_3": rdoSUPPLY_TYPE.Items[3].Text = row["ITEM_DESC"].ToString(); break;
            //                //
            //                //case "rdoLOT_CNTL_FLAG_0": rdoLOT_CNTL_FLAG.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoLOT_CNTL_FLAG_1": rdoLOT_CNTL_FLAG.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT
            //                //case "rdoNEG_BAL_FLAG_0": rdoNEG_BAL_FLAG.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoNEG_BAL_FLAG_1": rdoNEG_BAL_FLAG.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //  // IMV3 COMMENT OUT   
            //                //case "rdoWIP_TYPE_0": rdoWIP_TYPE.Items[0].Text = row["ITEM_DESC"].ToString(); break;
            //                //case "rdoWIP_TYPE_1": rdoWIP_TYPE.Items[1].Text = row["ITEM_DESC"].ToString(); break;
            //                //GridView HeadText  // IMV3 COMMENT OUT
            //                //case "dgvItemWS_0": dgvItemWS.Columns[0].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_1": dgvItemWS.Columns[1].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_2": dgvItemWS.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_3": dgvItemWS.Columns[3].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_4": dgvItemWS.Columns[4].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_5": dgvItemWS.Columns[5].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_6": dgvItemWS.Columns[6].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_7": dgvItemWS.Columns[7].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_8": dgvItemWS.Columns[8].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvItemWS_9": dgvItemWS.Columns[9].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //dgvRoutine  // IMV3 COMMENT OUT
            //                //case "dgvRoutine_0": dgvRoutine.Columns[0].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_1": dgvRoutine.Columns[1].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_2": dgvRoutine.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_3": dgvRoutine.Columns[3].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_4": dgvRoutine.Columns[4].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_5": dgvRoutine.Columns[5].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_6": dgvRoutine.Columns[6].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_7": dgvRoutine.Columns[7].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_8": dgvRoutine.Columns[8].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_9": dgvRoutine.Columns[9].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvRoutine_10": dgvRoutine.Columns[10].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //dvgPurchase
            //                //case "dvgPurchase_0": dvgPurchase.Columns[0].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_1": dvgPurchase.Columns[1].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_2": dvgPurchase.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_3": dvgPurchase.Columns[3].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_4": dvgPurchase.Columns[4].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_5": dvgPurchase.Columns[5].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_6": dvgPurchase.Columns[6].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_7": dvgPurchase.Columns[7].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_8": dvgPurchase.Columns[8].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_9": dvgPurchase.Columns[9].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dvgPurchase_10": dvgPurchase.Columns[10].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //dgvPurPrice  // IMV3 COMMENT OUT
            //                //case "dgvPurPrice_0": dgvPurPrice.Columns[0].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_1": dgvPurPrice.Columns[1].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_2": dgvPurPrice.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_3": dgvPurPrice.Columns[3].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_4": dgvPurPrice.Columns[4].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_5": dgvPurPrice.Columns[5].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_6": dgvPurPrice.Columns[7].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_7": dgvPurPrice.Columns[9].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_8": dgvPurPrice.Columns[10].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvPurPrice_9": dgvPurPrice.Columns[12].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //dgvStdPrice  // IMV3 COMMENT OUT
            //                //case "dgvStdPrice_0": dgvStdPrice.Columns[0].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvStdPrice_1": dgvStdPrice.Columns[1].HeaderText = row["ITEM_DESC"].ToString(); break;
            //                //case "dgvStdPrice_2": dgvStdPrice.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
            //        }
            //    }
            //}
            ////
            //switch (g_lang)
            //{
            //    case 1:
            //        //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-1.jpg";
            //        //cmdDisp.Attributes["onmouseover"] = "MM_swapImage('" + cmdDisp.ClientID + "','','../../Contents/Image/BackGround/btn-ind2-1.jpg',1);";
            //        //cmdDisp.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-1.jpg";
            //        //cmdUpdate.Attributes["onmouseover"] = "MM_swapImage('" + cmdUpdate.ClientID + "','','../../Contents/Image/BackGround/btn-update2-1.jpg',1);";
            //        //cmdUpdate.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdCancel.ImageUrl = "../../Contents/Image/BackGround/btn-cancel1-1.jpg";
            //        //cmdCancel.Attributes["onmouseover"] = "MM_swapImage('" + cmdCancel.ClientID + "','','../../Contents/Image/BackGround/btn-cancel2-1.jpg',1);";
            //        //cmdCancel.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        break;
            //    case 2:
            //        //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-2.jpg";
            //        //cmdDisp.Attributes["onmouseover"] = "MM_swapImage('" + cmdDisp.ClientID + "','','../../Contents/Image/BackGround/btn-ind2-2.jpg',1);";
            //        //cmdDisp.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-2.jpg";
            //        //cmdUpdate.Attributes["onmouseover"] = "MM_swapImage('" + cmdUpdate.ClientID + "','','../../Contents/Image/BackGround/btn-update2-2.jpg',1);";
            //        //cmdUpdate.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdCancel.ImageUrl = "../../Contents/Image/BackGround/btn-cancel1-2.jpg";
            //        //cmdCancel.Attributes["onmouseover"] = "MM_swapImage('" + cmdCancel.ClientID + "','','../../Contents/Image/BackGround/btn-cancel2-2.jpg',1);";
            //        //cmdCancel.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        break;
            //    case 3:
            //        //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-3.jpg";
            //        //cmdDisp.Attributes["onmouseover"] = "MM_swapImage('" + cmdDisp.ClientID + "','','../../Contents/Image/BackGround/btn-ind2-3.jpg',1);";
            //        //cmdDisp.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-3.jpg";
            //        //cmdUpdate.Attributes["onmouseover"] = "MM_swapImage('" + cmdUpdate.ClientID + "','','../../Contents/Image/BackGround/btn-update2-3.jpg',1);";
            //        //cmdUpdate.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdCancel.ImageUrl = "../../Contents/Image/BackGround/btn-cancel1-3.jpg";
            //        //cmdCancel.Attributes["onmouseover"] = "MM_swapImage('" + cmdCancel.ClientID + "','','../../Contents/Image/BackGround/btn-cancel2-3.jpg',1);";
            //        //cmdCancel.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        break;
            //    case 4:
            //        //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-4.jpg";
            //        //cmdDisp.Attributes["onmouseover"] = "MM_swapImage('" + cmdDisp.ClientID + "','','../../Contents/Image/BackGround/btn-ind2-4.jpg',1);";
            //        //cmdDisp.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-4.jpg";
            //        //cmdUpdate.Attributes["onmouseover"] = "MM_swapImage('" + cmdUpdate.ClientID + "','','../../Contents/Image/BackGround/btn-update2-4.jpg',1);";
            //        //cmdUpdate.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        //cmdCancel.ImageUrl = "../../Contents/Image/BackGround/btn-cancel1-4.jpg";
            //        //cmdCancel.Attributes["onmouseover"] = "MM_swapImage('" + cmdCancel + "','','../../Contents/Image/BackGround/btn-cancel2-4.jpg',1);";
            //        //cmdCancel.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //        break;
            //}
            //btnITEMSearch.Attributes["onmouseover"] = "MM_swapImage('" + btnITEMSearch.ClientID + "','','../../Contents/Image/BackGround/sbtn_srch_f2.gif',1);";
            //btnITEMSearch.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //btnOutStorage.Attributes["onmouseover"] = "MM_swapImage('" + btnOutStorage.ClientID + "','','../../Contents/Image/BackGround/sbtn_search_w2.gif',1);";
            //btnOutStorage.Attributes["onmouseout"] = "MM_swapImgRestore();";
            //btnOutStorageBond.Attributes["onmouseover"] = "MM_swapImage('" + btnOutStorageBond.ClientID + "','','../../Contents/Image/BackGround/sbtn_search_w2.gif',1);";
            //btnOutStorageBond.Attributes["onmouseout"] = "MM_swapImgRestore();";

            //APicture.Style.Add("display", "none");
            //IPicture.Style.Add("display", "none");
            flblTitle.Text = "Part Master";
            Init_Mode();
        }

        /// <summary>
        /// モード系ボタンイメージの編集
        /// </summary>
        protected void Init_Mode()
        {
            //
            // モード系ボタンイメージの編集     －      言語対応とSwapImage
            //
            switch (g_lang)
            {
                case 1:
                    //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq1-1.jpg";
                    //btnMdsp.Attributes["onmouseover"] = "MM_swapImage('" + btnMdsp.ClientID + "','','../../Contents/Image/BackGround/btn-inq2-1.jpg',1);";
                    //btnMdsp.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new1-1.jpg";
                    //btnMadd.Attributes["onmouseover"] = "MM_swapImage('" + btnMadd.ClientID + "','','../../Contents/Image/BackGround/btn-new2-1.jpg',1);";
                    //btnMadd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change1-1.jpg";
                    //btnMupd.Attributes["onmouseover"] = "MM_swapImage('" + btnMupd.ClientID + "','','../../Contents/Image/BackGround/btn-change2-1.jpg',1);";
                    //btnMupd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete1-1.jpg";
                    //btnMdel.Attributes["onmouseover"] = "MM_swapImage('" + btnMdel.ClientID + "','','../../Contents/Image/BackGround/btn-delete2-1.jpg',1);";
                    //btnMdel.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
                case 2:
                    //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq1-2.jpg";
                    //btnMdsp.Attributes["onmouseover"] = "MM_swapImage('" + btnMdsp.ClientID + "','','../../Contents/Image/BackGround/btn-inq2-2.jpg',1);";
                    //btnMdsp.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new1-2.jpg";
                    //btnMadd.Attributes["onmouseover"] = "MM_swapImage('" + btnMadd.ClientID + "','','../../Contents/Image/BackGround/btn-new2-2.jpg',1);";
                    //btnMadd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change1-2.jpg";
                    //btnMupd.Attributes["onmouseover"] = "MM_swapImage('" + btnMupd.ClientID + "','','../../Contents/Image/BackGround/btn-change2-2.jpg',1);";
                    //btnMupd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete1-2.jpg";
                    //btnMdel.Attributes["onmouseover"] = "MM_swapImage('" + btnMdel.ClientID + "','','../../Contents/Image/BackGround/btn-delete2-2.jpg',1);";
                    //btnMdel.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
                case 3:
                    //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq1-3.jpg";
                    //btnMdsp.Attributes["onmouseover"] = "MM_swapImage('" + btnMdsp.ClientID + "','','../../Contents/Image/BackGround/btn-inq2-3.jpg',1);";
                    //btnMdsp.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new1-3.jpg";
                    //btnMadd.Attributes["onmouseover"] = "MM_swapImage('" + btnMadd.ClientID + "','','../../Contents/Image/BackGround/btn-new2-3.jpg',1);";
                    //btnMadd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change1-3.jpg";
                    //btnMupd.Attributes["onmouseover"] = "MM_swapImage('" + btnMupd.ClientID + "','','../../Contents/Image/BackGround/btn-change2-3.jpg',1);";
                    //btnMupd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete1-3.jpg";
                    //btnMdel.Attributes["onmouseover"] = "MM_swapImage('" + btnMdel.ClientID + "','','../../Contents/Image/BackGround/btn-delete2-3.jpg',1);";
                    //btnMdel.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
                case 4:
                    //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq1-4.jpg";
                    //btnMdsp.Attributes["onmouseover"] = "MM_swapImage('" + btnMdsp.ClientID + "','','../../Contents/Image/BackGround/btn-inq2-4.jpg',1);";
                    //btnMdsp.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new1-4.jpg";
                    //btnMadd.Attributes["onmouseover"] = "MM_swapImage('" + btnMadd.ClientID + "','','../../Contents/Image/BackGround/btn-new2-4.jpg',1);";
                    //btnMadd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change1-4.jpg";
                    //btnMupd.Attributes["onmouseover"] = "MM_swapImage('" + btnMupd.ClientID + "','','../../Contents/Image/BackGround/btn-change2-4.jpg',1);";
                    //btnMupd.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete1-4.jpg";
                    //btnMdel.Attributes["onmouseover"] = "MM_swapImage('" + btnMdel.ClientID + "','','../../Contents/Image/BackGround/btn-delete2-4.jpg',1);";
                    //btnMdel.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
            }

        }

        /// <summary>
        /// 初期画面編集
        /// </summary>
        protected void Init_Proc()
        {
            // 初期状態は照会モードとする
            hdnInputMode.Value = "0";
            ddl_edit();
            Screen_Control("0");
            Edit_Grid();
        }

        /// <summary>
        /// EDIT DROP DOWN LIST
        /// </summary>
        protected void ddl_edit()
        {
            DataSet dt = new DataSet();
            ComLibrary com = new ComLibrary();

            //SystemParameter parameter = new SystemParameter(g_user_id, g_lang);
            //parameter.key01 = "CATG_CD";
            //dt = parameter.GetDetailList();

            //ddlCATG_CD.DataValueField = "KEY02";
            //ddlCATG_CD.DataTextField = "DATA_CHAR";
            //ddlCATG_CD.DataSource = dt;
            //ddlCATG_CD.DataBind();
            //ddlCATG_CD.Items.Insert(0, new ListItem(""));

            // IMV3 COMMENT OUT
            //dt = null;
            //parameter.key01 = "SCH_ID";
            //dt = parameter.GetDetailList();
            // IMV3 COMMENT OUT
            //ddlSCH_ID.DataValueField = "KEY02";
            //ddlSCH_ID.DataTextField = "DATA_CHAR";
            //ddlSCH_ID.DataSource = dt;
            //ddlSCH_ID.DataBind();
            //ddlSCH_ID.Items.Insert(0, new ListItem(""));

            //dt = null;
            //parameter.key01 = "ITEM_UMSR";
            //dt = parameter.GetDetailList();

            //ddlITEM_UMSR.DataValueField = "KEY02";
            //ddlITEM_UMSR.DataTextField = "DATA_CHAR";
            //ddlITEM_UMSR.DataSource = dt;
            //ddlITEM_UMSR.DataBind();
            //ddlITEM_UMSR.Items.Insert(0, new ListItem(""));

            Dept dept = new Dept(g_user_id, g_lang);

            dt = dept.GetDEPTList();
            ddl_DEPT_NO.DataValueField = "DEPT_NO";
            ddl_DEPT_NO.DataTextField = "DEPT_NAME";
            ddl_DEPT_NO.DataSource = dt;
            ddl_DEPT_NO.DataBind();
            ddl_DEPT_NO.Items.Insert(0, "");

            ddl_DEPT_TO.DataValueField = "DEPT_NO";
            ddl_DEPT_TO.DataTextField = "DEPT_NAME";
            ddl_DEPT_TO.DataSource = dt;
            ddl_DEPT_TO.DataBind();
            ddl_DEPT_TO.Items.Insert(0, "");
        }

        /// <summary>
        /// 初期画面権限編集
        /// </summary>
        protected void Auth_Proc()
        {
            IM_Menu menu = new IM_Menu(g_user_id, g_lang);
            menu.user_id = g_user_id;
            //menu.program_id = Request["program_id"].ToString();//品目マスタ
            menu.program_id = "MstItemMnt";
            menu.GetUserProgramAuthority();
            int g_auth = menu.executable_flag;
            if (g_auth == 2)//実行権限=1（変更）の場合、照会、新規、変更、削除ボタンを選択可に制御する。
            {
                //do nothing
            }
            else//実行権限=1（照会）の場合、照会のみ選択可にして、新規、変更、削除ボタンは選択不可に制御する。
            {
                btnMadd.Enabled = false;
                btnMdel.Enabled = false;
                btnMupd.Enabled = false;
                switch (g_lang)
                {
                    case 1:
                        //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new4-1.jpg";
                        //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change4-1.jpg";
                        //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete4-1.jpg";
                        break;
                    case 2:
                        //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new4-2.jpg";
                        //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change4-2.jpg";
                        //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete4-2.jpg";
                        break;
                    case 3:
                        //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new4-3.jpg";
                        //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change4-3.jpg";
                        //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete4-3.jpg";
                        break;
                    case 4:
                        //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new4-4.jpg";
                        //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change4-4.jpg";
                        //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete4-4.jpg";
                        break;
                }
            }
        }

        /// <summary>
        /// 検索画面追加
        /// </summary>
        protected void Add_Search()
        {
            // 品目検索画面
            //Search srch = new Search();
            //srch.search_type = Search.SearchType.ITEM;
            //srch.opener = this;
            //srch.opener_button = btnITEMSearch;
            /*** ADD 20090629 UBIQ-LIU  ***/
            //srch.submit_type = 1;
            //srch.btn_id = btnSearchSubmit.ClientID;
            /***            END         ***/
            //ArrayList arrObj = new ArrayList();
            //arrObj.Add(txtITEM_NO);
            //arrObj.Add(lblITEM_DESC);
            //srch.return_controls = arrObj;
            //int rtn = srch.CreateSearchWindow();
            // 出库倉庫検索画面
            //srch = new Search();
            //srch.search_type = Search.SearchType.WHS;
            //srch.opener = this;
            //srch.opener_button = btnOutStorage;
            //arrObj = new ArrayList();
            //arrObj.Add(txtDISB_WHS);
            //arrObj.Add(lblDISB_WHS);
            //srch.return_controls = arrObj;
            //rtn = srch.CreateSearchWindow();
            // 保税仓库検索画面
            //srch = new Search();
            //srch.search_type = Search.SearchType.WHS;
            //srch.opener = this;
            //srch.opener_button = btnOutStorageBond;
            //arrObj = new ArrayList();
            //arrObj.Add(txtBOND_DISB_WHS);
            //arrObj.Add(lblBOND_DISB_WHS);
            //srch.return_controls = arrObj;
            //rtn = srch.CreateSearchWindow();

        }

        /// <summary>
        /// 画面の制御
        /// </summary>
        /// <param name="pUpdMode"></param>
        protected void Screen_Control(string pUpdMode)
        {
            ComLibrary com = new ComLibrary();
            // モードボタンを選択状態から戻す
            Init_Mode();
            btnMdsp.Enabled = true;
            btnMadd.Enabled = true;
            btnMupd.Enabled = true;
            btnMdel.Enabled = true;
            hdnUpdMode.Value = pUpdMode;
            //Auth_Proc();//ADD BY UBIQ-LIU 2010/8/3
            // モードボタンを選択状態にする
            switch (pUpdMode)
            {
                case "0":   // 照会
                    btnMdsp.Enabled = false;
                    switch (g_lang)
                    {
                        case 1:
                            //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq3-1.jpg";
                            break;
                        case 2:
                            //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq3-2.jpg";
                            break;
                        case 3:
                            //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq3-3.jpg";
                            break;
                        case 4:
                            //btnMdsp.ImageUrl = "../../Contents/Image/BackGround/btn-inq3-4.jpg";
                            break;
                    }
                    break;
                case "1":   // 新規
                    btnMadd.Enabled = false;
                    switch (g_lang)
                    {
                        case 1:
                            //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new3-1.jpg";
                            break;
                        case 2:
                            //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new3-2.jpg";
                            break;
                        case 3:
                            //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new3-3.jpg";
                            break;
                        case 4:
                            //btnMadd.ImageUrl = "../../Contents/Image/BackGround/btn-new3-4.jpg";
                            break;
                    }
                    break;
                case "2":   // 変更
                    btnMupd.Enabled = false;
                    switch (g_lang)
                    {
                        case 1:
                            //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change3-1.jpg";
                            break;
                        case 2:
                            //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change3-2.jpg";
                            break;
                        case 3:
                            //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change3-3.jpg";
                            break;
                        case 4:
                            //btnMupd.ImageUrl = "../../Contents/Image/BackGround/btn-change3-4.jpg";
                            break;
                    }
                    break;
                case "3":   // 削除
                    btnMdel.Enabled = false;
                    switch (g_lang)
                    {
                        case 1:
                            //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete3-1.jpg";
                            break;
                        case 2:
                            //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete3-2.jpg";
                            break;
                        case 3:
                            //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete3-3.jpg";
                            break;
                        case 4:
                            //btnMdel.ImageUrl = "../../Contents/Image/BackGround/btn-delete3-4.jpg";
                            break;
                    }
                    break;
            }
            // 画面プロテクト
            switch (hdnInputMode.Value)
            {
                case "0":
                    //pnlKey.Enabled = true;
                    com.Set_Attributes(Div0, 1);
                    //pnlDetail.Enabled = false;
                    com.Set_Attributes(Div1, 0);
                    //com.Set_Attributes(Div6, 0);
                    //com.Set_Attributes(Div2, 0);
                    //com.Set_Attributes(Div3, 0);
                    //FileUpload1.Enabled = false;
                    //FileUpload2.Enabled = false;
                    //btnASSY_IMAGE.Enabled = false;
                    //btnITEM_IMAGE.Enabled = false;
                    //btnItemWS.Enabled = false;  // IMV3 COMMENT OUT
                    //btnPurchase.Enabled = false;
                    //btnPurPrice.Enabled = false;  // IMV3 COMMENT OUT
                    //btnRoutine.Enabled = false;  // IMV3 COMMENT OUT
                    //btnStdPrice.Enabled = false;  // IMV3 COMMENT OUT
                    //com.Set_Attributes(Div4, 0);
                    //com.Set_Attributes(Div5, 0);
                    btnITEMSearch.Visible = true;
                    //btnOutStorage.Visible = false;
                    //btnOutStorageBond.Visible = false;
                    cmdUpdate.Enabled = false;
                    cmdDisp.Enabled = true;
                    switch (g_lang)
                    {
                        case 1:
                            //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-1.jpg";
                            //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-1.jpg";
                            break;
                        case 2:
                            //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-2.jpg";
                            //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-2.jpg";
                            break;
                        case 3:
                            //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-3.jpg";
                            //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-3.jpg";
                            break;
                        case 4:
                            //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-4.jpg";
                            //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-4.jpg";
                            break;
                    }
                    com.SetInitialFocus(txtITEM_NO);
                    break;
                case "1":
                    com.Set_Attributes(Div0, 0);

                    if (hdnUpdMode.Value == "0")
                    {
                        cmdUpdate.Enabled = false;
                        switch (g_lang)
                        {
                            case 1:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-1.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-1.jpg";
                                break;
                            case 2:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-2.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-2.jpg";
                                break;
                            case 3:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-3.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-3.jpg";
                                break;
                            case 4:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind1-4.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update3-4.jpg";
                                break;
                        }
                    }
                    else
                    {
                        cmdUpdate.Enabled = true;
                        cmdDisp.Enabled = false;
                        switch (g_lang)
                        {
                            case 1:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind3-1.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-1.jpg";
                                break;
                            case 2:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind3-2.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-2.jpg";
                                break;
                            case 3:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind3-3.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-3.jpg";
                                break;
                            case 4:
                                //cmdDisp.ImageUrl = "../../Contents/Image/BackGround/btn-ind3-4.jpg";
                                //cmdUpdate.ImageUrl = "../../Contents/Image/BackGround/btn-update1-4.jpg";
                                break;
                        }
                    }
                    if (hdnUpdMode.Value == "1")
                    {
                        // btnItemWS.Enabled = false;  // IMV3 COMMENT OUT
                        //btnPurchase.Enabled = false;
                        //btnPurPrice.Enabled = false;  // IMV3 COMMENT OUT
                        //btnRoutine.Enabled = false;  // IMV3 COMMENT OUT
                        //btnStdPrice.Enabled = false;  // IMV3 COMMENT OUT
                    }
                    else
                    {
                        //btnItemWS.Enabled = true;  // IMV3 COMMENT OUT
                        //btnPurchase.Enabled = true;
                        //btnPurPrice.Enabled = true;  // IMV3 COMMENT OUT
                        //btnRoutine.Enabled = true;  // IMV3 COMMENT OUT
                        //btnStdPrice.Enabled = true;  // IMV3 COMMENT OUT
                    }

                    // 照会、削除時は明細入力を許さない
                    if (hdnUpdMode.Value == "3")
                    {
                        com.Set_Attributes(Div1, 0);
                        //com.Set_Attributes(Div6, 0);
                        //com.Set_Attributes(Div2, 0);
                        //com.Set_Attributes(Div3, 0);
                        //FileUpload1.Enabled = false;
                        //FileUpload2.Enabled = false;
                        //com.Set_Attributes(Div4, 0);
                        //com.Set_Attributes(Div5, 0);
                        btnITEMSearch.Visible = true;
                        //btnOutStorage.Visible = false;
                        //btnOutStorageBond.Visible = false;
                    }
                    if (hdnUpdMode.Value == "0")
                    {
                        com.Set_Attributes(Div0, 1);
                        com.Set_Attributes(Div1, 0);
                        //com.Set_Attributes(Div6, 0);
                        //com.Set_Attributes(Div2, 0);
                        //com.Set_Attributes(Div3, 0);
                        //FileUpload1.Enabled = false;
                        //FileUpload2.Enabled = false;
                        //com.Set_Attributes(Div4, 0);
                        //com.Set_Attributes(Div5, 0);
                        btnITEMSearch.Visible = true;
                        //btnOutStorage.Visible = false;
                        //btnOutStorageBond.Visible = false;
                    }
                    if (hdnUpdMode.Value == "1")
                    {
                        com.Set_Attributes(Div1, 1);
                        //com.Set_Attributes(Div6, 1);
                        //com.Set_Attributes(Div2, 1);
                        //com.Set_Attributes(Div3, 1);
                        //FileUpload1.Enabled = true;
                        //FileUpload2.Enabled = true;
                        //btnASSY_IMAGE.Enabled = true;
                        //btnITEM_IMAGE.Enabled = true;
                        //com.Set_Attributes(Div4, 1);
                        //com.Set_Attributes(Div5, 1);
                        btnITEMSearch.Visible = false;
                        //btnOutStorage.Visible = true;
                        //btnOutStorageBond.Visible = true;

                    }
                    if (hdnUpdMode.Value == "2")
                    {
                        com.Set_Attributes(Div1, 1);
                        //com.Set_Attributes(Div6, 1);
                        //com.Set_Attributes(Div2, 1);
                        //com.Set_Attributes(Div3, 1);
                        //FileUpload1.Enabled = true;
                        //FileUpload2.Enabled = true;
                        //btnASSY_IMAGE.Enabled = true;
                        //btnITEM_IMAGE.Enabled = true;
                        //com.Set_Attributes(Div4, 1);
                        //com.Set_Attributes(Div5, 1);
                        btnITEMSearch.Visible = false;
                        //btnOutStorage.Visible = true;
                        //btnOutStorageBond.Visible = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// 画面編集
        /// </summary>
        protected void Edit_Screen()
        {

            ComLibrary com = new ComLibrary();
            Message msg = new Message(g_user_id, g_lang);
            // 品目マスタを検索
            if (txtITEM_NO.Text.Trim() == "")
            {
                msg = new Message(g_user_id, g_lang);
                lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblITEM_NO.Text + ")";
                lblMsg.ForeColor = Color.Red;
                return;
            }
            Item ItemSearch = new Item(g_user_id, g_lang);
            ItemSearch.item_no = txtITEM_NO.Text.ToUpper();
            txtITEM_NO.Text = ItemSearch.item_no;
            int rtn = ItemSearch.GetItemDetail();
            //TabContainer1.ActiveTabIndex = 0;//ADD UBIQ-LIU 2010/05/24
            if (hdnUpdMode.Value == "1")
            {
                //
                // 新規のときは、すでに存在すればエラー
                //
                if (rtn != ComConst.FAILED)
                {
                    msg = new Message(g_user_id, g_lang);
                    lblMsg.Text = msg.GetMessage("ALREADY_EXIST_ERR");
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
            }
            else
            {
                //
                // 新規以外のときは、存在しなければエラー
                //
                if (rtn == ComConst.FAILED)
                {
                    msg = new Message(g_user_id, g_lang);
                    lblMsg.Text = msg.GetMessage("NOT_EXIST_ERR");
                    lblMsg.ForeColor = Color.Red;
                    lblITEM_DESC.Text = "";
                    return;
                }
                else
                {
                    // 画面編集
                    lblITEM_DESC.Text = ItemSearch.item_desc.ToString();
                    txtITEM_DESC.Text = ItemSearch.item_desc.ToString();
                    txtITEM_DESC2.Text = ItemSearch.item_desc2.ToString();
                    rdoITEM_TYPE.Text = ItemSearch.item_type.ToString();
                    //rdoITEM_TYPE.SelectedValue = ItemSearch.item_type.ToString();
                    try
                    {
                        ddl_DEPT_NO.SelectedValue = ItemSearch.data_num1.ToString();
                    }
                    catch
                    {
                    }
                    txtSPEC_DECS.Text = ItemSearch.spec_desc.ToString();
                    txtMaker_From.Text = ItemSearch.data_char1.ToString();
                    txtMaker_Code.Text = ItemSearch.data_char2.ToString();
                    try
                    {
                        ddl_DEPT_TO.SelectedValue = ItemSearch.data_num2.ToString();
                    }
                    catch
                    {
                    }
                    txtStock_Area.Text = ItemSearch.location.ToString();
                    txtSCH_ID.Text = ItemSearch.sch_id.ToString();
                    ddlCATG_CD.Text = ItemSearch.catg_cd.ToString();
                    //try//ADD BY UBIQ-LIU 2010/03/26
                    //{
                    //    ddlCATG_CD.SelectedValue = ItemSearch.catg_cd;
                    //}
                    //catch
                    //{
                    //    //NOT_EXIST_ERR
                    //}
                    //hdnLLC.Value = ItemSearch.llc.ToString();
                    txtMREMARKS.Text = ItemSearch.remarks.ToString();
                    txtDRAWING_NO.Text = ItemSearch.drawing_no.ToString();

                    // IMV3 COMMENT OUT
                    //rdoPO_STOP_FLAG.SelectedValue = ItemSearch.po_stop_flag.ToString();
                    //try//ADD BY UBIQ-LIU 2010/03/26
                    //{
                    //    ddlSCH_ID.SelectedValue = ItemSearch.sch_id;
                    //}
                    //catch
                    //{
                    //    //NOT_EXIST_ERR
                    //}
                    //rdoPO_TYPE.SelectedValue = ItemSearch.po_type.ToString();
                    //try//ADD BY UBIQ-LIU 2010/03/26
                    //{
                    //    ddlITEM_UMSR.SelectedValue = ItemSearch.item_umsr;
                    //}
                    //catch
                    //{
                    //    //NOT_EXIST_ERR
                    //}
                    //txtREORDER_POINT.Text = ItemSearch.reorder_point.ToString();
                    //rdoAUTO_DISB_TYPE.SelectedValue = ItemSearch.auto_disb_type.ToString();
                    //rdoWIP_TYPE.SelectedValue = ItemSearch.wip_type.ToString();

                    //txtDISB_LOT_SIZE.Text = ItemSearch.disb_lot_size.ToString();
                    // IMV3 COMMENT OUT
                    //rdoDEMAND_ROUD_TYPE.SelectedValue = ItemSearch.demand_roud_type.ToString();
                    //txtMIN_PUR_QTY.Text = ItemSearch.min_pur_qty.ToString();
                    //txtPUR_LOT_SIZE.Text = ItemSearch.pur_lot_size.ToString();  // 2015.08.13
                    //txtDEMAND_PERIOD.Text = ItemSearch.demand_period.ToString();
                    //txtPUR_PERIOD.Text = ItemSearch.pur_period.ToString(); ;
                    //rdoSAFETY_STOCK_TYPE.SelectedValue = ItemSearch.safety_stock_type.ToString();
                    //txtSAFETY_STOCK.Text = ItemSearch.safety_stock.ToString();
                    //txtSAFETY_STOCK_DAYS.Text = ItemSearch.safety_stock_days.ToString();
                    //txtSAFETY_STOCK_RATIO.Text = ItemSearch.safety_stock_ratio.ToString();
                    //rdoSS_CALC_CONDTN.SelectedValue = ItemSearch.ss_calc_condtn.ToString();
                    //rdoSS_INV_CONDTN.SelectedValue = ItemSearch.ss_inv_condtn.ToString();
                    //txtITEM_ADDN_ORDER_RATIO.Text = ItemSearch.item_addn_order_ratio.ToString();
                    //txtITEM_ADDN_RCV_RATIO.Text = ItemSearch.item_addn_rcv_ratio.ToString();//ADD BY UBIQ-LIU 2010/8/17
                    //txtPLANT_LT.Text = ItemSearch.plant_lt.ToString();
                    //txtBACKWD_ALLOWANCE_DAYS.Text = ItemSearch.backwd_allowance_days.ToString();
                    //rdoORDER_CONTROL_FLAG.SelectedValue = ItemSearch.order_control_flag.ToString();
                    //txtDISB_WHS.Text = ItemSearch.disb_whs;
                    //lblDISB_WHS.Text = ItemSearch.whs_desc;
                    //txtBOND_DISB_WHS.Text = ItemSearch.bond_disb_whs;
                    //lblBOND_DISB_WHS.Text = ItemSearch.bond_whs_desc;
                    //rdoBOND_TYPE.SelectedValue = ItemSearch.bond_type.ToString();
                    //txtLOCATION.Text = ItemSearch.location;
                    //txtITEM_ABC_CD.Text = ItemSearch.item_abc_cd;
                    //txtEXP_DATE.Text = ItemSearch.exp_date.ToString();  // IMV3 COMMENT OUT
                    //rdoSUPPLY_TYPE.SelectedValue = ItemSearch.supply_type.ToString();  // IMV3 COMMENT OUT
                    //rdoLOT_CNTL_FLAG.SelectedValue = ItemSearch.lot_cntl_flag.ToString();
                    //rdoNEG_BAL_FLAG.SelectedValue = ItemSearch.neg_bal_flag.ToString();  // IMV3 COMMENT OUT

                    //txtDATA_CHAR1.Text = ItemSearch.data_char1;
                    //txtDATA_CHAR2.Text = ItemSearch.data_char2;
                    //txtDATA_CHAR3.Text = ItemSearch.data_char3;
                    //txtDATA_CHAR4.Text = ItemSearch.data_char4;
                    //txtDATA_CHAR5.Text = ItemSearch.data_char5;
                    //txtDATA_CHAR6.Text = ItemSearch.data_char6;
                    //txtDATA_CHAR7.Text = ItemSearch.data_char7;
                    //txtDATA_CHAR8.Text = ItemSearch.data_char8;
                    //txtDATA_CHAR9.Text = ItemSearch.data_char9;
                    //txtDATA_CHAR10.Text = ItemSearch.data_char10;
                    //txtDATA_NUM1.Text = ItemSearch.data_num1.ToString();
                    //txtDATA_NUM2.Text = ItemSearch.data_num2.ToString();
                    //txtDATA_NUM3.Text = ItemSearch.data_num3.ToString();
                    //txtDATA_NUM4.Text = ItemSearch.data_num4.ToString();
                    //txtDATA_NUM5.Text = ItemSearch.data_num5.ToString();
                    //txtDATA_NUM6.Text = ItemSearch.data_num6.ToString();
                    //txtDATA_NUM7.Text = ItemSearch.data_num7.ToString();
                    //txtDATA_NUM8.Text = ItemSearch.data_num8.ToString();
                    //txtDATA_NUM9.Text = ItemSearch.data_num9.ToString();
                    //txtDATA_NUM10.Text = ItemSearch.data_num10.ToString();
                    //chkDATA_FLAG1.Checked = com.IntToBool(ItemSearch.data_flag1);
                    //chkDATA_FLAG2.Checked = com.IntToBool(ItemSearch.data_flag2);
                    //chkDATA_FLAG3.Checked = com.IntToBool(ItemSearch.data_flag3);
                    //chkDATA_FLAG4.Checked = com.IntToBool(ItemSearch.data_flag4);
                    //chkDATA_FLAG5.Checked = com.IntToBool(ItemSearch.data_flag5);
                    //chkDATA_FLAG6.Checked = com.IntToBool(ItemSearch.data_flag6);
                    //chkDATA_FLAG7.Checked = com.IntToBool(ItemSearch.data_flag7);
                    //chkDATA_FLAG8.Checked = com.IntToBool(ItemSearch.data_flag8);
                    //chkDATA_FLAG9.Checked = com.IntToBool(ItemSearch.data_flag9);
                    //chkDATA_FLAG10.Checked = com.IntToBool(ItemSearch.data_flag10);

                    dgvItemWS_Data();
                    dgvRoutine_Data();
                    //dvgPurchase_Data();
                    dgvPurPrice_Data();
                    dgvStdPrice_Data();
                    //图片的读取
                    if (ItemSearch.item_image != "")
                    {
                        ItemPicture.Value = ItemSearch.item_image;
                        //IPicture.ImageUrl = ItemSearch.item_image;
                        //IPicture.Style.Add("display", "block");
                    }
                    else
                    {
                        ItemPicture.Value = "";
                        //IPicture.Style.Add("display", "none");
                    }
                    if (ItemSearch.assy_image != "")
                    {
                        AssyPicture.Value = ItemSearch.assy_image;
                        //APicture.ImageUrl = ItemSearch.assy_image;
                        //APicture.Style.Add("display", "block");
                    }
                    else
                    {
                        AssyPicture.Value = "";
                        //APicture.Style.Add("display", "none");
                    }
                }
            }
            hdnInputMode.Value = "1";
            Screen_Control(hdnUpdMode.Value);
            if (hdnUpdMode.Value == "2" || hdnUpdMode.Value == "1") //UPD BY UBIQ-SUO 2011/02/17 add || hdnUpdMode.Value == "1"
            {
                //rdoITEM_TYPE_SelectedIndexChanged(null, null);
            }

        }

        /// <summary>
        /// From Clear
        /// </summary>
        /// <param name="flg">0:ALL Clear;1:Not Key</param>
        protected void FromClear(int flg)
        {
            if (flg == 1)
            {
                txtITEM_NO.Text = "";
                lblITEM_DESC.Text = "";
            }
            //No.1
            txtITEM_DESC.Text = "";
            txtITEM_DESC2.Text = "";
            rdoITEM_TYPE.Text = "";
            ddl_DEPT_NO.SelectedIndex = 0;
            txtSPEC_DECS.Text = "";
            txtMaker_From.Text = "";
            txtMaker_Code.Text = "";
            ddl_DEPT_TO.SelectedIndex = 0;
            txtStock_Area.Text = "";
            txtSCH_ID.Text = "";
            ddlCATG_CD.Text = "";
            txtMREMARKS.Text = "";
            txtDRAWING_NO.Text = "";
            //rdoPO_STOP_FLAG.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //rdoPO_TYPE.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //ddlITEM_UMSR.SelectedIndex = 0;
            //ddlSCH_ID.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //txtREORDER_POINT.Text = "";  // IMV3 COMMENT OUT
            //rdoAUTO_DISB_TYPE.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //txtDISB_LOT_SIZE.Text = "";
            //rdoDEMAND_ROUD_TYPE.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //rdoWIP_TYPE.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //txtMIN_PUR_QTY.Text = "";  // IMV3 COMMENT OUT
            //txtPUR_LOT_SIZE.Text = "";  //   // 2015.08.13
            //txtDEMAND_PERIOD.Text = "";  // IMV3 COMMENT OUT
            //txtPUR_PERIOD.Text = "";  // IMV3 COMMENT OUT
            //No.2
            //rdoSAFETY_STOCK_TYPE.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //txtSAFETY_STOCK.Text = "";  // IMV3 COMMENT OUT
            //txtSAFETY_STOCK_DAYS.Text = "";  // IMV3 COMMENT OUT
            //txtSAFETY_STOCK_RATIO.Text = "";  // IMV3 COMMENT OUT
            //rdoSS_CALC_CONDTN.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //rdoSS_INV_CONDTN.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //txtITEM_ADDN_ORDER_RATIO.Text = "";  // IMV3 COMMENT OUT
            //txtITEM_ADDN_RCV_RATIO.Text = "";  // IMV3 COMMENT OUT
            //txtPLANT_LT.Text = "";  // IMV3 COMMENT OUT
            //txtPLANT_LT.Text = "";  // IMV3 COMMENT OUT
            //txtBACKWD_ALLOWANCE_DAYS.Text = "";  // IMV3 COMMENT OUT
            //rdoORDER_CONTROL_FLAG.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //txtDISB_WHS.Text = "";
            //lblDISB_WHS.Text = "";
            //lblBOND_DISB_WHS.Text = "";
            //txtBOND_DISB_WHS.Text = "";
            //rdoBOND_TYPE.SelectedIndex = 0;
            //txtLOCATION.Text = "";
            //txtITEM_ABC_CD.Text = "";  // IMV3 COMMENT OUT
            //txtEXP_DATE.Text = "";  // IMV3 COMMENT OUT
            //rdoSUPPLY_TYPE.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //rdoLOT_CNTL_FLAG.SelectedIndex = 0;
            //rdoNEG_BAL_FLAG.SelectedIndex = 0;  // IMV3 COMMENT OUT
            //No.3
            AssyPicture.Value = "";
            //APicture.Style.Add("display", "none");
            ItemPicture.Value = "";
            //IPicture.Style.Add("display", "none");
            //No.4
            //txtDATA_CHAR1.Text = "";
            //txtDATA_NUM1.Text = "";
            //chkDATA_FLAG1.Checked = false;
            //txtDATA_CHAR2.Text = "";
            //txtDATA_NUM2.Text = "";
            //chkDATA_FLAG2.Checked = false;
            //txtDATA_CHAR3.Text = "";
            //txtDATA_NUM3.Text = "";
            //chkDATA_FLAG3.Checked = false;
            //txtDATA_CHAR4.Text = "";
            //txtDATA_NUM4.Text = "";
            //chkDATA_FLAG4.Checked = false;
            //txtDATA_CHAR5.Text = "";
            //txtDATA_NUM5.Text = "";
            //chkDATA_FLAG5.Checked = false;
            //txtDATA_CHAR6.Text = "";
            //txtDATA_NUM6.Text = "";
            //chkDATA_FLAG6.Checked = false;
            //txtDATA_CHAR7.Text = "";
            //txtDATA_NUM7.Text = "";
            //chkDATA_FLAG7.Checked = false;
            //txtDATA_CHAR8.Text = "";
            //txtDATA_NUM8.Text = "";
            //chkDATA_FLAG8.Checked = false;
            //txtDATA_CHAR9.Text = "";
            //txtDATA_NUM9.Text = "";
            //chkDATA_FLAG9.Checked = false;
            //txtDATA_CHAR10.Text = "";
            //txtDATA_NUM10.Text = "";
            //chkDATA_FLAG10.Checked = false;
            //No.5
            // IMV3 COMMENT OUT
            //dgvItemWS.DataSource = null;
            //dgvItemWS.DataBind();
            //dgvRoutine.DataSource = null;
            //dgvRoutine.DataBind();
            //dvgPurchase.DataSource = null;
            //dvgPurchase.DataBind();
            // IMV3 COMMENT OUT
            //dgvPurPrice.DataSource = null;
            //dgvPurPrice.DataBind();
            //dgvStdPrice.DataSource = null;
            //dgvStdPrice.DataBind();
        }

        /// <summary>
        /// Mode Change
        /// </summary>
        protected void Mode_Chg()
        {
            if (txtITEM_NO.Text != "")
            {
                cmdDisp_Click(null, null);
            }
        }

        /// <summary>
        /// Hide Button used by Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            cmdDisp_Click(null, null);
        }

        /// <summary>
        /// 照会ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMdsp_Click(object sender, EventArgs e)
        {
            hdnInputMode.Value = "0";//Recovery By UBIQ-LIU 2010/01/08
            Screen_Control("0");
            Mode_Chg();
            ShowPanel(pnlSUB2, true, 50, 50);
            Edit_Grid();

        }

        protected void ShowPanel(Panel panal, bool visable, int top, int left)
        {
            if (visable)
            {
                panal.Style.Add("top", string.Format("{0}px;", top));
                panal.Style.Add("left", string.Format("{0}px;", left));
            }
            //panal.Visible = visable;
            if (visable)
            {
                pnlSUB2.Style.Add("display", "block");

                pnlDetail.Style.Add("display", "none");
            }
            else
            {
                pnlSUB2.Style.Add("display", "none");   // KGC

                pnlDetail.Style.Add("display", "block");
            }
        }

        protected void Edit_Grid()
        {
            // 品目マスタより一覧を得る
            string[] strcou;
            //strcou = flblCount.Text.Split('=');
            Message msg = new Message(g_user_id, g_lang);

            Item SrchItem = new Item(g_user_id, g_lang);
            SrchItem.item_no = txtITEM_NO.Text.ToUpper().Trim();
            //SrchItem.item_type = ddlITEM_TYPE.SelectedValue;
            SrchItem.item_desc = lblITEM_DESC.Text.Trim();
            DataSet ds = SrchItem.GetItemList();
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                dgvSearch.DataSource = null;
                dgvSearch.DataBind();
                //flblCount.Text = strcou[0] + " = 0]";
            }
            //--> ADD BY UBIQ-SUO 2010/09/25
            if (SrchItem.range)
            {
                lblMsg.Text = msg.GetMessage("OUT_2000_RANGE");
                lblMsg.ForeColor = Color.Red;
            }
            //<-- ADD BY UBIQ-SUO 2010/09/25
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgvSearch.DataSource = ds.Tables[0];
                dgvSearch.DataBind();
                ViewState["dgvSearch"] = ds.Tables[0];
                //flblCount.Text = strcou[0] + " = " + ds.Tables[0].Rows.Count.ToString() + "]";
            }
        }

        protected void dgvSearch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //選択ボタンセルを非表示にする(Visible = False だと制御ができないため）        
            if (e.Row.RowType != DataControlRowType.Pager)
            {
                e.Row.Cells[0].Style.Add("display", "none");
            }
        }

        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMadd_Click(object sender, EventArgs e)
        {
            FromClear(0);
            hdnInputMode.Value = "0";
            Screen_Control("1");
            Mode_Chg();
            ShowPanel(pnlSUB2, false, 50, 50);
        }
        /// <summary>
        /// 訂正ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMupd_Click(object sender, EventArgs e)
        {
            hdnInputMode.Value = "0";//Recovery By UBIQ-LIU 2010/01/08
            Screen_Control("2");
            Mode_Chg();
            ShowPanel(pnlSUB2, false, 50, 50);
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMdel_Click(object sender, EventArgs e)
        {
            hdnInputMode.Value = "0";//Recovery By UBIQ-LIU 2010/01/08
            Screen_Control("3");
            Mode_Chg();
            ShowPanel(pnlSUB2, false, 50, 50);
        }

        /// <summary>
        /// 表示ボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdDisp_Click(object sender, EventArgs e)
        {

            if (hdnUpdMode.Value == "0")
            {
                ShowPanel(pnlSUB2, true, 50, 50);
                Edit_Grid();
            }
            else
            {
                ShowPanel(pnlSUB2, false, 50, 50);
                Edit_Screen();
            }

        }

        /// <summary>
        /// 更新ボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            Message msg = new Message(g_user_id, g_lang);
            Item ItemUpdate = new Item(g_user_id, g_lang);

            // 必須項目のチェック
            if (txtITEM_NO.Text == "")
            {
                msg = new Message(g_user_id, g_lang);
                lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblITEM_NO.Text + ")";
                lblMsg.ForeColor = Color.Red;
                return;
            }
            if (txtITEM_DESC.Text == "")
            {
                msg = new Message(g_user_id, g_lang);
                lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblITEM_DESC.Text + ")";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            // IMV3
            /*if (txtDISB_WHS.Text == "")
            {
                msg = new Message(g_user_id, g_lang);
                lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblDISB_WHS.Text + ")";
                lblMsg.ForeColor = Color.Red;
                return;
            }*/
            // IMV3 COMMENT OUT
            //if (rdoITEM_TYPE.SelectedValue.ToString() == "21" || rdoITEM_TYPE.SelectedValue.ToString() == "30" || rdoITEM_TYPE.SelectedValue.ToString() == "22")
            //{
            //    if (ddlSCH_ID.SelectedValue.ToString() == "")
            //    {
            //        msg = new Message(g_user_id, g_lang);
            //        lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblSCH_ID.Text + ")";
            //        lblMsg.ForeColor = Color.Red;
            //        return;
            //    }
            //}
            //add by zhao 2009/1/14                 //
            //if (ddlITEM_UMSR.SelectedValue.ToString() == "" && rdoITEM_TYPE.SelectedValue.ToString() != "99")
            //if (ddlITEM_UMSR.SelectedValue.ToString() == "" && rdoITEM_TYPE.Text == "")
            //{
            //    msg = new Message(g_user_id, g_lang);
            //    lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblITEM_UMSR.Text + ")";
            //    lblMsg.ForeColor = Color.Red;
            //    return;
            //}
            //******************************************//
            ComLibrary com = new ComLibrary();
            // 品目マスタを更新
            // 画面から項目を編集
            ItemUpdate.item_no = txtITEM_NO.Text.ToUpper();

            // IMV3 START 
            //
            // 変更時、PM共通のときにPM固有の値を上書きしないように、マスタデータを読み込む
            //
            //
            if (hdnUpdMode.Value == "2")
            {
                int ret = ItemUpdate.GetItemDetail();
            }
            //
            // 登録時、PMのチェックにかからないように、初期値をセットする
            //
            //
            if (hdnUpdMode.Value == "1")
            {
            }
            // IMV3 END

            ItemUpdate.item_desc = txtITEM_DESC.Text;
            ItemUpdate.item_desc2 = txtITEM_DESC2.Text;
            ItemUpdate.item_type = rdoITEM_TYPE.Text;
            //ItemUpdate.item_type = rdoITEM_TYPE.SelectedValue;
            ItemUpdate.data_num1 = com.StringToInt(ddl_DEPT_NO.SelectedValue.ToString().ToUpper());
            ItemUpdate.spec_desc = txtSPEC_DECS.Text;
            ItemUpdate.data_char1 = txtMaker_From.Text;
            ItemUpdate.data_char2 = txtMaker_Code.Text;
            ItemUpdate.data_num2 = com.StringToInt(ddl_DEPT_TO.SelectedValue.ToString().ToUpper());
            ItemUpdate.location = txtStock_Area.Text;
            ItemUpdate.sch_id = txtSCH_ID.Text;
            ItemUpdate.catg_cd = ddlCATG_CD.Text;
            ItemUpdate.remarks = txtMREMARKS.Text;
            ItemUpdate.drawing_no = txtDRAWING_NO.Text;
            //ItemUpdate.po_stop_flag = com.StringToInt(rdoPO_STOP_FLAG.SelectedValue);   // IMV3 COMMENT OUT
            //alter by zhao 2009/1/14                 //
            //switch (hdnUpdMode.Value)
            //{
            //    case "1":   // Insert
            //        ItemUpdate.llc = 0;
            //        break;
            //    case "2":   // Update
            //        ItemUpdate.llc = com.StringToInt(hdnLLC.Value);
            //        break;
            //}
            //***************************************//
            //ItemUpdate.sch_id = ddlSCH_ID.SelectedValue.ToString().ToUpper();  // IMV3 COMMENT OUT
            //ItemUpdate.po_type = com.StringToInt(rdoPO_TYPE.SelectedValue);  // IMV3 COMMENT OUT
            //ItemUpdate.item_umsr = ddlITEM_UMSR.SelectedValue.ToString().ToUpper();
            //ItemUpdate.reorder_point = com.StringToDouble(txtREORDER_POINT.Text);  // IMV3 COMMENT OUT
            //ItemUpdate.auto_disb_type = com.StringToInt(rdoAUTO_DISB_TYPE.SelectedValue);  // IMV3 COMMENT OUT
            //ItemUpdate.disb_lot_size = com.StringToDouble(txtDISB_LOT_SIZE.Text);
            // IMV3 COMMENT OUT
            //ItemUpdate.demand_roud_type = com.StringToInt(rdoDEMAND_ROUD_TYPE.SelectedValue);
            //ItemUpdate.min_pur_qty = com.StringToDouble(txtMIN_PUR_QTY.Text);
            //ItemUpdate.pur_lot_size = com.StringToDouble(txtPUR_LOT_SIZE.Text);  // 2015.08.13
            //ItemUpdate.demand_period = com.StringToInt(txtDEMAND_PERIOD.Text);
            //ItemUpdate.pur_period = com.StringToInt(txtPUR_PERIOD.Text);
            //ItemUpdate.safety_stock_type = com.StringToInt(rdoSAFETY_STOCK_TYPE.SelectedValue);
            //ItemUpdate.safety_stock = com.StringToDouble(txtSAFETY_STOCK.Text);
            //ItemUpdate.safety_stock_days = com.StringToInt(txtSAFETY_STOCK_DAYS.Text);
            //ItemUpdate.safety_stock_ratio = com.StringToDouble(txtSAFETY_STOCK_RATIO.Text);
            //ItemUpdate.ss_calc_condtn = com.StringToInt(rdoSS_CALC_CONDTN.SelectedValue);
            //ItemUpdate.ss_inv_condtn = com.StringToInt(rdoSS_INV_CONDTN.SelectedValue);
            //ItemUpdate.item_addn_order_ratio = com.StringToDouble(txtITEM_ADDN_ORDER_RATIO.Text);
            //ItemUpdate.item_addn_rcv_ratio = com.StringToDouble(txtITEM_ADDN_RCV_RATIO.Text);//ADD BY UBIQ-LIU 2010/8/17
            //ItemUpdate.plant_lt = com.StringToInt(txtPLANT_LT.Text);
            //ItemUpdate.backwd_allowance_days = com.StringToInt(txtBACKWD_ALLOWANCE_DAYS.Text);
            //ItemUpdate.order_control_flag = com.StringToInt(rdoORDER_CONTROL_FLAG.SelectedValue);
            //ItemUpdate.disb_whs = txtDISB_WHS.Text.ToUpper();
            //txtDISB_WHS.Text = ItemUpdate.disb_whs;
            //ItemUpdate.bond_disb_whs = txtBOND_DISB_WHS.Text.ToUpper();
            //txtBOND_DISB_WHS.Text = ItemUpdate.bond_disb_whs;
            //ItemUpdate.bond_type = com.StringToInt(rdoBOND_TYPE.SelectedValue);
            //ItemUpdate.location = txtLOCATION.Text.ToUpper();
            // IMV3 COMMENT OUT
            //ItemUpdate.item_abc_cd = txtITEM_ABC_CD.Text.ToUpper();
            //ItemUpdate.exp_date = com.StringToInt(txtEXP_DATE.Text);
            //ItemUpdate.supply_type = com.StringToInt(rdoSUPPLY_TYPE.SelectedValue);
            //ItemUpdate.lot_cntl_flag = com.StringToInt(rdoLOT_CNTL_FLAG.SelectedValue);
            // IMV3 COMMENT OUT
            //ItemUpdate.neg_bal_flag = com.StringToInt(rdoNEG_BAL_FLAG.SelectedValue);
            //ItemUpdate.wip_type = com.StringToInt(rdoWIP_TYPE.SelectedValue);
            if (ItemPicture.Value == "")
            {
                ItemUpdate.item_image = "";
            }
            else
                ItemUpdate.item_image = ItemPicture.Value;
            if (AssyPicture.Value == "")
            {
                ItemUpdate.assy_image = "";
            }
            else
                ItemUpdate.assy_image = AssyPicture.Value;

            //ItemUpdate.data_char1 = txtDATA_CHAR1.Text;
            //ItemUpdate.data_char2 = txtDATA_CHAR2.Text;
            //ItemUpdate.data_char3 = txtDATA_CHAR3.Text;
            //ItemUpdate.data_char4 = txtDATA_CHAR4.Text;
            //ItemUpdate.data_char5 = txtDATA_CHAR5.Text;
            //ItemUpdate.data_char6 = txtDATA_CHAR6.Text;
            //ItemUpdate.data_char7 = txtDATA_CHAR7.Text;
            //ItemUpdate.data_char8 = txtDATA_CHAR8.Text;
            //ItemUpdate.data_char9 = txtDATA_CHAR9.Text;
            //ItemUpdate.data_char10 = txtDATA_CHAR10.Text;
            //ItemUpdate.data_num1 = com.StringToDouble(txtDATA_NUM1.Text);
            //ItemUpdate.data_num2 = com.StringToDouble(txtDATA_NUM2.Text);
            //ItemUpdate.data_num3 = com.StringToDouble(txtDATA_NUM3.Text);
            //ItemUpdate.data_num4 = com.StringToDouble(txtDATA_NUM4.Text);
            //ItemUpdate.data_num5 = com.StringToDouble(txtDATA_NUM5.Text);
            //ItemUpdate.data_num6 = com.StringToDouble(txtDATA_NUM6.Text);
            //ItemUpdate.data_num7 = com.StringToDouble(txtDATA_NUM7.Text);
            //ItemUpdate.data_num8 = com.StringToDouble(txtDATA_NUM8.Text);
            //ItemUpdate.data_num9 = com.StringToDouble(txtDATA_NUM9.Text);
            //ItemUpdate.data_num10 = com.StringToDouble(txtDATA_NUM10.Text);
            //ItemUpdate.data_flag1 = com.BoolToInt(chkDATA_FLAG1.Checked);
            //ItemUpdate.data_flag2 = com.BoolToInt(chkDATA_FLAG2.Checked);
            //ItemUpdate.data_flag3 = com.BoolToInt(chkDATA_FLAG3.Checked);
            //ItemUpdate.data_flag4 = com.BoolToInt(chkDATA_FLAG4.Checked);
            //ItemUpdate.data_flag5 = com.BoolToInt(chkDATA_FLAG5.Checked);
            //ItemUpdate.data_flag6 = com.BoolToInt(chkDATA_FLAG6.Checked);
            //ItemUpdate.data_flag7 = com.BoolToInt(chkDATA_FLAG7.Checked);
            //ItemUpdate.data_flag8 = com.BoolToInt(chkDATA_FLAG8.Checked);
            //ItemUpdate.data_flag9 = com.BoolToInt(chkDATA_FLAG9.Checked);
            //ItemUpdate.data_flag10 = com.BoolToInt(chkDATA_FLAG10.Checked);
            ItemUpdate.chg_user_id = g_user_id;
            //ItemUpdate.chg_pgm = "MstITEMMnt";

            int rtn = 0;
            switch (hdnUpdMode.Value)
            {
                case "1":   // Insert
                    rtn = ItemUpdate.Insert();
                    break;
                case "2":   // Update
                    rtn = ItemUpdate.Update();
                    break;
                case "3":   // Delete
                    rtn = ItemUpdate.Delete();
                    break;
            }
            if (rtn == ComConst.FAILED)
            {
                lblMsg.Text = ItemUpdate.strErr;
                lblMsg.ForeColor = Color.Red;
                return;
            }
            lblMsg.Text = msg.GetMessage("NORMAL_UPDATE");
            lblMsg.ForeColor = Color.Blue;
            if (hdnUpdMode.Value == "3")
            {
                FromClear(0);
            }
            hdnInputMode.Value = "0";
            Screen_Control(hdnUpdMode.Value);
        }

        /// <summary>
        /// キャンセルボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            if (hdnInputMode.Value == "0")
            {
                FromClear(1);
            }
            else
            {
                FromClear(0);
            }
            hdnInputMode.Value = "0";
            Screen_Control(hdnUpdMode.Value);
        }

        /// <summary>
        /// 品目イメージ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnITEM_IMAGE_Click(object sender, EventArgs e)
        {

            ComLibrary com = new ComLibrary();
            Message msg = new Message(g_user_id, g_lang);
            /*if (FileUpload1.FileName == "")
            {
                lblMsg.Text = msg.GetMessage("IMAGE_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }
            string fileContentType = FileUpload1.PostedFile.ContentType;
            if (fileContentType == "image/pjpeg")
            {
                string name = FileUpload1.PostedFile.FileName;
                FileInfo file = new FileInfo(name);
                string fileName = file.Name;
                string webFilePath = Server.MapPath("~/ItemImage/Item/");
                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        if (File.Exists(webFilePath + txtITEM_NO.Text + ".jpg"))
                        {
                            FileInfo fileold = new FileInfo(webFilePath + txtITEM_NO.Text + ".jpg");
                            fileold.CopyTo(webFilePath + txtITEM_NO.Text + DateTime.Now.ToString("yyMMddhhmmss") + ".jpg");
                            File.Delete(webFilePath + txtITEM_NO.Text + ".jpg");
                        }
                        FileUpload1.PostedFile.SaveAs(webFilePath + txtITEM_NO.Text + ".jpg");
                        //file.CopyTo(webFilePath + txtITEM_NO.Text + ".jpg");
                        //lblMsg.Text = msg.GetMessage("IMAGE_UPLOAD_SUCCESSFUL");
                        ItemPicture.Value = "~/ItemImage/Item/" + txtITEM_NO.Text + ".jpg";
                        lblMsg.ForeColor = Color.Blue;
                        IPicture.ImageUrl = ItemPicture.Value + "?" + DateTime.Now.ToString("mmss"); ;
                        IPicture.Style.Add("display", "block");
                        Picture_UpLoad(1);
                        return;
                    }
                    catch
                    {
                        lblMsg.Text = msg.GetMessage("FOLDER_EXIST_ERR");
                        lblMsg.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = msg.GetMessage("IMAGE_TYPE_ERR");
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
            }
            else
            {
                lblMsg.Text = "Not the type of document";
                lblMsg.ForeColor = Color.Red;
                return;
            }*/
        }

        /// <summary>
        /// 組立イメージ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnASSY_IMAGE_Click(object sender, EventArgs e)
        {
            ComLibrary com = new ComLibrary();
            Message msg = new Message(g_user_id, g_lang);
            /*if (FileUpload2.FileName == "")
            {
                lblMsg.Text = msg.GetMessage("IMAGE_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }
            string fileContentType = FileUpload2.PostedFile.ContentType;
            if (fileContentType == "image/pjpeg")
            {
                string name = FileUpload2.PostedFile.FileName;
                FileInfo file = new FileInfo(name);
                string fileName = file.Name;
                string webFilePath = Server.MapPath("~/ItemImage/Assy/");
                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        if (File.Exists(webFilePath + txtITEM_NO.Text + ".jpg"))
                        {
                            FileInfo fileold = new FileInfo(webFilePath + txtITEM_NO.Text + ".jpg");
                            fileold.CopyTo(webFilePath + txtITEM_NO.Text + DateTime.Now.ToString("yyMMddhhmmss") + ".jpg");
                            File.Delete(webFilePath + txtITEM_NO.Text + ".jpg");
                        }
                        FileUpload2.PostedFile.SaveAs(webFilePath + txtITEM_NO.Text + ".jpg");
                        AssyPicture.Value = "~/ItemImage/Assy/" + txtITEM_NO.Text + ".jpg";
                        lblMsg.ForeColor = Color.Blue;
                        APicture.ImageUrl = AssyPicture.Value + "?" + DateTime.Now.ToString("mmss");
                        APicture.Style.Add("display", "block");
                        Picture_UpLoad(2);
                        return;
                    }
                    catch
                    {
                        lblMsg.Text = msg.GetMessage("FOLDER_EXIST_ERR");
                        lblMsg.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = msg.GetMessage("IMAGE_TYPE_ERR");
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
            }
            else
            {
                lblMsg.Text = "Not the type of document";
                lblMsg.ForeColor = Color.Red;
                return;
            }*/
        }

        //
        //dgvItemWS DataSource
        //
        protected void dgvItemWS_Data()
        {
            // IMV3 COMMENT OUT
            //ItemWS Ws = new ItemWS(g_user_id, g_lang);
            //ComLibrary Com = new ComLibrary();
            //DataSet dt = new DataSet();

            //Ws.beg_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            //Ws.end_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            //Ws.item_no = txtITEM_NO.Text.ToUpper();
            //txtITEM_NO.Text = Ws.item_no;
            //dt = Ws.GetItemWSList();
            //if (dt == null)
            //{
            //    return;
            //}
            //else
            //{
            //    dgvItemWS.DataSource = dt;
            //    dgvItemWS.DataBind();
            //    for (int i = 0; i < dgvItemWS.Rows.Count; i++)
            //    {
            //        dgvItemWS.Rows[i].Cells[3].Text = Com.StringToInt(dgvItemWS.Rows[i].Cells[3].Text).ToString("0###/##/##");
            //        dgvItemWS.Rows[i].Cells[4].Text = Com.StringToInt(dgvItemWS.Rows[i].Cells[4].Text).ToString("0###/##/##");
            //    }
            //}

        }
        //
        //dgvRoutine DataSource
        //
        protected void dgvRoutine_Data()
        {
            // IMV3 COMMENT OUT
            //Routine Rt = new Routine(g_user_id, g_lang);
            //ComLibrary Com = new ComLibrary();
            //DataSet dt = new DataSet();

            //Rt.beg_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            //Rt.end_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            //Rt.item_no = txtITEM_NO.Text.ToUpper();
            //txtITEM_NO.Text = Rt.item_no;
            //dt = Rt.GetRoutineList_item();
            //if (dt == null)
            //{
            //    return;
            //}
            //else
            //{
            //    dgvRoutine.DataSource = dt;
            //    dgvRoutine.DataBind();
            //    for (int i = 0; i < dgvRoutine.Rows.Count; i++)
            //    {
            //        dgvRoutine.Rows[i].Cells[5].Text = Com.StringToInt(dgvRoutine.Rows[i].Cells[5].Text).ToString("0###/##/##");
            //        dgvRoutine.Rows[i].Cells[6].Text = Com.StringToInt(dgvRoutine.Rows[i].Cells[6].Text).ToString("0###/##/##");
            //    }
            //}
        }
        //
        //dvgPurchase DataSource
        //
        /*protected void dvgPurchase_Data()
        {
            Purchase Rt = new Purchase(g_user_id, g_lang);
            ComLibrary Com = new ComLibrary();
            DataSet dt = new DataSet();

            Rt.item_no = txtITEM_NO.Text.ToUpper();
            Rt.beg_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            Rt.end_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            txtITEM_NO.Text = Rt.item_no;
            dt = Rt.GetPurchaseList_Item();
            if (dt == null)
            {
                return;
            }
            else
            {
                dvgPurchase.DataSource = dt;
                dvgPurchase.DataBind();
                for (int i = 0; i < dvgPurchase.Rows.Count; i++)
                {
                    dvgPurchase.Rows[i].Cells[3].Text = Com.StringToInt(dvgPurchase.Rows[i].Cells[3].Text).ToString("0###/##/##");
                    dvgPurchase.Rows[i].Cells[4].Text = Com.StringToInt(dvgPurchase.Rows[i].Cells[4].Text).ToString("0###/##/##");
                }
            }
        }*/
        //
        //dgvPurPrice DataSource
        //
        protected void dgvPurPrice_Data()
        {
            // IMV3 COMMENT OUT
            //PurPrice Rt = new PurPrice(g_user_id, g_lang);
            //ComLibrary Com = new ComLibrary();
            //DataSet dt = new DataSet();

            //Rt.item_no = txtITEM_NO.Text.ToUpper();
            //Rt.beg_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            //Rt.end_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMMdd"));
            //txtITEM_NO.Text = Rt.item_no;
            //dt = Rt.GetPurPriceList_Item();
            //if (dt == null)
            //{

            //    return;
            //}
            //else
            //{
            //    dgvPurPrice.DataSource = dt;
            //    dgvPurPrice.DataBind();
            //    for (int i = 0; i < dgvPurPrice.Rows.Count; i++)
            //    {
            //        dgvPurPrice.Rows[i].Cells[2].Text = Com.StringToInt(dgvPurPrice.Rows[i].Cells[2].Text).ToString("0###/##/##");
            //        dgvPurPrice.Rows[i].Cells[3].Text = Com.StringToInt(dgvPurPrice.Rows[i].Cells[3].Text).ToString("0###/##/##");
            //    }
            //}
        }
        //
        //dgvStdPrice DataSource
        //
        protected void dgvStdPrice_Data()
        {
            // IMV3 COMMENT OUT
            //StdPrice Rt = new StdPrice(g_user_id, g_lang);
            //ComLibrary Com = new ComLibrary();
            //DataSet dt = new DataSet();

            //Rt.item_no = txtITEM_NO.Text.ToUpper();
            //Rt.beg_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMM"));
            //Rt.end_eff_date = Com.StringToInt(DateTime.Today.ToString("yyyyMM"));
            //txtITEM_NO.Text = Rt.item_no;
            //dt = Rt.GetStdPriceList_item();
            //if (dt == null)
            //{
            //    return;
            //}
            //else
            //{
            //    dgvStdPrice.DataSource = dt;
            //    dgvStdPrice.DataBind();
            //    for (int i = 0; i < dgvStdPrice.Rows.Count; i++)
            //    {
            //        dgvStdPrice.Rows[i].Cells[0].Text = Com.StringToInt(dgvStdPrice.Rows[i].Cells[0].Text).ToString("0###/##");
            //        dgvStdPrice.Rows[i].Cells[1].Text = Com.StringToInt(dgvStdPrice.Rows[i].Cells[1].Text).ToString("0###/##");
            //    }
            //}
        }

        // IMV3 COMMENT OUT
        //protected void dgvItemWS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgvItemWS.SelectedIndex = -1;
        //    dgvItemWS.PageIndex = e.NewPageIndex;
        //    dgvItemWS_Data();
        //}

        // IMV3 COMMENT OUT
        //protected void dgvRoutine_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgvRoutine.SelectedIndex = -1;
        //    dgvRoutine.PageIndex = e.NewPageIndex;
        //    dgvRoutine_Data();
        //}

        protected void dvgPurchase_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //dvgPurchase.SelectedIndex = -1;
            //dvgPurchase.PageIndex = e.NewPageIndex;
            //dvgPurchase_Data();
        }

        // IMV3 COMMENT OUT
        //protected void dgvPurPrice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgvPurPrice.SelectedIndex = -1;
        //    dgvPurPrice.PageIndex = e.NewPageIndex;
        //    dgvPurPrice_Data();
        //}

        // IMV3 COMMENT OUT
        //protected void dgvStdPrice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgvStdPrice.SelectedIndex = -1;
        //    dgvStdPrice.PageIndex = e.NewPageIndex;
        //    dgvStdPrice_Data();
        //}

        protected void btnItemWS_Click(object sender, EventArgs e)
        {
            //string url = "~/Master/MstItemWSMnt/frmMain.aspx?ITEM_NO=" + txtITEM_NO.Text + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];

            //Upd 11.09.12 Ubiq-Sai
            string url = "~/Master/MstItemWSMnt/frmMain.aspx?ITEM_NO=" + HttpUtility.UrlEncode(txtITEM_NO.Text) + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];
            Response.Redirect(url);
        }

        protected void btnRoutine_Click(object sender, EventArgs e)
        {
            //string url = "~/Master/MstRoutineMnt/frmMain.aspx?ITEM_NO=" + txtITEM_NO.Text + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];

            //Upd 11.09.12 Ubiq-Sai
            string url = "~/Master/MstRoutineMnt/frmMain.aspx?ITEM_NO=" + HttpUtility.UrlEncode(txtITEM_NO.Text) + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];
            Response.Redirect(url);

        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            //string url = "~/Master/MstPurchaseMnt/frmMain.aspx?ITEM_NO=" + txtITEM_NO.Text + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];

            //Upd 11.09.12 Ubiq-Sai
            string url = "~/Master/MstPurchaseMnt/frmMain.aspx?ITEM_NO=" + HttpUtility.UrlEncode(txtITEM_NO.Text) + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];
            Response.Redirect(url);
        }

        protected void btnPurPrice_Click(object sender, EventArgs e)
        {
            //string url = "~/Master/MstPurPriceMnt/frmMain.aspx?ITEM_NO=" + txtITEM_NO.Text + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];

            //Upd 11.09.12 Ubiq-Sai
            string url = "~/Master/MstPurPriceMnt/frmMain.aspx?ITEM_NO=" + HttpUtility.UrlEncode(txtITEM_NO.Text) + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];
            Response.Redirect(url);

        }

        protected void btnStdPrice_Click(object sender, EventArgs e)
        {
            //string url = "~/Master/MstStdPriceMnt/frmMain.aspx?ITEM_NO=" + txtITEM_NO.Text + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];

            //Upd 11.09.12 Ubiq-Sai
            string url = "~/Master/MstStdPriceMnt/frmMain.aspx?ITEM_NO=" + HttpUtility.UrlEncode(txtITEM_NO.Text) + "&program_id=" + Request["program_id"] + "&level=" + Request["level"];
            Response.Redirect(url);
        }

        protected void rdoITEM_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComLibrary com = new ComLibrary();
            /*if (rdoITEM_TYPE.SelectedValue == "22")
            {
                com.Set_Attributes(Div1, 1);
                com.Set_Attributes(Div2, 1);
                com.Set_Attributes(Div3, 1);
                com.Set_Attributes(Div4, 1);
                com.Set_Attributes(Div5, 1);
                //com.Set_Attributes(Div6, 1);
                //rdoPO_TYPE.SelectedValue = "4";  // IMV3 COMMENT OUT
                //rdoPO_TYPE.Enabled = false;  // IMV3 COMMENT OUT

                FileUpload1.Enabled = true;
                FileUpload2.Enabled = true;
                btnASSY_IMAGE.Enabled = true;
                btnITEM_IMAGE.Enabled = true;
                //btnItemWS.Enabled = true;  // IMV3 COMMENT OUT
                btnPurchase.Enabled = true;
                //btnPurPrice.Enabled = true;  // IMV3 COMMENT OUT
                //btnRoutine.Enabled = true;  // IMV3 COMMENT OUT
                //btnStdPrice.Enabled = true;  // IMV3 COMMENT OUT
                btnOutStorage.Visible = true;
                btnOutStorageBond.Visible = true;
            }
            else if (rdoITEM_TYPE.SelectedValue == "99")
            {
                //rdoPO_TYPE.Enabled = true;
                com.Set_Attributes(Div1, 1);
                com.Set_Attributes(Div4, 1);
                com.Set_Attributes(Div2, 0);
                com.Set_Attributes(Div3, 0);
                com.Set_Attributes(Div5, 0);
                //com.Set_Attributes(Div6, 0);
                FileUpload1.Enabled = false;
                FileUpload2.Enabled = false;
                btnASSY_IMAGE.Enabled = false;
                btnITEM_IMAGE.Enabled = false;
                //btnItemWS.Enabled = false;  // IMV3 COMMENT OUT
                btnPurchase.Enabled = false;
                //btnPurPrice.Enabled = false;  // IMV3 COMMENT OUT
                //btnRoutine.Enabled = false;  // IMV3 COMMENT OUT
                //btnStdPrice.Enabled = false;  // IMV3 COMMENT OUT
                btnOutStorage.Visible = false;
                btnOutStorageBond.Visible = false;
            }
            else
            {
                com.Set_Attributes(Div1, 1);
                com.Set_Attributes(Div2, 1);
                com.Set_Attributes(Div3, 1);
                com.Set_Attributes(Div4, 1);
                com.Set_Attributes(Div5, 1);
                //com.Set_Attributes(Div6, 1);
                //rdoPO_TYPE.Enabled = true;
                FileUpload1.Enabled = true;
                FileUpload2.Enabled = true;
                btnASSY_IMAGE.Enabled = true;
                btnITEM_IMAGE.Enabled = true;
                //btnItemWS.Enabled = true;  // IMV3 COMMENT OUT
                btnPurchase.Enabled = true;
                //btnPurPrice.Enabled = true;  // IMV3 COMMENT OUT
                //btnRoutine.Enabled = true;  // IMV3 COMMENT OUT
                //btnStdPrice.Enabled = true;  // IMV3 COMMENT OUT
                btnOutStorage.Visible = true;
                btnOutStorageBond.Visible = true;
            }*/
        }

        protected void imgReturn_Click(object sender, EventArgs e)
        {

            string strUrl = "Default.aspx";
            Response.Redirect(strUrl);
        }

        /// <summary>
        /// Picture UpLoad
        /// </summary>
        /// <param name="FUD">FileUpload  </param>
        /// <param name="HDN">HiddenField </param>
        /// <param name="a"> </param>
        protected void Picture_UpLoad(int i)
        {

            Item it = new Item(g_user_id, g_lang);
            Message msg = new Message(g_user_id, g_lang);
            int rtn = 0;
            it.item_no = txtITEM_NO.Text.ToUpper();
            if (i == 1)
            {
                it.item_image = ItemPicture.Value;
                it.assy_image = "";
            }
            if (i == 2)
            {
                it.item_image = "";
                it.assy_image = AssyPicture.Value;
            }
            rtn = it.Picture_Update();
            if (rtn == ComConst.SUCCEED)
            {
                lblMsg.Text = msg.GetMessage("IMAGE_UPLOAD_SUCCESSFUL");
                lblMsg.ForeColor = Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = it.strErr;
                lblMsg.ForeColor = Color.Red;
                return;
            }
        }
    }
}