using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.API
{
    public class Result
    {
        public List<Entity.ClinicRoom> ClinicRoom { get; set; }

        public List<Entity.Doctor> Doctor { get; set; }
    }
}
