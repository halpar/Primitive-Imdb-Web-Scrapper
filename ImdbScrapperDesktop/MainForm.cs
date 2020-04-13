using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImdbScrapperDesktop
{

    public partial class MainForm : Form
    {
        SqlConnection connection = new SqlConnection(@"server=.\MSSQLSERVERHAL;database=IMDBDB;trusted_connection=true");
        public MainForm()
        {

            InitializeComponent();

        }
        private void Clear()
        {
            richMovieDescr.Text = "";
            rtbRating.Text = "";
            lstbxRoles.Items.Clear();
            lstbxActorName.Items.Clear();
            lblMovieName.Text = "";
            lstbxGenres.Items.Clear();
        }
        private void ClearAll()
        {
            tbReleaseDate.Text = "";
            lstbxJobs.Items.Clear();
            rtbActorDesc.Text = "";
            lblActorName.Text = "";
            pcbxActor.Image = null;
            lstbxKeys.Items.Clear();
            richMovieDescr.Text = "";
            pcbxMovie.Image = null;
            rtbRating.Text = "";
            lstbxActorName.Items.Clear();
            lstbxRoles.Items.Clear();
            lstbxDates.Items.Clear();
            lstbxMovieNames.Items.Clear();
            tbSearch.Text = "";
            lblMovieName.Text = "";
            lstbxGenres.Text = "";

            btnSearch.Enabled = true;
        }
        private void ClearMovie()
        {
            richMovieDescr.Text = "";
            pcbxMovie.Image = null;
            rtbRating.Text = "";
            lstbxActorName.Items.Clear();
            lstbxRoles.Items.Clear();
            lstbxDates.Items.Clear();
            lstbxMovieNames.Items.Clear();
            tbSearch.Text = "";
        }
        private void ClearActor()
        {
            lstbxJobs.Items.Clear();
            rtbActorDesc.Text = "";
            lblActorName.Text = "";
            pcbxActor.Image = null;
            lstbxKeys.Items.Clear();
            lstbxDates.Items.Clear();
        }
        private string DownloadMovieJson(Movie movie)
        {
            string htmlJson;
            string movieUrl = "https://www.imdb.com{0}";
            var titleKey = "@type";
            var scriptKey = "</script>";
            string movieHtml = string.Format($"{movieUrl}", movie.MovieTitleUrl);
            WebClient webClient = new WebClient();
            movieHtml = webClient.DownloadString(movieHtml);
            byte[] bytes = Encoding.Default.GetBytes(movieHtml);
            movieHtml = Encoding.UTF8.GetString(bytes);
            if (movieHtml.Contains("@type"))
            {
                var firstIndexTitleKey = movieHtml.IndexOf(titleKey);
                htmlJson = movieHtml.Substring(firstIndexTitleKey); //ilk @typetan sonrası kesildi
                var lastIndexTitleKey = htmlJson.IndexOf(scriptKey);

                htmlJson = htmlJson.Substring(0, lastIndexTitleKey);
                return htmlJson;
            }
            else
            {
                return string.Empty;
            }
        }
        private void FetchCast(string htmlJson, Movie movie)
        {
            //Actor işlemleri
            var actorBaseKey = "actor";
            var actorHtml = htmlJson;
            var urlKey = "\"url\"";
            var nameKey = "\"name\"";
            string result;

            if (actorHtml.Contains(actorBaseKey))  //String ifademin içerisinde actor var mı yok mu , yoksa aktörler gösterilemez
            {
                var firstIndexActor = actorHtml.IndexOf(actorBaseKey) + 8;
                result = actorHtml.Substring(firstIndexActor); //actor katarından sonraki ilk "[" katarına kadar string ifadeyi kesiyorum
                if (result.Contains("[") && result.Contains("]"))
                {
                    var lastIndexActor = result.IndexOf("]");
                    firstIndexActor = result.IndexOf("[");
                    var tempLenght = lastIndexActor - firstIndexActor;
                    actorHtml = result.Substring(firstIndexActor, tempLenght); //Köşeli parantezler arası tüm aktörler json formatı olarak burada

                    while (actorHtml.IndexOf(urlKey) != -1) //"name" bulunamayana kadar döner
                    {
                        var index = actorHtml.IndexOf(urlKey);
                        actorHtml = actorHtml.Substring(index + urlKey.Length + 3);// " "name" " katarının indexi ve uzunluğu  + 3 katar ilerletiyorum
                        var tempIndex = actorHtml.IndexOf("\"");
                        var tempLenght1 = tempIndex;
                        var actorUrl = actorHtml.Substring(0, tempLenght1);   // string ifademin 0. elemanından " işaretine kadar olan kısmı actor adı

                        index = actorHtml.IndexOf(nameKey);
                        actorHtml = actorHtml.Substring(index + urlKey.Length + 4);
                        tempIndex = actorHtml.IndexOf("\"");
                        tempLenght1 = tempIndex;
                        var actorName = actorHtml.Substring(0, tempLenght1);

                        Cast person = new Cast();
                        person.Roles.Add(Role.Actor);
                        person.Name = actorName;
                        person.Url = actorUrl;
                        movie.Casts.Add(person);
                    }
                }
                else
                {
                    var actorIndex = actorHtml.IndexOf("actor");
                    actorHtml = actorHtml.Substring(actorIndex);
                    string[] actorSplittedJson = actorHtml.Split('"');

                    Cast person = new Cast();
                    person.Roles.Add(Role.Actor);
                    person.Name = actorSplittedJson[12];
                    person.Url = actorSplittedJson[8];
                    movie.Casts.Add(person);
                }
            }
            else
            {
                lstbxActorName.Items.Add("Actors cannot found"); //?
            }
            //Director İşlemleri

            var directorKey = "\"director\"";
            var directorHtml = htmlJson;

            if (htmlJson.Contains(directorKey)) //director kontrolü , kimi zaman json içerisinde director gelmemekte
            {
                var temporaryIndex = actorHtml.IndexOf(directorKey) + 8;
                result = directorHtml.Substring(temporaryIndex); //director katarından sonraki ilk "[" katarına kadar string ifadeyi kesiyorum
                if (result.Contains("[") && result.Contains("]"))
                {
                    var firstIndexDirector = directorHtml.IndexOf(directorKey);
                    var tempResult = directorHtml.Substring(firstIndexDirector);
                    var lastIndexDirector = tempResult.IndexOf("]");
                    firstIndexDirector = tempResult.IndexOf("[");
                    var tempLenght = lastIndexDirector - firstIndexDirector;
                    directorHtml = tempResult.Substring(firstIndexDirector, tempLenght); //Köşeli parantezler arası json stringi

                    while (directorHtml.IndexOf(nameKey) != -1)//"name" bulunamayana kadar döner
                    {
                        var index = directorHtml.IndexOf(urlKey);
                        directorHtml = directorHtml.Substring(index + nameKey.Length + 2);
                        var tempIndex = directorHtml.IndexOf("\"");
                        tempLenght = tempIndex - 0;
                        var directorUrl = directorHtml.Substring(0, tempLenght); // İlk eleman ile tırnak işareti arası yönetmen ismi olacak
                        index = directorHtml.IndexOf(nameKey);
                        directorHtml = directorHtml.Substring(index + nameKey.Length + 3);
                        tempIndex = directorHtml.IndexOf("\"");
                        tempLenght = tempIndex;
                        var directorName = directorHtml.Substring(0, tempLenght);


                        bool isContains = false;

                        for (int i = 0; i < movie.Casts.Count; i++)
                        {
                            if (movie.Casts[i].Url == directorUrl)  //Url üzerinden kontrol et eğer varsa o elemanın rolüne directorü ekle
                            {
                                movie.Casts[i].Roles.Add(Role.Director);
                                isContains = true;
                            }
                            else
                            {

                                continue;
                            }
                        }

                        if (isContains == false)  // yoksa oluştur
                        {
                            Cast person1 = new Cast();
                            person1.Url = directorUrl;
                            person1.Name = directorName;
                            person1.Roles.Add(Role.Director);
                            movie.Casts.Add(person1);
                        }
                        else  // varsa bir şey yapma
                        {
                            continue;
                        }

                    }

                } //Bulursa yeni bir cast üyesi oluşturup rolünü director olarak belirleyip movie cast listesine referansını atıyor

                else // Bazı filmlerin tek castı , tek aktörü ve tek writeri olabiliyor onun için kontrol koymam gerekti
                {
                    var directorIndex = directorHtml.IndexOf("director");
                    directorHtml = directorHtml.Substring(directorIndex);
                    string[] splittedDirectorHtml = directorHtml.Split('"');

                    Cast person = new Cast();
                    person.Roles.Add(Role.Director);
                    person.Url = splittedDirectorHtml[8];
                    person.Name = splittedDirectorHtml[12];
                    movie.Casts.Add(person);
                }
            }


            else
            {
                lstbxRoles.Items.Add("Director cannot be found"); //?
            }

            // Writer işlemleri

            var writerKey = "\"writer\"";
            var writerHtml = htmlJson;

            if (htmlJson.Contains(writerKey))
            {
                var temporaryIndex = writerHtml.IndexOf(writerKey) + 8;
                result = writerHtml.Substring(temporaryIndex); //writer katarından sonraki ilk "[" katarına kadar string ifadeyi kesiyorum
                if (result.Contains("[") && result.Contains("]"))
                {
                    var firstIndexWriter = writerHtml.IndexOf(writerKey);
                    var tempResult = writerHtml.Substring(firstIndexWriter);
                    var lastIndexCreator = tempResult.IndexOf("]");
                    firstIndexWriter = tempResult.IndexOf("[");
                    var tempLenght = lastIndexCreator - firstIndexWriter;
                    writerHtml = tempResult.Substring(firstIndexWriter, tempLenght); //Köşeli parantezler arası json stringi

                    while (writerHtml.IndexOf(nameKey) != -1)//"name" bulunamayana kadar döner
                    {
                        var index = writerHtml.IndexOf(urlKey);
                        writerHtml = writerHtml.Substring(index + nameKey.Length + 2);
                        var tempIndex = writerHtml.IndexOf("\"");
                        tempLenght = tempIndex - 0;
                        var writerUrl = writerHtml.Substring(0, tempLenght); // İlk eleman ile tırnak işareti arası yönetmen ismi olacak
                        index = writerHtml.IndexOf(nameKey);
                        writerHtml = writerHtml.Substring(index + nameKey.Length + 3);
                        tempIndex = writerHtml.IndexOf("\"");
                        tempLenght = tempIndex;
                        var writerName = writerHtml.Substring(0, tempLenght);


                        bool isContains = false; //contains true dönerse aranılan eleman listede değildir yeni kişi oluşturulup listeye eklenmelidir

                        for (int i = 0; i < movie.Casts.Count; i++)
                        {
                            if (movie.Casts[i].Url == writerUrl)
                            {
                                movie.Casts[i].Roles.Add(Role.Writer);
                                isContains = true;
                            }
                            else
                            {

                                continue;
                            }
                        }

                        if (isContains == false)
                        {
                            Cast person1 = new Cast();
                            person1.Url = writerUrl;
                            person1.Name = writerName;
                            person1.Roles.Add(Role.Writer);
                            movie.Casts.Add(person1);
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
                else
                {
                    var writerIndex = writerHtml.IndexOf("writer");
                    writerHtml = writerHtml.Substring(writerIndex);
                    string[] splittedWriterHtml = writerHtml.Split('"');

                    Cast person = new Cast();
                    person.Roles.Add(Role.Writer);
                    person.Name = splittedWriterHtml[12];
                    movie.Casts.Add(person);
                }

            }
            else
            {
                //else getir
            }

            //Creator işlemleri

            var creatorKey = "\"creator\"";
            var creatorHtml = htmlJson;

            if (htmlJson.Contains(creatorKey))
            {

                var temporaryIndex = creatorHtml.IndexOf(creatorKey) + 8;
                result = creatorHtml.Substring(temporaryIndex); //writer katarından sonraki ilk "[" katarına kadar string ifadeyi kesiyorum
                if (result.Contains("[") && result.Contains("]"))
                {
                    var firstIndexCreator = creatorHtml.IndexOf(creatorKey);
                    var tempResult = creatorHtml.Substring(firstIndexCreator);
                    var lastIndexCreator = tempResult.IndexOf("]");
                    firstIndexCreator = tempResult.IndexOf("[");
                    var tempLenght = lastIndexCreator - firstIndexCreator;
                    creatorHtml = tempResult.Substring(firstIndexCreator, tempLenght); //Köşeli parantezler arası json stringi

                    while (creatorHtml.IndexOf(nameKey) != -1)//"name" bulunamayana kadar döner
                    {
                        var index = creatorHtml.IndexOf(urlKey);
                        creatorHtml = creatorHtml.Substring(index + nameKey.Length + 2);
                        var tempIndex = creatorHtml.IndexOf("\"");
                        tempLenght = tempIndex - 0;
                        var creatorUrl = creatorHtml.Substring(0, tempLenght); // İlk eleman ile tırnak işareti arası yönetmen ismi olacak
                        index = creatorHtml.IndexOf(nameKey);
                        creatorHtml = creatorHtml.Substring(index + nameKey.Length + 3);
                        tempIndex = creatorHtml.IndexOf("\"");
                        tempLenght = tempIndex;
                        var creatorName = creatorHtml.Substring(0, tempLenght);


                        bool isContains = false; //contains true dönerse aranılan eleman listede değildir yeni kişi oluşturulup listeye eklenmelidir

                        for (int i = 0; i < movie.Casts.Count; i++)
                        {
                            if (movie.Casts[i].Url == creatorUrl)
                            {
                                movie.Casts[i].Roles.Add(Role.Creator);
                                isContains = true;
                            }
                            else
                            {

                                continue;
                            }
                        }

                        if (isContains == false)
                        {
                            Cast person1 = new Cast();
                            person1.Url = creatorUrl;
                            person1.Name = creatorName;
                            person1.Roles.Add(Role.Creator);
                            movie.Casts.Add(person1);
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
                else
                {
                    var creatorIndex = creatorHtml.IndexOf("creator");
                    creatorHtml = creatorHtml.Substring(creatorIndex);
                    string[] splittedCreatorHtml = creatorHtml.Split('"');

                    Cast person = new Cast();
                    person.Roles.Add(Role.Creator);
                    person.Name = splittedCreatorHtml[12];
                    person.Url = splittedCreatorHtml[8];
                    movie.Casts.Add(person);
                }
            }
            else
            {
                //else getir
            }

            //for (int i = 0; i < movie.Casts.Count; i++) //listboxa cast referansını ekle   , listboxa o referansa ait enum rollerini ekle
            //{
            //    lstbxActorName.Items.Add((Cast)movie.Casts[i]);

            //    string roleName = null;

            //    for (int j = 0; j != movie.Casts[i].Roles.Count; j++)
            //    {
            //        roleName = String.Format("{0} , {1}", movie.Casts[i].Roles[j].ToString(), roleName);
            //    }

            //    lstbxRoles.Items.Add(roleName);

            //}

        }
        private void FetchDescriptionAndDate(string htmlJson, Movie movie)
        {

            var descriptionKey = "description";

            if (htmlJson.Contains(descriptionKey))
            {
                var htmlDescriptionPart = htmlJson;
                var descriptionIndex = htmlDescriptionPart.IndexOf(descriptionKey);
                descriptionIndex = descriptionIndex + descriptionKey.Length + 4;
                var tempLenght = descriptionIndex - 0;
                htmlDescriptionPart = htmlDescriptionPart.Remove(0, tempLenght);
                var datePublishedIndex = htmlDescriptionPart.IndexOf("datePublished");
                tempLenght = htmlDescriptionPart.IndexOf("\"") - 0;
                htmlDescriptionPart = htmlDescriptionPart.Substring(0, tempLenght);// descriptionun ilk bulunduğu yerdeki indexi ve " işareti arası
                movie.Description = htmlDescriptionPart;
            }
            else
            {
                movie.Description = string.Empty;
            }


            if (string.IsNullOrEmpty(movie.MovieDate))
            {
                string datePublishedKey = "\"datePublished\"";
                if (htmlJson.Contains(datePublishedKey))
                {
                    var tempIndex = htmlJson.IndexOf(datePublishedKey);
                    var datePublished = htmlJson.Substring(tempIndex + datePublishedKey.Length + 3);

                    tempIndex = datePublished.IndexOf("\"");
                    datePublished = datePublished.Substring(0, tempIndex);
                    datePublished = datePublished.Substring(1, 4);
                    movie.MovieDate = datePublished; // TODO
                }

                else
                {
                    movie.MovieDate = string.Empty;
                }
            }

            else
            {

            }
        }
        private void FetchRating(string htmlJson, Movie movie)
        {
            //Rating işlemleri
            var ratingKey = "\"ratingValue\"";
            if (htmlJson.Contains(ratingKey))
            {
                var ratingHtml = htmlJson;
                var tempIndexSecond = ratingHtml.IndexOf(ratingKey) + 3 + ratingKey.Length;
                ratingHtml = ratingHtml.Substring(tempIndexSecond, 4);
                ratingHtml = ratingHtml.Substring(0, 3);
                movie.Rating = ratingHtml;
            }
            else
            {
                movie.Rating = string.Empty;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnMovieImages.Enabled = false;
            btnPersonImages.Enabled = false;
            btnAddWL.Enabled = false;
        }
        private void FetchBornInfo(Cast person, string html)
        {
            string searchKey = "\"name-born-info\"";
            int tempIndex = html.IndexOf(searchKey);
            string bornInfo = html.Substring(tempIndex + searchKey.Length + 3);
            tempIndex = bornInfo.IndexOf("</div>");
            bornInfo = bornInfo.Substring(0, tempIndex);

            string[] bornInfoArray = new string[3];
            searchKey = "</a>";

            for (int i = 0; i < bornInfoArray.Length; i++)
            {
                tempIndex = bornInfo.IndexOf(searchKey);
                tempIndex = bornInfo.LastIndexOf(searchKey);
                if (tempIndex < 0)
                {
                    continue;
                }
                bornInfo = bornInfo.Substring(0, tempIndex);//</a> kesildi
                tempIndex = bornInfo.LastIndexOf(">");

                bornInfoArray[i] = bornInfo.Substring(tempIndex + 1);
            }

            tempIndex = bornInfoArray[0].IndexOf(",");

            if (tempIndex < 0)
            {

            }
            else
            {
                person.BornCity = bornInfoArray[0].Substring(0, tempIndex);
            }

            person.BornCountry = bornInfoArray[0].Substring(tempIndex + 1);
            person.BornYear = bornInfoArray[1];
            tempIndex = bornInfoArray[2].IndexOf(" ");
            person.BornMonth = bornInfoArray[2].Substring(0, tempIndex);
            person.BornDay = bornInfoArray[2].Substring(tempIndex);

            person.BornDetails = String.Format("{0} , {1} , {2}", bornInfoArray[2], bornInfoArray[1], bornInfoArray[0]);

            //tbBirthDetails.Text = person.BornDetails; TODO

        }
        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void lstbxActorName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnWL.Enabled = false;
            btnAddWL.Enabled = false;
            btnMovieImages.Enabled = false;
            btnPersonImages.Enabled = true;
            connection.Close();
            Cast person = (Cast)lstbxActorName.SelectedItem;
            ClearActor();
            connection.Open();
            //SqlCommand cmd = new SqlCommand("SELECT distinct pmr.MovieID ,m.MovieName,m.MovieDescription,m.MovieDate , m.MovieRating,m.MovieTitleURL FROM PersonMovieRole pmr INNER JOIN Movies m on m.ID = pmr.MovieID INNER JOIN Persons p on p.ID = pmr.PersonID WHERE PersonID = @personID EXCEPT SELECT distinct pmr.MovieID, m.MovieName, m.MovieDescription, m.MovieDate, m.MovieRating, m.MovieTitleURL FROM PersonMovieRole pmr INNER JOIN Movies m on m.ID = pmr.MovieID INNER JOIN Persons p on p.ID = pmr.PersonID WHERE MovieID = @movieID", connection);
            //cmd.Parameters.AddWithValue("@personId", person.Url);
            //cmd.Parameters.AddWithValue("@movieID", person.Movies[0].MovieID);
            SqlCommand cmd = new SqlCommand("Select * From Persons WHERE ID = @personID",connection);
            cmd.Parameters.AddWithValue("@personId", person.Url);
            SqlDataReader rdrPerson = cmd.ExecuteReader();
            bool state = rdrPerson.HasRows;
            while (rdrPerson.Read())
            {
                if (rdrPerson.IsDBNull(2))
                {
                    state = false;
                    break;
                }
                else
                {
                    state = true;
                    break;
                }
            }
            rdrPerson.Close();
            rdrPerson = cmd.ExecuteReader();

            if (state == true)//Aktör daha önce aratılmış mı? -Aratılmış
            {
                person.Movies.Clear();
                fetchJobs(person);
                rdrPerson.Close();

                cmd = new SqlCommand("SELECT * FROM Persons WHERE ID = @personId", connection); // o zaman db'de vardır
                cmd.Parameters.AddWithValue("@personID", person.Url);
                rdrPerson = cmd.ExecuteReader();
                while (rdrPerson.Read())
                {
                    person.Url = rdrPerson.GetString(0);
                    person.Name = rdrPerson.GetString(1);
                    person.Description = !rdrPerson.IsDBNull(2) ? rdrPerson.GetString(2) : "";
                    person.BornDay = !rdrPerson.IsDBNull(3) ? rdrPerson.GetString(3) : "";
                    person.BornMonth = !rdrPerson.IsDBNull(4) ? rdrPerson.GetString(4) : "";
                    person.BornYear = !rdrPerson.IsDBNull(5) ? rdrPerson.GetString(5) : "";
                    person.BornCity = !rdrPerson.IsDBNull(6) ? rdrPerson.GetString(6) : "";
                    person.BornCountry = !rdrPerson.IsDBNull(7) ? rdrPerson.GetString(7) : "";
                    person.ImageUrl = !rdrPerson.IsDBNull(8) ? rdrPerson.GetString(8) : "";
                }
                rdrPerson.Close();

                cmd = new SqlCommand("SELECT * FROM PersonImage WHERE PersonID = @personID", connection);
                cmd.Parameters.AddWithValue("@personID", person.Url);
                rdrPerson = cmd.ExecuteReader();
                while(rdrPerson.Read())
                {
                    person.Images.Add(rdrPerson.GetString(2));
                }

                rdrPerson.Close();
            }
            else //Aratılmamış
            {
                rdrPerson.Close();
                actorInitiator(person); //Person instance ının içerisinde tüm filmleri de mevcut
                FetchAllPersonImages(person);

                SqlCommand comm = new SqlCommand("UPDATE Persons SET Description = @description, BirthDay = @birthDay, BirthMonth = @birthMonth , BirthYear = @birthYear , BornCity = @bornCity , BornCountry = @bornCountry ,ImageURL = @imageURL WHERE ID = @personId", connection);
                comm.Parameters.AddWithValue("@personID", person.Url);
                comm.Parameters.AddWithValue("@description", person.Description);
                comm.Parameters.AddWithValue("@birthDay", person.BornDay);
                comm.Parameters.AddWithValue("@birthMonth", person.BornMonth);
                comm.Parameters.AddWithValue("@birthYear", person.BornYear);
                comm.Parameters.AddWithValue("@bornCity", person.BornCity);
                comm.Parameters.AddWithValue("@bornCountry", person.BornCountry);
                comm.Parameters.AddWithValue("@imageURL", person.ImageUrl);
                comm.ExecuteNonQuery();


                foreach (var image in person.Images) //Foto ekle
                {
                    comm = new SqlCommand("INSERT INTO PersonImage(PersonID , Image)VALUES(@personID,@ImageURL)", connection);
                    comm.Parameters.AddWithValue("@personID", person.Url);
                    comm.Parameters.AddWithValue("@ImageURL", image);
                    comm.ExecuteNonQuery();
                }

            }
            rdrPerson.Close();
            connection.Close();
            rtbActorDesc.Text = person.Description == "" ? "No Description" : person.Description;
            tbBirthDetails.Text = $"{person.BornCountry} {person.BornCity} , {person.BornDay} , {person.BornMonth}, {person.BornYear}";
            lblActorName.Text = person.Name;
            foreach (var movie in person.Movies)
            {
                lstbxJobs.Items.Add(movie);
            }
            foreach (var title in person.JobTitles)
            {
                lstbxKeys.Items.Add(title);
            }
            WebRequest request = WebRequest.Create(person.ImageUrl);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            pcbxActor.Image = Bitmap.FromStream(stream);

        }
        private void lstbxMovieNames_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnAddWL.Enabled = true;
            btnMovieImages.Enabled = true;
            Clear();
            Movie movie = (Movie)lstbxMovieNames.SelectedItem; //movie referansı tutuldu
            MovieInitializer(movie);

            richMovieDescr.Text = movie.Description == "" || movie.Description == null ? "No Description" : movie.Description;
            tbReleaseDate.Text = movie.MovieDate == "" || movie.MovieDate == null ? "Release date cannot found" : movie.MovieDate;
            lblMovieName.Text = movie.MovieName.ToString();
            rtbRating.Text = movie.Rating == "" || movie.Rating == null ? "No Description" : movie.Rating;

            foreach (var genre in movie.Genres)
            {
                lstbxGenres.Items.Add(genre);
            }

            foreach (var person in movie.Casts)
            {
                lstbxActorName.Items.Add(person);
                person.Movies.Add(movie);
                string roleNames = "";
                foreach (var role in person.Roles)
                {
                    roleNames = $"{roleNames} {role}";
                }
                lstbxRoles.Items.Add(roleNames);

            }
            WebRequest request = WebRequest.Create(movie.ImageUrl);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            pcbxMovie.Image = Bitmap.FromStream(stream);

        }
        private void lstbxJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWL.Enabled = true;
            btnAddWL.Enabled = true;
            btnMovieImages.Enabled = true;
            Movie movie = (Movie)lstbxJobs.SelectedItem; //movie referansı tutuldu
            ClearMovie();
            lblMovieName.Text = movie.MovieName;
            MovieInitializer(movie);
            richMovieDescr.Text = movie.Description == "" || movie.Description == null ? "No Description" : movie.Description;
            tbReleaseDate.Text = movie.MovieDate == "" || movie.MovieDate == null ? "Release date cannot found" : movie.MovieDate;
            lblMovieName.Text = movie.MovieName.ToString();
            rtbRating.Text = movie.Rating == "" || movie.Rating == null ? "No Rating" : movie.Rating;
            foreach (var person in movie.Casts)
            {
                lstbxActorName.Items.Add(person);
                person.Movies.Add(movie);//edited
                string roleNames = "";
                foreach (var role in person.Roles)
                {
                    roleNames = $"{roleNames} {role}";
                }
                lstbxRoles.Items.Add(roleNames);
            }
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            Imdb imdb = new Imdb(tbSearch.Text);//initializing object


            for (int i = 0; i < imdb.skMovieDates.Count; i++) //Kaç isim varsa o kadar film oluşturuldu
            {
                Movie movie = new Movie();
                movie.MovieTitleUrl = imdb.skMovieTitles[i];
                movie.MovieName = imdb.skMovieNames[i];
                movie.MovieDate = imdb.skMovieDates[i];

                //Generate ID
                int tempIndex = movie.MovieTitleUrl.IndexOf("?");
                int tempIndex2 = movie.MovieTitleUrl.IndexOf("e");
                movie.MovieID = movie.MovieTitleUrl.Substring(tempIndex2 + 2, (tempIndex - 2) - (tempIndex2 + 1));

                lstbxDates.Items.Add(movie.MovieDate);
                lstbxMovieNames.Items.Add(movie);
            }

            btnSearch.Enabled = false;

        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearAll();

            btnSearch.Enabled = true;
        }
        private void actorInitiator(Cast person)
        {

            WebClient webclient = new WebClient();

            string actorUrl = String.Format("https://www.imdb.com{0}", person.Url);
            string actorHtml = webclient.DownloadString(actorUrl);
            byte[] bytes = Encoding.Default.GetBytes(actorHtml);
            actorHtml = Encoding.UTF8.GetString(bytes);


            string htmlKey = "@type";
            var tempIndex = actorHtml.IndexOf(htmlKey);
            var actorJson = actorHtml.Substring(tempIndex);
            tempIndex = actorJson.IndexOf("}");
            actorJson = actorJson.Substring(0, tempIndex);

            FetchBornInfo(person, actorHtml);

            //Person image

            string imageKey = "\"image\"";
            tempIndex = actorJson.IndexOf(imageKey);
            if (tempIndex < 0)
            {

            }
            else
            {
                actorJson = actorJson.Substring(tempIndex);
                var imageUrl = actorJson.Substring(imageKey.Length + 3);
                tempIndex = imageUrl.IndexOf("\"");
                imageUrl = imageUrl.Substring(0, tempIndex);
                person.ImageUrl = imageUrl;

               

            }

            //Jobtitle

            string jobTitleKey = "\"jobTitle\"";
            tempIndex = actorJson.IndexOf(jobTitleKey);
            var jobTitle = actorJson.Substring(tempIndex);
            jobTitle = jobTitle.Substring(jobTitleKey.Length + 3);
            if (jobTitle.Contains("]"))
            {
                tempIndex = jobTitle.IndexOf("]");
                jobTitle = jobTitle.Substring(0, tempIndex);
                string[] jobTitles = jobTitle.Split('"');

                for (int i = 1; i < jobTitles.Length; i++)
                {
                    /*lstbxKeys.Items.Add(jobTitles[i]); //DB YE EKLE SONRA*/
                    person.JobTitles.Add(jobTitles[i]);
                    i++;
                }
            }
            else
            {
                tempIndex = jobTitle.IndexOf("\"");
                jobTitle = jobTitle.Substring(0, tempIndex);
                person.JobTitles.Add(jobTitle);
            }
            

            //Description

            string descriptionKey = "\"description\"";
            tempIndex = actorJson.IndexOf(descriptionKey);
            var descriptionHtml = actorJson.Substring(tempIndex);
            descriptionHtml = descriptionHtml.Substring(descriptionKey.Length + 3);
            tempIndex = descriptionHtml.IndexOf("\"birthDate\"");
            descriptionHtml = descriptionHtml.Substring(0, tempIndex);

            person.Description = descriptionHtml;

            //rtbActorDesc.Text = person.Description;

            //Filmography


            tempIndex = actorHtml.IndexOf("\"filmography\"");


            var filmography = actorHtml.Substring(tempIndex);
            tempIndex = filmography.IndexOf("</div>    <script>");
            filmography = filmography.Substring(0, tempIndex);

            lstbxMovieNames.Items.Clear();
            person.Movies.Clear();
            var searchKey = "\"/title/";
            while (filmography.IndexOf(searchKey) != -1)
            {

                tempIndex = filmography.IndexOf(searchKey);
                filmography = filmography.Substring(tempIndex + 1);

                tempIndex = filmography.IndexOf("\"");
                var filmUrl = filmography.Substring(0, tempIndex);

                //Generate ID
                tempIndex = filmUrl.IndexOf("?");
                int tempIndex2 = filmUrl.IndexOf("e");
                string movieID = filmUrl.Substring(tempIndex2 + 2, (tempIndex - 2) - (tempIndex2 + 1));

                tempIndex = filmography.IndexOf(">");
                var filmName = filmography.Substring(tempIndex + 1);
                tempIndex = filmName.IndexOf("<");
                filmName = filmName.Substring(0, tempIndex);

                Movie movie1 = new Movie();
                movie1.MovieTitleUrl = filmUrl;
                movie1.MovieName = filmName;
                movie1.MovieID = movieID;
                //lstbxJobs.Items.Add(movie1);

                //if (person.Movies[0].MovieID == movie1.MovieID)
                //{
                //    continue;
                //}
                person.Movies.Add(movie1);


            }

        }
        private void fetchJobs(Cast person)
        {
            WebClient webclient = new WebClient();

            string actorUrl = String.Format("https://www.imdb.com{0}", person.Url);
            string actorHtml = webclient.DownloadString(actorUrl);
            byte[] bytes = Encoding.Default.GetBytes(actorHtml);
            actorHtml = Encoding.UTF8.GetString(bytes);

            //Filmography
            int tempIndex = actorHtml.IndexOf("\"filmography\"");


            var filmography = actorHtml.Substring(tempIndex);
            tempIndex = filmography.IndexOf("</div>    <script>");
            filmography = filmography.Substring(0, tempIndex);

            lstbxMovieNames.Items.Clear();
            person.Movies.Clear();
            var searchKey = "\"/title/";
            while (filmography.IndexOf(searchKey) != -1)
            {

                tempIndex = filmography.IndexOf(searchKey);
                filmography = filmography.Substring(tempIndex + 1);

                tempIndex = filmography.IndexOf("\"");
                var filmUrl = filmography.Substring(0, tempIndex);

                //Generate ID
                tempIndex = filmUrl.IndexOf("?");
                int tempIndex2 = filmUrl.IndexOf("e");
                string movieID = filmUrl.Substring(tempIndex2 + 2, (tempIndex - 2) - (tempIndex2 + 1));

                tempIndex = filmography.IndexOf(">");
                var filmName = filmography.Substring(tempIndex + 1);
                tempIndex = filmName.IndexOf("<");
                filmName = filmName.Substring(0, tempIndex);

                Movie movie1 = new Movie();
                movie1.MovieTitleUrl = filmUrl;
                movie1.MovieName = filmName;
                movie1.MovieID = movieID;
                person.Movies.Add(movie1);
            }
        }
        private void FetchMovieImage(string htmlJson, Movie movie)
        {
            var imageKey = "\"image\"";
            if (htmlJson.Contains(imageKey))
            {
                var tempImageIndex = htmlJson.IndexOf(imageKey);
                tempImageIndex = tempImageIndex + imageKey.Length + 3;
                var imageUrl = htmlJson.Substring(tempImageIndex);
                tempImageIndex = imageUrl.IndexOf("\"");
                imageUrl = imageUrl.Substring(0, tempImageIndex);

                
                movie.ImageUrl = imageUrl;
            }

            else
            {
                lblPictureboxNotify.Text = "Image is not released yet";
            }
        }
        private void MovieInitializer(Movie movie)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Movies WHERE ID = @movieID", connection);
            cmd.Parameters.AddWithValue("@movieID", movie.MovieID);
            SqlDataReader rdrMovie = cmd.ExecuteReader();
            bool state = rdrMovie.HasRows;


            if (state == false) //Film db'de bulunmuyorsa
            {
                rdrMovie.Close();
                string htmlJson = DownloadMovieJson(movie);
                FetchDescriptionAndDate(htmlJson, movie);
                FetchRating(htmlJson, movie);
                FetchCast(htmlJson, movie);
                FetchGenre(movie);
                FetchAllMoviePhotos(movie);
                FetchMovieImage(htmlJson, movie);
                //Filmi ekle
                SqlCommand comm = new SqlCommand("INSERT INTO Movies(ID,MovieName,MovieDate,MovieTitleURL,MovieDescription,MovieRating,ImageUrl)VALUES(@id,@movieName,@movieDate,@movieTitleURL,@movieDescription,@movieRating,@imageUrl)", connection);
                comm.Parameters.AddWithValue("@id", movie.MovieID);
                comm.Parameters.AddWithValue("@movieName", movie.MovieName);
                comm.Parameters.AddWithValue("@movieDate", movie.MovieDate);
                comm.Parameters.AddWithValue("@movieTitleUrl", movie.MovieTitleUrl);
                comm.Parameters.AddWithValue("@movieDescription", movie.Description);
                comm.Parameters.AddWithValue("@movieRating", movie.Rating);
                comm.Parameters.AddWithValue("@imageUrl", movie.ImageUrl = movie.ImageUrl == null ? "" : movie.ImageUrl);
                comm.ExecuteNonQuery();

                foreach (var genre in movie.Genres) //Genre ekle
                {
                    comm = new SqlCommand("INSERT INTO MovieGenre(MovieID , GenreID)VALUES(@movieID,@genreID)", connection);
                    comm.Parameters.AddWithValue("@movieID", movie.MovieID);
                    comm.Parameters.AddWithValue("@genreID",(Int32)genre);
                    comm.ExecuteNonQuery();
                }
                foreach (var image in movie.Images) //Foto ekle
                {
                    comm = new SqlCommand("INSERT INTO MovieImage(MovieID , ImageUrl)VALUES(@movieID,@ImageURL)", connection);
                    comm.Parameters.AddWithValue("@movieID", movie.MovieID);
                    comm.Parameters.AddWithValue("@ImageURL", image);
                    comm.ExecuteNonQuery();
                }

                

                if (movie.Casts.Count > 0)//boş değilse
                {
                    foreach (var cast in movie.Casts)  // DB'de bu castlar var mı ? Yoksa db'ye yaz instanceları doldur : Varsa Dbden getir instanceları doldur;
                    {
                        string commandText = "SELECT * FROM Persons WHERE Id = @castID"; //persons'table arama işlemi
                        comm = new SqlCommand(commandText, connection);
                        comm.Parameters.AddWithValue("@castID", cast.Url);
                        comm.ExecuteNonQuery();
                        SqlDataReader rdrPerson = comm.ExecuteReader();
                        state = rdrPerson.HasRows;
                        rdrPerson.Close();
                        if (state == false)//DB'de bu aktör yoksa bu aktörü oluştur
                        {
                            comm = new SqlCommand("INSERT INTO Persons(ID,Name)VALUES(@personID,@personName)", connection);
                            comm.Parameters.AddWithValue("@personID", cast.Url);
                            comm.Parameters.AddWithValue("@personName", cast.Name);
                            comm.ExecuteNonQuery();
                            //person name , id insertlendi

                            foreach (var role in cast.Roles) //Mappinge eklendi
                            {
                                SqlCommand comms = new SqlCommand("INSERT INTO PersonMovieRole(MovieID,PersonID,RoleID)VALUES(@movieID,@personID,@roleID)", connection);
                                comms.Parameters.AddWithValue("@movieID", movie.MovieID);
                                comms.Parameters.AddWithValue("@personID", cast.Url);
                                comms.Parameters.AddWithValue("@roleID", (Int32)role);
                                comms.ExecuteNonQuery();
                            }
                        }
                        else//Cast db'de varsa tamamını burda doldur
                        {
                            SqlCommand comms = new SqlCommand("SELECT pmr.PersonID, p.Name, p.Description, p.BirthDay, p.BirthMonth, p.BirthYear, p.BornCity, p.BornCountry FROM PersonMovieRole pmr inner join Movies m on m.ID = pmr.MovieID inner join Persons p on p.ID = pmr.PersonID WHERE m.ID = @movieID and p.ID =@personID", connection);
                            comms.Parameters.AddWithValue("@movieID", movie.MovieID);
                            comms.Parameters.AddWithValue("@personID", cast.Url);
                            rdrPerson = comms.ExecuteReader();
                            state = rdrPerson.HasRows;

                            if (state == false)
                            {
                                rdrPerson.Close();
                                  foreach(var role in cast.Roles) //Mappinge eklendi
                                  {
                                    SqlCommand cmd1 = new SqlCommand("INSERT INTO PersonMovieRole(MovieID,PersonID,RoleID)VALUES(@movieID,@personID,@roleID)", connection);
                                    cmd1.Parameters.AddWithValue("@movieID", movie.MovieID);
                                    cmd1.Parameters.AddWithValue("@personID", cast.Url);
                                    cmd1.Parameters.AddWithValue("@roleID", (Int32)role);
                                    cmd1.ExecuteNonQuery();
                                  }

                            }
                            else
                            {
                                while (rdrPerson.Read()) //DB'den çek
                                {
                                    cast.Url = rdrPerson.GetString(0);
                                    cast.Name = rdrPerson.GetString(1);
                                    cast.Description = !rdrPerson.IsDBNull(2) ? rdrPerson.GetString(2) : "";
                                    cast.BornDay = !rdrPerson.IsDBNull(3) ? rdrPerson.GetString(3) : "";
                                    cast.BornMonth = !rdrPerson.IsDBNull(4) ? rdrPerson.GetString(4) : "";
                                    cast.BornYear = !rdrPerson.IsDBNull(5) ? rdrPerson.GetString(5) : "";
                                    cast.BornCity = !rdrPerson.IsDBNull(6) ? rdrPerson.GetString(6) : "";
                                    cast.BornCountry = !rdrPerson.IsDBNull(7) ? rdrPerson.GetString(7) : "";
                                    //cast.ImageUrl = !rdrPerson.IsDBNull(6) ? rdrPerson.GetString(6) : "";
                                    //cast.Movies.Add(movie);
                                    //movie.Casts.Add(cast);//movie casts'te yoksa ekle varsa ekleme
                                }
                                rdrPerson.Close();

                                comm = new SqlCommand("SELECT RoleID FROM PersonMovieRole WHERE MovieID = @movieID and PersonID = @personID", connection); //mappingi yaz
                                comm.Parameters.AddWithValue("@movieID", movie.MovieID);
                                comm.Parameters.AddWithValue("@personID", cast.Url);
                                comm.ExecuteNonQuery();

                                SqlDataReader rdrMapping = comm.ExecuteReader();
                                bool status = rdrMapping.HasRows;
                                if (status == true)
                                {
                                    while (rdrMapping.Read())
                                    {
                                        cast.Roles.Add((Role)rdrMapping.GetInt32(0));
                                    }
                                }
                                else
                                {
                                    //Rolü daha önceden belli değilse buraya sonra bak
                                }

                                rdrMapping.Close();
                            }
                        }
                    }
                }

            }
            else //Film db'de varsa movie propertylerini doldur
            {
                
                rdrMovie.Close();
                string commandText = "SELECT * FROM Movies WHERE ID = @movieID";
                SqlCommand cmm = new SqlCommand(commandText, connection);
                cmm.Parameters.AddWithValue("@movieID", movie.MovieID.Trim());
                cmm.ExecuteNonQuery();
                rdrMovie = cmm.ExecuteReader();

                while (rdrMovie.Read()) //Movie oku
                {
                    movie.MovieID = rdrMovie.GetString(0);
                    movie.MovieName = rdrMovie.GetString(1);
                    movie.MovieDate = !rdrMovie.IsDBNull(2) ? rdrMovie.GetString(2) : "";
                    movie.Description = !rdrMovie.IsDBNull(3) ? rdrMovie.GetString(3) : "";
                    movie.Rating = !rdrMovie.IsDBNull(4) ? rdrMovie.GetString(4) : "";
                    movie.MovieTitleUrl = !rdrMovie.IsDBNull(5) ? rdrMovie.GetString(5) : "";
                    movie.ImageUrl = !rdrMovie.IsDBNull(6) ? rdrMovie.GetString(6) : "";
                }
                rdrMovie.Close();

                cmm = new SqlCommand("SELECT * FROM MovieGenre WHERE MovieID = @movieID", connection);
                cmm.Parameters.AddWithValue("@movieID", movie.MovieID);
                rdrMovie = cmm.ExecuteReader();

                while (rdrMovie.Read())
                {
                    movie.Genres.Add((Genre)rdrMovie.GetInt32(1));
                }

                rdrMovie.Close();
                
                cmm = new SqlCommand("SELECT * FROM MovieImage WHERE MovieID = @movieID", connection);
                cmm.Parameters.AddWithValue("@movieID", movie.MovieID);
                rdrMovie = cmm.ExecuteReader();

                while (rdrMovie.Read())
                {
                    movie.Images.Add(rdrMovie.GetString(2));
                }

                rdrMovie.Close();

                commandText = "SELECT distinct pmr.PersonID ,p.Name,p.Description,p.BirthDay,p.BirthMonth,p.BirthYear,p.BornCity,p.BornCountry FROM PersonMovieRole pmr inner join Movies m on m.ID = pmr.MovieID inner join Persons p on p.ID = pmr.PersonID WHERE m.ID = @movieID";
                SqlCommand coms = new SqlCommand(commandText, connection);
                //filmin oyuncularını getir
                coms.Parameters.AddWithValue("@movieID", movie.MovieID);
                SqlDataReader personRdr = coms.ExecuteReader();

                bool hasCasts = personRdr.HasRows;
                if (hasCasts == true)//Db'de  bu filmin oyuncuları mevcut mu?
                {
                    movie.Casts.Clear();
                    while (personRdr.Read())
                    {
                        Cast person = new Cast();
                        person.Url = personRdr.GetString(0);
                        person.Name = personRdr.GetString(1);
                        person.Description = !personRdr.IsDBNull(2) ? personRdr.GetString(2) : "";
                        person.BornDay = !personRdr.IsDBNull(3) ? personRdr.GetString(3) : "";
                        person.BornMonth = !personRdr.IsDBNull(4) ? personRdr.GetString(4) : "";
                        person.BornYear = !personRdr.IsDBNull(5) ? personRdr.GetString(5) : "";
                        person.BornCity = !personRdr.IsDBNull(6) ? personRdr.GetString(6) : "";
                        person.BornCountry = !personRdr.IsDBNull(7) ? personRdr.GetString(7) : "";
                        movie.Casts.Add(person);//Her bir satır için yeni bir instance oluştur ve movie<cast>'e ata
                    }
                    personRdr.Close();
                    foreach (var person in movie.Casts)
                    {
                        commandText = "SELECT PersonID , RoleID FROM PersonMovieRole WHERE MovieID = @movieID and PersonID = @personID";
                        SqlCommand cms = new SqlCommand(commandText, connection);
                        //oyuncunun rollerini getir
                        cms.Parameters.AddWithValue("@movieID", movie.MovieID);
                        cms.Parameters.AddWithValue("@personID", person.Url);
                        SqlDataReader roleRdr = cms.ExecuteReader();
                        bool hasPersonRole = roleRdr.HasRows;

                        if (hasPersonRole == true)
                        {
                            while (roleRdr.Read())
                            {
                                person.Roles.Add((Role)roleRdr.GetInt32(1));
                            }
                            roleRdr.Close();
                        }
                        else//rolü yok
                        {
                            person.Roles.Clear();
                        }
                    }
                }//oyuncuları yok
                else
                {
                    movie.Casts.Clear();
                }

            }
            connection.Close();
        }
        private void FetchAllMoviePhotos(Movie movie)
        {

            string url = $"https://www.imdb.com/title/{movie.MovieID}/mediaindex?ref_=tt_pv_mi_sm";
            WebClient wc = new WebClient();

            string htmlImages = wc.DownloadString(url);

            var tempIndex = htmlImages.IndexOf("\"media_index_pagination leftright\"");
            htmlImages = htmlImages.Substring(tempIndex + 1);
            tempIndex = htmlImages.IndexOf("\"media_index_pagination leftright\"");
            if (tempIndex < 0 )
            {
                movie.Images.Clear();
            }
            else
            {
                htmlImages = htmlImages.Substring(0, tempIndex);

                while (htmlImages.IndexOf("https://m.media-amazon.com/images/") != -1)
                {
                    tempIndex = htmlImages.IndexOf("https://m.media-amazon.com/images/");
                    htmlImages = htmlImages.Substring(tempIndex);
                    tempIndex = htmlImages.IndexOf("\"");

                    var image = htmlImages.Substring(0, tempIndex);

                    htmlImages = htmlImages.Remove(0, tempIndex);
                    movie.Images.Add(image);
                }
            }
            
            
        }
        private void FetchAllPersonImages(Cast person)
        {
            string url = $"https://www.imdb.com{person.Url}mediaindex?ref_=nm_phs_md_sm";
            WebClient wc = new WebClient();

            string htmlImages = wc.DownloadString(url);

            var tempIndex = htmlImages.IndexOf("\"media_index_pagination leftright\"");
            htmlImages = htmlImages.Substring(tempIndex + 1);
            tempIndex = htmlImages.IndexOf("\"media_index_pagination leftright\"");
            htmlImages = htmlImages.Substring(0, tempIndex);

            while (htmlImages.IndexOf("https://m.media-amazon.com/images/") != -1)
            {
                tempIndex = htmlImages.IndexOf("https://m.media-amazon.com/images/");
                htmlImages = htmlImages.Substring(tempIndex);
                tempIndex = htmlImages.IndexOf("\"");
                var image = htmlImages.Substring(0, tempIndex);
                htmlImages = htmlImages.Remove(0, tempIndex);
                person.Images.Add(image);
            }
        }
        private void FetchGenre(Movie movie)
        {
            string url = $"https://www.imdb.com/title/{movie.MovieID}/?ref_=ttmi_tt";
            WebClient wc = new WebClient();
            string genre = wc.DownloadString(url);
            var genreKey = "Genres:";
            var tempIndex = genre.IndexOf(genreKey);
            genre = genre.Substring(tempIndex + genreKey.Length + 6);
            //string searchingtext = genre;
            tempIndex = genre.IndexOf("</div>");
            genre = genre.Substring(0, tempIndex);
            string searchingtext = genre;
            string searchKey = "</a>";

            while (searchingtext.IndexOf(searchKey) != -1)
            {
                tempIndex = searchingtext.IndexOf(searchKey);
                genre = searchingtext.Substring(0,tempIndex);
                int tempIndex2 = genre.LastIndexOf(">");
                genre = genre.Substring(tempIndex2+1);
                searchingtext = searchingtext.Remove(0, tempIndex+1);
                //tempIndex = searchingtext.IndexOf("</div>");
                //searchingtext = searchingtext.Substring(0, tempIndex);
                //tempIndex = searchingtext.IndexOf(">");
                //searchingtext = searchingtext.Substring(tempIndex +1);
                //tempIndex = searchingtext.IndexOf("<");

                //genre = searchingtext.Substring(0, tempIndex);

                switch (genre.Trim())
                {
                    case "Action":
                        movie.Genres.Add((Genre)1);
                        break;
                    case "Adventure":
                        movie.Genres.Add((Genre)2);
                        break;
                    case "Animation":
                        movie.Genres.Add((Genre)3);
                        break;
                    case "Biography":
                        movie.Genres.Add((Genre)4);
                        break;
                    case "Comedy":
                        movie.Genres.Add((Genre)5);
                        break;
                    case "Crime":
                        movie.Genres.Add((Genre)6);
                        break;
                    case "Documentary":
                        movie.Genres.Add((Genre)7);
                        break;
                    case "Drama":
                        movie.Genres.Add((Genre)8);
                        break;
                    case "Family":
                        movie.Genres.Add((Genre)9);
                        break;
                    case "Fantasy":
                        movie.Genres.Add((Genre)10);
                        break;
                    case "Film Noir":
                        movie.Genres.Add((Genre)11);
                        break;
                    case "History":
                        movie.Genres.Add((Genre)12);
                        break;
                    case "Horror":
                        movie.Genres.Add((Genre)13);
                        break;
                    case "Music":
                        movie.Genres.Add((Genre)14);
                        break;
                    case "Musical":
                        movie.Genres.Add((Genre)15);
                        break;
                    case "Mystery":
                        movie.Genres.Add((Genre)16);
                        break;
                    case "Romance":
                        movie.Genres.Add((Genre)17);
                        break;
                    case "Sci-Fi":
                        movie.Genres.Add((Genre)18);
                        break;
                    case "Short Film":
                        movie.Genres.Add((Genre)19);
                        break;
                    case "Sport":
                        movie.Genres.Add((Genre)20);
                        break;
                    case "Superhero":
                        movie.Genres.Add((Genre)21);
                        break;
                    case "Thriller":
                        movie.Genres.Add((Genre)22);
                        break;
                    case "War":
                        movie.Genres.Add((Genre)23);
                        break;
                    case "Western":
                        movie.Genres.Add((Genre)24);
                        break;
                    default:
                        
                        break;

                }

                        //movie.Genres.Add((Genre)a);

            }


        }
        private void btnMovieImages_Click(object sender, EventArgs e)
        {
            Movie movie = (Movie)lstbxMovieNames.SelectedItem;

            MovieImages formMoviePictures = new MovieImages();

            int x = 40;
            int y = 40;

            int maxHeight = -1;


            foreach (var image in movie.Images)
            {
                PictureBox pic = new PictureBox();
                WebRequest request = WebRequest.Create(image);
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                pic.Image = Bitmap.FromStream(stream);
                pic.Location = new Point(x, y);
                x += pic.Width + 10;
                maxHeight = Math.Max(pic.Height, maxHeight);
                if (x>this.ClientSize.Width-100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }

                formMoviePictures.gradientPanel2.Controls.Add(pic);
            }

            formMoviePictures.Show();
            

        }
        private void btnPersonImages_Click(object sender, EventArgs e)
        {
            Cast person = (Cast)lstbxActorName.SelectedItem;

            PersonImages formPersonPictures = new PersonImages();

            int x = 20;
            int y = 20;

            int maxHeight = -1;


            foreach (var image in person.Images)
            {
                PictureBox pic = new PictureBox();
                WebRequest request = WebRequest.Create(image);
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                pic.Image = Bitmap.FromStream(stream);
                pic.Location = new Point(x, y);
                x += pic.Width + 10;
                maxHeight = Math.Max(pic.Height, maxHeight);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }

                formPersonPictures.gradientPanel2.Controls.Add(pic);
            }

            formPersonPictures.Show();
        }
        private void btnAddWL_Click(object sender, EventArgs e)
        {
            Movie movie = (Movie)lstbxMovieNames.SelectedItem;
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Watchlist Where MovieID = @movieID and IsWatched = @isWatched", connection);
            cmd.Parameters.AddWithValue("@movieID", movie.MovieID);
            cmd.Parameters.AddWithValue("@isWatched", 1);
            SqlDataReader rdr = cmd.ExecuteReader();
            bool state = rdr.HasRows;
            rdr.Close();
            WatchListForm formProfile = new WatchListForm();

            if (state == true)
            {
                MessageBox.Show("Bu Filmi Zaten İzlediniz");
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Watchlist(MovieID , IsWatched)VALUES(@movieID,@isWatched)", connection);
                cmd.Parameters.AddWithValue("@movieID", movie.MovieID);
                cmd.Parameters.AddWithValue("@isWatched", 0);
                cmd.ExecuteNonQuery();
                formProfile.Show();
            }



            connection.Close();
        }
        private void btnWL_Click(object sender, EventArgs e)
        {
            WatchListForm formWL = new WatchListForm();
            formWL.Show();
            //formWL.lstbxWatchList.Enabled = false;
            //formWL.btnShow.Enabled = false;


        }
    }
}




