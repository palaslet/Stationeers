using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeersStuff
{
    public class GasMixture
    {
        public Oxygen Oxygen = new Oxygen(0f);

        public Nitrogen Nitrogen = new Nitrogen(0f);

        public CarbonDioxide CarbonDioxide = new CarbonDioxide(0f);

        public Volatiles Volatiles = new Volatiles(0f);

        public Pollutant Pollutant = new Pollutant(0f);

        public Water Water = new Water(0f);

        public NitrousOxide NitrousOxide = new NitrousOxide(0f);

        public float TotalMolesGassesAndLiquids
        {
            get
            {
                float num = 0f;
                num += Oxygen.Quantity;
                num += CarbonDioxide.Quantity;
                num += Nitrogen.Quantity;
                num += Volatiles.Quantity;
                num += Pollutant.Quantity;
                num += Water.Quantity;
                return num + NitrousOxide.Quantity;
            }
        }

        public float TotalDensity
        {
            get
            {
                float totalQuantity = TotalMolesGassesAndLiquids;
                float totalDensity = 0;
                totalDensity += Oxygen.Density * Oxygen.Quantity / totalQuantity;
                totalDensity += CarbonDioxide.Density * CarbonDioxide.Quantity / totalQuantity;
                totalDensity += Nitrogen.Density * Nitrogen.Quantity / totalQuantity;
                totalDensity += Volatiles.Density * Volatiles.Quantity / totalQuantity;
                totalDensity += Pollutant.Density * Pollutant.Quantity / totalQuantity;
                totalDensity += Water.Density * Water.Quantity / totalQuantity;
                totalDensity += NitrousOxide.Density * NitrousOxide.Quantity / totalQuantity;
                return totalDensity;
            }
        }
    }
}
