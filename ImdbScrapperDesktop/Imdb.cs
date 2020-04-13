using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImdbScrapperDesktop
{
    class Imdb 
    {
        readonly string searchUrl = "https://www.imdb.com/find?q={0}&ref_=nv_sr_sm";

        public List<string> skMovieTitles = new List<string>();
        public List<string> skMovieNames = new List<string>();
        public List<string> skMovieDates = new List<string>();
        public string TitleUrl { get; set; }
        public string Input { get; set; }
        private string Html;
        public Imdb(string input)
        {
            Input = input;

            DownloadHtml();
            FetchFields();
        }
        public string DownloadHtml()
        {
            string inputMovieName = Input;
            string downloadingUrl = string.Format($"{searchUrl}", Input);
            WebClient webClient = new WebClient();
            
            Html = webClient.DownloadString(downloadingUrl);
            byte[] bytes = Encoding.Default.GetBytes(Html);
            Html = Encoding.UTF8.GetString(bytes);
            return Html;
        }
        private void FetchFields()
        {
            int tempIndex;
            string uniqueKey = "result_text";

            var htmlresultIndex = Html.IndexOf(uniqueKey);
            var htmllastresultIndex = Html.IndexOf("\"findMoreMatches\"");
            var tempLenght = htmllastresultIndex - htmlresultIndex;
            Html = Html.Substring(htmlresultIndex, tempLenght);//title harici gelenler siliniyor

            while (Html.IndexOf(uniqueKey) != -1)
            {
                tempIndex = Html.IndexOf(uniqueKey);//result_txt uniq keyword arama işlemi
                tempIndex = tempIndex + uniqueKey.Length; // indexi result_txt'nin boyutu kadar , ilerletiyorum ilk resulttexti yok etmiş oluyorum
                var htmlNeeded = Html.Substring(tempIndex + 2); // <ahref'ten itibaren string ifadem 

                //Title String işlemleri

                var titleurlFirstIndex = htmlNeeded.IndexOf("/title");
                var titleurlLastIndex = htmlNeeded.IndexOf(">");
                tempLenght = titleurlLastIndex - titleurlFirstIndex;
                var titleUrl = htmlNeeded.Substring(titleurlFirstIndex, tempLenght - 2);// /title ile başlayan url parçası > arası alınır
                skMovieTitles.Add(titleUrl);

                // Film ismi için string işlemleri

                var movieNameFirstIndex = htmlNeeded.IndexOf(">");
                var movieName = htmlNeeded.Substring(movieNameFirstIndex+1);
                tempIndex = movieName.IndexOf("<");
                htmlNeeded = movieName;
                htmlNeeded.Substring(tempIndex);
                movieName = movieName.Substring(0, tempIndex);

                skMovieNames.Add(movieName);
                
                //Date string parçalama işlemleri
                var controlString = "(";
                var tempstr = htmlNeeded.Substring(tempIndex + 6, 1);

                if (controlString == htmlNeeded.Substring(tempIndex + 5, 1))
                {
                    var movieDate = htmlNeeded.Substring(tempIndex + 5, 6);
                    movieDate = movieDate.Substring(1, 4);

                    skMovieDates.Add(movieDate);
                }

                else
                {
                    skMovieDates.Add(null);
                }


                Html = htmlNeeded;
            }
        }
    }
}
