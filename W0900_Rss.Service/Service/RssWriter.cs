using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;


using W0900_Rss.Model;


namespace W0900_Rss.Service
{

    public class RssWriter
    {




        public void WriteRssFile(Rss rssData, string rssFileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Rss));
            using (StreamWriter sw = new StreamWriter(rssFileName))
            {
                xs.Serialize(sw, rssData);
                sw.Close();
            }
        }




    }

}
