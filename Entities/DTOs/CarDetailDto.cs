using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {

        public int CarId { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public decimal DailyPrice { get; set; }

        public List<string> ImagePaths { get; set; }

    }
}
