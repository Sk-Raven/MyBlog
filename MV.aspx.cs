using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MV :  System.Web.UI.Page
{
    public string directory=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int num = 2;
        string conn = "Server=localhost;Database=data;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT text.html,text.title,text.download FROM life ORDER BY life.`int` ASC", con);
        MySqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        dr.Read();
        while (dr.Read())
        {
            if (dr[2].ToString().Equals("1"))
            {
                directory += "<a class=\"h4\" target=\"_blank\" style=\"text-decoration:none\" href=\"Downloadcontroller.aspx?" + dr[0].ToString() + "\">";
                
            }
            else if (dr[2].ToString().Equals("2"))
            {
                directory += "<a class=\"h4\" target=\"_blank\" style=\"text-decoration:none\" href=\"" + dr[0].ToString() + "\">";
            }
            else
            {
                directory += "<a class=\"h4\"  style=\"text-decoration:none\" href=\"text.aspx?text=" + num.ToString() + "\">";
                num++;
            }
            directory += dr[1].ToString();
            directory += "</a>";
            directory += "<br />";
            directory += "<p class=\"col-sm-pull-0\"></p>";
        }
        dr.Close();
        con.Close();
    }
}