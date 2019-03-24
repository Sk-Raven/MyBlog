using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Downloadcontroller : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)

    {

        var filename = Request.QueryString;
        var fullpath = "/data/" + filename;
       
        this.Response.Clear();
        this.Response.ContentType = "application/octet-stream";
        this.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        this.Response.TransmitFile(fullpath);
        this.Response.End();
    }
}