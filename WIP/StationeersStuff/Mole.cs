using System;

namespace StationeersStuff
{
    [Serializable]
    public abstract class Mole
    {
        public float Quantity;

        public float Temperature;

        public float Density;

        public Mole(float quantity)
        {
            Quantity = quantity;
        }
    }
}