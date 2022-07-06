using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class DefaultCarImages
    {

        public static List<CarImage> GetDefaultImages(int carId)
        {
            List<CarImage> carImages = new List<CarImage> { new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = PathConstants.ImagesPath + "teslalogo.jpg" } };

            return carImages;
        }
    }
}
