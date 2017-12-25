using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BknDto.Dto
{
    public class RealEstateObjectDto
    {
        public long RealEstateObjectId { get; set; }
        public long Unid { get; set; }
        public string Address { get; set; }
        public Nullable<int> Code { get; set; }
        public string Infosource { get; set; }
        public Nullable<int> Responsible { get; set; }
        public string ContactPhoneCode1 { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactPhoneCode2 { get; set; }
        public string ContactPhone2 { get; set; }
        public string ContactPhoneCode3 { get; set; }
        public string ContactPhone3 { get; set; }
        public string ContactPhoneCode4 { get; set; }
        public string ContactPhone4 { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateReception { get; set; }
        public Nullable<System.DateTime> DateRevision { get; set; }
        public Nullable<System.DateTime> LastModification { get; set; }
        public string Archive { get; set; }
        public string Terms { get; set; }
        public string Seller { get; set; }
        public Nullable<int> StateDistrictId { get; set; }
        public Nullable<int> DirectionId { get; set; }
        public Nullable<int> TownDistance { get; set; }
        public Nullable<int> TownId { get; set; }
        public string TownName { get; set; }
        public Nullable<int> TownDistrictId { get; set; }
        public Nullable<int> TownSubdistrictId { get; set; }
        public Nullable<int> StreetId { get; set; }
        public string StreetName { get; set; }
        public Nullable<int> MetroLineId { get; set; }
        public Nullable<int> MetroStationId { get; set; }
        public Nullable<int> HouseNumber { get; set; }
        public string BuildingNumber { get; set; }
        public Nullable<decimal> PositionX { get; set; }
        public Nullable<decimal> PositionY { get; set; }
        public Nullable<int> Rooms { get; set; }
        public Nullable<int> SeparateRooms { get; set; }
        public Nullable<int> BuildingYear { get; set; }
        public Nullable<int> RepairYear { get; set; }
        public Nullable<int> Storey { get; set; }
        public Nullable<int> Storeys { get; set; }
        public string StoreyType { get; set; }
        public string HouseType { get; set; }
        public string Layout { get; set; }
        public Nullable<decimal> AreaTotal { get; set; }
        public Nullable<decimal> AreaLiving { get; set; }
        public Nullable<decimal> AreaKitchen { get; set; }
        public Nullable<int> Levels { get; set; }
        public Nullable<decimal> CeilingHeight { get; set; }
        public string FloorType { get; set; }
        public string Lavatory { get; set; }
        public string Balcony { get; set; }
        public string Phone { get; set; }
        public string Owner { get; set; }
        public string RepairState { get; set; }
        public string Comments { get; set; }
        public Nullable<int> ExtraInfo { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Contract { get; set; }
        public Nullable<System.DateTime> DtContractOpened { get; set; }
        public Nullable<System.DateTime> DtContractClosed { get; set; }
        public Nullable<long> RequestId { get; set; }
        public string Price { get; set; }
        public Nullable<int> PriceHaggle { get; set; }
        public bool TvoyaStolitsa { get; set; }
        public bool Realt { get; set; }
        public bool Onliner { get; set; }
        public bool Confan { get; set; }


        public List<RealEstateObjectPhotoDto> ObjectPhotos { get; set; }
    }
}
