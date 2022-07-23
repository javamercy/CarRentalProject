using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageCountLimitExceeded(carImage.CarId));

            if (result != null)
            {

                return result;
            }


            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesRoot);
            SetImageDateToNow(carImage);

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            string imagePath = _carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
            _fileHelper.Delete(imagePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfAnyCarImageExists(id));

            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(DefaultCarImages.GetDefaultImages(id));

            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));

        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(
                file, PathConstants.ImagesRoot
                + carImage.ImagePath, PathConstants.ImagesRoot);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private void SetImageDateToNow(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
        }


        private IResult CheckIfAnyCarImageExists(int carId)
        {

            var result = _carImageDal.GetAll(c => c.CarId == carId);

            if (result.Count == 0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageCountLimitExceeded(int carId)
        {

            var result = _carImageDal.GetAll(c => c.CarId == carId);

            if (result.Count < 5)
            {

                return new SuccessResult();
            }

            return new ErrorResult(Messages.CarImageCountLimitExceeded);
        }

    }
}
