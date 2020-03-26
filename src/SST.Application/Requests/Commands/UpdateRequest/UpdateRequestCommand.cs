using MediatR;
using System;

namespace SST.Application.Requests.Commands.UpdateRequest
{
    class UpdateRequestCommand : IRequest
    {
        public int Id { get; set; }

        public bool? IsApproved { get; set; }

        public DateTime? CreationDate { get; set; }

        public string UserRef { get; set; }
    }
}
