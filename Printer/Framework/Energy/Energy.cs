namespace Printer.Framework.Energy
{
    public class Energy
    {
        public bool IsUsed { get; set; }

        public double Value { get; set; }

        public void Resume(ref double pool)
        {
            if (!IsUsed)
            {
                IsUsed = true;
                pool += Value;
            }
        }

        public EnergyType Type { get; set; }
    }

    public enum EnergyType
    {
        LightEnergy = 0,
        Electricity = 1,
        Christmas = 2,
        Machine = 3
    }
}
