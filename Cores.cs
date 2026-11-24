using MercadorDeArcadia;

namespace MercadorDeArcadia
{
    public class Cores
    {
        public void Colorir(CoresEnum Cor)
        {
            switch (Cor)
            {
                case CoresEnum.Amarelo: Console.ForegroundColor = ConsoleColor.Yellow; break;

                case CoresEnum.Ciano: Console.ForegroundColor = ConsoleColor.Cyan; break;

                case CoresEnum.Vermelho: Console.ForegroundColor = ConsoleColor.Red; break;

                case CoresEnum.Cinza: Console.ForegroundColor = ConsoleColor.Gray; break;

                case CoresEnum.Magenta: Console.ForegroundColor = ConsoleColor.Magenta; break;

                case CoresEnum.Verde: Console.ForegroundColor = ConsoleColor.Green; break;

                case CoresEnum.AzulEscuro: Console.ForegroundColor = ConsoleColor.DarkBlue; break;

                case CoresEnum.Padrao: Console.ResetColor(); break;
            }
        }
        public void ColorirRaridade(RaridadeEnum Raridade)
        {
            switch (Raridade)
            {
                case RaridadeEnum.Lendario: Console.ForegroundColor = ConsoleColor.Yellow; break;

                case RaridadeEnum.Comum: Console.ForegroundColor = ConsoleColor.Cyan; break;

                case RaridadeEnum.Epico: Console.ForegroundColor = ConsoleColor.Magenta; break;

                case RaridadeEnum.Raro: Console.ForegroundColor = ConsoleColor.DarkBlue; break;
            }
        }
    }
}

