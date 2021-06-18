using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace az204_redis
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            string connectionString = "az204redis01.redis.cache.windows.net:6380,password=WRolrL5uiM3Red7Np29nsr6A6P4LdnzfYnosFf098WE=,ssl=True,abortConnect=False";
            using(var cache = ConnectionMultiplexer.Connect(connectionString))
            {
                IDatabase db = cache.GetDatabase();
                bool setValue = await db.StringSetAsync("test:key", "100");
                Console.WriteLine($"SET:{setValue}");

                string getValue = await db.StringGetAsync("test:key");
                Console.WriteLine($"GET: {getValue}");
            }
        }
    }
}
