using MemoryTiles.CacheServices;
using MemoryTiles.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.ViewModels
{
    public class SignInViewModel : ObservableObject
    {
        private string _selectedUser;
        private string _selectedUserImageUri;
        public List<string> Usernames
        {
            get
            {
                return UserCacheService.GetCachedUsernames();
            }
        }
        public string ImageURI
        {
            get
            {
                return _selectedUserImageUri;
            }
            set
            {
                _selectedUserImageUri = value;
                OnPropertyChanged();
            }
        }
        public string SelectedUsername
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                ImageURI = Environment.CurrentDirectory + @"\" + UserCacheService.GetAvatarImageURI(value);
            }
        }
    }
}
