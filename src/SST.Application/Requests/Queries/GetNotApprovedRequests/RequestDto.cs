using System;
using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Requests.Queries.GetNotApprovedRequests
{
    public class RequestDto : IMapFrom<Request>
    {
        public int Id { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserRef { get; set; }
    }
}
