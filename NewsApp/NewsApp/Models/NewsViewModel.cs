namespace NewsApp.Models
{
  
        public class NewsViewModel
        {
            public int NewsID { get; set; }
            public string NewsTitle { get; set; }
            public string NewsPhoto { get; set; }
            public string NewsShortDescription { get; set; }
            public DateTime NewsDate { get; set; }
            public string CategoryName { get; set; }
        }
    

}
