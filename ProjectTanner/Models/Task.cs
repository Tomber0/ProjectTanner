namespace ProjectTanner.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime ExpDate { get; set; }
        public int Streak {  get; set; }
        public User? User { get; set; }
    }
}
