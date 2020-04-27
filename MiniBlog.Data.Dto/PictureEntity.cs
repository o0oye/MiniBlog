namespace MiniBlog.Data.Entity
{
    public class PictureEntity : EntityBase<long>
    {
        public string Origin { get; set; }
        public string Big { get; set; }
        public string Small { get; set; }
    }
}
