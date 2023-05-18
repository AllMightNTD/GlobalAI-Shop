using GlobalAI.Utils.ConstantVariables.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.Utils.Attributes;

namespace GlobalAI.CoreEntities.DataEntities
{
    /// <summary>
    /// Tỉnh / Thành phố
    /// </summary>
    [Table("C_PROVINCES")]
    public class CoreProvince
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

        [ColumnSnackCase(nameof(AdministrativeUnitId))]
        public int AdministrativeUnitId { get; set; }

        [ColumnSnackCase(nameof(AdministrativeRegionId))]
        public int AdministrativeRegionId { get; set; }
    }
}
