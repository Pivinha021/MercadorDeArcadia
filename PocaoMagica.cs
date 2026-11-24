using MercadorDeArcadia;

namespace MercadorDeArcadia
{
    public class PocaoMagica : ItemMagico
    {
        Cores Cores = new Cores();

        public string Efeito;

        public PocaoMagica() =>  Efeito = "Descohecido";
        
        public PocaoMagica(string Efeito, string Nome, int Preco, RaridadeEnum Raridade) : base(Nome, Preco, Raridade)
        {
            SetEfeito(Efeito);            
        }

        public void SetEfeito(string efeito)
        {
            if (string.IsNullOrWhiteSpace(efeito))
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Erro... O efeito da poção não pode ser vazio!!!");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else Efeito = efeito;
        }
        public string GetEfeito()
        {
            return Efeito;
        }

        public override string Especialidade()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"Efeito Causado pela poção: {GetEfeito()}\n";            
        }
    }
}
