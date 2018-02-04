using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoKingdomAPI.Models;
using AutoMapper;

namespace PhotoKingdomAPI.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper components
        MapperConfiguration config;
        public IMapper mapper;

        public Manager()
        {
            // Configure AutoMapper...
            config = new MapperConfiguration(cfg =>
            {
                // Define the mappings
                cfg.CreateMap<Models.Attraction, Controllers.AttractionBase>();
                cfg.CreateMap<Controllers.AttractionAdd, Models.Attraction>();
                cfg.CreateMap<Models.AttractionPhotowar, Controllers.AttractionPhotowarBase>();
                cfg.CreateMap<Controllers.AttractionPhotowarAdd, Models.AttractionPhotowar>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadBase>();
                cfg.CreateMap<Controllers.AttractionPhotowarUploadAdd, Models.AttractionPhotowarUpload>();
                cfg.CreateMap<Models.City, Controllers.CityBase>();
                cfg.CreateMap<Controllers.CityAdd, Models.City>();
                cfg.CreateMap<Models.Continent, Controllers.ContinentBase>();
                cfg.CreateMap<Controllers.ContinentAdd, Models.Continent>();
                cfg.CreateMap<Models.ContinentPhotowar, Controllers.ContinentPhotowarBase>();
                cfg.CreateMap<Controllers.ContinentPhotowarAdd, Models.ContinentPhotowar>();
                cfg.CreateMap<Models.ContinentPhotowarPhotorequest, Controllers.ContinentPhotowarPhotorequestBase>();
                cfg.CreateMap<Controllers.ContinentPhotowarPhotorequestAdd, Models.ContinentPhotowarPhotorequest>();
                cfg.CreateMap<Models.ContinentPhotowarRequestedphotoUpload, Controllers.ContinentPhotowarRequestedphotoUploadBase>();
                cfg.CreateMap<Controllers.ContinentPhotowarRequestedphotoUploadAdd, Models.ContinentPhotowarRequestedphotoUpload>();
                cfg.CreateMap<Models.ContinentPhotowarUpload, Controllers.ContinentPhotowarUploadBase>();
                cfg.CreateMap<Controllers.ContinentPhotowarUploadAdd, Models.ContinentPhotowarUpload>();
                cfg.CreateMap<Models.ContinentProfile, Controllers.ContinentProfileBase>();
                cfg.CreateMap<Controllers.ContinentProfileAdd, Models.ContinentProfile>();
                cfg.CreateMap<Models.Country, Controllers.CountryBase>();
                cfg.CreateMap<Controllers.CountryAdd, Models.Country>();
                cfg.CreateMap<Models.CountryPhotowar, Controllers.CountryPhotowarBase>();
                cfg.CreateMap<Controllers.CountryPhotowarAdd, Models.CountryPhotowar>();
                cfg.CreateMap<Models.CountryPhotowarPhotorequest, Controllers.CountryPhotowarPhotorequestBase>();
                cfg.CreateMap<Controllers.CountryPhotowarPhotorequestAdd, Models.CountryPhotowarPhotorequest>();
                cfg.CreateMap<Models.CountryPhotowarRequestdphotoUpload, Controllers.CountryPhotowarRequestdphotoUploadBase>();
                cfg.CreateMap<Controllers.CountryPhotowarRequestdphotoUploadAdd, Models.CountryPhotowarRequestdphotoUpload>();
                cfg.CreateMap<Models.CountryPhotowarUpload, Controllers.CountryPhotowarUploadBase>();
                cfg.CreateMap<Controllers.CountryPhotowarUploadAdd, Models.CountryPhotowarUpload>();
                cfg.CreateMap<Models.CountryProfile, Controllers.CountryProfileBase>();
                cfg.CreateMap<Controllers.CountryProfileAdd, Models.CountryProfile>();
                cfg.CreateMap<Models.Photo, Controllers.PhotoBase>();
                cfg.CreateMap<Controllers.PhotoAdd, Models.Photo>();
                cfg.CreateMap<Models.Ping, Controllers.PingBase>();
                cfg.CreateMap<Controllers.PingAdd, Models.Ping>();
                cfg.CreateMap<Models.Province, Controllers.ProvinceBase>();
                cfg.CreateMap<Controllers.ProvinceAdd, Models.Province>();
                cfg.CreateMap<Models.Queue, Controllers.QueueBase>();
                cfg.CreateMap<Controllers.QueueAdd, Models.Queue>();
                cfg.CreateMap<Models.Resident, Controllers.ResidentBase>();
                cfg.CreateMap<Controllers.ResidentAdd, Models.Resident>();
                cfg.CreateMap<Models.ResidentAttractionOwn, Controllers.ResidentAttractionOwnBase>();
                cfg.CreateMap<Controllers.ResidentAttractionOwnAdd, Models.ResidentAttractionOwn>();
                cfg.CreateMap<Models.ResidentCityOwn, Controllers.ResidentCityOwnBase>();
                cfg.CreateMap<Controllers.ResidentCityOwnAdd, Models.ResidentCityOwn>();
                cfg.CreateMap<Models.ResidentContinentOwn, Controllers.ResidentContinentOwnBase>();
                cfg.CreateMap<Controllers.ResidentContinentOwnAdd, Models.ResidentContinentOwn>();
                cfg.CreateMap<Models.ResidentCountryOwn, Controllers.ResidentCountryOwnBase>();
                cfg.CreateMap<Controllers.ResidentCountryOwnAdd, Models.ResidentCountryOwn>();
                cfg.CreateMap<Models.ResidentProvinceOwn, Controllers.ResidentProvinceOwnBase>();
                cfg.CreateMap<Controllers.ResidentProvinceOwnAdd, Models.ResidentProvinceOwn>();
                cfg.CreateMap<Models.VoteAttractionPhotowarUpload, Controllers.VoteAttractionPhotowarUploadBase>();
                cfg.CreateMap<Controllers.VoteAttractionPhotowarUploadAdd, Models.VoteAttractionPhotowarUpload>();
                cfg.CreateMap<Models.VoteContinentPhotowarUpload, Controllers.VoteContinentPhotowarUploadBase>();
                cfg.CreateMap<Controllers.VoteContinentPhotowarUploadAdd, Models.VoteContinentPhotowarUpload>();
                cfg.CreateMap<Models.VoteCountryPhotowarUpload, Controllers.VoteCountryPhotowarUploadBase>();
                cfg.CreateMap< Controllers.VoteCountryPhotowarUploadAdd, Models.VoteCountryPhotowarUpload >();
            });

            mapper = config.CreateMapper();


            // Data-handling configuration

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // TODO: Need to implement CRUD methods
    }
}