namespace MiniBlog.Data.Dto
{
    public interface IDtoBase<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }
}
