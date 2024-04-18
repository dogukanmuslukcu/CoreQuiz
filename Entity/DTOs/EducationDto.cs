using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class EducationDto:IDto
    {
            public int EducationId { get; set; }
            public string ContentName { get; set; }
            public string EducationName { get; set; }
            public string EducationDescription { get; set; }
            public string VideoUrl { get; set; }
            public string ContentImageUrl { get; set; }

    }
}
