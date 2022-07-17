using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM.models
{
    internal class OurTableOut
    {
        public long PropId { get; set; }

        public int NCanonId { get; set; }

        public DateTime DtReportDate { get; set; }

        public int NTerOtdelenie { get; set; }

        public int NTerPodrazdel { get; set; }

        public decimal VProcent { get; set; }
    }
}
