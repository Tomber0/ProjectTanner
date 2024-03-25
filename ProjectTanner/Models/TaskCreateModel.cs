namespace ProjectTanner.Models
{
    public class TaskCreateModel
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsRepeated { get; set; }
        public DateTime ExpDate { get; set; }

    }
}
