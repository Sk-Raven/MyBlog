using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        int num = 2;
        string conn = "Server=localhost;Database=data;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT text.html,text.title,text.download FROM text ORDER BY text.`int` ASC", con);
        MySqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        Response.Write(dr[0].ToString());
        dr.Read();
        string str = dr[0].ToString();
        Response.Write("<div id=\"gtco - maine\">< div class=\"container\"><div class=\"row row-pb-md\"><div class=\"col-md-12\"><article class=\"mt-negative\"><div class=\"text-left content-article\"><div class=\"row\"><div class=\"col-lg-13 cp-r animate-box\"><div class=\"WordSection1\"> <div align = \"center\" ></ div ></ div > ");
        while (dr.Read())
        {   if (dr[2].ToString().Equals("1"))
            {
                Response.Write("<a class=\"h4\" target=\"_blank\" style=\"text - decoration:none\" href=\"Downloadcontroller.aspx?" + dr[0].ToString() + "\">");
                Response.Write(dr[1].ToString());
            }
            else
            {
                Response.Write("<a class=\"h4\"  style=\"text - decoration:none\" href=\"text.aspx?text="+num.ToString()+"\">");
                num++;
                Response.Write(dr[1].ToString());
            }
            Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            Response.Write("</a>");
        }
        Response.Write("</div></ div ></ div ></ article ></ div ></ div ></ div ></ div > ");
        Response.Write(str);
        dr.Close();
        con.Close();
    }
}