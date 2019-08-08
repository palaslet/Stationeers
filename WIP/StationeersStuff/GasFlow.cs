using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeersStuff
{
    public static class GasFlow
    {
        /// <summary>
        /// Pumps One tick of gas from input atmosphere.
        /// This removes gas from inputAtmosphere, but nothing is added to outputAtmosphere. This enables internal processing before adding to output network(s).
        /// </summary>
        /// <param name="power">pump power (W/tick)</param>
        /// <param name="inputAtmosphere">Usually InputNetwork.Atmosphere</param>
        /// <param name="outputAtmosphere">Usually OutputNetwork.Atmosphere</param>
        /// <returns>GasMixture containing one tick of pumped gas from inputAtmosphere</returns>
        public static GasMixture PowerPumpOneTickFromInput(float power, Atmosphere inputAtmosphere, Atmosphere outputAtmosphere)
        {
            float head = (outputAtmosphere.PressureGasses - inputAtmosphere.PressureGasses) * 102f; // Based on PressureGasses using "Pa"
            float density = inputAtmosphere.GasMixture.TotalDensity;

            float pumpedMoles = power / (head * 9.81f * density);


            return inputAtmosphere.Remove(pumpedMoles);
        }

        /// <summary>
        /// Pumps One tick of gas from input atmosphere.
        /// This removes gas from inputAtmosphere, but nothing is added to outputAtmosphere. This enables internal processing before adding to output network(s).
        /// </summary>
        /// <param name="power">pump power (W/tick)</param>
        /// <param name="inputAtmosphere">Usually InputNetwork.Atmosphere</param>
        /// <param name="outputAtmosphere">Usually OutputNetwork.Atmosphere</param>
        /// <returns>GasMixture containing one tick of pumped gas from inputAtmosphere</returns>
        public static GasMixture VolumePumpOneTickFromInput(float quantityolume, Atmosphere inputAtmosphere, Atmosphere outputAtmosphere, out float usedPower)
        {
            float pumpedMoles = 0;


            return inputAtmosphere.Remove(pumpedMoles);
        }
    }
}
