using GrumingAPI.Models;

namespace GrumingAPI.Service
{
    public class DBService
    {
        private DBService()
        {
            context = new DBGruming();
        }
        private static DBService? instance;
        public static DBService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBService();
                return instance;
            }
        }
        private DBGruming context;
        public DBGruming Context => context;
    }
}
