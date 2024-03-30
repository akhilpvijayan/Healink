using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class AddPostDto
    {
        public string Content { get; set; }
        public IFormFile? ContentImage { get; set; } = null;

        public long UserId { get; set; }
    }
}
