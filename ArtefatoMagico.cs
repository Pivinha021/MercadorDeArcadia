

using MercadorDeArcadia;

namespace MercadorDeArcadia
{
    public class ArtefatoMagico : ItemMagico
    {
        Cores Cores = new Cores();

        public string PoderEspecial;

        public ArtefatoMagico() => PoderEspecial = "Desconhecido";

        public ArtefatoMagico(string Nome, int Preco, RaridadeEnum Raridade, string PoderEspecial) : base(Nome, Preco, Raridade) => SetPoderEspecial(PoderEspecial);

        public void SetPoderEspecial(string poderEspecial)
        {
            if (string.IsNullOrWhiteSpace(poderEspecial))
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Erro!!.... O nome do poder especial não pode ser vazio.");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else
            {
                PoderEspecial = poderEspecial;
            }
        }
        public string GetPoderEspecial()
        {
            return PoderEspecial;
        }

        public override string Especialidade()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"Poder Especial Do Artefato: {GetPoderEspecial()}";
        }
    }
}