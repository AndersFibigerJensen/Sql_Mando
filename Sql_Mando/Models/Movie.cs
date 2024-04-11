namespace Sql_Mando.Models
{
    public class Movie
    {
        public string tconst { get; set; }

        public string titleType { get; set; }

        public string primaryTitle { get; set; }

        public string originalTitle { get; set; }

        public bool isAdult { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }

        public int RunTime { get; set; }

        public Movie()
        {
                
        }


    }
}
