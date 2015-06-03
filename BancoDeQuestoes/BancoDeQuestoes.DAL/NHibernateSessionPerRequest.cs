using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Transform;
using System.Web.SessionState;

namespace BancoDeQuestoes.DAL
{
    public class NHibernateSessionPerRequest : IHttpModule
    {
        private static readonly ISessionFactory _sessionFactory;

        static NHibernateSessionPerRequest()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        public static ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory))
                CurrentSessionContext.Bind(_sessionFactory.OpenSession());

            return _sessionFactory.GetCurrentSession();
        }

        public void Dispose() { }

        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(_sessionFactory);

            if (session == null) return;
           
            try
            { session.Transaction.Commit(); }
            catch (Exception)
            { session.Transaction.Rollback(); }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                //string connectionString = "";
                //if (ConfigurationSettings.AppSettings["TipoBanco"].ToString() == "G")
                //{
                //    connectionString = @"Data Source=GABRIEL-PC\GABRIEL;User Id=bancodequestao;database=BancoDeQuestoes;password=banco123";
                //}
                //else
                //{
                //    connectionString = @"Data Source=JULLE\SQLSERVER2014;User Id=bancodequestao;database=BancoDeQuestoes;password=banco123";
                //}

                string connectionString = @"Data Source=GABRIEL-PC\GABRIEL;User Id=bancodequestao;database=BancoDeQuestoes;password=banco123";


                //var conexao = @"Server=GABRIEL\SQLEXPRESS;User Id=Gabriel\Argonauta;Database=BancoDeQuestoes;Trusted_Connection=Yes";
                //string connectionString = ConfigurationManager.ConnectionStrings["BancoDeQuestoes"].ConnectionString;
                //string connectionString = @"server=10.85.1.22\SQLEXPRESS;User Id=volare;database=PUB-VOLAREDES;password=pini#2013"
                FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .CurrentSessionContext<WebSessionContext>();

                return configuration.BuildSessionFactory();

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}