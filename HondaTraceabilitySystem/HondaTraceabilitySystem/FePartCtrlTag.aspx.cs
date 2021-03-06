﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMClass;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Web.Configuration;
using System.Text;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace HondaTraceabilitySystem
{
    public partial class FePartCtrlTag : System.Web.UI.Page
    {
        protected string g_user_id;
        protected int g_lang;
        protected string g_company_cd;
        protected string g_name;
        protected int form_load = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie MyCookie;
            try
            {
                MyCookie = new HttpCookie("IMLastVisit");
                HttpCookieCollection MyCookieColl = Request.Cookies;
                MyCookie = MyCookieColl.Get("IMLastVisit");

                g_user_id = MyCookie.Values["USER_ID"];
                g_lang = int.Parse(MyCookie.Values["LANG"]);
                g_company_cd = MyCookie.Values["COMPANY_CD"];
                g_name = HttpUtility.UrlDecode(MyCookie.Values["NAME"]);
            }
            catch
            {
                //Response.Redirect("~/NotLoginErr.htm");
                Response.Redirect("~/Login.aspx");
            }
            //g_user_id = "test";
            //g_lang = 2;
            //g_name = "TEST USER";
            //Page.Form.DefaultButton = cmdDisp.UniqueID;
            if (!IsPostBack)
            {
                //// 画面編集
                Init_Label();
                Init_Proc();
            }
            else
            {
                Edit_Screen();
            }
            lblMsg.Text = "";
            //Auth_Proc();
        }

        //
        // 初期画面ラベル編集
        //
        protected void Init_Label()
        {
            lblUserName.Text = g_name;

        }

        /// <summary>
        /// 初期画面編集
        /// </summary>
        protected void Init_Proc()
        {
            ddl_edit();
        }

        /// <summary>
        /// EDIT DROP DOWN LIST
        /// </summary>
        protected void ddl_edit()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("PROCESS_NO"));
            dt.Columns.Add(new DataColumn("PROCESS_NAME"));

            dt.Rows.Add("Crank Shaft", "Crank Shaft");
            dt.Rows.Add("Conn Rod", "Conn Rod");

            ddlPROCESS.DataValueField = "PROCESS_NO";
            ddlPROCESS.DataTextField = "PROCESS_NAME";
            ddlPROCESS.DataSource = dt;
            ddlPROCESS.DataBind();
        }

        #region ：画面権限編集
        /// <summary>
        /// 画面権限編集 
        /// </summary>
        protected void Auth_Proc()
        {
        }

        #endregion

        protected void cmdDisp_Click(object sender, EventArgs e)
        {
            gdvDetail.DataSource = null;
            gdvDetail.DataBind();
            ViewState["gdvDetail"] = null;

            Edit_Screen();
        }

        protected void Edit_Screen()
        {
            ComLibrary com = new ComLibrary();
            Message msg = new Message(g_user_id, g_lang);
            WIPJo jo = new WIPJo(g_user_id, g_lang);
            DataSet ds = new DataSet();

            chkALL_SEL.Checked = false;
            gdvDetail.DataSource = null;
            gdvDetail.DataBind();
            ViewState["gdvDetail"] = null;

            // 製造指示情報を検索
            jo.process_cd = ddlPROCESS.Text;
            jo.entry_date = DateTime.Now;

            ds = jo.Get_JOList5();
            if (ds == null)
            {
                lblMsg.Text = jo.strErr;
                lblMsg.ForeColor = Color.Red;
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblMsg.Text = msg.GetMessage("DATA_NOT_EXIST_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }
            else
            {
                gdvDetail.PageIndex = 0;
                ViewState["gdvDetail"] = ds.Tables[0];
                Edit_Grid();
            }
        }

        protected void SaveGridData()
        {
            if (gdvDetail.Rows.Count != 0)
            {
                ComLibrary com = new ComLibrary();
                DataTable dt = (DataTable)(ViewState["gdvDetail"]);
                if (dt.Columns["SELECT"] == null)
                {
                    dt.Columns.Add("SELECT");
                }
                int j;
                for (int i = 0; i < gdvDetail.Rows.Count; i++)
                {
                    j = gdvDetail.Rows[i].DataItemIndex;
                    dt.Rows[j]["SELECT"] = com.BoolToInt(((CheckBox)gdvDetail.Rows[i].FindControl("chkSEL")).Checked);
                }
                ViewState["gdvDetail"] = dt;
            }
        }

        protected void Edit_Grid()
        {
            SaveGridData();
            int j;
            ComLibrary com = new ComLibrary();
            DataTable dt = (DataTable)ViewState["gdvDetail"];
            if (dt.Columns["SELECT"] == null)
            {
                dt.Columns.Add("SELECT");
            }
            gdvDetail.DataSource = dt;
            gdvDetail.DataBind();
            for (int i = 0; i < gdvDetail.Rows.Count; i++)
            {
                j = gdvDetail.Rows[i].DataItemIndex;
                if (dt.Rows[j]["SELECT"].ToString() != "")
                    ((CheckBox)gdvDetail.Rows[i].FindControl("chkSEL")).Checked = com.IntToBool(com.StringToInt(dt.Rows[j]["SELECT"].ToString()));
            }
        }

        protected void cmdPrint_Click(object sender, EventArgs e)
        {
            
        }

        protected void ChangeColor(int i, bool Flag)
        {
            int j;
            if (gdvDetail.PageIndex != i / gdvDetail.PageSize)
            {
                gdvDetail.PageIndex = (i / gdvDetail.PageSize);
                Edit_Grid();
            }
            j = i - ((gdvDetail.PageIndex) * gdvDetail.PageSize);
            if (Flag)
            {
                gdvDetail.Rows[j].BackColor = Color.Red;
            }
            else
            {
                gdvDetail.Rows[j].BackColor = Color.Transparent;
            }
        }

        protected void imgReturn_Click(object sender, EventArgs e)
        {
            //string g_program_id = Request["program_id"].ToString();
            //int g_level = int.Parse(Request["level"].ToString());
            //IMClass.Common com = new IMClass.Common();
            //g_program_id = com.GetBackMenuGrp(g_program_id, g_level);
            //string strUrl = "~/Default.aspx?program_id=" + g_program_id + "&level=" + g_level.ToString();
            string strUrl = "Default.aspx";
            Response.Redirect(strUrl);
        }

        protected void gdvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvDetail.PageIndex = e.NewPageIndex;
            if (ViewState["gdvDetail"] != null)
            {
                Edit_Grid();
            }
        }

        protected void gdvDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void chkALL_SEL_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["gdvDetail"] != null)
            {
                DataTable dt = (DataTable)ViewState["gdvDetail"];
                string chk;
                if (chkALL_SEL.Checked)
                {
                    chk = "1";
                }
                else
                {
                    chk = "0";
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SELECT"] = chk;
                }
                for (int i = 0; i < gdvDetail.Rows.Count; i++)
                {
                    ((CheckBox)gdvDetail.Rows[i].FindControl("chkSEL")).Checked = chkALL_SEL.Checked;
                }
            }
        }

        protected void ddlPROCESS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit_Screen();
        }

        protected void chkSEL_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}