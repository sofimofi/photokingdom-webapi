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
                #region Define the mappings

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
                cfg.CreateMap<Models.CountryPhotowarRequestedphotoUpload, Controllers.CountryPhotowarRequestedphotoUploadBase>();
                cfg.CreateMap<Controllers.CountryPhotowarRequestedphotoUploadAdd, Models.CountryPhotowarRequestedphotoUpload>();
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
                //cfg.CreateMap<Models.VoteAttractionPhotowarUpload, Controllers.VoteAttractionPhotowarUploadBase>();
                //cfg.CreateMap<Controllers.VoteAttractionPhotowarUploadAdd, Models.VoteAttractionPhotowarUpload>();
                //cfg.CreateMap<Models.VoteContinentPhotowarUpload, Controllers.VoteContinentPhotowarUploadBase>();
                //cfg.CreateMap<Controllers.VoteContinentPhotowarUploadAdd, Models.VoteContinentPhotowarUpload>();
                //cfg.CreateMap<Models.VoteCountryPhotowarUpload, Controllers.VoteCountryPhotowarUploadBase>();
                //cfg.CreateMap< Controllers.VoteCountryPhotowarUploadAdd, Models.VoteCountryPhotowarUpload >();

                #endregion Define the mappings
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


        // **************************************************************
        //                          Attraction
        // **************************************************************

        public IEnumerable<AttractionBase> AttractionGetAll()
        {
            return mapper.Map<IEnumerable<Attraction>, IEnumerable<AttractionBase>>(ds.Attractions);
        }

		public int loadData(){
			int count = 0;
			if (ds.Continents.Count() == 0)
			{
				ds.Continents.Add(new Continent { Name = "North America" });
				ds.Continents.Add(new Continent { Name = "South America" });
				ds.Continents.Add(new Continent { Name = "Europe" });
				ds.Continents.Add(new Continent { Name = "Africa" });
				ds.Continents.Add(new Continent { Name = "Middle East" });
				ds.Continents.Add(new Continent { Name = "Asia" });
				ds.Continents.Add(new Continent { Name = "Australia" });
				ds.SaveChanges();
				count++;
			}

			if (ds.Countries.Count() == 0)
			{
				var northAmerica = ds.Continents.SingleOrDefault(o => o.Name == "North America");
				if (northAmerica != null)
				{
					var canada = ds.Countries.Add(new Country { Name = "Canada" });
					canada.Continent = northAmerica;
					var usa = ds.Countries.Add(new Country { Name = "United States of America" });
					usa.Continent = northAmerica;
					ds.SaveChanges();
					count++;
				}
			}
			return count;
		}

        #region Resident
        // **************************************************************
        //                          Resident
        // **************************************************************
        public IEnumerable<ResidentBase> ResidentGetAll()
        {
            var c = ds.Residents.OrderBy(r => r.Id);
            return mapper.Map<IEnumerable<ResidentBase>>(c);
        }

        public ResidentBase ResidentGetById(int id)
        {
            var o = ds.Residents.Find(id);
            return (o == null) ? null : mapper.Map<ResidentBase>(o);
        }

        public ResidentBase ResidentAdd(ResidentAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Resident>(newItem);

                ds.Residents.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<ResidentBase>(addedItem);
            }
        }
        #endregion Resident

        #region City
        // **************************************************************
        //                          City
        // **************************************************************
        public IEnumerable<CityBase> CityGetAll()
        {
            var c = ds.Cities.OrderBy(r => r.Id);
            return mapper.Map<IEnumerable<CityBase>>(c);
        }

        public CityBase CityGetById(int id)
        {
            var o = ds.Cities.Find(id);
            return (o == null) ? null : mapper.Map<CityBase>(o);
        }

        public CityBase CityAdd(CityAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<City>(newItem);

                ds.Cities.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<CityBase>(addedItem);
            }
        }
        #endregion City

        #region Country
        // **************************************************************
        //                          Country
        // **************************************************************
        public IEnumerable<CountryBase> CountryGetAll()
        {
            var c = ds.Countries.OrderBy(r => r.Id);
            return mapper.Map<IEnumerable<CountryBase>>(c);
        }

        public CountryBase CountryGetById(int id)
        {
            var o = ds.Countries.Find(id);
            return (o == null) ? null : mapper.Map<CountryBase>(o);
        }

        public CountryBase CountryAdd(CountryAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Country>(newItem);

                ds.Countries.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<CountryBase>(addedItem);
            }
        }
        #endregion Country

        #region Province
        // **************************************************************
        //                          Province
        // **************************************************************
        public IEnumerable<ProvinceBase> ProvinceGetAll()
        {
            var c = ds.Provinces.OrderBy(r => r.Id);
            return mapper.Map<IEnumerable<ProvinceBase>>(c);
        }

        public ProvinceBase ProvinceGetById(int id)
        {
            var o = ds.Provinces.Find(id);
            return (o == null) ? null : mapper.Map<ProvinceBase>(o);
        }

        public ProvinceBase ProvinceAdd(ProvinceAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Province>(newItem);

                ds.Provinces.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<ProvinceBase>(addedItem);
            }
        }
        #endregion Province

        #region Continent
        // **************************************************************
        //                          Continent
        // **************************************************************
        public IEnumerable<ContinentBase> ContinentGetAll()
        {
            var c = ds.Continents.OrderBy(r => r.Id);
            return mapper.Map<IEnumerable<ContinentBase>>(c);
        }

        public ContinentBase ContinentGetById(int id)
        {
            var o = ds.Continents.Find(id);
            return (o == null) ? null : mapper.Map<ContinentBase>(o);
        }

        public ContinentBase ContinentAdd(ContinentAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Continent>(newItem);

                ds.Continents.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<ContinentBase>(addedItem);
            }
        }
        #endregion Continent
    }
}
