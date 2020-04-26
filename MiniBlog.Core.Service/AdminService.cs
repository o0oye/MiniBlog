﻿using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Dto;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class AdminService : ServiceBase<AdminDto, int>, IAdminService
    {
        public AdminService(IUnitOfWork unitOfWork, IRepository<AdminDto, int> repository)
            : base(unitOfWork, repository) { }
    }
}