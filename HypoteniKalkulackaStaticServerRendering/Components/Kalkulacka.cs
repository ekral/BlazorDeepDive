using System.Reflection.Metadata.Ecma335;

namespace HypoteniKalkulackaStaticServerRendering.Components
{
    public class Kalkulacka
    {
        required public decimal Dluh { get; set; }
        required public decimal RocniUrokovaMira { get; set; }
        required public int PocetLet { get; set; }

        public decimal MesicniSplatka { get; private set; }

        public void SpocitejSplatku()
        {
            decimal i = RocniUrokovaMira / 12.0m / 100.0m;
            decimal v = 1.0m / (1.0m + i);
            int n = PocetLet * 12;

            decimal pow = (decimal)Math.Pow((double)v, n);

            MesicniSplatka = (i * Dluh) / (1.0m - pow);
        }
    }
}
