using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BknDto.Dto
{
    public class RealEstateObjectPhotoDto
    {
        public long RealEstateObjectPhotoId { get; set; }
        public long Unid { get; set; }
        public string Url { get; set; }
        public string Md5 { get; set; }
        public Nullable<bool> isPrimary { get; set; }
    }
}
