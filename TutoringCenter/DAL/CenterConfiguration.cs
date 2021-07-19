using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace TutoringCenter.DAL
{
    public class CenterConfiguration : DbConfiguration
    {
        public CenterConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }

    }
}