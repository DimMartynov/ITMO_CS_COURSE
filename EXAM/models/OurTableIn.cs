using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM.models
{
    internal class OurTableIn
    {
        public int NCanonId { get; set; }

        public DateTime DtReportDate { get; set; }

        public int NTerOtdelenie { get; set; }

        public int NTerPodrazdel { get; set; }

        public string[] VProcent { get; set; }
    }
}
