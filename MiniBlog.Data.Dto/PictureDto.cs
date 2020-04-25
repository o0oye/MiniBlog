namespace MiniBlog.Data.Dto
{
    public class PictureDto : DtoBase<long>
    {
        public string Origin { get; set; }
        public string Big { get; set; }
        public string Small { get; set; }
    }
}
