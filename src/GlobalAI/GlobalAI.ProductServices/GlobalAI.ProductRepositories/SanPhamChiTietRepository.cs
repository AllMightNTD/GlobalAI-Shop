﻿using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils;
using GlobalAI.Utils.ConstantVariables.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class SanPhamChiTietRepository : BaseEFRepository<SanPhamChiTiet>
    {
        private readonly IMapper _mapper;
        public SanPhamChiTietRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
            
        }

        public PagingResult<SanPhamChiTiet> FindAll(FilterSanPhamChiTietDto input)
        {
            PagingResult<SanPhamChiTiet> result = new();

            var sanPhamChiTietQuery = (from sanPhamChiTiet in _dbSet
                               where sanPhamChiTiet.Deleted == DeletedBool.NO
                               //&& (input.IdSanPham == null || input.IdSanPham == sanPhamChiTiet.IdSanPham)
                               && (input.Status == null || input.Status == sanPhamChiTiet.Status)
                               select sanPhamChiTiet);

            result.TotalItems = sanPhamChiTietQuery.Count();
            if (!string.IsNullOrEmpty(input.SortBy) && !string.IsNullOrEmpty(input.SortOrder))
            {
                switch (input.SortBy)
                {
                    case "SoLuong":
                        if (input.SortOrder.ToLower() == "asc")
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderBy(x => x.SoLuong);
                        }
                        else
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.SoLuong);
                        }
                        break;

                    case "CreatedDate":
                        if (input.SortOrder.ToLower() == "asc")
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderBy(x => x.CreatedDate);
                        }
                        else
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.CreatedDate);
                        }
                        break;

                    case "LuotBan":
                        if (input.SortOrder.ToLower() == "asc")
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderBy(x => x.LuotBan);
                        }
                        else
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.LuotBan);
                        }
                        break;
                    // Các trường hợp sắp xếp theo các trường khác có thể được thêm vào ở đây
                    default:
                        sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.Id);
                        break;
                }
            }
            else
            {
                sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.Id);
            }

            if (input.PageSize != -1)
            {
                sanPhamChiTietQuery = sanPhamChiTietQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.Items = sanPhamChiTietQuery;
            return result;
        }

        /// <summary>
        /// Thêm sản phẩm chi tiết
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public SanPhamChiTiet Add(SanPhamChiTiet entity, string username)
        {
            _logger.LogInformation($"{nameof(Add)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);

            return entity;
        }

        /// <summary>
        /// Add thuộc tính cho sản phẩm chi tiết
        /// </summary>
        /// <param name="idSanPhamChiTiet"></param>
        /// <param name="listIdThuocTinhGiaTri"></param>
        /// <param name="username"></param>
        public void AddSanPhamChiTietThuocTinh(int idSanPhamChiTiet, List<int> listIdThuocTinhGiaTri , string username)
        {
            _logger.LogInformation($"{nameof(AddSanPhamChiTietThuocTinh)}: idSanPhamChiTiet={idSanPhamChiTiet}; listIdThuocTinhGiaTri={JsonSerializer.Serialize(listIdThuocTinhGiaTri)}; username={username}");

            var now = DateTime.Now;
            foreach (var item in listIdThuocTinhGiaTri)
            { 
                _globalAIDbContext.SanPhamChiTietThuocTinhs.Add(new SanPhamChiTietThuocTinh
                {
                    IdSanPhamChiTiet = idSanPhamChiTiet,
                    IdThuocTinhGiaTri = item,
                    CreatedBy = username,
                    CreatedDate = now
                });
            }
        }

        /// <summary>
        /// Lấy list sp chi tiết theo id sp
        /// </summary>
        /// <param name="idSanPham"></param>
        /// <returns></returns>
        public List<SanPhamChiTiet> GetListByIdSanPham(int idSanPham)
        {
            _logger.LogInformation($"{nameof(GetListByIdSanPham)}: idSanPham={idSanPham}");

            var query = from spct in _dbSet.AsNoTracking()
                        join sp in _globalAIDbContext.SanPhams.AsNoTracking() on spct.IdSanPham equals sp.Id
                        where !spct.Deleted && !sp.Deleted && sp.Id == idSanPham
                        select spct;
            return query.ToList();

        }

        /// <summary>
        /// Cập nhật sản phẩm chi tiết
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        public void UpdateSanPhamChiTiet(SanPhamChiTiet entity, string username)
        {
            _logger.LogInformation($"{nameof(UpdateSanPhamChiTiet)}: lisentitytIdThuocTinhGiaTri={JsonSerializer.Serialize(entity)}");

            var spChiTiet = _dbSet.FirstOrDefault(x => !x.Deleted && x.Id == entity.Id).ThrowIfNull(_globalAIDbContext, ErrorCode.ProductSpChiTietNotFound);

            checkSpChiTietInUsed(spChiTiet.Id);

            spChiTiet.ModifiedBy = username;
            spChiTiet.ModifiedDate = DateTime.Now;

            spChiTiet.MaSanPhamChiTiet = entity.MaSanPhamChiTiet;
            spChiTiet.SoLuong = entity.SoLuong;
            spChiTiet.MoTa = entity.MoTa;
            spChiTiet.GiaBan = entity.GiaBan;
            spChiTiet.GiaChietKhau = entity.GiaChietKhau;
            spChiTiet.GiaToiThieu = entity.GiaToiThieu;
            spChiTiet.Thumbnail = entity.Thumbnail;
        }

        /// <summary>
        /// Xóa mềm các thuộc tính giá trị của sản phẩm chi tiết
        /// </summary>
        /// <param name="listIdThuocTinhGiaTri"></param>
        /// <param name="username"></param>
        public void DeleteSanPhamChiTietThuocTinh(List<int> listIdThuocTinhGiaTri, string username)
        {
            _logger.LogInformation($"{nameof(DeleteSanPhamChiTietThuocTinh)}: listIdThuocTinhGiaTri={JsonSerializer.Serialize(listIdThuocTinhGiaTri)}; username={username}");

            var now = DateTime.Now;
            var listThuocTinhGiaTri = _globalAIDbContext.SanPhamChiTietThuocTinhs.Where(x => !x.Deleted && listIdThuocTinhGiaTri.Contains(x.Id));
            foreach (var item in listThuocTinhGiaTri)
            {
                item.Deleted = true;
                item.DeletedDate = now;
                item.DeletedBy = username;
            }
        }

        /// <summary>
        /// Get list sản phẩm chi tiết thuộc tính theo id sản phẩm chi tiết
        /// </summary>
        /// <param name="idSanPhamChiTiet"></param>
        /// <returns></returns>
        public List<SanPhamChiTietThuocTinh> GetListSanPhamChiTietThuocTinh(int idSanPhamChiTiet)
        {
            _logger.LogInformation($"{nameof(GetListSanPhamChiTietThuocTinh)}: idSanPhamChiTiet={idSanPhamChiTiet}");

            return _globalAIDbContext.SanPhamChiTietThuocTinhs.Where(x => !x.Deleted && x.IdSanPhamChiTiet == idSanPhamChiTiet).ToList();
        }

        /// <summary>
        /// Xoá mềm sản phẩm chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        public void DeleteSanPhamChiTiet(int id, string username)
        {
            _logger.LogInformation($"{nameof(DeleteSanPhamChiTiet)}: id={id}, username={username}");

            var spChiTiet = _dbSet.FirstOrDefault(x => !x.Deleted && x.Id == id).ThrowIfNull(_globalAIDbContext, ErrorCode.ProductSpChiTietNotFound);
            checkSpChiTietInUsed(id);

            spChiTiet.DeletedBy = username;
            spChiTiet.DeletedDate = DateTime.Now;
            spChiTiet.Deleted = true;
        }

        /// <summary>
        /// Get list thuộc tính bằng id sản phẩm chi tiết
        /// </summary>
        /// <param name="idSanPhamChiTiet"></param>
        /// <returns></returns>
        public List<ViewSanPhamChiTietThuocTinhDto> GetListThuocTinhByIdSanPhamChiTiet(int idSanPhamChiTiet)
        {
            _logger.LogInformation($"{nameof(GetListThuocTinhByIdSanPhamChiTiet)}: idSanPhamChiTiet={idSanPhamChiTiet}");

            var query = from spct in _dbSet.AsNoTracking()
                        join spcttt in _globalAIDbContext.SanPhamChiTietThuocTinhs.AsNoTracking() on spct.Id equals spcttt.IdSanPhamChiTiet
                        join gt in _globalAIDbContext.ThuocTinhGiaTris.AsNoTracking() on spcttt.IdThuocTinhGiaTri equals gt.Id
                        join tt in _globalAIDbContext.ThuocTinhs.AsNoTracking() on gt.IdThuocTinh equals tt.Id
                        where !spct.Deleted && !spcttt.Deleted && !gt.Deleted && !tt.Deleted && spct.Id == idSanPhamChiTiet
                        select new ViewSanPhamChiTietThuocTinhDto
                        {
                            Id = spcttt.Id,
                            IdSanPhamChiTiet = spcttt.IdSanPhamChiTiet,
                            IdThuocTinhGiaTri = spcttt.IdThuocTinhGiaTri,
                            TenThuocTinh = tt.TenThuocTinh,
                            GiaTri = gt.GiaTri
                        };
            return query.ToList();
        }

        /// <summary>
        /// Check sp chi tiết có đang được sử dụng ko
        /// </summary>
        /// <param name="id"></param>
        private void checkSpChiTietInUsed(int id)
        {
            var isInChiTietDonHang = _globalAIDbContext.ChiTietDonHangs.Any(x => !x.Deleted && x.IdSanPhamChiTiet == id);

            if (isInChiTietDonHang)
            {
                ThrowException(ErrorCode.ProductSpChiTietDaDuocTaoDonHang);
            }
        }
    }
}
