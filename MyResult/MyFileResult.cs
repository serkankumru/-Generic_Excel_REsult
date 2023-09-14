using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.MyResult
{
    public class MyFileResult<T> : ActionResult where T :class
    {
        List<T> list;
        public MyFileResult(List<T> listT)
        {
            list = listT;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var news = list;
            var grid = new GridView();

            grid.DataSource = news;
            grid.DataBind();

            context.RequestContext.HttpContext.Response.ClearContent();
            context.RequestContext.HttpContext.Response.Buffer = true;
            context.RequestContext.HttpContext.Response.AddHeader("content-disposition", "attacmant; filename="+typeof(T).Name+".xls");
            context.RequestContext.HttpContext.Response.ContentType = "application/ms-excel";

            context.RequestContext.HttpContext.Response.Charset = "";




            //string s = "";
            //foreach (var item in news)
            //{
            //    s += string.Format(@"<tr><td>{0}</td><td>{1}</td><td>{1}</td></tr>", item.Title, item.Spot, item.Content);
            //}
            //string result = @"<div><table cellspacing = '0' rules='all' border='1' style='border-collapse:collapse;'><tr>
            //        <th scope='col'>Title</th>
            //        <th scope='col'>Spot</th>
            //        <th scope='col'>Content</th>                
            //    </tr>"+s+"</table></div>";



            // context.RequestContext.HttpContext.Response.Output.Write(result);


            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            context.RequestContext.HttpContext.Response.Output.Write(sw.ToString());


            context.RequestContext.HttpContext.Response.Flush();
            context.RequestContext.HttpContext.Response.End();
        }
    }
}