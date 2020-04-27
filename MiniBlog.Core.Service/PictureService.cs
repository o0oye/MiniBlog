using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class PictureService : ServiceBase<PictureEntity, long>,IPictureService
    {
        public PictureService(IUnitOfWork unitOfWork, IRepository<PictureEntity, long> repository)
            : base(unitOfWork, repository) { }
    }
}
