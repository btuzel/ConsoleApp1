using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1      //BU DA ÇALIŞIYOR
{   
    class HaberturkNews
    {

        static void Maoin(string[] args)
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
            string sporRssLink = "http://www.haberturk.com/rss/spor.xml";
            string ekonomiRssLink = "http://www.haberturk.com/rss/ekonomi.xml";
            string magazinRssLink = "http://www.haberturk.com/rss/magazin.xml";
            XmlReader sporReader = XmlReader.Create(sporRssLink);
            XmlReader ekonomiReader = XmlReader.Create(ekonomiRssLink);
            XmlReader magazinReader = XmlReader.Create(magazinRssLink);
            SyndicationFeed sporFeed = SyndicationFeed.Load(sporReader);
            SyndicationFeed ekonomiFeed = SyndicationFeed.Load(ekonomiReader);
            SyndicationFeed magazinFeed = SyndicationFeed.Load(magazinReader);
            foreach (SyndicationItem item2 in sporFeed.Items)
            {
                sporNewsLinkPathList.Add(item2.Links[1].Uri.ToString());
                sporImageList.Add(item2.Links[0].Uri.ToString());
                sporTitleList.Add(item2.Title.Text);
                sporDateTimeList.Add(item2.PublishDate);
                string alt = "alt";
                int indexOfAlt = item2.Summary.Text.IndexOf(alt);
                string align = "align";
                int indexofAlign = item2.Summary.Text.LastIndexOf(align);
                sporDescriptionList.Add(item2.Summary.Text.Substring(indexOfAlt+5,indexofAlign-indexOfAlt-7));
               
                
                    ///alt ve align arasını al,sağ ve soldan 2 char kes
            }
            for (int i = 0; i < sporTitleList.Count; i++)
            {
                Console.WriteLine(sporTitleList[i] + "   " + sporNewsLinkPathList[i] + "    " + sporDateTimeList[i] + "     " + sporImageList[i] + "    " + sporDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in ekonomiFeed.Items)
            {
                ekonomiNewsLinkPathList.Add(item2.Links[1].Uri.ToString());
                ekonomiImageList.Add(item2.Links[0].Uri.ToString());
                ekonomiTitleList.Add(item2.Title.Text);
                ekonomiDateTimeList.Add(item2.PublishDate);
                string alt = "alt";
                int indexOfAlt = item2.Summary.Text.IndexOf(alt);
                string align = "align";
                int indexofAlign = item2.Summary.Text.LastIndexOf(align);
                ekonomiDescriptionList.Add(item2.Summary.Text.Substring(indexOfAlt + 5, indexofAlign - indexOfAlt - 7));


            }
            for (int i = 0; i < ekonomiTitleList.Count; i++)
            {
                Console.WriteLine(ekonomiTitleList[i] + "    " + ekonomiNewsLinkPathList[i] + "     " + ekonomiDateTimeList[i] + "    " + ekonomiImageList[i] + "    " + ekonomiDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in magazinFeed.Items)
            {
                magazinNewsLinkPathList.Add(item2.Links[1].Uri.ToString());
                magazinImageList.Add(item2.Links[0].Uri.ToString());
                magazinTitleList.Add(item2.Title.Text);
                magazinDateTimeList.Add(item2.PublishDate);
                string alt = "alt";
                int indexOfAlt = item2.Summary.Text.IndexOf(alt);
                string align = "align";
                int indexofAlign = item2.Summary.Text.LastIndexOf(align);
                magazinDescriptionList.Add(item2.Summary.Text.Substring(indexOfAlt + 5, indexofAlign - indexOfAlt - 7));


            }
            for (int i = 0; i < magazinTitleList.Count; i++)
            {
                Console.WriteLine(magazinTitleList[i] + "    " + magazinNewsLinkPathList[i] + "    " + magazinDateTimeList[i] + "    " + magazinImageList[i] + "    " + magazinDescriptionList[i]);
            }
            Console.ReadLine();
        }
    }
}

