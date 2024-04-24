namespace AppRating1.Data
{
    public class RatingViewModel
    {
        public int RatingId { get; set; }
        public string UserName { get; set; }
        public string RatedEntityName { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }

        public RatingTable RatingTable { get; set; }
        public RatedEntityTable RatedEntityTable { get; set; }
        public UserTable UserTable { get; set; }
    }
}
