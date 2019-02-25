using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;


namespace ConsoleApp1
{
    class MilliyetNews    //// BU ÇALIŞIYOR
    {                                                 
        static void Main(string[] args)
        {
            List<string> siyasetTitleList = new List<string>();
            List<string> ekonomiTitleList = new List<string>();
            List<string> teknolojiTitleList = new List<string>();
            List<DateTimeOffset> siyasetDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> ekonomiDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> teknolojiDateTimeList = new List<DateTimeOffset>();
            List<string> siyasetImageList = new List<string>();
            List<string> ekonomiImageList = new List<string>();
            List<string> teknolojiImageList = new List<string>();
            List<string> siyasetNewsLinkPathList = new List<string>();
            List<string> ekonomiNewsLinkPathList = new List<string>();
            List<string> teknolojiNewsLinkPathList = new List<string>();
            List<string> siyasetDescriptionList = new List<string>();
            List<string> ekonomiDescriptionList = new List<string>();
            List<string> teknolojiDescriptionList = new List<string>();
            string siyasetRssLink = "http://www.milliyet.com.tr/rss/rssNew/siyasetRss.xml";
            string ekonomiRssLink = "http://www.milliyet.com.tr/rss/rssNew/ekonomiRss.xml";
            string teknolojiRssLink = "http://www.milliyet.com.tr/rss/rssNew/teknolojiRss.xml";
            XmlReader siyasetReader = XmlReader.Create(siyasetRssLink);
            XmlReader ekonomiReader = XmlReader.Create(ekonomiRssLink);
            XmlReader teknolojiReader = XmlReader.Create(teknolojiRssLink);
            SyndicationFeed siyasetFeed = SyndicationFeed.Load(siyasetReader);
            SyndicationFeed ekonomiFeed = SyndicationFeed.Load(ekonomiReader);
            SyndicationFeed teknolojiFeed = SyndicationFeed.Load(teknolojiReader);
            foreach (SyndicationItem item2 in siyasetFeed.Items)
            {
                if (item2.Summary.Text.Contains("src"))
                {
                    siyasetImageList.Add(item2.Summary.Text.Substring(51, 70));
                    siyasetTitleList.Add(item2.Title.Text);
                    siyasetDateTimeList.Add(item2.PublishDate);
                    siyasetDescriptionList.Add(item2.Summary.Text.Split(';')[2]);
                    siyasetNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                }
            }
            for (int i = 0; i < siyasetTitleList.Count; i++)
            {
                Console.WriteLine(siyasetTitleList[i] + "    " + siyasetDateTimeList[i] + "     " + siyasetImageList[i] + "    "+ siyasetNewsLinkPathList[i] + "    " +siyasetDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in ekonomiFeed.Items)
            {
                if (item2.Summary.Text.Contains("src"))
                {
                    ekonomiImageList.Add(item2.Summary.Text.Substring(51, 70));
                    ekonomiTitleList.Add(item2.Title.Text);
                    ekonomiDateTimeList.Add(item2.PublishDate);
                    ekonomiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                    ekonomiDescriptionList.Add(item2.Summary.Text.Split(';')[2]);

                }
            }
            for (int i = 0; i < ekonomiTitleList.Count; i++)
            {
                Console.WriteLine(ekonomiTitleList[i] + "    " + ekonomiDateTimeList[i] + "    " + ekonomiImageList[i] + "   " + ekonomiNewsLinkPathList[i] + "    " + ekonomiDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in teknolojiFeed.Items)
            {
                if (item2.Summary.Text.Contains("src"))
                {
                    teknolojiImageList.Add(item2.Summary.Text.Substring(51, 84));
                    teknolojiTitleList.Add(item2.Title.Text);
                    teknolojiDateTimeList.Add(item2.PublishDate);
                    teknolojiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                    teknolojiDescriptionList.Add(item2.Summary.Text.Split(';')[2]);

                }
            }
            for (int i = 0; i < teknolojiTitleList.Count; i++)
            {
                Console.WriteLine(teknolojiTitleList[i] + "    " + teknolojiDateTimeList[i] + "    " + teknolojiImageList[i] + "   " + teknolojiNewsLinkPathList[i] + "    " +teknolojiDescriptionList[i] );
            }
            Console.ReadLine();
        }
    }
}
