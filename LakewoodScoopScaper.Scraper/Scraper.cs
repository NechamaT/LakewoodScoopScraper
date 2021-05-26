using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace LakewoodScoopScaper.Scraper
{
    public  static class Scraper
    {
        public static List<LakewoodScoopElement> ScrapeResults()
        {
            var results = new List<LakewoodScoopElement>();
            var html = GetHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            IHtmlCollection<IElement> resultsElements = document.QuerySelectorAll(".post");
            foreach (IElement element in resultsElements)
            {

                var titleSpan = element.QuerySelector("h2");
                var lakewoodScoopElement = new LakewoodScoopElement();
                if (titleSpan == null)
                {
                    continue;
                }

                var titleSpanText = titleSpan.TextContent;
                lakewoodScoopElement.Title = titleSpan.TextContent;
                var url = titleSpan.QuerySelector("a");
                if (url != null)
                {
                    lakewoodScoopElement.Url = url.Attributes["href"].Value;
                }

                var imageSpan = element.QuerySelector("img");
                if (imageSpan != null)
                {
                    lakewoodScoopElement.Image = imageSpan.Attributes["src"].Value;
                }

                var textSpan = element.QuerySelector("p");
                var text = textSpan.TextContent;
                if (text != null)
                {
                    lakewoodScoopElement.Blurb = text;
                }

                var commentsSpan = element.QuerySelector(".backtotop");
                var commentsCount = commentsSpan.TextContent;
                if (commentsCount != null)
                {
                    lakewoodScoopElement.Comments = commentsCount;
                }

                results.Add(lakewoodScoopElement);
                Console.WriteLine(results.Count);
            }
            return results;
        }




        public static string GetHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            string url = "https://www.thelakewoodscoop.com/";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;
        }


    }
}
