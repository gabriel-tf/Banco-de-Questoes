using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL
{
    public class BaseClassDAL<T>
    {
        public ISession Session
        {
            get
            {
                try
                {
                    return NHibernateSessionPerRequest.GetCurrentSession();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public T Get(int id)
        { return Session.Get<T>(id); }

        public List<T> List()
        {
            try
            {
                return Session.CreateCriteria(typeof(T))
                    .SetResultTransformer(new DistinctRootEntityResultTransformer())
                    .List<T>().ToList();
            }
            catch (Exception)
            {
                return null; // tratar
            }
        }

        public T Save(T instance)
        {
            Session.Save(instance);
            Session.Flush();

            return instance;
        }

        public T SaveOrUpdate(T instance)
        {
            Session.SaveOrUpdate(instance);
            Session.Flush();

            return instance;
        }

        public void Delete(T instance)
        {
            Session.Delete(instance);
            Session.Flush();
        }
    }
}
