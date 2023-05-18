using GlobalAI.CoreDomain.Implements;
using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.Dto.Role;
using GlobalAI.CoreEntities.Dto.User;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.CoreAPI.Controllers
{
    [Authorize]
    [Route("api/core")]
    [ApiController]
    public class ProvinceController : BaseController
    {
        private readonly IProvinceServices _provinceServices;

        public ProvinceController(ILogger<ProvinceController> logger, IProvinceServices provinceServices)
        {
            _logger = logger;
            _provinceServices = provinceServices;
        }


        /// <summary>
        /// Danh sách tỉnh thành
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("province")]
        public APIResponse GetListProvince(string keyword)
        {
            try
            {
                var result = _provinceServices.GetListProvince(keyword);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Success");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Danh sách quận huyện
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("district")]
        public APIResponse GetListDistrict(string keyword, string provinceCode)
        {
            try
            {
                var result = _provinceServices.GetListDistrict(keyword, provinceCode);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Success");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Danh sách xã phường
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="districtCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ward")]
        public APIResponse GetListWard(string keyword, string districtCode)
        {
            try
            {
                var result = _provinceServices.GetListWard(keyword, districtCode);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Success");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
