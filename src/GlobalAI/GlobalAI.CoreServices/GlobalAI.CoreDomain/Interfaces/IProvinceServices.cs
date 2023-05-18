using GlobalAI.CoreEntities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Interfaces
{
    public interface IProvinceServices
    {
        public List<CoreProvince> GetListProvince(string keyword);
        public List<CoreDistrict> GetListDistrict(string keyword, string provinceCode);
        public List<CoreWard> GetListWard(string keyword, string districtCode);

    }
}
