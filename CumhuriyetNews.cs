using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class CumhuriyetNews      /// BU DA ÇALIŞIYOR
    {
        static void Maian(string[] args)
        {
            List<string> sporTitleList = new List<string>();
            List<string> ekonomiTitleList = new List<string>();
            List<string> siyasetTitleList = new List<string>();
            List<DateTimeOffset> sporDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> ekonomiDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> siyasetDateTimeList = new List<DateTimeOffset>();
            List<string> sporImageList = new List<string>();
            List<string> ekonomiImageList = new List<string>();
            List<string> siyasetImageList = new List<string>();
            List<string> sporNewsLinkPathList = new List<string>();
            List<string> ekonomiNewsLinkPathList = new List<string>();
            List<string> siyasetNewsLinkPathList = new List<string>();
            string sporRssLink = "http://www.cumhuriyet.com.tr/rss/9.xml";
            string ekonomiRssLink = "http://www.cumhuriyet.com.tr/rss/6.xml";
            string siyasetRssLink = "http://www.cumhuriyet.com.tr/rss/3.xml";
            List<string> sporDescriptionList = new List<string>();
            List<string> ekonomiDescriptionList = new List<string>();
            List<string> siyasetDescriptionList = new List<string>();
            XmlReader sporReader = XmlReader.Create(sporRssLink);
            XmlReader ekonomiReader = XmlReader.Create(ekonomiRssLink);
            XmlReader siyasetReader = XmlReader.Create(siyasetRssLink);
            SyndicationFeed sporFeed = SyndicationFeed.Load(sporReader);
            SyndicationFeed ekonomiFeed = SyndicationFeed.Load(ekonomiReader);
            SyndicationFeed siyasetFeed = SyndicationFeed.Load(siyasetReader);
            foreach (SyndicationItem item2 in sporFeed.Items)
            {
                sporNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                sporImageList.Add(item2.Links[1].Uri.ToString());
                sporTitleList.Add(item2.Title.Text);
                sporDateTimeList.Add(item2.PublishDate);
                sporDescriptionList.Add(item2.Summary.Text.Split('<')[0]);  //çünkü cumhuriyet descriptionları içinde <div> vs var....
            }
            for (int i = 0; i < sporTitleList.Count; i++)
            {
                Console.WriteLine(sporTitleList[i] + "   " + sporNewsLinkPathList[i] + "    " + sporDateTimeList[i] + "     " + sporImageList[i] + "     " + sporDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in ekonomiFeed.Items)
            {
                ekonomiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                ekonomiImageList.Add(item2.Links[1].Uri.ToString());
                ekonomiTitleList.Add(item2.Title.Text);
                ekonomiDateTimeList.Add(item2.PublishDate);
                ekonomiDescriptionList.Add(item2.Summary.Text.Split('<')[0]);

            }
            for (int i = 0; i < ekonomiTitleList.Count; i++)
            {
                Console.WriteLine(ekonomiTitleList[i] + "    " + ekonomiNewsLinkPathList[i] + "     " + ekonomiDateTimeList[i] + "    " + ekonomiImageList[i] + "    " + ekonomiDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in siyasetFeed.Items)
            {
                siyasetNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                siyasetImageList.Add(item2.Links[1].Uri.ToString());
                siyasetTitleList.Add(item2.Title.Text);
                siyasetDateTimeList.Add(item2.PublishDate);
                siyasetDescriptionList.Add(item2.Summary.Text.Split('<')[0]);

            }
            for (int i = 0; i < siyasetTitleList.Count; i++)
            {
                Console.WriteLine(siyasetTitleList[i] + "    " + siyasetNewsLinkPathList[i] + "    " + siyasetDateTimeList[i] + "    " + siyasetImageList[i] + "     " + siyasetDescriptionList[i]);
            }
            Console.ReadLine();
        }
    }
}


