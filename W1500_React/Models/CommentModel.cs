using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W1500_React.Models
{

    /// <summary>
    /// 引用自
    /// https://reactjs.net/getting-started/tutorial_aspnet4.html
    /// 
    /// 用于测试 Server-side Data 的类.
    /// </summary>
    public class CommentModel
    {

        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

    }
}