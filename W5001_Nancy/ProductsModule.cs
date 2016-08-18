using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Nancy;


namespace W5001_Nancy
{


    public class ProductsModule : NancyModule
    {

        /// <summary>
        /// 这里 定义的 路径， 需要   /products  开头.
        /// </summary>
        public ProductsModule() : base("/products")
        {


            Get["/list"] = _ =>
            {
                return "This page will show products list";
            };

        }


    }
}
