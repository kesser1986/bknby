using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using BknDal.Models;
using BknDal.Repositories.Interfaces;
using System.Data.Entity;

namespace BknDal.Repositories.Classes
{
    public class RealEstateObjectsRepository : BaseRepository<RealEstateObject, long>, IRealEstateObjectsRepository
    {
        public RealEstateObject GetRealEstateObject(int realEstateObjectId)
        {
            using(var db = DbContextFactory.OpenContext())
            {
                return db.RealEstateObject.FirstOrDefault(p => p.RealEstateObjectId == realEstateObjectId);
            }
        }

        public List<RealEstateObjectPhoto> GetRealEstateObjectPhotos(long unid)
        {
            using(var db = DbContextFactory.OpenContext())
            {
                return db.RealEstateObjectPhoto.Where(p => p.Unid == unid).ToList();
            }
        }

        public List<RealEstateObject> GetRealEstateObjects()
        {
            using(var db = DbContextFactory.OpenContext())
            {
                var result = db.RealEstateObject.Where(p => p.RealEstateObjectId > 0).ToList();

                return result;
            }
        }

        public void ImportRealEstateObjects()
        {
            using (var db = DbContextFactory.OpenContext())
            {
                var toRemoveObjects = db.RealEstateObject.Where(p => p.RealEstateObjectId > 0).ToList();
                var toRemoveObjectsPhotos = db.RealEstateObjectPhoto.Where(p => p.RealEstateObjectPhotoId > 0).ToList();
                if(toRemoveObjects != null)
                    db.RealEstateObject.RemoveRange(toRemoveObjects);
                if (toRemoveObjectsPhotos != null)
                    db.RealEstateObjectPhoto.RemoveRange(toRemoveObjectsPhotos);

                db.SaveChanges();

                XDocument xdoc = XDocument.Load("http://crm.t-s.by/xml/xml_flats_realt.php");
                var records = xdoc.Element("uedb")?.Element("table")?.Elements("record");
                if (records != null && records.Any())
                {
                    foreach (XElement record in records)
                    {
                        var itemObject = new RealEstateObject();
                        itemObject.Unid = string.IsNullOrEmpty(record.Element("unid")?.Value) ? -1 : long.Parse(record.Element("unid")?.Value);
                        itemObject.Address = record.Element("address")?.Value;
                        itemObject.Code = string.IsNullOrEmpty(record.Element("code")?.Value) ? -1 : int.Parse(record.Element("code")?.Value);
                        itemObject.Infosource = record.Element("infosource")?.Value;
                        itemObject.Responsible = string.IsNullOrEmpty(record.Element("responsible")?.Value) ? -1 : int.Parse(record.Element("responsible")?.Value);
                        itemObject.ContactPhoneCode1 = record.Element("contact_phone_code_1")?.Value;
                        itemObject.ContactPhone1 = record.Element("contact_phone_1")?.Value;
                        itemObject.ContactPhoneCode2 = record.Element("contact_phone_code_2")?.Value;
                        itemObject.ContactPhone2 = record.Element("contact_phone_2")?.Value;
                        itemObject.ContactPhoneCode3 = record.Element("contact_phone_code_3")?.Value;
                        itemObject.ContactPhone3 = record.Element("contact_phone_3")?.Value;
                        itemObject.ContactPhoneCode4 = record.Element("contact_phone_code_4")?.Value;
                        itemObject.ContactPhone4 = record.Element("contact_phone_4")?.Value;
                        itemObject.Email = record.Element("email")?.Value;
                        itemObject.DateReception = Convert.ToDateTime(record.Element("date_reception")?.Value);
                        itemObject.DateRevision = Convert.ToDateTime(record.Element("date_revision")?.Value);
                        itemObject.LastModification = Convert.ToDateTime(record.Element("last_modification")?.Value);
                        itemObject.Archive = record.Element("archive")?.Value;
                        itemObject.Terms = record.Element("terms")?.Value;
                        itemObject.Seller = record.Element("seller")?.Value;
                        itemObject.StateDistrictId = string.IsNullOrEmpty(record.Element("state_district_id")?.Value) ? -1 : int.Parse(record.Element("state_district_id")?.Value);
                        itemObject.DirectionId = string.IsNullOrEmpty(record.Element("direction_id")?.Value) ? -1 : int.Parse(record.Element("direction_id")?.Value);
                        itemObject.TownDistance = string.IsNullOrEmpty(record.Element("town_distance")?.Value) ? -1 : int.Parse(record.Element("town_distance")?.Value);
                        itemObject.TownId = string.IsNullOrEmpty(record.Element("town_id")?.Value) ? -1 : int.Parse(record.Element("town_id")?.Value);
                        itemObject.TownName = record.Element("town_name")?.Value;
                        itemObject.TownDistrictId = string.IsNullOrEmpty(record.Element("town_district_id")?.Value) ? -1 : int.Parse(record.Element("town_district_id")?.Value);
                        itemObject.TownSubdistrictId = string.IsNullOrEmpty(record.Element("town_subdistrict_id")?.Value) ? -1 : int.Parse(record.Element("town_subdistrict_id")?.Value);
                        itemObject.StreetId = string.IsNullOrEmpty(record.Element("street_id")?.Value) ? -1 : int.Parse(record.Element("street_id")?.Value);
                        itemObject.StreetName = record.Element("street_name")?.Value;
                        itemObject.MetroLineId = string.IsNullOrEmpty(record.Element("metro_line_id")?.Value) ? -1 : int.Parse(record.Element("metro_line_id")?.Value);
                        itemObject.MetroStationId = string.IsNullOrEmpty(record.Element("metro_station_id")?.Value) ? -1 : int.Parse(record.Element("metro_station_id")?.Value);
                        itemObject.HouseNumber = string.IsNullOrEmpty(record.Element("house_number")?.Value) ? -1 : int.Parse(record.Element("house_number")?.Value);
                        itemObject.BuildingNumber = record.Element("building_number")?.Value;
                        itemObject.PositionX = string.IsNullOrEmpty(record.Element("position_x")?.Value) ? decimal.Zero : decimal.Parse(record.Element("position_x")?.Value.Replace(".",","));
                        itemObject.PositionY = string.IsNullOrEmpty(record.Element("position_y")?.Value) ? decimal.Zero : decimal.Parse(record.Element("position_y")?.Value.Replace(".", ","));
                        itemObject.Rooms = string.IsNullOrEmpty(record.Element("rooms")?.Value) ? -1 : int.Parse(record.Element("rooms")?.Value);
                        itemObject.SeparateRooms = string.IsNullOrEmpty(record.Element("separate_rooms")?.Value) ? -1 : int.Parse(record.Element("separate_rooms")?.Value);
                        itemObject.BuildingYear = string.IsNullOrEmpty(record.Element("building_year")?.Value) ? -1 : int.Parse(record.Element("building_year")?.Value);
                        itemObject.RepairYear = string.IsNullOrEmpty(record.Element("repair_year")?.Value) ? -1 : int.Parse(record.Element("repair_year")?.Value);
                        itemObject.Storey = string.IsNullOrEmpty(record.Element("storey")?.Value) ? -1 : int.Parse(record.Element("storey")?.Value);
                        itemObject.Storeys = string.IsNullOrEmpty(record.Element("storeys")?.Value) ? -1 : int.Parse(record.Element("storeys")?.Value);
                        itemObject.StoreyType = record.Element("storey_type")?.Value;
                        itemObject.HouseType = record.Element("house_type")?.Value;
                        itemObject.Layout = record.Element("layout")?.Value;
                        itemObject.AreaTotal = string.IsNullOrEmpty(record.Element("area_total")?.Value) ? -1 : decimal.Parse(record.Element("area_total")?.Value.Replace(".", ","));
                        itemObject.AreaLiving = string.IsNullOrEmpty(record.Element("area_living")?.Value) ? -1 : decimal.Parse(record.Element("area_living")?.Value.Replace(".", ","));
                        itemObject.AreaKitchen = string.IsNullOrEmpty(record.Element("area_kitchen")?.Value) ? -1 : decimal.Parse(record.Element("area_kitchen")?.Value.Replace(".", ","));
                        itemObject.Levels = string.IsNullOrEmpty(record.Element("levels")?.Value) ? -1 : int.Parse(record.Element("levels")?.Value);
                        itemObject.CeilingHeight = string.IsNullOrEmpty(record.Element("ceiling_height")?.Value) ? -1 : decimal.Parse(record.Element("ceiling_height")?.Value.Replace(".", ","));
                        itemObject.FloorType = record.Element("floor_type")?.Value;
                        itemObject.Lavatory = record.Element("lavatory")?.Value;
                        itemObject.Balcony = record.Element("balcony")?.Value;
                        itemObject.Phone = record.Element("phone")?.Value;
                        itemObject.Owner = record.Element("owner")?.Value;
                        itemObject.RepairState = record.Element("repair_state")?.Value;
                        itemObject.Comments = record.Element("comments")?.Value;
                        itemObject.ExtraInfo = string.IsNullOrEmpty(record.Element("extra_info")?.Value) ? -1 : int.Parse(record.Element("extra_info")?.Value);
                        itemObject.Description = record.Element("description")?.Value;
                        itemObject.Link = record.Element("link")?.Value;
                        itemObject.Contract = record.Element("contract")?.Value;
                        itemObject.DtContractOpened = Convert.ToDateTime(record.Element("dt_contract_opened")?.Value);
                        itemObject.DtContractClosed = Convert.ToDateTime(record.Element("dt_contract_closed")?.Value);
                        itemObject.RequestId = string.IsNullOrEmpty(record.Element("request_id")?.Value) ? -1 : int.Parse(record.Element("request_id")?.Value);
                        itemObject.Price = record.Element("price")?.Value;
                        itemObject.PriceHaggle = string.IsNullOrEmpty(record.Element("price_haggle")?.Value) ? -1 : int.Parse(record.Element("price_haggle")?.Value);
                        itemObject.Confan = true;
                        itemObject.Realt = true;
                        itemObject.TvoyaStolitsa = true;
                        itemObject.Onliner = true;

                        var photos = record.Element("photos")?.Elements("photo");
                        foreach(var photo in photos)
                        {
                            var objectPhoto = new RealEstateObjectPhoto();
                            objectPhoto.Unid = string.IsNullOrEmpty(record.Element("unid")?.Value) ? -1 : long.Parse(record.Element("unid")?.Value);
                            objectPhoto.Url = photo.Attribute("url")?.Value;
                            objectPhoto.Md5 = photo.Attribute("md5")?.Value;
                            var primary = photo.Attribute("primary")?.Value;
                            objectPhoto.isPrimary = (primary != null && primary == "1") ? true : false;
                            db.RealEstateObjectPhoto.Add(objectPhoto);
                        }

                        db.RealEstateObject.Add(itemObject);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
