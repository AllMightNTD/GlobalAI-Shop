using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreRepositories;
using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Implements
{
    public class ProvinceServices : IProvinceServices
    {
        private readonly GlobalAIDbContext _dbContext;
        //private readonly IMapper _mapper;
        private readonly ILogger<ProvinceServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly TinhThanhRepository _tinhThanhRepository;

        public ProvinceServices(GlobalAIDbContext dbContext, ILogger<ProvinceServices> logger, DatabaseOptions databaseOptions, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _logger = logger;
            _connectionString = databaseOptions.ConnectionString;
            _httpContext = httpContext;
            _tinhThanhRepository = new TinhThanhRepository(dbContext, logger);
        }

        public List<CoreDistrict> GetListDistrict(string keyword, string provinceCode)
        {
            _logger.LogInformation($"{nameof(GetListDistrict)}: keyword={keyword}; provinceCode={provinceCode}");
            return _tinhThanhRepository.GetDistricts(keyword, provinceCode);
        }

        public List<CoreProvince> GetListProvince(string keyword)
        {
            _logger.LogInformation($"{nameof(GetListProvince)}: keyword = {keyword}");
            return _tinhThanhRepository.GetProvinces(keyword);
        }

        public List<CoreWard> GetListWard(string keyword, string districtCode)
        {
            _logger.LogInformation($"{nameof(GetListWard)}: keyword={keyword}; districtCode={districtCode}");
            return _tinhThanhRepository.GetWard(keyword, districtCode);
        }
    }
}
