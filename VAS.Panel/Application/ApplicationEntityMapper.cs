using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;
using VAS.Panel.DataModels;
using System.Data.Entity;

namespace VAS.Panel.Application.Data
{
    public interface IDataModel
    {
        int ID { get; set; }
    }
    public abstract class ApplicationEntityMapper<TModel, TDBEntity>
        where TModel : class, IDataModel, new()
        where TDBEntity : class , new()
    {
        #region Contructors

        public ApplicationEntityMapper(ApplicationEntityContext context)
        {
            _context = context;
        }

        #endregion

        #region Private Members

        ApplicationEntityContext _context;

        DbSet<TDBEntity> _DbSet;
       

        #endregion

        #region Abstract Members

        public abstract TDBEntity ToDBEntity(TModel source);
        public abstract IQueryable<TModel> ToModel(IQueryable<TDBEntity> source);

        #endregion

        #region Public Members

        public ApplicationEntityContext Context { get { return _context; } }

        public DbSet<TDBEntity> EntitySet
        {
            get
            {
                if (_DbSet == null) _DbSet = this.Context.Set<TDBEntity>();
                return _DbSet;
            }
        }
        public virtual IQueryable<TModel> ObjectsQuery
        {
            get { return ToModel(this.EntitySet); }
        }

        public virtual TModel GetObjectByID(int ID)
        {
            return ObjectsQuery.FirstOrDefault(t => t.ID == ID);
        }

        #endregion
    }
}