using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPS.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ISession GetSession();
        IStatelessSession GetStatelessSession();
        void OpenStatelessSession();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Flush();
        void Clear();
        void Rollback();
        bool HasOpenTransaction();
        void CloseSession();
        T Repository<T>() where T : class;
    }
}
