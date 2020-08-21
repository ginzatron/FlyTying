using System;
using System.Collections.Generic;

namespace FlyTying.Entities
{
    public class AppUser : EntityBase
    {
        public string Email { get; set; }
        public string SubjectId { get; set; }

        public IEnumerable<Fly> UserFlys { get; set; }
    }
}