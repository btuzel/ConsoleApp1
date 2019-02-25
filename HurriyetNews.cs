using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ConsoleApp1
{
    class HurriyetNews       /// BU DA ÇALIŞIYOR
    {

        static void Maain(string[] args)
        {
            List<string> gundemTitleList = new List<string>();       //başlıklar
            List<string> ekonomiTitleList = new List<string>();
            List<string> teknolojiTitleList = new List<string>();
            List<DateTimeOffset> gundemDateTimeList = new List<DateTimeOffset>();  //yayımlanma tarihi
            List<DateTimeOffset> ekonomiDateTimeList = new List<DateTimeOffset>();
            List<DateTimeOffset> teknolojiDateTimeList = new List<DateTimeOffset>();
            List<string> gundemImageList = new List<string>();    //resimler
            List<string> ekonomiImageList = new List<string>();
            List<string> teknolojiImageList = new List<string>();
            List<string> gundemNewsLinkPathList = new List<string>();   //linkler
            List<string> ekonomiNewsLinkPathList = new List<string>();
            List<string> teknolojiNewsLinkPathList = new List<string>();
            List<string> gundemDescriptionList = new List<string>();      //haberin açıklaması
            List<string> ekonomiDescriptionList = new List<string>();
            List<string> teknolojiDescriptionList = new List<string>();
            string gundemRssLink ="http://www.hurriyet.com.tr/rss/gundem";      //rss linki
            string ekonomiRssLink = "http://www.hurriyet.com.tr/rss/ekonomi";
            string teknolojiRssLink = "http://www.hurriyet.com.tr/rss/teknoloji";
            XmlReader gundemReader = XmlReader.Create(gundemRssLink);      //xml reader
            XmlReader ekonomiReader = XmlReader.Create(ekonomiRssLink);
            XmlReader teknolojiReader = XmlReader.Create(teknolojiRssLink);
            SyndicationFeed gundemFeed = SyndicationFeed.Load(gundemReader);    //rss feed yükleyici
            SyndicationFeed ekonomiFeed = SyndicationFeed.Load(ekonomiReader);
            SyndicationFeed teknolojiFeed = SyndicationFeed.Load(teknolojiReader);
            foreach (SyndicationItem item2 in gundemFeed.Items)      //xml'deki her item için
            {
                    gundemNewsLinkPathList.Add(item2.Links[0].Uri.ToString());    //listeye ekle
                    gundemImageList.Add(item2.Links[1].Uri.ToString().Substring(7));    
                    gundemTitleList.Add(item2.Title.Text);
                    gundemDateTimeList.Add(item2.PublishDate);
                    gundemDescriptionList.Add(item2.Summary.Text);
            }
            for (int i = 0; i < gundemTitleList.Count; i++)
            { 
                Console.WriteLine(gundemTitleList[i] + "   " + gundemNewsLinkPathList[i] +"    " + gundemDateTimeList[i] + "     " +gundemImageList[i] + "   " + gundemDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in ekonomiFeed.Items)
            {
                    ekonomiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                    ekonomiImageList.Add(item2.Links[1].Uri.ToString().Substring(7));
                    ekonomiTitleList.Add(item2.Title.Text);
                    ekonomiDateTimeList.Add(item2.PublishDate);
                    ekonomiDescriptionList.Add(item2.Summary.Text);
                
            }
            for (int i = 0; i < ekonomiTitleList.Count; i++)
            {
                Console.WriteLine(ekonomiTitleList[i] + "    " + ekonomiNewsLinkPathList[i]+"     "+  ekonomiDateTimeList[i] + "    " +ekonomiImageList[i] + "    " + ekonomiDescriptionList[i]);
            }
            Console.WriteLine("---------------------");
            foreach (SyndicationItem item2 in teknolojiFeed.Items)
            {
                    teknolojiNewsLinkPathList.Add(item2.Links[0].Uri.ToString());
                    teknolojiImageList.Add(item2.Links[1].Uri.ToString().Substring(7));
                    teknolojiTitleList.Add(item2.Title.Text);
                    teknolojiDateTimeList.Add(item2.PublishDate);
                    teknolojiDescriptionList.Add(item2.Summary.Text);
                
            }
            for (int i = 0; i < teknolojiTitleList.Count; i++)
            {
                Console.WriteLine(teknolojiTitleList[i] + "    " +teknolojiNewsLinkPathList[i]+"    " + teknolojiDateTimeList[i] + "    "+  teknolojiImageList[i] + "   " + teknolojiDescriptionList[i]);
            }
            Console.ReadLine();
        }
    }
}


