namespace Printer.Framework.Machine.Printer.Printers
{
    public class HP1130 : Printer
    {
        public HP1130(ref List<Energy.Energy> energies)
        {

        }

        public void Proccess(string content)
        {
            if (GetWorkingStatus())
            {
                if (CanResumeSavedEnergy(10))
                {
                    WorkingPaper.Content = content;
                }
            }
        }
    }
}
