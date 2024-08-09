using Avalonia.Media.Imaging;
using Avalonia.Skia.Helpers;
using AvaloniaStudying01.Helper;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaStudying01.ViewModels
{
    public class ImagePageViewModel : ObservableObject
    {
        public string ImageSourceString
            => "/Assets/Images/snow.jpg";

        public Bitmap ImageSourceBitmapLocal
            => ImageHelper.LoadFromResource("/Assets/Images/tiny_house.jpg");

        public Task<Bitmap?> ImageSourceBitmapWeb
            => ImageHelper.LoadFromWeb("https://images.unsplash.com/photo-1607956853617-d9d248a8f327?q=80&w=600&auto=format&fit=crop");
    }
}
