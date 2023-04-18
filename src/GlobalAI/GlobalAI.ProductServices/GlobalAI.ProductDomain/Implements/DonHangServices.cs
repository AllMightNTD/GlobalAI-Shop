﻿using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class DonHangServices : IDonHangServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ChiTietDonHangServices _chitietdonhangservices;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DonHangRepository _repositoryDonHang;
        private readonly SanPhamRepository _repositorySanPham;
        private readonly ChiTietDonHangRepository _repositoryChiTietDonHang;
        private readonly IMapper _mapper;
        public DonHangServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger, IMapper mapper)
        {
            _repositoryDonHang = new DonHangRepository(dbContext, logger, mapper);
            _repositorySanPham = new SanPhamRepository(dbContext, logger, mapper);
            _repositoryChiTietDonHang = new ChiTietDonHangRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;
            _mapper = mapper;

        }

        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetDonHangDto> FindAll(FindDonHangDto input)
        {
            return _repositoryDonHang.FindAll(input);
        }

        /// <summary>
        /// tạo đơn hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public DonHang CreateDonhang(AddDonHangDto input)
        {
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var donHang = _mapper.Map<DonHang>(input);
            _repositoryDonHang.CreateDonHang(donHang);
            _dbContext.SaveChanges();
            return donHang;
        }
        /// <summary>
        /// Sửa đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DonHang EditDonhang(string id, AddDonHangDto newDonHang)
        {
            var donHang = _repositoryDonHang.FindById(id);
            if (donHang != null)
            {
                _repositoryDonHang.EditDonHang(donHang, newDonHang);
            }
            _dbContext.SaveChanges();
            return donHang;
        }


        public void DeleteDonHangById(int id)
        {
            _repositoryDonHang.DeleteDonHangById(id);
        }

        /// <summary>
        /// Lấy ra tất cả thông tin trong đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        public DonHangFullDto GetDonHangFull(int maDonHang)
        {

            var DonhangFull = new DonHangFullDto();

            // Save DonHang
            var resultDh = _repositoryDonHang.GetDonHang(maDonHang);

            // Save ChiTietDonHang
            var resultChiTiet = _repositoryChiTietDonHang.GetListChiTietDonHang(maDonHang);

            DonhangFull.ChiTietDonHangFullDtos = _mapper.Map<List<GetChiTietDonHangDto>>(resultChiTiet);
            DonhangFull.donHang = _mapper.Map<GetDonHangDto>(resultDh);

            return DonhangFull;
        }
        /// <summary>
        /// Tạo tất cả thông tin của đơn hàng
        /// </summary>
        /// <param name="donhangDto"></param>
        /// <param name="ctDto"></param>
        public void CreateDonHangFull(AddDonHangFullDto donHangFullDto)
        {
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    donHangFullDto.donHang.IdNguoiMua = CommonUtils.GetCurrentUserId(_httpContext);
                    // Save DonHang
                    var resultDh = CreateDonhang(donHangFullDto.donHang);

                    _dbContext.SaveChanges();
                    var idDonHang = resultDh.Id;
                    // Save ChiTietDonHang
                    foreach (var item in donHangFullDto.ChiTietDonHangFullDtos)
                    {
                        var ctDonhang = _repositoryChiTietDonHang.CreateChiTietDonHang(_mapper.Map<ChiTietDonHang>(item));
                        ctDonhang.IdDonHang = idDonHang;

                    }
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

            }
        }
        /// <summary>
        /// Cập nhật trạng thái đơn hàng
        /// </summary>
        /// <param name="idDonHang"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public DonHang UpdateStatusDonHang(UpdateStatusDonHangDto updateDonHangDto)
        {
            var result = _repositoryDonHang.UpdateStatusDonHang(updateDonHangDto);
            _dbContext.SaveChanges();
            return result;
        }
    }
}