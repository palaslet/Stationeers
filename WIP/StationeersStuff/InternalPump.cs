using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeersStuff
{
    public class InternalPump
    {
        /// <summary>
        /// A measure of the pumps efficiency. Since the game simulates heat radiation, it should make sense to use the rest of the energy for pumping purposes.
        /// This makes the default efficiency = 1-Device.EnergyToHeatRatio
        /// </summary>
        public float Efficiency = 1 - Device.EnergyToHeatRatio;

        /// <summary>
        /// The power(W) consumed by the internal logic of the pump. This will ensure the pump will use some power even though the input pressure is higher that output pressure, and the pump doesn't really need to spend energy doing the actual pumping.
        /// </summary>
        public float IdlePower;

        /// <summary>
        /// The maximum amount of power (W) that this pump can use for one tick of pumping action. The volume pumped per tick will be adjusted accordingly.
        /// </summary>
        public float MaximumPower;

        public PipeNetwork InputNetwork;
        public PipeNetwork OutputNetwork;

        public GasMixture PumpIn(float volume, out float requiredPower)
        {
            Atmosphere inputAtmosphere = InputNetwork.Atmosphere;
            Atmosphere outputAtmosphere = OutputNetwork.Atmosphere;

            float deltaP = outputAtmosphere.PressureGassesAndLiquidsInPa - inputAtmosphere.PressureGassesAndLiquidsInPa;

            volume /= 1000; // convert from Liters to m3
            requiredPower = deltaP * volume / Efficiency; // https://en.wikipedia.org/wiki/Pump#Pumping_power
            requiredPower = Math.Max(0, requiredPower) + IdlePower; // disallow negative power consumption and adding IdlePower.
            if (requiredPower > MaximumPower)
            {
                // Maximum power usage limit reached, so we're clamping the power and adjusting the volume accordingly
                requiredPower = MaximumPower;
                float adjustedPumpingPower = requiredPower - IdlePower;
                volume = adjustedPumpingPower * Efficiency / deltaP;
            }

            volume *= 1000; // Convert from m3 to Liters
            float molesToPump = inputAtmosphere.TotalMoles * volume / inputAtmosphere.Volume;
            return inputAtmosphere.Remove(molesToPump);
        }

        public void PumpOut(GasMixture gasMixture)
        {
            OutputNetwork.Atmosphere.Add(gasMixture);
        }

        public void PumpThrough(float volume, out float requiredPower)
        {
            GasMixture gasMixture = PumpIn(volume, out requiredPower);
            PumpOut(gasMixture);
        }
    }
}
