namespace ProjectTanner.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TId { get; set; }
        public List<Task> Tasks { get; set; } = new();

    }
}
