using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Core.Objects;
using VAS.Panel.DataModels;
using System.Data.Common;

namespace VAS.Panel.Application.Data
{
    public class ApplicationEntityContext : VASEntities
    {
        DbTransaction _transaction;
        internal void BeginTransaction(IsolationLevel IsolationLevel = IsolationLevel.ReadUncommitted)
        {
            if (this.Database.Connection.State != ConnectionState.Open)
                this.Database.Connection.Open();

            if (this == null)
                _transaction = this.Database.Connection.BeginTransaction(IsolationLevel);
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    using (_transaction)
                    {
                        _transaction.Commit();
                    }
                }
                finally
                {
                    _transaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    using (_transaction)
                    {
                        _transaction.Rollback();
                    }
                }
                finally
                {
                    _transaction = null;
                }
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    public class ApplicationEntityContextFactory
    {
        static ApplicationEntityContext Create()
        {
            return new ApplicationEntityContext();
        }
        public static ApplicationEntityContext Current { get { return Create(); } }
    }

}