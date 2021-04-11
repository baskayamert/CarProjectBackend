using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool RentalState { get; set; }
        public int FindexPoints { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
    }
}
