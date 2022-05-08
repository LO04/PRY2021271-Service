namespace Montrac.API.Domain.DataObjects
{
    public class NewProgram
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeUsed { get; set; }
        public int UserId { get; set; }
    }
}
