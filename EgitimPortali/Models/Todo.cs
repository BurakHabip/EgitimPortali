namespace EgitimPortali.Models
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IsOK { get; set; }
        public string UserId { get; set; }
    }
}
