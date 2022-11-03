namespace WebApplication22_11_1.Models
{
    public class Lunch
    {
        public int? Id { get; set; }
        public virtual int CuisineId { get; set; }
        public virtual int RestaurantId { get; set; }
        public bool isHot { get; set; }
        public decimal cost { get; set; }
        public bool isDelicious { get; set; }
        public bool isHealthy { get; set; }



        public Lunch(int? id, int cuisineid, int restaurantid, bool IsHot, decimal Cost, bool IsDelicious, bool IsHealthy)
        {
            Id = id;
            CuisineId = cuisineid;
            RestaurantId = restaurantid;
            isHot = IsHot;
            cost = Cost;
            isDelicious = IsDelicious;
            isHealthy = IsHealthy;

        }

        public Lunch()
        {
            return;
        }
    }

}

