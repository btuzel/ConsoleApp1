using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class OnedioNews /// BU ÇALIŞIYOR 
    {
        static void Mamin(string[] args)
        {
            List<string> modaTitleList = new List<string>();
            List<string> goygoyTitleList = new List<string>();
            List<string> astrolojiTitleList = new List<string>();
            List<DateTimeOffset> modaDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> goygoyDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> astrolojiDateTimeList = new List<DateTimeOffset>();
            List<string> modaImageList = new List<string>();
            List<string> goygoyImageList = new List<string>();
            List<string> astrolojiImageList = new List<string>();
            List<string> modaNewsLinkPathList = new List<string>();
            List<string> goygoyNewsLinkPathList = new List<string>();
            List<string> astrolojiNewsLinkPathList = new List<string>();
            string modaRssLink = "https://onedio.com/support/rss.xml?category=4fa8fda4ed765b112200000f";
            string goygoyRssLink = "https://onedio.com/support/rss.xml?category=59edf033289af902f042bceb";
            string astrolojiRssLink = "https://onedio.com/support/rss.xml?category=5a292d8ef9222eb9b448cea2";
            List<string> modaDescriptionList = new List<string>();
            List<string> goygoyDescriptionList = new List<string>();
            List<string> astrolojiDescriptionList = new List<string>();
            XmlReader modaReader = XmlReader.Create(modaRssLink);
            XmlReader goygoyReader = XmlReader.Create(goygoyRssLink);
            XmlReader astrolojiReader = XmlReader.Create(astrolojiRssLink);
            SyndicationFeed modaFeed = SyndicationFeed.Load(modaReader);
            SyndicationFeed goygoyFeed = SyndicationFeed.Load(goygoyReader);
            SyndicationFeed astrolojiFeed = SyndicationFeed.Load(astrolojiReader);
            foreach (SyndicationItem item2 in modaFeed.Items)
            {
                modaNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                modaImageList.Add(item2.Summary.Text.Substring(13, 69));
                modaTitleList.Add(item2.Title.Text);
                modaDateTimeList.Add(item2.PublishDate);
                modaDescriptionList.Add(item2.Summary.Text.Split('>')[4]); 
            }
            for (int i = 0; i < modaTitleList.Count; i++)
            {
                Console.WriteLine(modaTitleList[i] + "   " + modaNewsLinkPathList[i] + "    " + modaImageList[i] +  "     " + modaDateTimeList[i] + "     " + modaDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in goygoyFeed.Items)
            {
                goygoyNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                goygoyImageList.Add(item2.Summary.Text.Substring(13, 69));
                goygoyTitleList.Add(item2.Title.Text);
                goygoyDateTimeList.Add(item2.PublishDate);
                goygoyDescriptionList.Add(item2.Summary.Text.Split('>')[4]);

            }
            for (int i = 0; i < goygoyTitleList.Count; i++)
            {
                Console.WriteLine(goygoyTitleList[i] + "    " + goygoyNewsLinkPathList[i] + "     " + goygoyImageList[i] + "    " + goygoyDateTimeList[i]  + "    " + goygoyDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in astrolojiFeed.Items)
            {
                astrolojiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                astrolojiImageList.Add(item2.Summary.Text.Substring(13, 69));
                astrolojiTitleList.Add(item2.Title.Text);
                astrolojiDateTimeList.Add(item2.PublishDate);
                astrolojiDescriptionList.Add(item2.Summary.Text.Split('>')[4]);

            }
            for (int i = 0; i < astrolojiTitleList.Count; i++)
            {
                Console.WriteLine(astrolojiTitleList[i] + "    " + astrolojiNewsLinkPathList[i] + "    " + astrolojiImageList[i] + "     " + astrolojiDateTimeList[i]  + "     " + astrolojiDescriptionList[i]);
            }
            Console.ReadLine();
        }
    }
}
