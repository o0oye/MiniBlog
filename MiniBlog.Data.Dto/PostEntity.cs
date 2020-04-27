namespace MiniBlog.Data.Entity
{
    public class PostEntity : EntityBase<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
