using System;
using System.Collections.Generic;

namespace FlyTying.Entities
{
    public class AppUser : BaseEntity
    {
        public string Email { get; set; }
        public string SubjectId { get; set; }

        public IEnumerable<Fly> UserFlys { get; set; }
    }
}