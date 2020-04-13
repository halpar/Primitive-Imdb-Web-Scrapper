using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImdbScrapperDesktop
{
    public partial class WatchListForm : Form
    {
        SqlConnection connection = new SqlConnection(@"server=.\MSSQLSERVERHAL;database=IMDBDB;trusted_connection=true");
        public WatchListForm()
        {
            InitializeComponent();
        }

        private void btnSetWatched_Click(object sender, EventArgs e)
        {
            Movie movie = (Movie)lstbxWatchList.SelectedItem;
            connection.Open();
            SqlCommand comm = new SqlCommand("UPDATE Watchlist SET IsWatched = @isWatched WHERE MovieID = @movieID", connection);
            comm.Parameters.AddWithValue("@MovieID", movie.MovieID);
            comm.Parameters.AddWithValue("@isWatched", 1);
            comm.ExecuteNonQuery();

            connection.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lstbxWatchList.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MovieID ,MovieName , MovieDate , MovieDescription , MovieRating , ImageUrl , IsWatched FROM Watchlist wl inner join Movies m on m.ID = wl.MovieID WHERE IsWatched = @isWatched", connection);
            cmd.Parameters.AddWithValue("@isWatched", 0);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Movie movie = new Movie();
                movie.MovieID = rdr.GetString(0);
                movie.MovieName = rdr.GetString(1);
                movie.MovieDate = !rdr.IsDBNull(2) ? rdr.GetString(2) : "";
                movie.Description = !rdr.IsDBNull(3) ? rdr.GetString(3) : "";
                movie.Rating = !rdr.IsDBNull(4) ? rdr.GetString(4) : "";
                movie.ImageUrl = !rdr.IsDBNull(5) ? rdr.GetString(5) : "";
                movie.isWatched = rdr.GetBoolean(6);
                lstbxWatchList.Items.Add(movie);
            }
            connection.Close();
        }

        private void lstbxWatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Movie movie = (Movie)lstbxWatchList.SelectedItem;
            lblMovieName.Text = movie.MovieName;
            tbReleaseDate.Text = movie.MovieDate;
            richMovieDescr.Text = movie.Description;
            rtbRating.Text = movie.Rating;

            WebRequest request = WebRequest.Create(movie.ImageUrl);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            pcbxMovie.Image = Bitmap.FromStream(stream);

        }

        private void btnWatched_Click(object sender, EventArgs e)
        {

            lstbxWatched.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MovieID ,MovieName , MovieDate , MovieDescription , MovieRating , ImageUrl , IsWatched FROM Watchlist wl inner join Movies m on m.ID = wl.MovieID WHERE IsWatched = @isWatched", connection);
            cmd.Parameters.AddWithValue("@isWatched", 1);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Movie movie = new Movie();
                movie.MovieID = rdr.GetString(0);
                movie.MovieName = rdr.GetString(1);
                movie.MovieDate = !rdr.IsDBNull(2) ? rdr.GetString(2) : "";
                movie.Description = !rdr.IsDBNull(3) ? rdr.GetString(3) : "";
                movie.Rating = !rdr.IsDBNull(4) ? rdr.GetString(4) : "";
                movie.ImageUrl = !rdr.IsDBNull(5) ? rdr.GetString(5) : "";
                movie.isWatched = rdr.GetBoolean(6);
                lstbxWatched.Items.Add(movie);
            }
            connection.Close();


        }

        private void lstbxWatched_SelectedIndexChanged(object sender, EventArgs e)
        {
            Movie movie = (Movie)lstbxWatched.SelectedItem;
            lblMovieName.Text = movie.MovieName;
            tbReleaseDate.Text = movie.MovieDate;
            richMovieDescr.Text = movie.Description;
            rtbRating.Text = movie.Rating;

            WebRequest request = WebRequest.Create(movie.ImageUrl);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            pcbxMovie.Image = Bitmap.FromStream(stream);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            lstbxWatched.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MovieID ,MovieName , MovieDate , MovieDescription , MovieRating , ImageUrl , IsWatched FROM Watchlist wl inner join Movies m on m.ID = wl.MovieID WHERE IsWatched = @isWatched order by MovieRating desc", connection);
            cmd.Parameters.AddWithValue("@isWatched", 1);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Movie movie = new Movie();
                movie.MovieID = rdr.GetString(0);
                movie.MovieName = rdr.GetString(1);
                movie.MovieDate = !rdr.IsDBNull(2) ? rdr.GetString(2) : "";
                movie.Description = !rdr.IsDBNull(3) ? rdr.GetString(3) : "";
                movie.Rating = !rdr.IsDBNull(4) ? rdr.GetString(4) : "";
                movie.ImageUrl = !rdr.IsDBNull(5) ? rdr.GetString(5) : "";
                movie.isWatched = rdr.GetBoolean(6);
                lstbxWatched.Items.Add(movie);
            }
            connection.Close();
        }
    }
}
