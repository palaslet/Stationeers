using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeersStuff
{
    public class Atmosphere
    {
        public GasMixture GasMixture = new GasMixture();

        public float PressureGassesAndLiquidsInPa;

        public float Volume { get; internal set; }

        public float TotalMoles { get { return GasMixture.TotalMolesGassesAndLiquids; } }
        public GasMixture Remove(float transferMoles)
        {
            return null;
        }

        public void Add(GasMixture gasMixture)
        {
        }
    }
}
