﻿using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
}
public class TinBaiRepository : BaseEFRepository<BaiTin>
{
    private readonly IMapper _mapper;
    public TinBaiRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
    {
        _mapper = mapper;
    }

    public BaiTin Add(BaiTin input)
    {
        input.CreatedDate = DateTime.Now;
        input.NgayDang = DateTime.Now;
        input.Deleted = DeletedBool.NO;
        return _dbSet.Add(input).Entity;
    }

    public void Update(BaiTin input)
    {
        var bargainQuery = _dbSet.FirstOrDefault(d => d.Id == input.Id && d.Deleted == DeletedBool.NO);
        bargainQuery.ModifiedDate = DateTime.Now;
        bargainQuery.ModifiedBy = input.ModifiedBy;
    }

    /// <summary>
    /// Danh sach
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public PagingResult<BaiTin> FindAll(FilterBaiTinDto input, int? userId = null)
    {
        PagingResult<BaiTin> result = new();

        var baiTinQuery = (from baiTin in _dbSet
                           where baiTin.Deleted == DeletedBool.NO
                                && (input.Slug == null || input.Slug == baiTin.Slug)
                                 && (input.Status == null || input.Status == baiTin.Status)
                           select baiTin);

        result.TotalItems = baiTinQuery.Count();
        baiTinQuery = baiTinQuery.OrderByDescending(d => d.Id);
        if (input.PageSize != -1)
        {
            baiTinQuery = baiTinQuery.Skip(input.Skip).Take(input.PageSize);
        }
        result.Items = baiTinQuery;
        return result;
    }

    public void DeleteBaiTinById(int id, string username)
    {
        var result = _dbSet.FirstOrDefault(e => e.Id == id);
        if (result != null)
        {
            result.DeletedBy = username;
            result.DeletedDate = DateTime.Now;
            result.Deleted = DeletedBool.YES;
            _dbContext.SaveChanges();
        }
    }
    public BaiTin FindById(int id, int? userId = null)
    {
        return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
    }
}
