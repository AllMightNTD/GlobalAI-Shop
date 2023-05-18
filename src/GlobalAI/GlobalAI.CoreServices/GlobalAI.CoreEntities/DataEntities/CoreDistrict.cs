using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.CoreEntities.DataEntities
{
    [Table("C_DISTRICTS")]
    public class CoreDistrict
    {
        [Key]
        [ColumnSnackCase(nameof(Code))]
        public string Code { get; set; }

        [ColumnSnackCase(nameof(Name))]
        public string Name { get; set; }

        [ColumnSnackCase(nameof(NameEn))]
        public string NameEn { get; set; }

        [ColumnSnackCase(nameof(FullName))]
        public string FullName { get; set; }

        [ColumnSnackCase(nameof(FullNameEn))]
        public string FullNameEn { get; set; }

        [ColumnSnackCase(nameof(CodeName))]
        public string CodeName { get; set; }

        [ColumnSnackCase(nameof(ProvinceCode))]
        public string ProvinceCode { get; set; }

        [ColumnSnackCase(nameof(AdministrativeUnitId))]
        public int AdministrativeUnitId { get; set; }
    }
}
