﻿using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.DataAccess.Base
{
    public partial class GlobalAIDbContext : DbContext
    {
        #region User
        public DbSet<User> Users { get; set; }
        #endregion
        #region danh mục
        public DbSet<DanhMuc> DanhMucs { get; set; }
        #endregion
        #region sanpham
        public DbSet<SanPham> SanPhams { get; set; }
        #endregion
        public DbSet<AddProductDto> Products { get; set; }
        public GlobalAIDbContext(DbContextOptions<GlobalAIDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
