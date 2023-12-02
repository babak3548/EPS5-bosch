using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS
{
   public class ResultTest
   {//
        public string TestName { get; set; }
        public string StrResul { get; set; }
        public string Pressure { get; set; }
        public string InjectedFuelQuantityActualValue { get; set; }
        public string ReturnQuantityActualValue { get; set; }
        public string InjectedFuelQuantitySetValue { get; set; }
        public string ReturnQuantitySetValue { get; set; }
        public string MeasurementTime { get; set; }
        public string ActuationTime { get; set; }

        public bool boolResulRj { get; set; }
        public bool boolResulij { get; set; }
    }
}
