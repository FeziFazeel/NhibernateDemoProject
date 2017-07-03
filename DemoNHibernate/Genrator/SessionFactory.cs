using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Cfg;
using NHibernate.Context;
using MySql;
using NHibernate;

namespace DemoNHibernate
{
    static public class SessionFactory
    {
        // make sure this should be gerneated only once.
        static public ISessionFactory _SF = null;

        static public ISessionFactory GetSF()
        {
            try
            {
                if (_SF == null)
                {

                    var nhCnfig = new NHibernate.Cfg.Configuration();

                    nhCnfig.DataBaseIntegration(delegate (NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties abc)
                    {
                       
                        abc.ConnectionString = "Database=test_db;Data Source=localhost;Port=3306;User Id=root;Password=1234";
                        abc.Dialect<NHibernate.Dialect.MySQL55Dialect>();
                        abc.Driver<NHibernate.Driver.MySqlDataDriver>();
                        abc.Timeout = 60;
                    }
                        );
                    //one of your model in our case we just have one model
                    nhCnfig.AddAssembly(typeof(TestTable).Assembly);
                    nhCnfig.CurrentSessionContext<WebSessionContext>();
                    _SF = nhCnfig.BuildSessionFactory();
                }

            }

            catch (Exception ex)
            { }


            return _SF;


        }
    }
}
