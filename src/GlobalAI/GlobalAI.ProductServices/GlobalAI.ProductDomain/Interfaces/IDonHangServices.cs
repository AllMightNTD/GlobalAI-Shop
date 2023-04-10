﻿using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IDonHangServices
    {
        public PagingResult<GetDonHangDto> FindAll(FindDonHangDto input);
        public void CreateDonhang(AddDonHangDto input);
        public DonHang EditDonhang(int id, AddDonHangDto newDonHang);
    }
}