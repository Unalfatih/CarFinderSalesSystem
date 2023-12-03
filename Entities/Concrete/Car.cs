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

        public int ModelYear { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Brand Brand { get; set; } = null!;

        public virtual Color Color { get; set; } = null!;

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
    }
}