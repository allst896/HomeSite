using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeSite.Models
{
    public interface IHomeSiteDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remote<T>(T entity) where T : class;
        void SaveChanges();
    }

    public class HomeSiteDb : DbContext, IHomeSiteDb
    {
        public HomeSiteDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<Cow> Cows { get; set; }
        public DbSet<Bull> Bulls { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        IQueryable<T> IHomeSiteDb.Query<T>()
        {
            return Set<T>();
        }

        void IHomeSiteDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IHomeSiteDb.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IHomeSiteDb.Remote<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IHomeSiteDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}