using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
    }
}
