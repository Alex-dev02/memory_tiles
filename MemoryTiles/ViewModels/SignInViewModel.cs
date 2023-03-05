using MemoryTiles.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.ViewModels
{
    public class SignInViewModel
    {
        public List<string> Usernames
        {
            get
            {
                return UserCacheService.GetCachedUsernames();
            }
        }
    }
}
