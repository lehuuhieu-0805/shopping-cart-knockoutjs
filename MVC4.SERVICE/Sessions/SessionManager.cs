using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4.SERVICE.Sessions
{
    public static class SessionManager
    {
        private static readonly ISessionFactory SessionFactory;

        static SessionManager()
        {
            var configuration = new Configuration();
            configuration.Configure(System.Web.HttpContext.Current.Server.MapPath("~/Configs/DB/tutorial.ptud.cbbank.vn.xml"));
            SessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession Session
        {
            get { return SessionFactory.OpenSession(); }
        }

        public static void DoWork(Action<ISession> work)
        {
            using (var session = Session)
            {
                using (var trans = session.BeginTransaction())
                {
                    work.Invoke(session);
                    trans.Commit();
                }
            }
        }

        public static void DoWork(Action<ISession, ITransaction> work)
        {
            using (var session = Session)
            {
                using (var trans = session.BeginTransaction())
                {
                    work.Invoke(session, trans);
                }
            }
        }
    }
}
