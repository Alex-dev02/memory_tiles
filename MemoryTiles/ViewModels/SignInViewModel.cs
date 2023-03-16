using CommunityToolkit.Mvvm.ComponentModel;
using MemoryTiles.CacheServices;
using System;
using System.Collections.Generic;

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
                SetProperty(ref _selectedUserImageUri, value);
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
                SetProperty(ref _selectedUser, value);
                ImageURI = Environment.CurrentDirectory + @"\" + UserCacheService.GetAvatarImageURI(value);
                ContextService.CacheUsername(value);
            }
        }
    }
}
