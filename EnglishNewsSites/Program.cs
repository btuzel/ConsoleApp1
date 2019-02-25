using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace EnglishNewsSites
{
    class BbcNews
    {
        static void Maimn(string[] args)
        {
            List<string> sporTitleList = new List<string>();
            List<string> ekonomiTitleList = new List<string>();
            List<string> magazinTitleList = new List<string>();
            List<DateTimeOffset> sporDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> ekonomiDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> magazinDateTimeList = new List<DateTimeOffset>();
            List<string> sporImageList = new List<string>();
            List<string> ekonomiImageList = new List<string>();
            List<string> magazinImageList = new List<string>();
            List<string> sporNewsLinkPathList = new List<string>();
            List<string> ekonomiNewsLinkPathList = new List<string>();
            List<string> magazinNewsLinkPathList = new List<string>();
            List<string> sporDescriptionList = new List<string>();      //haberin açıklaması
            List<string> ekonomiDescriptionList = new List<string>();
            List<string> magazinDescriptionList = new List<string>();
            string sporRssLink = "https://www.theguardian.com/football/rss";
            string ekonomiRssLink = "https://www.theguardian.com/uk/business/rss";
            string magazinRssLink = "https://www.theguardian.com/uk/culture/rss";
            XmlReader sporReader = XmlReader.Create(sporRssLink);
            XmlReader ekonomiReader = XmlReader.Create(ekonomiRssLink);
            XmlReader magazinReader = XmlReader.Create(magazinRssLink);
            SyndicationFeed sporFeed = SyndicationFeed.Load(sporReader);
            SyndicationFeed ekonomiFeed = SyndicationFeed.Load(ekonomiReader);
            SyndicationFeed magazinFeed = SyndicationFeed.Load(magazinReader);
            foreach (SyndicationItem item2 in sporFeed.Items)
            {

                if (!item2.Title.Text.Contains("sign") && !item2.Title.Text.Contains("Sign"))
                {
                    sporNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                    sporTitleList.Add(item2.Title.Text);
                    sporDateTimeList.Add(item2.PublishDate);
                }

                ///alt ve align arasını al,sağ ve soldan 2 char kes
            }
            for (int i = 0; i < sporTitleList.Count; i++)
            {
                Console.WriteLine(sporTitleList[i] + "   " + sporNewsLinkPathList[i] + "    " + sporDateTimeList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in ekonomiFeed.Items)
            {
                if (!item2.Title.Text.Contains("sign") && !item2.Title.Text.Contains("Sign"))
                {
                    ekonomiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                    ekonomiTitleList.Add(item2.Title.Text);
                    ekonomiDateTimeList.Add(item2.PublishDate);
                }


            }
            for (int i = 0; i < ekonomiTitleList.Count; i++)
            {
                Console.WriteLine(ekonomiTitleList[i] + "    " + ekonomiNewsLinkPathList[i] + "     " + ekonomiDateTimeList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in magazinFeed.Items)
            {


                if (!item2.Title.Text.Contains("Sign") && !item2.Title.Text.Contains("Sign")) { 
                magazinNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                magazinTitleList.Add(item2.Title.Text);
                magazinDateTimeList.Add(item2.PublishDate);
                magazinDescriptionList.Add(item2.Summary.Text.Substring(3));


            }
            }
            for (int i = 0; i < magazinTitleList.Count; i++)
            {
                Console.WriteLine(magazinTitleList[i] + "    " + magazinNewsLinkPathList[i] + "    " + magazinDateTimeList[i] + "    " + magazinDescriptionList[i]);
            }
            Console.ReadLine();












        }
    }
}
