using System;

namespace SST.Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public bool? IsApproved { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserRef { get; set; }

        public User User { get; set; }
    }
}
