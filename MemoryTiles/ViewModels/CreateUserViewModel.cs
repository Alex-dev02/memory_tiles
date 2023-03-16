using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemoryTiles.CacheServices;
using System.Collections.Generic;
using System.Windows.Input;

namespace MemoryTiles.ViewModels
{
    public class CreateUserViewModel : ObservableObject
    {
        private string _username;
        private int _imageURIListIndex = 0;
        private List<string> _imageURIs = AssetsCacheService.GetImagesFullPaths();
        private string _imageURI;
        public ICommand NextImageCommand { get; }
        public ICommand PreviousImageCommand { get; }
        public ICommand SubmitUserCommand { get; }

        public CreateUserViewModel()
        {
            _imageURI = _imageURIs[0];
            NextImageCommand = new RelayCommand(NextImage);
            PreviousImageCommand = new RelayCommand(PreviousImage);
            SubmitUserCommand = new RelayCommand(SubmitUser);
        }
        public string ImageURI
        {
            get
            {
                return _imageURI;
            }
            set
            {
                SetProperty(ref _imageURI, value);
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                SetProperty(ref _username, value);
            }
        }
        private void NextImage()
        {
            if (_imageURIListIndex == (_imageURIs.Count - 1))
                _imageURIListIndex = 0;
            else
                _imageURIListIndex++;
            ImageURI = _imageURIs[_imageURIListIndex];
        }
        private void PreviousImage()
        {
            if (_imageURIListIndex == 0)
                _imageURIListIndex = _imageURIs.Count - 1;
            else
                _imageURIListIndex--;
            ImageURI = _imageURIs[_imageURIListIndex];
        }
        private void SubmitUser()
        {
            UserCacheService.CacheUser(
                new Models.User(_username, AssetsCacheService.GetRelativePathForImageFromAbsolute(ImageURI), 0, 0)
            );
        }
    }
}
