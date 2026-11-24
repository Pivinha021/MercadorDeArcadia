
using MercadorDeArcadia;

namespace MercadorDeArcadia
{
    public class GrimorioMagico : ItemMagico
    {
        Cores Cores = new Cores();

        public string Feitico;

        public GrimorioMagico() =>  Feitico = "Desconhecido";

        public GrimorioMagico(string Nome, int Preco, RaridadeEnum Raridade, string Feitico) : base(Nome, Preco, Raridade) => SetFeitico(Feitico);
        public void SetFeitico(string feitico)
        {
            if (string.IsNullOrWhiteSpace(feitico))
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Erro!!.... O nome do feitiço não pode ser vazio.");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else
            {
                Feitico = feitico;
            }
        }
        public string GetFeitico()
        {
            return Feitico;
        }

        public override string Especialidade()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"Feitiço Imbuido Ao Grimorio: {GetFeitico()}";            
        }
    }
}