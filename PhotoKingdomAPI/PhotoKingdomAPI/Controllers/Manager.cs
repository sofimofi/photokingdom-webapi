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
                cfg.CreateMap<Models.Attraction, Controllers.AttractionWithDetails>();
                cfg.CreateMap<Models.AttractionPhotowar, Controllers.AttractionPhotowarBase>();
                cfg.CreateMap<Models.AttractionPhotowar, Controllers.AttractionPhotowarWithDetails>();
                cfg.CreateMap<Controllers.AttractionPhotowarAdd, Models.AttractionPhotowar>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadBase>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadWithDetails>();
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
                cfg.CreateMap<Models.Photo, Controllers.PhotoWithDetails>();
                cfg.CreateMap<Controllers.PhotoAdd, Models.Photo>();
                cfg.CreateMap<Models.Ping, Controllers.PingBase>();
                cfg.CreateMap<Models.Ping, Controllers.PingWithDetails>();
                cfg.CreateMap<Controllers.PingAdd, Models.Ping>();
                cfg.CreateMap<Models.Province, Controllers.ProvinceBase>();
                cfg.CreateMap<Controllers.ProvinceAdd, Models.Province>();
                cfg.CreateMap<Models.Queue, Controllers.QueueBase>();
                cfg.CreateMap<Models.Queue, Controllers.QueueWithDetails>();
                cfg.CreateMap<Controllers.QueueAdd, Models.Queue>();
                cfg.CreateMap<Models.Resident, Controllers.ResidentBase>();
                cfg.CreateMap<Controllers.ResidentAdd, Models.Resident>();
                cfg.CreateMap<Models.ResidentAttractionOwn, Controllers.ResidentAttractionOwnBase>();
                cfg.CreateMap<Models.ResidentAttractionOwn, Controllers.ResidentAttractionOwnWithDetails>();
                cfg.CreateMap<Controllers.ResidentAttractionOwnAdd, Models.ResidentAttractionOwn>();
                cfg.CreateMap<Models.ResidentCityOwn, Controllers.ResidentCityOwnBase>();
                cfg.CreateMap<Models.ResidentCityOwn, Controllers.ResidentCityOwnWithDetails>();
                cfg.CreateMap<Controllers.ResidentCityOwnAdd, Models.ResidentCityOwn>();
                cfg.CreateMap<Models.ResidentContinentOwn, Controllers.ResidentContinentOwnBase>();
                cfg.CreateMap<Models.ResidentContinentOwn, Controllers.ResidentContinentOwnWithDetails>();
                cfg.CreateMap<Controllers.ResidentContinentOwnAdd, Models.ResidentContinentOwn>();
                cfg.CreateMap<Models.ResidentCountryOwn, Controllers.ResidentCountryOwnBase>();
                cfg.CreateMap<Models.ResidentCountryOwn, Controllers.ResidentCountryOwnWithDetails>();
                cfg.CreateMap<Controllers.ResidentCountryOwnAdd, Models.ResidentCountryOwn>();
                cfg.CreateMap<Models.ResidentProvinceOwn, Controllers.ResidentProvinceOwnBase>();
                cfg.CreateMap<Models.ResidentProvinceOwn, Controllers.ResidentProvinceOwnWithDetails>();
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

        // Programmatically load seed data for testing

		public int loadData(){
			int count = 0;

            // continents
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

            // countries
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

            // provinces
            if (ds.Provinces.Count() == 0)
            {
                var canada = ds.Countries.SingleOrDefault(o => o.Name == "Canada");
                if(canada != null)
                {
                    var ontario = ds.Provinces.Add(new Province { Name = "Ontario" });
                    ontario.Country = canada;
                    var quebec = ds.Provinces.Add(new Province { Name = "Quebec" });
                    quebec.Country = canada;
                    ds.SaveChanges();
                    count++;
                }
            }

            // cities
            if (ds.Cities.Count() == 0)
            {
                var ontario = ds.Provinces.SingleOrDefault(o => o.Name == "Ontario" && o.Country.Name == "Canada");
                var canada = ds.Countries.SingleOrDefault(o => o.Name == "Canada");
                if (ontario != null && canada != null)
                {
                    var toronto = ds.Cities.Add(new City { Name = "Toronto", Province = ontario, Country = canada });
                    var hamilton = ds.Cities.Add(new City { Name = "Hamilton", Province = ontario, Country = canada });
                    var ottawa = ds.Cities.Add(new City { Name = "Ottawa", Province = ontario, Country = canada });
                    var mississauga = ds.Cities.Add(new City { Name = "Mississauga", Province = ontario, Country = canada });
                    ds.SaveChanges();
                    count++;
                }
            }

            // attractions
            if(ds.Attractions.Count() == 0)
            {
                var toronto = ds.Cities.SingleOrDefault(o => o.Name == "Toronto" && o.Country.Name == "Canada");
                var hamilton = ds.Cities.SingleOrDefault(o => o.Name == "Hamilton" && o.Country.Name == "Canada");
                if (toronto != null && hamilton != null)
                {
                    var cnTower = ds.Attractions.Add(new Attraction
                    {
                        Name = "CN Tower",
                        Lat = 43.6426F,
                        Lng = -79.3871F,
                        IsActive = 1,
                        City = toronto
                    });

                    var casaloma = ds.Attractions.Add(new Attraction
                    {
                        Name = "Casa Loma",
                        Lat = 43.6781F,
                        Lng = -79.4095F,
                        IsActive = 1,
                        City = toronto
                    });

                    var albionFalls = ds.Attractions.Add(new Attraction
                    {
                        Name = "Albion Falls",
                        Lat = 43.2003F,
                        Lng = -79.8199F,
                        IsActive = 1,
                        City = hamilton
                    });
                    ds.SaveChanges();
                    count++;
                }
            }

            // residents
            if(ds.Residents.Count() == 0)
            {
                var toronto = ds.Cities.SingleOrDefault(o => o.Name == "Toronto" && o.Country.Name == "Canada");
                var hamilton = ds.Cities.SingleOrDefault(o => o.Name == "Hamilton" && o.Country.Name == "Canada");
                if (toronto != null && hamilton != null)
                {
                    var sofia = ds.Residents.Add(new Resident
                    {
                        UserName = "Sofia",
                        Email = "sofia.ngo@gmail.com",
                        Gender = "F",
                        IsActive = 1,
                        Password = "password",
                        City = toronto
                    });
                    var wonho = ds.Residents.Add(new Resident
                    {
                        UserName = "Wonho",
                        Email = "wonho@gmail.com",
                        Gender = "M",
                        IsActive = 1,
                        Password = "password",
                        City = toronto
                    });
                    var zhihao = ds.Residents.Add(new Resident
                    {
                        UserName = "Zhihao",
                        Email = "zhihao@gmail.com",
                        Gender = "M",
                        IsActive = 1,
                        Password = "password",
                        City = hamilton
                    });
                    ds.SaveChanges();
                    count++;
                }
            }

            // attractionphotowars & attractionphotowaruploads & photos
            if(ds.AttractionPhotowars.Count() == 0)
            {
                var cntower = ds.Attractions.SingleOrDefault(o => o.Name == "CN Tower" && o.City.Name == "Toronto");
                var casaloma = ds.Attractions.SingleOrDefault(o => o.Name == "Casa Loma" && o.City.Name == "Toronto");
                var sofia = ds.Residents.SingleOrDefault(o => o.UserName == "Sofia");
                var wonho = ds.Residents.SingleOrDefault(o => o.UserName == "Wonho");
                var zhihao = ds.Residents.SingleOrDefault(o => o.UserName == "Zhihao");
                if (cntower != null && casaloma != null && sofia != null && wonho != null && zhihao != null)
                {
                    var cntowerPhoto1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7426F,
                        Lng = -79.4871F,
                        Resident = sofia,
                        PhotoFilePath = "path/path"
                    });
                    var cntowerPhoto2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7336F,
                        Lng = -79.4221F,
                        Resident = wonho,
                        PhotoFilePath = "path/path2"
                    });
                    var casalomaPhoto = ds.Photos.Add(new Photo
                    {
                        Lat = 43.2181F,
                        Lng = -79.9895F,
                        Resident = wonho,
                        PhotoFilePath = "path/path3"
                    });
                    var casalomaPhoto2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.2181F,
                        Lng = -79.9895F,
                        Resident = zhihao,
                        PhotoFilePath = "path/path4"
                    });
                    ds.SaveChanges();

                    var photowar1 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = cntower.Id
                    });
                    var photowar2 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = casaloma.Id
                    });
                    ds.SaveChanges();


                    var upload1 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = cntowerPhoto1,
                        AttractionPhotoWar = photowar1
                    });
                    var upload2 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = cntowerPhoto2,
                        AttractionPhotoWar = photowar1
                    });
                    var upload3 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = casalomaPhoto,
                        AttractionPhotoWar = photowar2
                    });
                    var upload4 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = casalomaPhoto2,
                        AttractionPhotoWar = photowar2
                    });
                    ds.SaveChanges();
                    count++;
                } else
                {
                    throw new Exception("Seed data problem!");
                }
            }

            // pings
            if(ds.Pings.Count() == 0)
            {
                var cntower = ds.Attractions.SingleOrDefault(o => o.Name == "CN Tower" && o.City.Name == "Toronto");
                var albionfalls = ds.Attractions.SingleOrDefault(o => o.Name == "Albion Falls" && o.City.Name == "Hamilton");
                var sofia = ds.Residents.SingleOrDefault(o => o.UserName == "Sofia");
                var wonho = ds.Residents.SingleOrDefault(o => o.UserName == "Wonho");
                var zhihao = ds.Residents.SingleOrDefault(o => o.UserName == "Zhihao");
                if(cntower != null && albionfalls != null && sofia != null && wonho != null && zhihao != null)
                {
                    ds.Pings.Add(new Ping
                    {
                        Attraction = cntower,
                        Resident = sofia
                    });
                    ds.Pings.Add(new Ping
                    {
                        Attraction = cntower,
                        Resident = wonho
                    });
                    ds.Pings.Add(new Ping
                    {
                        Attraction = albionfalls,
                        Resident = sofia
                    });
                    ds.Pings.Add(new Ping
                    {
                        Attraction = albionfalls,
                        Resident = zhihao
                    });
                    ds.Pings.Add(new Ping
                    {
                        Attraction = albionfalls,
                        Resident = wonho
                    });
                    ds.SaveChanges();
                    count++;
                } else
                {
                    throw new Exception("Seed data problem!");
                }
            }

			return count;
		}

        #region Attraction
        // **************************************************************
        //                          Attraction
        // **************************************************************

        public IEnumerable<AttractionBase> AttractionGetAll()
        {
            return mapper.Map<IEnumerable<Attraction>, IEnumerable<AttractionBase>>(ds.Attractions);
        }

        public AttractionBase AttractionGetById(int? id)
        {
            var a = ds.Attractions.Find(id);
            return (a == null) ? null : mapper.Map<AttractionBase>(a);
        }

        public AttractionWithDetails AttractionGetByIdWithDetails(int id)
        {
            var a = ds.Attractions.Include("City").Include("QueuedUploads").Include("AttractionPhotoWars").Include("Owners").SingleOrDefault(o => o.Id == id);
            return (a == null) ? null : mapper.Map<AttractionWithDetails>(a);
        }
        #endregion Attraction

        #region AttractionPhotoWar
        // **************************************************************
        //                          AttractionPhotowar
        // **************************************************************

        public IEnumerable<AttractionPhotowarBase> AttractionPhotowarGetAll()
        {
            var a = ds.AttractionPhotowars.OrderBy(o => o.StartDate);
            return mapper.Map<IEnumerable<AttractionPhotowarBase>>(a);
        }

        public AttractionPhotowarBase AttractionPhotowarGetById(int id)
        {
            var a = ds.AttractionPhotowars.Find(id);
            return (a == null) ? null : mapper.Map<AttractionPhotowarBase>(a);
        }

        public AttractionPhotowarBase AttractionPhotowarAdd(AttractionPhotowarAdd newItem)
        {
            if(newItem == null)
            {
                return null;
            } else
            {
                var addedItem = mapper.Map<AttractionPhotowar>(newItem);
                ds.AttractionPhotowars.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<AttractionPhotowarBase>(addedItem);
            }
        }

        public AttractionPhotowarWithDetails AttractionPhotowarGetByIdWithDetails(int id)
        {
            var a = ds.AttractionPhotowars.Include("Attraction").Include("AttractionPhotowarUploads").SingleOrDefault(o => o.Id == id);
            return (a == null) ? null : mapper.Map<AttractionPhotowarWithDetails>(a);
        }
        #endregion AttractionPhotowar

        #region AttractionPhotowarUpload
        // **************************************************************
        //                          AttractionPhotowar
        // **************************************************************

        public IEnumerable<AttractionPhotowarUploadBase> AttractionPhotowarUploadGetAll()
        {
            var a = ds.AttractionPhotowarUploads.OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<AttractionPhotowarUploadBase>>(a);
        }

        public AttractionPhotowarUploadBase AttractionPhotowarUploadGetById(int id)
        {
            var a = ds.AttractionPhotowarUploads.Find(id);
            return (a == null) ? null : mapper.Map<AttractionPhotowarUploadBase>(a);
        }

        public AttractionPhotowarUploadBase AttractionPhotowarUploadAdd(AttractionPhotowarUploadAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<AttractionPhotowarUpload>(newItem);
                ds.AttractionPhotowarUploads.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<AttractionPhotowarUploadBase>(addedItem);
            }
        }

        public AttractionPhotowarUploadWithDetails AttractionPhotowarUploadGetByIdWithDetails(int id)
        {
            var a = ds.AttractionPhotowarUploads.Include("Photo").Include("AttractionPhotowar").Include("ResidentVotes").SingleOrDefault(o => o.Id == id);
            return (a == null) ? null : mapper.Map<AttractionPhotowarUploadWithDetails>(a);
        }
        #endregion AttractionPhotowarUpload

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

        #region Photo
        // **************************************************************
        //                          Photo
        // **************************************************************

        public IEnumerable<PhotoBase> PhotoGetAllForResident(int id)
        {
            var a = ds.Photos.Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<PhotoBase>>(a);
        }

        public PhotoWithDetails PhotoGetByIdWithDetails(int id)
        {
            var a = ds.Photos.Include("Resident").Include("AttractionPhotowarUploads").Include("CountryPhotowarUploads")
                .Include("ContinentPhotowarUploads").Include("CountryPhotowarRequestedphotoUploads").Include("ContinentPhotowarRequestedphotoUploads").SingleOrDefault(o => o.Id == id);
            return (a == null) ? null : mapper.Map<PhotoWithDetails>(a);
        }

        public PhotoBase PhotoAdd(PhotoAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Photo>(newItem);
                ds.Photos.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<PhotoBase>(addedItem);
            }
        }
        #endregion Photo

        #region Ping
        // **************************************************************
        //                          Ping
        // **************************************************************

        public IEnumerable<PingWithDetails> PingGetAllForResident(int id)
        {
            var p = ds.Pings.Include("Attraction").Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<PingWithDetails>>(p);
        }

        public PingBase PingAdd(PingAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Ping>(newItem);
                ds.Pings.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<PingBase>(addedItem);
            }
        }
        #endregion Ping

        #region Queue
        // **************************************************************
        //                          Queue
        // **************************************************************

        // Get all queues for an attraction
        public IEnumerable<QueueBase> QueueGetAllForAttraction(int id)
        {
            var p = ds.Queues.Where(o => o.AttractionId == id).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<QueueBase>>(p);
        }

        // Get all queues with details for an attraction
        public IEnumerable<QueueWithDetails> QueueGetAllWithDetailsForAttraction(int id)
        {
            var p = ds.Queues.Include("AttractionPhotowarUpload").Where(o => o.AttractionId == id).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<QueueWithDetails>>(p);
        }

        public QueueBase QueueAdd(QueueAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<Queue>(newItem);
                ds.Queues.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<QueueBase>(addedItem);
            }
        }
        #endregion Ping

        #region ResidentAttractionOwn
        // **************************************************************
        //                          ResidentAttractionOwn
        // **************************************************************

        // Get all the current active ResidentAttractionOwns
        public IEnumerable<ResidentAttractionOwnWithDetails> ResidentAttractionOwnGetAllActiveWithDetails()
        {
            var a = ds.ResidentAttractionOwns.Include("Attraction").Include("Resident").Where(o => o.EndOfOwn == null).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentAttractionOwnWithDetails>>(a);
        }

        // Get all attraction owns for a resident
        public IEnumerable<ResidentAttractionOwnWithDetails> AttractionOwnGetAllForResident(int id)
        {
            var a = ds.ResidentAttractionOwns.Include("Attraction").Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentAttractionOwnWithDetails>>(a);
        }

        // Get all resident owns for an attraction
        public IEnumerable<ResidentAttractionOwnWithDetails> ResidentOwnGetAllForAttraction(int id)
        {
            var r = ds.ResidentAttractionOwns.Include("Resident").Where(o => o.AttractionId == id).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<ResidentAttractionOwnWithDetails>>(r);
        }

        public ResidentAttractionOwnBase ResidentAttractionOwnAdd(ResidentAttractionOwnAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<ResidentAttractionOwn>(newItem);
                ds.ResidentAttractionOwns.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<ResidentAttractionOwnBase>(addedItem);
            }
        }
        #endregion ResidentAttractionOwn


        #region ResidentCityOwn
        // **************************************************************
        //                          ResidentCityOwn
        // **************************************************************

        // Get all the current active ResidentCityOwns
        public IEnumerable<ResidentCityOwnWithDetails> ResidentCityOwnGetAllActiveWithDetails()
        {
            var a = ds.ResidentCityOwns.Include("City").Include("Resident").Where(o => o.EndOfOwn == null).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentCityOwnWithDetails>>(a);
        }

        // Get all city owns for a resident
        public IEnumerable<ResidentCityOwnWithDetails> CityOwnGetAllForResident(int id)
        {
            var a = ds.ResidentCityOwns.Include("City").Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentCityOwnWithDetails>>(a);
        }

        // Get all active resident owns for a city
        public IEnumerable<ResidentCityOwnWithDetails> ResidentOwnGetAllActiveForCity(int id)
        {
            var r = ds.ResidentCityOwns.Include("Resident").Where(o => o.CityId == id && o.EndOfOwn == null).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<ResidentCityOwnWithDetails>>(r);
        }

        public ResidentCityOwnBase ResidentCityOwnAdd(ResidentCityOwnAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<ResidentCityOwn>(newItem);
                ds.ResidentCityOwns.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<ResidentCityOwnBase>(addedItem);
            }
        }
        #endregion ResidentCityOwn

        #region ResidentProvinceOwn
        // **************************************************************
        //                          ResidentProvinceOwn
        // **************************************************************

        // Get all the current active ResidentProvinceOwns
        public IEnumerable<ResidentProvinceOwnWithDetails> ResidentProvinceOwnGetAllActiveWithDetails()
        {
            var a = ds.ResidentProvinceOwns.Include("Province").Include("Resident").Where(o => o.EndOfOwn == null).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentProvinceOwnWithDetails>>(a);
        }

        // Get all province owns for a resident
        public IEnumerable<ResidentProvinceOwnWithDetails> ProvinceOwnGetAllForResident(int id)
        {
            var a = ds.ResidentProvinceOwns.Include("Province").Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentProvinceOwnWithDetails>>(a);
        }

        // Get all active resident owns for a province
        public IEnumerable<ResidentProvinceOwnWithDetails> ResidentOwnGetAllActiveForProvince(int id)
        {
            var r = ds.ResidentProvinceOwns.Include("Resident").Where(o => o.ProvinceId == id && o.EndOfOwn == null).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<ResidentProvinceOwnWithDetails>>(r);
        }

        public ResidentProvinceOwnBase ResidentProvinceOwnAdd(ResidentProvinceOwnAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<ResidentProvinceOwn>(newItem);
                ds.ResidentProvinceOwns.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<ResidentProvinceOwnBase>(addedItem);
            }
        }
        #endregion ResidentProvinceOwn

        #region ResidentCountryOwn
        // **************************************************************
        //                          ResidentCountryOwn
        // **************************************************************

        // Get all the current active ResidentCountryOwns
        public IEnumerable<ResidentCountryOwnWithDetails> ResidentCountryOwnGetAllActiveWithDetails()
        {
            var a = ds.ResidentCountryOwns.Include("Country").Include("Resident").Where(o => o.EndOfOwn == null).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentCountryOwnWithDetails>>(a);
        }

        // Get all country owns for a resident
        public IEnumerable<ResidentCountryOwnWithDetails> CountryOwnGetAllForResident(int id)
        {
            var a = ds.ResidentCountryOwns.Include("Country").Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentCountryOwnWithDetails>>(a);
        }

        // Get all active resident owns for a country
        public IEnumerable<ResidentCountryOwnWithDetails> ResidentOwnGetAllActiveForCountry(int id)
        {
            var r = ds.ResidentCountryOwns.Include("Resident").Where(o => o.CountryId == id && o.EndOfOwn == null).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<ResidentCountryOwnWithDetails>>(r);
        }

        public ResidentCountryOwnBase ResidentCountryOwnAdd(ResidentCountryOwnAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<ResidentCountryOwn>(newItem);
                ds.ResidentCountryOwns.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<ResidentCountryOwnBase>(addedItem);
            }
        }
        #endregion ResidentCountryOwn

        #region ResidentContinentOwn
        // **************************************************************
        //                          ResidentContinentOwn
        // **************************************************************

        // Get all the current active ResidentContinentOwns
        public IEnumerable<ResidentContinentOwnWithDetails> ResidentContinentOwnGetAllActiveWithDetails()
        {
            var a = ds.ResidentContinentOwns.Include("Continent").Include("Resident").Where(o => o.EndOfOwn == null).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentContinentOwnWithDetails>>(a);
        }

        // Get all country owns for a resident
        public IEnumerable<ResidentContinentOwnWithDetails> ContinentOwnGetAllForResident(int id)
        {
            var a = ds.ResidentContinentOwns.Include("Continent").Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);
            return mapper.Map<IEnumerable<ResidentContinentOwnWithDetails>>(a);
        }

        // Get all active resident owns for a continent
        public IEnumerable<ResidentContinentOwnWithDetails> ResidentOwnGetAllActiveForContinent(int id)
        {
            var r = ds.ResidentContinentOwns.Include("Resident").Where(o => o.ContinentId == id && o.EndOfOwn == null).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<ResidentContinentOwnWithDetails>>(r);
        }

        public ResidentContinentOwnBase ResidentContinentOwnAdd(ResidentContinentOwnAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var addedItem = mapper.Map<ResidentContinentOwn>(newItem);
                ds.ResidentContinentOwns.Add(addedItem);
                ds.SaveChanges();
                return mapper.Map<ResidentContinentOwnBase>(addedItem);
            }
        }
        #endregion ResidentContinentOwn
    }
}
