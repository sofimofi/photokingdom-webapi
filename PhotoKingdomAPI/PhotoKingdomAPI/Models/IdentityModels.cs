using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace PhotoKingdomAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<AttractionPhotowar> AttractionPhotowars { get; set; }
        public DbSet<AttractionPhotowarUpload> AttractionPhotowarUploads { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<ContinentPhotowar> ContinentPhotowars { get; set; }
        public DbSet<ContinentPhotowarPhotorequest> ContinentPhotowarPhotorequests { get; set; }
        public DbSet<ContinentPhotowarRequestedphotoUpload> ContinentPhotowarRequestedphotoUploads { get; set; }
        public DbSet<ContinentPhotowarUpload> ContinentPhotowarUploads { get; set; }
        public DbSet<ContinentProfile> ContinentProfiles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryPhotowar> CountryPhotowars { get; set; }
        public DbSet<CountryPhotowarPhotorequest> CountryPhotowarPhotorequests { get; set; }
        public DbSet<CountryPhotowarRequestdphotoUpload> CountryPhotowarRequestdphotoUploads { get; set; }
        public DbSet<CountryPhotowarUpload> CountryPhotowarUploads { get; set; }
        public DbSet<CountryProfile> CountryProfiles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Ping> Pings { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<ResidentAttractionOwn> ResidentAttractionOwns { get; set; }
        public DbSet<ResidentCityOwn> ResidentCityOwns { get; set; }
        public DbSet<ResidentContinentOwn> ResidentContinentOwns { get; set; }
        public DbSet<ResidentCountryOwn> ResidentCountryOwns { get; set; }
        public DbSet<ResidentProvinceOwn> ResidentProvinceOwns { get; set; }
        public DbSet<VoteAttractionPhotowarUpload> VoteAttractionPhotowarUploads { get; set; }
        public DbSet<VoteContinentPhotowarUpload> VoteContinentPhotowarUploads { get; set; }
        public DbSet<VoteCountryPhotowarUpload> VoteCountryPhotowarUploads { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}