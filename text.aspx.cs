using System;
using  MySql.Data.MySqlClient;

public partial class text : System.Web.UI.Page
{
    public string html = "a";
    public string image ;
    public string title;
    public string date="2017.11.10";
    public string writter = "我到处瞎抄的";

    protected void Page_Load(object sender, EventArgs e)
    {    
        string num = Request["text"];
        string data = Request["data"];      
        if(data=="life")
        image= "b.JPG";
        if (data == "MV")
            image = "2.JPG";
        if (data == "travel")
            image = "10.png";
        if (data == "resotfware")
            image = "1.png";
        if (data == "cpp")
            image = "9.png";
        string conn = "Server=localhost;Database=test;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT "+data+".html,"+ data+".title FROM " + data+" ORDER BY " + data+".`int` ASC", con);
        MySqlDataReader dr = cmd.ExecuteReader();
        for (int k = 0; k <= int.Parse(num); k++)
            dr.Read();
        title = dr[1].ToString();
        html = dr[0].ToString();
        con.Close();
            

        
    }
}


