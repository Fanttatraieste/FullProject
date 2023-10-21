using MediatR;
using RetroBack.Common.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RetroBack.Application.Common
{
    public class BaseRequest<T> : IRequest<T>
    {
        [JsonIgnore]
        public CurrentUser? User { get; set; }
    }
}
