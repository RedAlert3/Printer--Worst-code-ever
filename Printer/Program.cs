using Printer.Framework.Energy;
using Printer.Framework.Machine.Printer.Printers;
using Printer.Framework.Material;

namespace Printer
{
    public class Entry
    {
        public static void Main(string[] args)
        {
            List<Energy> energies = new();
            for (int i = 0; i < 10; ++i)
                energies.Add(new Energy()
                {
                    Type = EnergyType.Electricity,
                    Value = 100
                });
            HP1130 hp1130 = new HP1130(ref energies);
            Paper paper = new()
            {
                Width = 21,
                Length = 29.7
            };
            Energy energy = new Energy()
            {
                Type = EnergyType.Electricity,
                Value = 10
            };
            hp1130.Start(energy);
            hp1130.Input(paper);
            hp1130.Proccess("Hello printer!");
            hp1130.Stop();
            Console.WriteLine(paper.Content);
        }
    }
}
