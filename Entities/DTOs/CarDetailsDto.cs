using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailsDto :IDto
    {
        public int Id { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; } = null!;

        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public int FuelId { get; set; }

        public string FuelName { get; set; } = null!;

        public int GearId { get; set; }

        public string GearName { get; set; } = null!;

        public int ModelYear { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public byte[]? CarImage { get; set; }
    }
}
