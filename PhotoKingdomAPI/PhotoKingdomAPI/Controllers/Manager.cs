using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PhotoKingdomAPI.Models;
using AutoMapper;
using Excel;

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
                cfg.CreateMap<Models.Attraction, Controllers.AttractionForMapView>();
                cfg.CreateMap<Models.AttractionPhotowar, Controllers.AttractionPhotowarBase>();
                cfg.CreateMap<Models.AttractionPhotowar, Controllers.AttractionPhotowarWithDetails>();
                cfg.CreateMap<Controllers.AttractionPhotowarAdd, Models.AttractionPhotowar>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadBase>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadWithDetails>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadForPhotowar>();
                cfg.CreateMap<Models.AttractionPhotowarUpload, Controllers.AttractionPhotowarUploadForPhotoView>();
                cfg.CreateMap<Controllers.AttractionPhotowarUploadAdd, Models.AttractionPhotowarUpload>();
                cfg.CreateMap<Models.City, Controllers.CityBase>();
                cfg.CreateMap<Models.Continent, Controllers.ContinentBase>();
                cfg.CreateMap<Models.Continent, Controllers.ContinentWithCountries>();
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
                cfg.CreateMap<Models.Country, Controllers.CountryWithProvinces>();
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
                cfg.CreateMap<Models.Province, Controllers.ProvinceWithCities>();
                cfg.CreateMap<Models.Queue, Controllers.QueueBase>();
                cfg.CreateMap<Models.Queue, Controllers.QueueWithDetails>();
                cfg.CreateMap<Controllers.QueueAdd, Models.Queue>();
                cfg.CreateMap<Models.Resident, Controllers.ResidentBase>();
                cfg.CreateMap<Models.Resident, Controllers.ResidentWithDetails>();
                cfg.CreateMap<Controllers.ResidentAdd, Models.Resident>();
                cfg.CreateMap<Models.ResidentAttractionOwn, Controllers.ResidentAttractionOwnBase>();
                cfg.CreateMap<Models.ResidentAttractionOwn, Controllers.ResidentAttractionOwnWithDetails>();
                cfg.CreateMap<Models.ResidentAttractionOwn, Controllers.ResidentAttractionOwnForMapView>();
                cfg.CreateMap<Controllers.ResidentAttractionOwnAdd, Models.ResidentAttractionOwn>();
                cfg.CreateMap<Models.ResidentCityOwn, Controllers.ResidentCityOwnBase>();
                cfg.CreateMap<Models.ResidentCityOwn, Controllers.ResidentCityOwnWithDetails>();
                cfg.CreateMap<Models.ResidentCityOwn, Controllers.ResidentCityOwnForMapView>();
                cfg.CreateMap<Controllers.ResidentCityOwnAdd, Models.ResidentCityOwn>();
                cfg.CreateMap<Models.ResidentContinentOwn, Controllers.ResidentContinentOwnBase>();
                cfg.CreateMap<Models.ResidentContinentOwn, Controllers.ResidentContinentOwnWithDetails>();
                cfg.CreateMap<Models.ResidentContinentOwn, Controllers.ResidentContinentOwnForMapView>();
                cfg.CreateMap<Controllers.ResidentContinentOwnAdd, Models.ResidentContinentOwn>();
                cfg.CreateMap<Models.ResidentCountryOwn, Controllers.ResidentCountryOwnBase>();
                cfg.CreateMap<Models.ResidentCountryOwn, Controllers.ResidentCountryOwnWithDetails>();
                cfg.CreateMap<Models.ResidentCountryOwn, Controllers.ResidentCountryOwnForMapView>();
                cfg.CreateMap<Controllers.ResidentCountryOwnAdd, Models.ResidentCountryOwn>();
                cfg.CreateMap<Models.ResidentProvinceOwn, Controllers.ResidentProvinceOwnBase>();
                cfg.CreateMap<Models.ResidentProvinceOwn, Controllers.ResidentProvinceOwnWithDetails>();
                cfg.CreateMap<Models.ResidentProvinceOwn, Controllers.ResidentProvinceOwnForMapView>();
                cfg.CreateMap<Controllers.ResidentProvinceOwnAdd, Models.ResidentProvinceOwn>();

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

        public int loadData()
        {
            int count = 0;
            /*
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
            */

            // Load world data for testing
            // If this is for loading all data, call this method with "false" parameter
            if (ds.Continents.Count() == 0)
            {
                LoadWorldData(true);
            }

            // attractions
            if (ds.Attractions.Count() == 0)
            {
                // Remove country and add province
                //var toronto = ds.Cities.SingleOrDefault(o => o.Name == "Toronto" && o.Country.Name == "Canada");
                //var hamilton = ds.Cities.SingleOrDefault(o => o.Name == "Hamilton" && o.Country.Name == "Canada");
                var toronto = ds.Cities.SingleOrDefault(o => o.Name == "Toronto" && o.Province.Name == "Ontario");
                var hamilton = ds.Cities.SingleOrDefault(o => o.Name == "Hamilton" && o.Province.Name == "Ontario");
                if (toronto != null && hamilton != null)
                {
                    var cnTower = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJmzrzi9Y0K4gRgXUc3sTY7RU",
                        Name = "CN Tower",
                        Lat = 43.6425662,
                        Lng = -79.3870568,
                        IsActive = 1,
                        City = toronto
                    });

                    var casaloma = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJs6Elz500K4gRT1jWAsHIfGE",
                        Name = "Casa Loma",
                        Lat = 43.67803709999999,
                        Lng = -79.4094439,
                        IsActive = 1,
                        City = toronto
                    });

                    var boyerWoodlot = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJayuRaDAuK4gRp_DQLDA40x4",
                        Name = "Boywer Woodlot",
                        Lat = 43.77585490000001,
                        Lng = -79.50518649999999,
                        IsActive = 1,
                        City = toronto
                    });

                    var danIannuzziPark = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJKXjaUSguK4gRgvTrZyaK6_4",
                        Name = "Dan Iannuzzi Park",
                        Lat = 43.7668115,
                        Lng = -79.5065087,
                        IsActive = 1,
                        City = toronto
                    });

                    var shorehamPark = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJJ4p-dtQvK4gR35Y1pY2iulI",
                        Name = "Shoreham Park",
                        Lat = 43.7685742,
                        Lng = -79.5178353,
                        IsActive = 1,
                        City = toronto
                    });

                    var edgeleyPark = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJsT_iuCowK4gRoRQDo0cKQL8",
                        Name = "Edgeley Park",
                        Lat = 43.7652519,
                        Lng = -79.5185398,
                        IsActive = 1,
                        City = toronto
                    });

                    var albionFalls = ds.Attractions.Add(new Attraction
                    {
                        googlePlaceId = "ChIJYfLnmo2ZLIgRWmwJTr1WtQc",
                        Name = "Albion Falls",
                        Lat = 43.2003789,
                        Lng = -79.8196464,
                        IsActive = 1,
                        City = hamilton
                    });
                    ds.SaveChanges();
                    count++;
                }
            }

            // residents
            if (ds.Residents.Count() == 0)
            {
                //var toronto = ds.Cities.SingleOrDefault(o => o.Name == "Toronto" && o.Country.Name == "Canada");
                //var hamilton = ds.Cities.SingleOrDefault(o => o.Name == "Hamilton" && o.Country.Name == "Canada");
                var toronto = ds.Cities.SingleOrDefault(o => o.Name == "Toronto" && o.Province.Name == "Ontario");
                var hamilton = ds.Cities.SingleOrDefault(o => o.Name == "Hamilton" && o.Province.Name == "Ontario");
                if (toronto != null && hamilton != null)
                {
                    var sofia = ds.Residents.Add(new Resident
                    {
                        UserName = "Sofia",
                        Email = "sofia.ngo@gmail.com",
                        Gender = "F",
                        IsActive = 1,
                        Password = "password",
                        City = toronto,
                        AvatarImagePath = "img/girl.png"
                    });
                    var wonho = ds.Residents.Add(new Resident
                    {
                        UserName = "Wonho",
                        Email = "wonho@gmail.com",
                        Gender = "M",
                        IsActive = 1,
                        Password = "password",
                        City = toronto,
                        AvatarImagePath = "img/boy.png"
                    });
                    var zhihao = ds.Residents.Add(new Resident
                    {
                        UserName = "Zhihao",
                        Email = "zhihao@gmail.com",
                        Gender = "M",
                        IsActive = 1,
                        Password = "password",
                        City = hamilton,
                        AvatarImagePath = "img/3.png"
                    });
                    var testAccount = ds.Residents.Add(new Resident
                    {
                        UserName = "Test",
                        Email = "test@example.com",
                        Gender = "M",
                        IsActive = 1,
                        Password = "password",
                        City = toronto,
                        AvatarImagePath = "img/boy.png"
                    });
                    ds.SaveChanges();
                    count++;
                }
            }

            // attractionphotowars & attractionphotowaruploads & photos & votes
            if (ds.AttractionPhotowars.Count() == 0)
            {
                var cntower = ds.Attractions.SingleOrDefault(o => o.Name == "CN Tower" && o.City.Name == "Toronto");
                var casaloma = ds.Attractions.SingleOrDefault(o => o.Name == "Casa Loma" && o.City.Name == "Toronto");
                var boyerwoodlot = ds.Attractions.SingleOrDefault(o => o.Name == "Boywer Woodlot" && o.City.Name == "Toronto");
                var danIannuzziPark = ds.Attractions.SingleOrDefault(o => o.Name == "Dan Iannuzzi Park" && o.City.Name == "Toronto");
                var shorehamPark = ds.Attractions.SingleOrDefault(o => o.Name == "Shoreham Park" && o.City.Name == "Toronto");
                var edgeleyPark = ds.Attractions.SingleOrDefault(o => o.Name == "Edgeley Park" && o.City.Name == "Toronto");
                var sofia = ds.Residents.SingleOrDefault(o => o.UserName == "Sofia");
                var wonho = ds.Residents.SingleOrDefault(o => o.UserName == "Wonho");
                var zhihao = ds.Residents.SingleOrDefault(o => o.UserName == "Zhihao");
                var testuser = ds.Residents.SingleOrDefault(o => o.UserName == "Test");
                if (cntower != null && casaloma != null && sofia != null && wonho != null && zhihao != null && testuser != null)
                {
                    // Photos
                    var cntowerPhoto1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7426F,
                        Lng = -79.4871F,
                        Resident = sofia,
                        PhotoFilePath = "img/cntower1.jpg"
                    });
                    var cntowerPhoto2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7336F,
                        Lng = -79.4221F,
                        Resident = wonho,
                        PhotoFilePath = "img/cntower2.jpg"
                    });
                    var casalomaPhoto = ds.Photos.Add(new Photo
                    {
                        Lat = 43.2181F,
                        Lng = -79.9895F,
                        Resident = wonho,
                        PhotoFilePath = "img/casaloma1.jpg"
                    });
                    var casalomaPhoto2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.2181F,
                        Lng = -79.9895F,
                        Resident = zhihao,
                        PhotoFilePath = "img/casaloma2.jpg"
                    });
                    var boyerwoodlotPhoto1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.77585490000001,
                        Lng = -79.50518649999999,
                        Resident = sofia,
                        PhotoFilePath = "img/boyerwoodlot1.jpg"
                    });
                    var boyerwoodlotPhoto2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.77585490000001,
                        Lng = -79.50518649999999,
                        Resident = wonho,
                        PhotoFilePath = "img/boyerwoodlot2.jpg"
                    });
                    var danIannuzziPark1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7668115,
                        Lng = -79.5065087,
                        Resident = sofia,
                        PhotoFilePath = "img/daniannuzzipark1.png"
                    });
                    var danIannuzziPark2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7668115,
                        Lng = -79.5065087,
                        Resident = wonho,
                        PhotoFilePath = "img/daniannuzzipark2.jpg"
                    });
                    var shorehamPark1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7685742,
                        Lng = -79.5178353,
                        Resident = wonho,
                        PhotoFilePath = "img/shorehampark1.jpg"
                    });
                    var shorehamPark2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7685742,
                        Lng = -79.5178353,
                        Resident = zhihao,
                        PhotoFilePath = "img/shorehampark2.jpg"
                    });
                    var edgeleyPark1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7652519,
                        Lng = -79.5185398,
                        Resident = sofia,
                        PhotoFilePath = "img/edgeleypark1.jpg"
                    });
                    var edgeleyPark2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7652519,
                        Lng = -79.5185398,
                        Resident = zhihao,
                        PhotoFilePath = "img/edgeleypark2.png"
                    });

                    ds.SaveChanges();

                    // AttractionPhotowars - expired photowars
                    var photowarExpired = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = cntower.Id,
                        StartDate = new DateTime(2018, 3, 1),
                        EndDate = new DateTime(2018, 3, 4)
                    });
                    var photowarExpired2 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = cntower.Id,
                        StartDate = new DateTime(2018, 3, 6),
                        EndDate = new DateTime(2018, 3, 9)
                    });
                    var photowar3 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = boyerwoodlot.Id,
                        StartDate = new DateTime(2018, 3, 1),
                        EndDate = new DateTime(2018, 3, 4)
                    });
                    var photowar4 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = danIannuzziPark.Id,
                        StartDate = new DateTime(2018, 3, 1),
                        EndDate = new DateTime(2018, 3, 4)
                    });
                    var photowar5 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = shorehamPark.Id,
                        StartDate = new DateTime(2018, 3, 1),
                        EndDate = new DateTime(2018, 3, 4)
                    });
                    var photowar6 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = edgeleyPark.Id,
                        StartDate = new DateTime(2018, 3, 1),
                        EndDate = new DateTime(2018, 3, 4)
                    });
                    ds.SaveChanges();

                    // uploads for the expired photowars
                    var upload5 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = cntowerPhoto1,
                        AttractionPhotoWar = photowarExpired
                    });
                    var upload6 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = cntowerPhoto2,
                        AttractionPhotoWar = photowarExpired
                    });
                    var upload7 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = boyerwoodlotPhoto1,
                        AttractionPhotoWar = photowar3//,
                        //IsWinner = 1
                    });
                    var upload8 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = boyerwoodlotPhoto2,
                        AttractionPhotoWar = photowar3
                    });
                    var upload9 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = danIannuzziPark1,
                        AttractionPhotoWar = photowar4
                    });
                    var upload10 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = danIannuzziPark2,
                        AttractionPhotoWar = photowar4//,
                        //IsWinner = 1
                    });
                    var upload11 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = shorehamPark1,
                        AttractionPhotoWar = photowar5//,
                        //IsWinner = 1
                    });
                    var upload12 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = shorehamPark2,
                        AttractionPhotoWar = photowar5
                    });
                    var upload13 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = edgeleyPark1,
                        AttractionPhotoWar = photowar6
                    });
                    var upload14 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = edgeleyPark2,
                        AttractionPhotoWar = photowar6//,
                        //IsWinner = 1
                    });
                    var upload15 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = cntowerPhoto1,
                        AttractionPhotoWar = photowarExpired2
                    });
                    var upload16 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        Photo = cntowerPhoto2,
                        AttractionPhotoWar = photowarExpired2
                    });


                    // AttractionPhotowars - new photowars
                    //var photowar1 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    //{
                    //    AttractionId = cntower.Id
                    //});
                    var photowar2 = ds.AttractionPhotowars.Add(new AttractionPhotowar
                    {
                        AttractionId = casaloma.Id
                    });

                    // AttractionPhotowarUploads
                    //var upload1 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    //{
                    //    Photo = cntowerPhoto1,
                    //    AttractionPhotoWar = photowar1
                    //});
                    //var upload2 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    //{
                    //    Photo = cntowerPhoto2,
                    //    AttractionPhotoWar = photowar1
                    //});
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

                    // Votes for the expired photowar
                    upload7.ResidentVotes.Add(testuser);
                    upload10.ResidentVotes.Add(zhihao);
                    upload11.ResidentVotes.Add(sofia);
                    upload14.ResidentVotes.Add(wonho);
                    upload6.ResidentVotes.Add(testuser);
                    upload6.ResidentVotes.Add(zhihao);
                    upload15.ResidentVotes.Add(testuser);
                    upload15.ResidentVotes.Add(zhihao);

                    //Votes - new photowars
                    //upload1.ResidentVotes.Add(testuser);
                    //upload2.ResidentVotes.Add(zhihao);
                    upload3.ResidentVotes.Add(sofia);
                    upload3.ResidentVotes.Add(testuser);

                    ds.SaveChanges();

                    count += 4;
                }
                else
                {
                    throw new Exception("Seed data problem!");
                }
            }
            
            // Photowar queues
            if (ds.Queues.Count() == 0)
            {
                var cntower = ds.Attractions.SingleOrDefault(o => o.Name == "CN Tower" && o.City.Name == "Toronto");
                var casaloma = ds.Attractions.SingleOrDefault(o => o.Name == "Casa Loma" && o.City.Name == "Toronto");
                var boyerwoodlot = ds.Attractions.SingleOrDefault(o => o.Name == "Boywer Woodlot" && o.City.Name == "Toronto");
                var danIannuzziPark = ds.Attractions.SingleOrDefault(o => o.Name == "Dan Iannuzzi Park" && o.City.Name == "Toronto");
                var shorehamPark = ds.Attractions.SingleOrDefault(o => o.Name == "Shoreham Park" && o.City.Name == "Toronto");
                var edgeleyPark = ds.Attractions.SingleOrDefault(o => o.Name == "Edgeley Park" && o.City.Name == "Toronto");
                var sofia = ds.Residents.SingleOrDefault(o => o.UserName == "Sofia");
                var wonho = ds.Residents.SingleOrDefault(o => o.UserName == "Wonho");
                var zhihao = ds.Residents.SingleOrDefault(o => o.UserName == "Zhihao");
                var testuser = ds.Residents.SingleOrDefault(o => o.UserName == "Test");
                if (cntower != null && casaloma != null && sofia != null && wonho != null && zhihao != null && testuser != null)
                {
                    // CN Tower Queue 1
                    var cntowerPhoto1 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7426F,
                        Lng = -79.4871F,
                        Resident = testuser,
                        PhotoFilePath = "img/cntower3.jpg"
                    });
                    var cntowerQueue = ds.Queues.Add(new Queue
                    {
                        Attraction = cntower,
                        Photo = cntowerPhoto1,
                        QueueDate = DateTime.Now
                    });

                    // CN Tower Queue 2
                    var cntowerPhoto2 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7426F,
                        Lng = -79.4871F,
                        Resident = wonho,
                        PhotoFilePath = "img/cntower4.jpg"
                    });
                    var cntowerQueue2 = ds.Queues.Add(new Queue
                    {
                        Attraction = cntower,
                        Photo = cntowerPhoto2,
                        QueueDate = DateTime.Now.AddDays(-3)
                    });
                    
                    // CN Tower Queue 3
                    var cntowerPhoto3 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7426F,
                        Lng = -79.4871F,
                        Resident = zhihao,
                        PhotoFilePath = "img/cntower5.jpg"
                    });
                    var cntowerQueue3 = ds.Queues.Add(new Queue
                    {
                        Attraction = cntower,
                        Photo = cntowerPhoto3,
                        QueueDate = DateTime.Now.AddDays(-6)
                    });

                    // CN Tower Queue 4
                    var cntowerPhoto4 = ds.Photos.Add(new Photo
                    {
                        Lat = 43.7426F,
                        Lng = -79.4871F,
                        Resident = sofia,
                        PhotoFilePath = "img/cntower6.jpg"
                    });
                    var cntowerQueue4 = ds.Queues.Add(new Queue
                    {
                        Attraction = cntower,
                        Photo = cntowerPhoto4,
                        QueueDate = DateTime.Now.AddDays(-9)
                    });
                    
                    ds.SaveChanges();
                    count++;
                }
                else
                {
                    throw new Exception("Seed data problem!");
                }
            }
            
            // pings
            if (ds.Pings.Count() == 0)
            {
                var cntower = ds.Attractions.SingleOrDefault(o => o.Name == "CN Tower" && o.City.Name == "Toronto");
                var albionfalls = ds.Attractions.SingleOrDefault(o => o.Name == "Albion Falls" && o.City.Name == "Hamilton");
                var boyerwoodlot = ds.Attractions.SingleOrDefault(o => o.Name == "Boywer Woodlot" && o.City.Name == "Toronto");
                var sofia = ds.Residents.SingleOrDefault(o => o.UserName == "Sofia");
                var wonho = ds.Residents.SingleOrDefault(o => o.UserName == "Wonho");
                var zhihao = ds.Residents.SingleOrDefault(o => o.UserName == "Zhihao");
                var testAccount = ds.Residents.SingleOrDefault(o => o.UserName == "Test");
                if (cntower != null && albionfalls != null && sofia != null && wonho != null && zhihao != null)
                {
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = cntower.googlePlaceId,
                        AttractionName = cntower.Name,
                        Resident = sofia
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = cntower.googlePlaceId,
                        AttractionName = cntower.Name,
                        Resident = wonho
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = albionfalls.googlePlaceId,
                        AttractionName = albionfalls.Name,
                        Resident = sofia
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = albionfalls.googlePlaceId,
                        AttractionName = albionfalls.Name,
                        Resident = zhihao
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = albionfalls.googlePlaceId,
                        AttractionName = albionfalls.Name,
                        Resident = wonho
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = cntower.googlePlaceId,
                        AttractionName = cntower.Name,
                        Resident = testAccount
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = albionfalls.googlePlaceId,
                        AttractionName = albionfalls.Name,
                        Resident = testAccount
                    });
                    ds.Pings.Add(new Ping
                    {
                        AttractionGooglePlaceId = boyerwoodlot.googlePlaceId,
                        AttractionName = boyerwoodlot.Name,
                        Resident = wonho
                    });
                    ds.SaveChanges();
                    count++;
                }
                else
                {
                    throw new Exception("Seed data problem!");
                }
            }

            if (ds.ResidentAttractionOwns.Count() == 0)
            {
                var boyerWoodlot = ds.Attractions.SingleOrDefault(o => o.Name == "Boywer Woodlot" && o.City.Name == "Toronto");
                var danIannuzziPark = ds.Attractions.SingleOrDefault(o => o.Name == "Dan Iannuzzi Park" && o.City.Name == "Toronto");
                var shorehamPark = ds.Attractions.SingleOrDefault(o => o.Name == "Shoreham Park" && o.City.Name == "Toronto");
                var edgeleyPark = ds.Attractions.SingleOrDefault(o => o.Name == "Edgeley Park" && o.City.Name == "Toronto");
                var cntower = ds.Attractions.SingleOrDefault(o => o.Name == "CN Tower" && o.City.Name == "Toronto");
                var albionfalls = ds.Attractions.SingleOrDefault(o => o.Name == "Albion Falls" && o.City.Name == "Hamilton");
                var sofia = ds.Residents.SingleOrDefault(o => o.UserName == "Sofia");
                var wonho = ds.Residents.SingleOrDefault(o => o.UserName == "Wonho");
                var zhihao = ds.Residents.SingleOrDefault(o => o.UserName == "Zhihao");

                if (boyerWoodlot != null && danIannuzziPark != null && shorehamPark != null && edgeleyPark != null && cntower != null && albionfalls != null && sofia != null && wonho != null && zhihao != null)
                {
                    ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
                    {
                        Title = "Lady of " + boyerWoodlot.Name,
                        Resident = sofia,
                        Attraction = boyerWoodlot
                    });
                    ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
                    {
                        Title = "Lord of " + danIannuzziPark.Name,
                        Resident = wonho,
                        Attraction = danIannuzziPark
                    });
                    ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
                    {
                        Title = "Lord of " + shorehamPark.Name,
                        Resident = wonho,
                        Attraction = shorehamPark
                    });
                    ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
                    {
                        Title = "Lord of " + edgeleyPark.Name,
                        Resident = zhihao,
                        Attraction = edgeleyPark
                    });
                    ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
                    {
                        Title = "Lady of " + cntower.Name,
                        Resident = sofia,
                        Attraction = cntower
                    });
                    ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
                    {
                        Title = "Lord of " + albionfalls.Name,
                        Resident = zhihao,
                        Attraction = albionfalls
                    });
                    ds.SaveChanges();
                    count++;
                }
                else
                {
                    throw new Exception("Seed data problem!");
                }
            }

            return count;
        }

        // Delete All Sample Data (Does not delete world data)
        public void DeleteSeedData()
        {
            foreach (var e in ds.Queues)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.ResidentAttractionOwns)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.Pings)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.AttractionPhotowarUploads)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.AttractionPhotowars)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.Photos)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.Residents)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();

            foreach (var e in ds.Attractions)
            {
                ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }
            ds.SaveChanges();
        }

        /// <summary>
        /// This code (loding data from Excel) is from INT422 (BTI420) class
        /// https://github.com/peteratseneca/bti420winter2017/blob/master/Week_04/AssocOneToMany/AssocOneToMany/Controllers/Manager.cs#LC235
        /// I created "WorldData.xlsx" based on data from:
        /// 
        /// Continents and Countries
        /// https://gist.github.com/kamermans/1441495
        /// 
        /// Countries, States, Cities
        /// https://github.com/hiiamrohit/Countries-States-Cities-database
        /// </summary>
        public void LoadWorldData(bool isTesting)
        {
            // File system path to the data file (in this project's App_Data folder)
            string path = HttpContext.Current.Server.MapPath(
                isTesting == true ? "~/SampleData/WorldData_Simple.xlsx" : "~/SampleData/WorldData.xlsx");

            // Get or open the workbook
            var wb = Workbook.Worksheets(path);

            // Go through all the worksheets in the workbook
            for (int i = 0; i < wb.Count(); i++)
            {
                // Get a reference to the current worksheet
                var ws = wb.ElementAt(i);

                // Worksheets can't be referenced by worksheet (tab) name
                // Therefore, we'll have to go by index                

                // Continents
                if (i == 0)
                {
                    for (int j = 1; j < ws.Rows.Count(); j++)
                    {
                        // Get a reference to the cell collection
                        // This just makes the syntax that follows easier to work with
                        var c = ws.Rows[j].Cells;

                        // Add a new continents
                        ds.Continents.Add(new Continent
                        {
                            Name = c[1].Text
                        });
                    }

                    // Save the continents
                    ds.SaveChanges();
                }

                // Countries
                if (i == 1)
                {
                    for (int j = 1; j < ws.Rows.Count(); j++)
                    {
                        var c = ws.Rows[j].Cells;

                        // Add a new countries
                        ds.Countries.Add(new Country
                        {
                            Name = c[1].Text,
                            ContinentId = (int)c[2].Amount
                        });
                    }

                    // Save the countries
                    ds.SaveChanges();
                }

                // Provinces
                if (i == 2)
                {
                    for (int j = 1; j < ws.Rows.Count(); j++)
                    {
                        var c = ws.Rows[j].Cells;

                        // Add a new provinces
                        ds.Provinces.Add(new Province
                        {
                            Name = c[1].Text,
                            CountryId = (int)c[2].Amount
                        });

                        if (j % 1000 == 0)
                        {
                            // Save every 1000 provinces
                            ds.SaveChanges();
                        }
                    }

                    // Save the provinces
                    ds.SaveChanges();
                }

                // Cities
                if (i == 3)
                {
                    int lastProvinceId = 0;
                    int curProvinceId;
                    for (uint j = 1; j < ws.Rows.Count(); j++)
                    {
                        var c = ws.Rows[j].Cells;

                        // isTesting: for testing data
                        // j > 2: always insert "Toronto" and "Hamilton" in "Ontario"
                        if (!isTesting && j > 2)
                        {
                            // Add only 1 row in each province to reduce time
                            // Be careful add all sample data for testing
                            // It could take more than 30 minutes
                            curProvinceId = (int)c[2].Amount;
                            if (curProvinceId == lastProvinceId)
                            {
                                continue;
                            }
                            lastProvinceId = curProvinceId;
                        }

                        // Add a new cities
                        ds.Cities.Add(new City
                        {
                            Name = c[1].Text,
                            ProvinceId = (int)c[2].Amount
                        });

                        if (j % 1000 == 0)
                        {
                            // Save every 1000 cities
                            ds.SaveChanges();
                        }
                    }

                    // Save the cities
                    ds.SaveChanges();
                }
            }
        }

        // Checks Photowars for new wins, updates all owns at all hiearchichal levels affected
        // Returns Photowars that have been updated
        public IEnumerable<AttractionPhotowarWithDetails> checkOwns()
        {
            // fetch the photowars that have just ended or that have been extended, and have no winners declared yet
            var newPhotowarEnds = ds.AttractionPhotowarUploads.Where(u => u.IsWinner == null).Select(u => u.AttractionPhotoWar).Include("AttractionPhotowarUploads.ResidentVotes")
                .Where(p => p.EndDate < DateTime.Now || (p.ExtendedDate != null && p.ExtendedDate < DateTime.Now) ).Distinct();

            // keep Ids to return at the end
            var newPhotowarIds = newPhotowarEnds.Select(p => p.Id).ToList();

            // declare the winner/loser for each of those photowars
            if (newPhotowarEnds != null)
            {
                foreach (var photowar in newPhotowarEnds.ToArray())
                {
                    var firstUpload = photowar.AttractionPhotowarUploads.First();
                    var secondUpload = photowar.AttractionPhotowarUploads.Last();
                    if (firstUpload == null || secondUpload == null)
                    {
                        return null;
                    }

                    if (firstUpload.ResidentVotes.Count > secondUpload.ResidentVotes.Count)
                    {
                        // first photo is winner
                        firstUpload.IsWinner = 1;
                        firstUpload.IsLoser = 0;
                        secondUpload.IsWinner = 0;
                        secondUpload.IsLoser = 1;
                        ds.SaveChanges();

                        var addOwn = CreateAttractionOwnForPhotoUpload(firstUpload.Id);
                        if (!addOwn) return null;

                        // Check if there is a queue for this attraction
                        var queue = checkPhotowarQueue(photowar.AttractionId);
                        if (queue != null)
                        {
                            createPhotowarFromQueue(queue, firstUpload);
                        }

                    } else if (secondUpload.ResidentVotes.Count > firstUpload.ResidentVotes.Count)
                    {
                        // second photo is winner
                        secondUpload.IsWinner = 1;
                        secondUpload.IsLoser = 0;
                        firstUpload.IsWinner = 0;
                        firstUpload.IsLoser = 1;
                        ds.SaveChanges();

                        var addOwn = CreateAttractionOwnForPhotoUpload(secondUpload.Id);
                        if (!addOwn) return null;

                        // Check if there is a queue for this attraction
                        var queue = checkPhotowarQueue(photowar.AttractionId);
                        if (queue != null)
                        {
                            createPhotowarFromQueue(queue, secondUpload);
                        }
                    } else
                    {
                        // equal score - keep extend vote for another 3 days, and the next vote will determine winner
                        photowar.ExtendedDate = DateTime.Now.AddDays(3);

                        ds.SaveChanges();
                    }

                }
            }

            var newPhotowars = ds.AttractionPhotowars.Where(a => newPhotowarIds.Contains(a.Id));
            return mapper.Map<IEnumerable<AttractionPhotowarWithDetails>>(newPhotowars);
        }

        /*public bool checkCurrentPhotowar(int attractionId)
        {
            var curPhotowar = ds.AttractionPhotowars
                .Where(w => w.AttractionId == attractionId && w.EndDate > DateTime.Now)
                .SingleOrDefault();

            if (curPhotowar != null)
            {
                return true;
            }

            return false;
        }*/

        public Queue checkPhotowarQueue(int attractionId)
        {
            var queue = ds.Queues.Include("Photo").Where(q => q.AttractionId == attractionId);
            if (queue == null)
            {
                return null;     
            }

            return queue.OrderBy(q => q.QueueDate).FirstOrDefault();
        }

        // Creates photowar 3 days after the last photowar ended (or today's date if 3 days after is in the past) for an attraction
        public void createPhotowarFromQueue(Queue queue, AttractionPhotowarUpload upload)
        {
            int attractionId = upload.AttractionPhotoWar.AttractionId;

            // get last attractionphotowar enddate
            DateTime endDate = upload.AttractionPhotoWar.ExtendedDate != null ? (DateTime) upload.AttractionPhotoWar.ExtendedDate : upload.AttractionPhotoWar.EndDate;

            DateTime startDate;
            if(endDate < DateTime.Now.AddDays(-3))
            {
                startDate = DateTime.Now; // can't start a photowar in the past, so start it now
            } else
            {
                startDate = endDate.AddDays(3);
            }

            // New Photowar
            var photowar = ds.AttractionPhotowars.Add(new AttractionPhotowar
            {
                AttractionId = attractionId,
                StartDate = startDate,
                EndDate = startDate.AddDays(3)
            });

            // Upload from current winning photo
            var upload1 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
            {
                Photo = upload.Photo,
                AttractionPhotoWar = photowar
            });

            // Upload from queue
            var upload2 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
            {
                Photo = queue.Photo,
                AttractionPhotoWar = photowar
            });

            // Delete queue created Photowar
            ds.Queues.Remove(queue);
            ds.SaveChanges();
        }

        public bool CreateAttractionOwnForPhotoUpload(int photoUploadId)
        {
            var upload = ds.AttractionPhotowarUploads.Include("Photo.Resident").Include("AttractionPhotoWar.Attraction.Owners").SingleOrDefault(a => a.Id == photoUploadId);
            if (upload == null) return false;

            var resident = upload.Photo.Resident;
            var attraction = upload.AttractionPhotoWar.Attraction;

            // find out if someone previously owned the attraction
            var previousOwner = attraction.Owners.SingleOrDefault(o => o.EndOfOwn == null);

            if(previousOwner == null)
            {
                // no previous owners - make first owner
                var addedOwn = addAttractionOwn(resident, attraction);
                if (addedOwn == false) return false;

                // check owns up hierarchy
                recalibrateOwnsHierarchy(attraction.Id);
            } else if (previousOwner != null && previousOwner.ResidentId != resident.Id)
            {
                // update new owner if it's a different owner
 
                // put expiry date to previous own
                previousOwner.EndOfOwn = DateTime.Now;
                ds.SaveChanges();

                var addedOwn = addAttractionOwn(resident, attraction);
                if (addedOwn == false) return false;

                // check owns up whole hierarchy
                var emperor = recalibrateOwnsHierarchy(attraction.Id);
                if (emperor == null) return false; // unable to create all the owns in the hierarchy
            }
            return true;
        }

        public bool addAttractionOwn(Resident resident, Attraction attraction)
        {
            // create title
            string title = "";
            if (resident.Gender == "M")
            {
                title += "Lord of ";
            }
            else
            {
                title += "Lady of ";
            }
            title += attraction.Name;

            var addedOwn = ds.ResidentAttractionOwns.Add(new ResidentAttractionOwn
            {
                Title = title,
                Resident = resident,
                Attraction = attraction
            });

            ds.SaveChanges();

            return addedOwn == null ? false : true;
        }

        // Re-checks highest attraction-owner at city, province, country, and continent level, and creates new owns as necessary
        // Returns Resident that is owner of the continent that the attraction belongs to
        public ResidentBase recalibrateOwnsHierarchy(int attractionId)
        {
            var attraction = ds.Attractions.Find(attractionId);


            /* City */

            // 1) find out the City of the Attraction
            var city = ds.Cities.Find(attraction.CityId);

            // 2) get all attraction in City
            var attractionsInCity = ds.Attractions.Where(a => a.CityId == city.Id).Select(a => a.Id);

            // 3) get all attraction owns in city, grouped by residentId, ordered by highest count
            var ownsInCity = ds.ResidentAttractionOwns.Where(a => attractionsInCity.Contains(a.AttractionId)).GroupBy(a => a.ResidentId)
                .Select(a => new { residentKey = a.Key, count = a.Count()}).OrderByDescending(o => o.count).ToList();

            // 4) determine the top resident(s) in the city
            List<int> topResidentsInCity = new List<int>();
            int topOwnCount = 0;
            foreach(var own in ownsInCity)
            {
                if(topOwnCount == 0) // first loop
                {
                    topOwnCount = own.count; // update count
                    topResidentsInCity.Add(own.residentKey); // add resident
                } else
                {
                    // subsequent loops
                    if(topOwnCount == own.count) // residents have same count
                    {
                        topResidentsInCity.Add(own.residentKey);
                    } else
                    {
                        // current resident count is less than last resident - stop loop
                        break;
                    }
                }  
            }

            int topResidentInCity = -1;

            if(topResidentsInCity.Count() == 1)
            {
                // only 1 top owner - becomes owner of City
                topResidentInCity = topResidentsInCity[0];
            } else if(topResidentsInCity.Count() > 1)
            {
                // some tied owns - need to determine winner by points
                topResidentInCity = getHighestOwnerByPointsInCity(topResidentsInCity, city.Id);
            }

            Resident residentCity = ds.Residents.Find(topResidentInCity);
            if (residentCity == null) return null;

            // 5) create City Own
            var addedCityOwn = generateCityOwn(residentCity, city);
            if (addedCityOwn == false) return null;


            /* Province */

            // 1) find out the province of the attraction
            var province = ds.Provinces.Find(city.ProvinceId);

            // 2) get all attractions in the province
            var attractionsInProvince = ds.Attractions.Where(a => a.City.ProvinceId == province.Id).Select(a => a.Id);

            // 3) get all attraction owns in province, grouped by Resident Id, ordered by highest count
            var ownsInProvince = ds.ResidentAttractionOwns.Where(a => attractionsInProvince.Contains(a.AttractionId)).GroupBy(a => a.ResidentId)
                .Select(a => new { residentKey = a.Key, count = a.Count() }).OrderByDescending(o => o.count).ToList();

            // 4) determine the top resident(s) in the province
            List<int> topResidentsInProvince = new List<int>();
            topOwnCount = 0; // reset
            foreach (var own in ownsInProvince)
            {
                if (topOwnCount == 0) // first loop
                {
                    topOwnCount = own.count; // update count
                    topResidentsInProvince.Add(own.residentKey); // add resident
                }
                else
                {
                    // subsequent loops
                    if (topOwnCount == own.count) // residents have same count
                    {
                        topResidentsInProvince.Add(own.residentKey);
                    }
                    else
                    {
                        // current resident count is less than last resident - stop loop
                        break;
                    }
                }
            }

            int topResidentInProvince = -1;

            if (topResidentsInProvince.Count() == 1)
            {
                // only 1 top owner - becomes owner of Province
                topResidentInProvince = topResidentsInProvince[0];
            }
            else if (topResidentsInProvince.Count() > 1)
            {
                // some tied owns - need to determine winner by points
                topResidentInProvince = getHighestOwnerByPointsInProvince(topResidentsInProvince, province.Id);
            }

            Resident residentProvince = ds.Residents.Find(topResidentInProvince);
            if (residentProvince == null) return null;

            // 5) create Province Own
            var addedProvinceOwn = generateProvinceOwn(residentProvince, province);
            if (addedProvinceOwn == false) return null;


            /* Country */

            // 1) find out the country of the attraction
            var country = ds.Countries.Find(province.CountryId);

            // 2) get all attractions in the province
            var attractionsInCountry = ds.Attractions.Where(a => a.City.Province.CountryId == country.Id).Select(a => a.Id);

            // 3) get all attraction owns in country, grouped by Resident Id, ordered by highest count
            var ownsInCountry = ds.ResidentAttractionOwns.Where(a => attractionsInCountry.Contains(a.AttractionId)).GroupBy(a => a.ResidentId)
                .Select(a => new { residentKey = a.Key, count = a.Count() }).OrderByDescending(o => o.count).ToList();

            // 4) determine the top resident(s) in the country
            List<int> topResidentsInCountry = new List<int>();
            topOwnCount = 0; // reset
            foreach (var own in ownsInCountry)
            {
                if (topOwnCount == 0) // first loop
                {
                    topOwnCount = own.count; // update count
                    topResidentsInCountry.Add(own.residentKey); // add resident
                }
                else
                {
                    // subsequent loops
                    if (topOwnCount == own.count) // residents have same count
                    {
                        topResidentsInCountry.Add(own.residentKey);
                    }
                    else
                    {
                        // current resident count is less than last resident - stop loop
                        break;
                    }
                }
            }

            int topResidentInCountry = -1;

            if (topResidentsInCountry.Count() == 1)
            {
                // only 1 top owner - becomes owner of Country
                topResidentInCountry = topResidentsInCountry[0];
            }
            else if (topResidentsInCountry.Count() > 1)
            {
                // some tied owns - need to determine winner by points
                topResidentInCountry = getHighestOwnerByPointsInCountry(topResidentsInCountry, country.Id);
            }

            Resident residentCountry = ds.Residents.Find(topResidentInCountry);
            if (residentCountry == null) return null;

            // 5) create Country Own
            var addedCountryOwn = generateCountryOwn(residentCountry, country);
            if (addedCountryOwn == false) return null;


            /* Continent */

            // 1) find out the continent of the attraction
            var continent = ds.Continents.Find(country.ContinentId);

            // 2) get all attractions in the province
            var attractionsInContinent = ds.Attractions.Where(a => a.City.Province.Country.ContinentId == continent.Id).Select(a => a.Id);

            // 3) get all attraction owns in country, grouped by Resident Id
            var ownsInContinent = ds.ResidentAttractionOwns.Where(a => attractionsInContinent.Contains(a.AttractionId)).GroupBy(a => a.ResidentId)
                .Select(a => new { residentKey = a.Key, count = a.Count() }).OrderByDescending(o => o.count).ToList();


            // 4) determine the top resident(s) in the continent
            List<int> topResidentsInContinent = new List<int>();
            topOwnCount = 0; // reset
            foreach (var own in ownsInContinent)
            {
                if (topOwnCount == 0) // first loop
                {
                    topOwnCount = own.count; // update count
                    topResidentsInContinent.Add(own.residentKey); // add resident
                }
                else
                {
                    // subsequent loops
                    if (topOwnCount == own.count) // residents have same count
                    {
                        topResidentsInContinent.Add(own.residentKey);
                    }
                    else
                    {
                        // current resident count is less than last resident - stop loop
                        break;
                    }
                }
            }

            int topResidentInContinent = -1;

            if (topResidentsInContinent.Count() == 1)
            {
                // only 1 top owner - becomes owner of Country
                topResidentInContinent = topResidentsInContinent[0];
            }
            else if (topResidentsInContinent.Count() > 1)
            {
                // some tied owns - need to determine winner by points
                topResidentInContinent = getHighestOwnerByPointsInContinent(topResidentsInContinent, continent.Id);
            }

            Resident residentContinent = ds.Residents.Find(topResidentInContinent);
            if (residentContinent == null) return null;

            // 5) create Continent Own
            var addedContinentOwn = generateContinentOwn(residentContinent, continent);
            if (addedContinentOwn == false) return null;

            return mapper.Map<ResidentBase>(residentContinent);
        }

        // Returns ID of the owner with the most points in the city
        public int getHighestOwnerByPointsInCity(List<int> residentIdList, int cityId)
        {
            // winning resident
            int winningResidentId = -1;

            // keep track of highest votes count
            int highestVotesCount = 0;

            foreach(int residentId in residentIdList)
            {
                var uploads = ds.AttractionPhotowarUploads.Include("ResidentVotes")
                    .Where(u => u.AttractionPhotoWar.Attraction.CityId == cityId && u.Photo.ResidentId == residentId);

                // calculate all the votes
                int totalVotes = 0;
                foreach(var upload in uploads)
                {
                    totalVotes += upload.ResidentVotes.Count();
                }

                if(totalVotes > highestVotesCount)
                {
                    highestVotesCount = totalVotes;
                    winningResidentId = residentId;
                } else if(totalVotes == highestVotesCount)
                {
                    // TODO: handle same vote count situations
                }
            }

            return winningResidentId;
        }
        public bool generateCityOwn(Resident resident, City city)
        {
            // find out if previous City owner is same person
            var previousOwn = ds.ResidentCityOwns.SingleOrDefault(o => o.EndOfOwn == null && o.CityId == city.Id);

            if(previousOwn == null)
            {
                // brand new own

                var addedOwn = addCityOwn(resident, city);
                if (addedOwn == false) return false;
            } else if (previousOwn != null && previousOwn.ResidentId != resident.Id)
            {
                // different owner

                // put expiry date to previous own
                previousOwn.EndOfOwn = DateTime.Now;
                ds.SaveChanges();

                var addedOwn = addCityOwn(resident, city);
                if (addedOwn == false) return false;

            } 
            return true;
        }

        public bool addCityOwn(Resident resident, City city)
        {
            // create title
            string title = "";
            if (resident.Gender == "M")
            {
                title += "Duke of ";
            }
            else
            {
                title += "Duchess of ";
            }
            title += city.Name;

            var addedOwn = ds.ResidentCityOwns.Add(new ResidentCityOwn
            {
                Title = title,
                Resident = resident,
                City = city
            });

            ds.SaveChanges();

            return addedOwn == null ? false : true;
            //return true;
        }

        // Returns ID of the owner with the most points in the province
        public int getHighestOwnerByPointsInProvince(List<int> residentIdList, int provinceId)
        {
            // winning resident
            int winningResidentId = -1;

            // keep track of highest votes count
            int highestVotesCount = 0;

            foreach (int residentId in residentIdList)
            {
                var uploads = ds.AttractionPhotowarUploads.Include("ResidentVotes")
                    .Where(u => u.AttractionPhotoWar.Attraction.City.ProvinceId == provinceId && u.Photo.ResidentId == residentId);

                // calculate all the votes
                int totalVotes = 0;
                foreach (var upload in uploads)
                {
                    totalVotes += upload.ResidentVotes.Count();
                }

                if (totalVotes > highestVotesCount)
                {
                    highestVotesCount = totalVotes;
                    winningResidentId = residentId;
                }
                else if (totalVotes == highestVotesCount)
                {
                    // TODO: handle same vote count situations
                }
            }

            return winningResidentId;
        }

        public bool generateProvinceOwn(Resident resident, Province province)
        {
            // find out if previous Province owner is same person
            var previousOwn = ds.ResidentProvinceOwns.SingleOrDefault(o => o.EndOfOwn == null && o.ProvinceId == province.Id);

            if (previousOwn == null)
            {
                // brand new own

                var addedOwn = addProvinceOwn(resident, province);
                if (addedOwn == false) return false;
            }
            else if (previousOwn != null && previousOwn.ResidentId != resident.Id)
            {
                // different owner

                // put expiry date to previous own
                previousOwn.EndOfOwn = DateTime.Now;
                ds.SaveChanges();

                var addedOwn = addProvinceOwn(resident, province);
                if (addedOwn == false) return false;

            }
            return true;
        }

        public bool addProvinceOwn(Resident resident, Province province)
        {
            // create title
            string title = "";
            if (resident.Gender == "M")
            {
                title += "Prince of ";
            }
            else
            {
                title += "Princess of ";
            }
            title += province.Name;

            var addedOwn = ds.ResidentProvinceOwns.Add(new ResidentProvinceOwn
            {
                Title = title,
                Resident = resident,
                Province = province
            });

            ds.SaveChanges();

            return addedOwn == null ? false : true;
        }

        // Returns ID of the owner with the most points in the country
        public int getHighestOwnerByPointsInCountry(List<int> residentIdList, int countryId)
        {
            // winning resident
            int winningResidentId = -1;

            // keep track of highest votes count
            int highestVotesCount = 0;

            foreach (int residentId in residentIdList)
            {
                var uploads = ds.AttractionPhotowarUploads.Include("ResidentVotes")
                    .Where(u => u.AttractionPhotoWar.Attraction.City.Province.CountryId == countryId && u.Photo.ResidentId == residentId);

                // calculate all the votes
                int totalVotes = 0;
                foreach (var upload in uploads)
                {
                    totalVotes += upload.ResidentVotes.Count();
                }

                if (totalVotes > highestVotesCount)
                {
                    highestVotesCount = totalVotes;
                    winningResidentId = residentId;
                }
                else if (totalVotes == highestVotesCount)
                {
                    // TODO: handle same vote count situations
                }
            }

            return winningResidentId;
        }

        public bool generateCountryOwn(Resident resident, Country country)
        {
            // find out if previous Country owner is same person
            var previousOwn = ds.ResidentCountryOwns.SingleOrDefault(o => o.EndOfOwn == null && o.CountryId == country.Id);

            if (previousOwn == null)
            {
                // brand new own

                var addedOwn = addCountryOwn(resident, country);
                if (addedOwn == false) return false;
            }
            else if (previousOwn != null && previousOwn.ResidentId != resident.Id)
            {
                // different owner

                // put expiry date to previous own
                previousOwn.EndOfOwn = DateTime.Now;
                ds.SaveChanges();

                var addedOwn = addCountryOwn(resident, country);
                if (addedOwn == false) return false;

            }
            return true;
        }

        public bool addCountryOwn(Resident resident, Country country)
        {
            // create title
            string title = "";
            if (resident.Gender == "M")
            {
                title += "King of ";
            }
            else
            {
                title += "Queen of ";
            }
            title += country.Name;

            var addedOwn = ds.ResidentCountryOwns.Add(new ResidentCountryOwn
            {
                Title = title,
                Resident = resident,
                Country = country
            });

            ds.SaveChanges();

            return addedOwn == null ? false : true;
        }

        // Returns ID of the owner with the most points in the continent
        public int getHighestOwnerByPointsInContinent(List<int> residentIdList, int continentId)
        {
            // winning resident
            int winningResidentId = -1;

            // keep track of highest votes count
            int highestVotesCount = 0;

            foreach (int residentId in residentIdList)
            {
                var uploads = ds.AttractionPhotowarUploads.Include("ResidentVotes")
                    .Where(u => u.AttractionPhotoWar.Attraction.City.Province.Country.ContinentId == continentId && u.Photo.ResidentId == residentId);

                // calculate all the votes
                int totalVotes = 0;
                foreach (var upload in uploads)
                {
                    totalVotes += upload.ResidentVotes.Count();
                }

                if (totalVotes > highestVotesCount)
                {
                    highestVotesCount = totalVotes;
                    winningResidentId = residentId;
                }
                else if (totalVotes == highestVotesCount)
                {
                    // TODO: handle same vote count situations
                }
            }

            return winningResidentId;
        }

        public bool generateContinentOwn(Resident resident, Continent continent)
        {
            // find out if previous Country owner is same person
            var previousOwn = ds.ResidentContinentOwns.SingleOrDefault(o => o.EndOfOwn == null && o.ContinentId == continent.Id);

            if (previousOwn == null)
            {
                // brand new own

                var addedOwn = addContinentOwn(resident, continent);
                if (addedOwn == false) return false;
            }
            else if (previousOwn != null && previousOwn.ResidentId != resident.Id)
            {
                // different owner

                // put expiry date to previous own
                previousOwn.EndOfOwn = DateTime.Now;
                ds.SaveChanges();

                var addedOwn = addContinentOwn(resident, continent);
                if (addedOwn == false) return false;

            }
            return true;
        }

        public bool addContinentOwn(Resident resident, Continent continent)
        {
            // create title
            string title = "";
            if (resident.Gender == "M")
            {
                title += "Emperor of ";
            }
            else
            {
                title += "Empress of ";
            }
            title += continent.Name;

            var addedOwn = ds.ResidentContinentOwns.Add(new ResidentContinentOwn
            {
                Title = title,
                Resident = resident,
                Continent = continent
            });

            ds.SaveChanges();

            return addedOwn == null ? false : true;
        }

        #region Attraction
        // **************************************************************
        //                          Attraction
        // **************************************************************

        public IEnumerable<AttractionBase> AttractionGetAll()
        {
            return mapper.Map<IEnumerable<Attraction>, IEnumerable<AttractionBase>>(ds.Attractions);
        }

        public IEnumerable<AttractionForMapView> AttractionGetAllForMapViewRegion(LatLngBoundaries latLng)
        {
            //TODO : Need to modify so that not all of Resident's info gets returned (email and password)
            //var o = ds.Attractions.Include(a => a.Owners.Select(w => w.Resident)).Where(a => a.Lat <= latLng.maxLat && a.Lat >= latLng.minLat && a.Lng <= latLng.maxLng && a.Lng >= latLng.minLng);
            var o = ds.Attractions.Include("Owners.Resident").Include("AttractionPhotowars").Where(a => a.Lat <= latLng.maxLat && a.Lat >= latLng.minLat && a.Lng <= latLng.maxLng && a.Lng >= latLng.minLng).ToList().Select(a => new Attraction
            {
                Id = a.Id,
                googlePlaceId = a.googlePlaceId,
                Name = a.Name,
                Lat = a.Lat,
                Lng = a.Lng,
                IsActive = a.IsActive,
                CityId = a.CityId,
                Owners = a.Owners.Where(owner => owner.EndOfOwn == null).ToList(), // filter Owner to current owner only
                AttractionPhotowars = a.AttractionPhotowars.Where(pw => pw.EndDate > DateTime.Now).ToList() // filter only current attractionphotowar
            });

            return mapper.Map<IEnumerable<Attraction>, IEnumerable<AttractionForMapView>>(o);
        }

        public AttractionBase AttractionGetById(int? id)
        {
            var a = ds.Attractions.Find(id);
            return (a == null) ? null : mapper.Map<AttractionBase>(a);
        }

        public AttractionBase AttractionGetByGooglePlaceId(string googlePlaceId)
        {
            var a = ds.Attractions.SingleOrDefault(o => o.googlePlaceId == googlePlaceId);
            return (a == null) ? null : mapper.Map<AttractionBase>(a);
        }

        public AttractionWithDetails AttractionGetByIdWithDetails(int id)
        {
            var a = ds.Attractions
                .Include("City")
                .Include("QueuedUploads")
                .Include("AttractionPhotoWars")
                .Include("Owners")
                .SingleOrDefault(o => o.Id == id);

            return (a == null) ? null : mapper.Map<AttractionWithDetails>(a);
        }

        public AttractionWithDetails AttractionGetByGooglePlaceIdWithDetails(string googlePlaceId)
        {
            var a = ds.Attractions
                .Include("City")
                .Include("QueuedUploads")
                .Include("AttractionPhotoWars.AttractionPhotowarUploads.Photo")
                .Include("Owners.Resident")
                .SingleOrDefault(o => o.googlePlaceId == googlePlaceId);

            if (a == null)
            {
                return null;
            }

            var attraction = mapper.Map<AttractionWithDetails>(a);

            // get photowars that have ended already
            var photowars = a.AttractionPhotowars.Where(p => p.EndDate < DateTime.Now).OrderByDescending(p => p.EndDate).ToArray();
            if (photowars.Length > 0)
            {
                var winningUpload = photowars[0].AttractionPhotowarUploads.SingleOrDefault(u => u.IsWinner == 1);
                if (winningUpload != null)
                {
                    var path = winningUpload.Photo.PhotoFilePath;
                    attraction.PhotoImagePath = path;
                    attraction.CurrentAttractionPhotowarUploadsCount = winningUpload.AttractionPhotoWar.AttractionPhotowarUploads.Count;
                }
            }

            var owners = a.Owners.OrderByDescending(o => o.StartOfOwn).ToArray();
            if (owners.Length > 0)
            {
                var ownerName = owners[0].Resident.UserName;
                attraction.OwnerName = ownerName;
            }

            return attraction;
        }

        public AttractionBase AttractionAdd(AttractionAddForm newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                // find out the city Id
                var city = ds.Cities.SingleOrDefault(o => o.Name == newItem.CityName && o.Province.Country.Name == newItem.CountryName);
                
                if (city == null)
                {
                    // city doesn't exist
                    return null;
                }

                AttractionAdd attractionAdd = new AttractionAdd
                {
                    googlePlaceId = newItem.googlePlaceId,
                    Name = newItem.Name,
                    Lat = newItem.Lat,
                    Lng = newItem.Lng,
                    CityId = city.Id,
                    IsActive = 1
                };

                var addedItem = mapper.Map<Attraction>(attractionAdd);

                ds.Attractions.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<AttractionBase>(addedItem);
            }
        }

        public AttractionWithDetails AttractionEditWin(AttractionWithWin item)
        {
            if (item == null)
            {
                return null;
            }
            else
            {
                var a = ds.Attractions
                    .Include("City")
                    .Include("QueuedUploads")
                    .Include("AttractionPhotoWars.AttractionPhotowarUploads.Photo")
                    .Include("Owners.Resident")
                    .SingleOrDefault(o => o.Id == item.AttractionId);

                if (a != null && a.Owners.Count == 0 && a.AttractionPhotowars.Count == 0)
                {
                    var resident = ds.Residents.Find(item.OwnerId);

                    if (resident != null)
                    {
                        // set winning photo
                        var winningPhoto = ds.Photos.Add(new Photo
                        {
                            PhotoFilePath = item.PhotoImagePath,
                            Lat = item.PhotoLat,
                            Lng = item.PhotoLng,
                            ResidentId = resident.Id
                        });

                        // photowar & photowar upload with winner
                        var photowar = ds.AttractionPhotowars.Add(new AttractionPhotowar
                        {
                            AttractionId = a.Id,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now
                        });

                        var photowarUpload = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                        {
                            IsWinner = 1,
                            PhotoId = winningPhoto.Id,
                            AttractionPhotowarId = photowar.Id
                        });
                        ds.SaveChanges();

                        // set owner
                        var owner = CreateAttractionOwnForPhotoUpload(photowarUpload.Id);

                        // pass in place id, and return details
                        var res = AttractionGetByGooglePlaceIdWithDetails(item.PlaceId);
                        
                        return res;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
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

        public IEnumerable<AttractionPhotowarWithDetails> AttractionPhotowarGetAllWithDetails()
        {
            var a = ds.AttractionPhotowars
                .Include("Attraction")
                .Include("AttractionPhotowarUploads.Photo.Resident")
                .Include("AttractionPhotowarUploads.ResidentVotes")
                .Where(ap => ap.AttractionPhotowarUploads.Count() == 2)
                .OrderByDescending(o => o.StartDate);

            return mapper.Map<IEnumerable<AttractionPhotowarWithDetails>>(a);
        }

        public AttractionPhotowarBase AttractionPhotowarGetById(int id)
        {
            var a = ds.AttractionPhotowars.Find(id);
            return (a == null) ? null : mapper.Map<AttractionPhotowarBase>(a);
        }

        public IEnumerable<AttractionPhotowarWithDetails> AttractionPhotowarGetAllForAttraction(int id)
        {
            var photowars = ds.AttractionPhotowars.Include("AttractionPhotowarUploads.ResidentVotes").Include("AttractionPhotowarUploads.Photo.Resident")
                .Where(a => a.AttractionId == id && a.AttractionPhotowarUploads.Count() == 2).OrderByDescending(a => a.StartDate);

            return mapper.Map<IEnumerable<AttractionPhotowar>, IEnumerable<AttractionPhotowarWithDetails>>(photowars);
        }

        public AttractionPhotowarWithDetails AttractionPhotowarAdd(AttractionPhotoWarAddForm newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                // create new photowar
                var war = ds.AttractionPhotowars.Add(new AttractionPhotowar
                {
                    AttractionId = newItem.AttractionId
                });

                var attraction = AttractionGetByGooglePlaceIdWithDetails(newItem.PlaceId);
                if (attraction != null)
                {
                    // get owner photo
                    var ownerPhoto = ds.Photos.SingleOrDefault(o => o.PhotoFilePath == attraction.PhotoImagePath);

                    // create new uploaded photo
                    var competitorPhoto = ds.Photos.Add(new Photo
                    {
                        PhotoFilePath = newItem.PhotoImagePath,
                        Lat = newItem.PhotoLat,
                        Lng = newItem.PhotoLng,
                        ResidentId = newItem.CompetitorId
                    });

                    // create photowar upload for owner and competitor
                    var photoUpload1 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        AttractionPhotowarId = war.Id,
                        PhotoId = ownerPhoto.Id
                    });

                    var photoUpload2 = ds.AttractionPhotowarUploads.Add(new AttractionPhotowarUpload
                    {
                        AttractionPhotowarId = war.Id,
                        PhotoId = competitorPhoto.Id
                    });

                    ds.SaveChanges();
                    return mapper.Map<AttractionPhotowarWithDetails>(war);
                }
                else
                {
                    return null;
                }
            }
        }

        // Gets AttractionPhotowarWithDetails by Id, and if residentId passed in, identifies whether Resident has voted or is part of the photowar
        public AttractionPhotowarWithDetails AttractionPhotowarGetByIdWithDetails(int id, int? residentId)
        {
            var a = ds.AttractionPhotowars.Include("Attraction").Include("AttractionPhotowarUploads.ResidentVotes").Include("AttractionPhotowarUploads.Photo.Resident").SingleOrDefault(o => o.Id == id);
            var attraction_vm = mapper.Map<AttractionPhotowarWithDetails>(a);

            if (residentId.HasValue)
            {
                var resident = ds.Residents.Find(residentId.Value);
                if(resident != null)
                {
                    var uploads = a.AttractionPhotowarUploads;
                    foreach(var upload in uploads)
                    {
                        if(upload.Photo.ResidentId == residentId.Value)
                        {
                            // photo belongs to Resident - set flag true
                            attraction_vm.residentInPhotowar = 1;
                            break; // break out of loop - Resident not allowed to vote because Resident part of photowar
                        } else
                        {
                            var votes = upload.ResidentVotes;
                            var upload_vm = attraction_vm.AttractionPhotowarUploads.Single(u => u.Id == upload.Id);
                            if (votes.Contains(resident))
                            {
                                // Resident has voted for this photo - set flag true
                                upload_vm.residentHasVoted = 1;
                                continue;
                            } else
                            {
                                // Resident hasn't voted for this photo - set flag from null to false
                                upload_vm.residentHasVoted = 0;
                            }
                        }
                    }

                    // if Resident doesn't own any photos, set flag from null to false
                    if(attraction_vm.residentInPhotowar != 1)
                    {
                        attraction_vm.residentInPhotowar = 0;
                    }
                } else
                {
                    throw new Exception("Resident with Id " + residentId.Value + " not found!");
                }
            }
            
            return attraction_vm;
        }

        // Adds a resident vote to a photo in an Attractionphotowar photoupload, and removes vote in the opponent photo if there was a vote
        // Returns updated AttractionPhotowarWithDetails with resident's voting info
        public AttractionPhotowarWithDetails AttractionPhotowarAddPhotoVote(int photowarId, int photoUploadId, int residentId)
        {
            var photowar = ds.AttractionPhotowars.Include("Attraction").Include("AttractionPhotowarUploads.ResidentVotes").Include("AttractionPhotowarUploads.Photo.Resident").SingleOrDefault(a => a.Id == photowarId);
            if (photowar == null) { return null; }

            var photoUpload = photowar.AttractionPhotowarUploads.SingleOrDefault(u => u.Id == photoUploadId);
            if (photoUpload == null) { return null; }

            var resident = ds.Residents.Find(residentId);
            if (resident == null) { return null; }

            bool voteAdded = false; 

            // add vote to photoUpload
            if (!photoUpload.ResidentVotes.Contains(resident))
            {
                photoUpload.ResidentVotes.Add(resident);

                voteAdded = true;
            }

            // get the opponent photo
            var opposingPhoto = photowar.AttractionPhotowarUploads.SingleOrDefault(u => u.Id != photoUploadId);
            if(opposingPhoto == null) { return null; }

            // if resident had a previous vote on opponent photo, remove it
            if (opposingPhoto.ResidentVotes.Contains(resident))
            {
                opposingPhoto.ResidentVotes.Remove(resident);
            }
            ds.SaveChanges();

            if (voteAdded)
            {
                // if photowar was an extended photowar, it was just waiting for one more vote to declare the winner
                if (photowar.ExtendedDate != null)
                {
                    photowar.ExtendedDate = DateTime.Now; // stop the war
                    checkOwns(); // calculate all winners
                }
            }

            // Update voting details for AttractionPhotowar
            var attraction_vm = mapper.Map<AttractionPhotowarWithDetails>(photowar);
            attraction_vm.residentInPhotowar = 0; // resident doesn't own any of these photos

            // get the voted photo
            var votedUpload = attraction_vm.AttractionPhotowarUploads.Single(u => u.Id == photoUploadId);
            votedUpload.residentHasVoted = 1; // mark resident's vote

            // get opponent photo
            var opposingUpload = attraction_vm.AttractionPhotowarUploads.Single(u => u.Id != photoUploadId);
            opposingUpload.residentHasVoted = 0; // mark resident non-vote

            return attraction_vm;
        }

        // Removes a resident vote to a photo in an Attractionphotowar
        // Returns updated AttractionPhotowarWithDetails with Resident's voting info
        public AttractionPhotowarWithDetails AttractionPhotowarRemovePhotoVote(int photowarId, int photoUploadId, int residentId)
        {
            var photowar = ds.AttractionPhotowars.Include("Attraction").Include("AttractionPhotowarUploads.ResidentVotes").Include("AttractionPhotowarUploads.Photo.Resident").SingleOrDefault(a => a.Id == photowarId);
            if(photowar == null) { return null; }

            var photoUpload = photowar.AttractionPhotowarUploads.SingleOrDefault(u => u.Id == photoUploadId);
            if(photoUpload == null) { return null; }

            var resident = ds.Residents.Find(residentId);
            if(resident == null) { return null; }

            // remove vote from photoUpload
            var removedResidentVote = photoUpload.ResidentVotes.Remove(resident);
            if (!removedResidentVote) { return null; }
            ds.SaveChanges();

            // if photowar was an extended photowar, it was just waiting for one more vote difference to declare the winner
            if (photowar.ExtendedDate != null)
            {
                photowar.ExtendedDate = DateTime.Now; // stop the war
                checkOwns(); // calculate all winners
            }

            // Update voting details for AttractionPhotowar
            var attraction_vm = mapper.Map<AttractionPhotowarWithDetails>(photowar);
            attraction_vm.residentInPhotowar = 0; // resident doesn't own any of these photos

            // get the removed-vote photo
            var unvotedUpload = attraction_vm.AttractionPhotowarUploads.Single(u => u.Id == photoUploadId);
            unvotedUpload.residentHasVoted = 0; // mark resident non-vote

            // get opponent photo
            var opposingUpload = attraction_vm.AttractionPhotowarUploads.Single(u => u.Id != photoUploadId);
            opposingUpload.residentHasVoted = 0; // mark resident non-vote

            return attraction_vm;
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

        public ResidentWithDetails ResidentWithDetailsGetById(int id)
        {
            var o = ds.Residents.Include("City.Province.Country.Continent").Include("ResidentAttractionOwns").Include("ResidentCityOwns").Include("ResidentProvinceOwns")
                .Include("ResidentCountryOwns").Include("ResidentContinentOwns").SingleOrDefault(i => i.Id == id);
            return (o == null) ? null : mapper.Map<ResidentWithDetails>(o);
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

        public ResidentWithDetails ResidentLogin(ResidentLogin info)
        {
            if (info == null)
            {
                return null;
            }
            else
            {
                var o = ds.Residents
                    .Include("City")
                    .Include("ResidentAttractionOwns")
                    .SingleOrDefault(r => r.Email == info.Email && r.Password == info.Password);

                return mapper.Map<ResidentWithDetails>(o);
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

        public CountryWithProvinces CountryGetByIdWithProvinces(int id)
        {
            var c = ds.Countries
                .Include("Provinces")
                .SingleOrDefault(country => country.Id == id);

            return mapper.Map<CountryWithProvinces>(c);
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

        public ProvinceWithCities ProvinceGetByIdWithCities(int id)
        {
            var o = ds.Provinces
                .Include("Cities")
                .SingleOrDefault(p => p.Id == id);

            return (o == null) ? null : mapper.Map<ProvinceWithCities>(o);
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

        public ContinentWithCountries ContinentGetByIdWithCountries(int id)
        {
            var o = ds.Continents
                .Include("Countries")
                .SingleOrDefault(c => c.Id == id);

            return (o == null) ? null : mapper.Map<ContinentWithCountries>(o);
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
            var a = ds.Photos.Include("Resident").Include("AttractionPhotowarUploads.AttractionPhotoWar.Attraction").Include("AttractionPhotowarUploads.ResidentVotes").Include("CountryPhotowarUploads")
                .Include("ContinentPhotowarUploads").Include("CountryPhotowarRequestedphotoUploads").Include("ContinentPhotowarRequestedphotoUploads").SingleOrDefault(o => o.Id == id);
            return (a == null) ? null : mapper.Map<PhotoWithDetails>(a);
        }

        public List<PhotoWinning> PhotosWinningGetAllForAttraction(int id)
        {
            var photowars = ds.AttractionPhotowars.Include("AttractionPhotowarUploads.Photo.Resident").Include("AttractionPhotowarUploads.ResidentVotes")
                .Where(p => p.AttractionId == id && p.EndDate < DateTime.Now).OrderByDescending(p => p.EndDate);

            List<PhotoWinning> winningPhotos = new List<PhotoWinning>();

            foreach(AttractionPhotowar photowar in photowars){
                var winningUpload = photowar.AttractionPhotowarUploads.Single(u => u.IsWinner == 1);
                var winningPhoto = winningUpload.Photo;
                winningPhotos.Add(new PhotoWinning
                {
                    Id = winningPhoto.Id,
                    PhotoFilePath = winningPhoto.PhotoFilePath,
                    Lat = winningPhoto.Lat,
                    Lng = winningPhoto.Lng,
                    ResidentId = winningPhoto.ResidentId,
                    ResidentUserName = winningPhoto.Resident.UserName,
                    ResidentAvatarImagePath = winningPhoto.Resident.AvatarImagePath,
                    Votes = winningUpload.ResidentVotes.Count(),
                    WinningDate = photowar.EndDate
                });
            }
            return winningPhotos;
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

        public IEnumerable<PingBase> PingGetAllForResident(int id)
        {
            var p = ds.Pings
                .Where(o => o.ResidentId == id).OrderByDescending(o => o.Id);

            return mapper.Map<IEnumerable<PingBase>>(p);
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

        public IEnumerable<QueueBase> QueueGetAll()
        {
            return mapper.Map<IEnumerable<QueueBase>>(ds.Queues.OrderBy(q => q.Id));
        }

        // Get all queues for an attraction
        public IEnumerable<QueueBase> QueueGetAllForAttraction(int id)
        {
            var p = ds.Queues.Where(o => o.AttractionId == id).OrderBy(o => o.Id);
            return mapper.Map<IEnumerable<QueueBase>>(p);
        }

        // Get all queues with details for an attraction
        public IEnumerable<QueueWithDetails> QueueGetAllWithDetailsForAttraction(int id)
        {
            var p = ds.Queues
                .Include("Photo.Resident")
                .Where(o => o.AttractionId == id)
                .OrderBy(o => o.QueueDate);

            return mapper.Map<IEnumerable<QueueWithDetails>>(p);
        }

        public QueueWithDetails QueueAdd(QueueAddWithPhoto newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                var newPhoto = ds.Photos.Add(new Photo
                {
                    PhotoFilePath = newItem.PhotoPhotoFilePath,
                    Lat = newItem.PhotoLat,
                    Lng = newItem.PhotoLng,
                    ResidentId = newItem.PhotoResidentId
                });

                var addedItem = mapper.Map<Queue>(newItem);
                ds.Queues.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<QueueWithDetails>(addedItem);
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

        public ResidentCityOwnForMapView ResidentOwnGetActiveForCityByCityName(string city, string province, string country)
        {
            var cityObj = ds.Cities.SingleOrDefault(c => c.Name == city && c.Province.Country.Name == country);
            if (cityObj == null) return null;

            var cityOwn = ds.ResidentCityOwns.Include("Resident").SingleOrDefault(o => o.EndOfOwn == null && o.CityId == cityObj.Id);

            return cityOwn == null ? null : mapper.Map<ResidentCityOwnForMapView>(cityOwn);
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

        public ResidentProvinceOwnForMapView ResidentOwnGetActiveForProvinceByProvinceName(string province, string country)
        {
            var provinceObj = ds.Provinces.SingleOrDefault(p => p.Name == province && p.Country.Name == country);
            if (provinceObj == null) return null;

            var provinceOwn = ds.ResidentProvinceOwns.Include("Resident").SingleOrDefault(o => o.EndOfOwn == null && o.ProvinceId == provinceObj.Id);

            return provinceOwn == null ? null : mapper.Map<ResidentProvinceOwnForMapView>(provinceOwn);
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

        public ResidentCountryOwnForMapView ResidentOwnGetActiveForCountryByCountryName(string country)
        {
            var countryObj = ds.Countries.SingleOrDefault(p => p.Name == country);
            if (countryObj == null) return null;

            var countryOwn = ds.ResidentCountryOwns.Include("Resident").SingleOrDefault(o => o.EndOfOwn == null && o.CountryId == countryObj.Id);

            return countryOwn == null ? null : mapper.Map<ResidentCountryOwnForMapView>(countryOwn);
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

        public ResidentContinentOwnForMapView ResidentOwnGetActiveForContinentByCountryName(string country)
        {
            var countryObj = ds.Countries.SingleOrDefault(p => p.Name == country);
            if (countryObj == null) return null;

            var continentOwn = ds.ResidentContinentOwns.Include("Resident").SingleOrDefault(o => o.EndOfOwn == null && o.ContinentId == countryObj.ContinentId);

            return continentOwn == null ? null : mapper.Map<ResidentContinentOwnForMapView>(continentOwn);
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