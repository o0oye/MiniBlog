namespace MiniBlog.Data.Entity
{
    public class AdminEntity : EntityBase<int>
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
