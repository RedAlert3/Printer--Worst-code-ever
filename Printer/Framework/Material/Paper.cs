namespace Printer.Framework.Material
{
    public class Paper
    {
        public double Width { get; set; }

        public double Length { get; set; }

        public string? Content { get; set; }

        public ConsoleColor Background { get; set; }

        public ConsoleColor Foreground { get; set; }
    }
}
