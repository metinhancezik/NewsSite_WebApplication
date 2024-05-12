namespace Entities.RequestParameters
{
    public class NewsRequestParameters : RequestParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public NewsRequestParameters() : this(1,6)
        {
            
        }
        public NewsRequestParameters(int pageNumber=1, int pageSize=6)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}