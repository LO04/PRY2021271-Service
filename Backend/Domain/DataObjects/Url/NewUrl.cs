namespace Montrac.API.Domain.DataObjects.Url
{
    public class NewUrl
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Title { get; set; }
        public string Browser { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
    }
}
