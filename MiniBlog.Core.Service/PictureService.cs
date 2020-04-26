using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Dto;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class PictureService : ServiceBase<PictureDto, long>,IPictureService
    {
        public PictureService(IUnitOfWork unitOfWork, IRepository<PictureDto, long> repository)
            : base(unitOfWork, repository) { }
    }
}
