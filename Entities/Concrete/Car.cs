using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{

    public partial class Car :IEntity
    {
        public int Id { get; set; }

        public int ColorId { get; set; }

        public int BrandId { get; set; }

        public int FuelId { get; set; }

        public int GearId { get; set; }

        public int ModelYear { get; set; }

        public int Kilometer { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public virtual Brand? Brand { get; set; } = null!;

        public virtual Color? Color { get; set; } = null!;

        public virtual Fuel? Fuel { get; set; } = null!;

        public virtual Gear? Gear { get; set; } = null!;

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
    }
}