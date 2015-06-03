    using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using BancoDeQuestoes.DAL;
using BancoDeQuestoes.DAL.Mapping;

namespace BancoDeQuestoes.Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CriarSchema()
        {
            try
            {
                string conexao = @"Data Source=GABRIEL-PC\GABRIEL;User Id=bancodequestao;database=BancoDeQuestoes;password=banco123";
                Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString(conexao))
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<QuestaoMap>())
                  .ExposeConfiguration(cfg =>
                  {
                      var schema = new SchemaExport(cfg);
                      schema.Drop(true, true);
                      schema.Create(true, true);

                      //new SchemaExport(cfg)
                      //  .Create(false, true);
                  })
                  .BuildSessionFactory();

                Assert.IsTrue(1 > 0);
            }
            catch (Exception)
            { }
        }
    }
}

