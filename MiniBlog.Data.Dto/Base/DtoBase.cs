namespace MiniBlog.Data.Dto
{
    public class DtoBase<TPrimaryKey> : IDtoBase<TPrimaryKey>
    {
       public TPrimaryKey ID { get; set; }
    }
}
