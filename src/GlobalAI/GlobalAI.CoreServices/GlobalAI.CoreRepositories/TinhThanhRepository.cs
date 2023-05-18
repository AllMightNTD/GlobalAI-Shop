using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreRepositories
{
    public class TinhThanhRepository : BaseEFRepository<CoreProvince>
    {

        public TinhThanhRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {

        }

        /// <summary>
        /// Lấy list tỉnh thành
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<CoreProvince> GetProvinces(string keyword)
        {
            _logger.LogInformation($"{nameof(GetProvinces)}: keyword = {keyword}");
            return _dbSet.AsNoTracking().Where(x => (string.IsNullOrEmpty((keyword ?? "").Trim()) || x.FullName.ToLower().Contains((keyword ?? "").Trim().ToLower()))).ToList();
        }

        /// <summary>
        /// Lấy list quận huyện
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        public List<CoreDistrict> GetDistricts(string keyword, string provinceCode)
        {
            _logger.LogInformation($"{nameof(GetDistricts)}: keyword={keyword}; provinceCode={provinceCode}");
            return _globalAIDbContext.CoreDistricts.AsNoTracking().Where(x => (string.IsNullOrEmpty((keyword ?? "").Trim()) || x.FullName.ToLower().Contains((keyword ?? "").Trim().ToLower())) && x.ProvinceCode == provinceCode).ToList();
        }

        /// <summary>
        /// Lấy list xã phường
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="districtCode"></param>
        /// <returns></returns>
        public List<CoreWard> GetWard(string keyword, string districtCode)
        {
            _logger.LogInformation($"{nameof(GetWard)}: keyword={keyword}; districtCode={districtCode}");
            return _globalAIDbContext.CoreWards.AsNoTracking().Where(x => (string.IsNullOrEmpty((keyword ?? "").Trim()) || x.FullName.ToLower().Contains((keyword ?? "").Trim().ToLower())) && x.DistrictCode == districtCode).ToList();
        }
    }
}
