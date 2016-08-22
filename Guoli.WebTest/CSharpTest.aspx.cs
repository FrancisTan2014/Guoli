using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Guoli.Bll;
using Guoli.Utilities.Helpers;

namespace Guoli.WebTest
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public struct Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Change(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", _x.ToString(), _y.ToString());
        }
    }
    
    public partial class CSharpTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 本例证明了对引用类型来说，LINQ函数只是复制了对原集中对象的引用，而没有新创建一个对象
            var li = new Person { Name = "LI", Age = 32 };
            var wang = new Person{ Name = "WANG", Age = 48 };

            var list = new List<Person>();
            list.Add(li);
            list.Add(wang);

            var subList = list.Where(person => person.Age == 32).ToList();
            subList[0].Age = 22;

            Response.Write(list[0].Age);

            // 装箱与拆箱，观察值的变化
            Point p = new Point(1, 1);
            Response.Write(p);

            p.Change(2, 2);
            Response.Write(p);

            object o = p;
            Response.Write(o);

            ((Point) o).Change(3, 3);
            Response.Write(o);

            Response.Write("<br/><hr/><br/>");

            // 反射调用带out参数的方法：跟普通反射调用方法一样，不过区别在于将传入的参数数组定义成变量，方法在执行完成后，out参数值会被更新到此数组变量中
            var bll = new ViewPersonInfoBll();
            var type = bll.GetType();
            
            var arguments = new object[]
            {
                1, 1, "UpdateTime", true, 0
            };
            var data = type.InvokeMember("QueryPageList", BindingFlags.InvokeMethod, null, bll, arguments);

            Response.Write("反射调用带out参数的方法：<br/>");
            Response.Write("totalCount: " + arguments[4] + "<br/>");
            Response.Write("data: " + JsonHelper.Serialize(data));

            // 2016-08 字符串转换为DateTime类型的结果
            Response.Write("<br/><hr/><br/>");
            Response.Write("字符串'2016-08'转换为DateTime的结果：<br/>");
            Response.Write(Convert.ToDateTime("2016-08"));

            Response.Write("<br/><hr/><br/>");

            // Request.Querystring与Request.Form的区别
            var typeGet = Request.QueryString["type"];
            Response.Write("通过Request.QueryString[\"type\"]获取的结果：" + typeGet);
            Response.Write("<br/>");

            var typePost = Request.Form["type"];
            Response.Write("通过Request.Form[\"type\"]获取的结果：" + typePost);
            
        }
    }
}