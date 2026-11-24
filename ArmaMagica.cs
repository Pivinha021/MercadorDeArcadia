using MercadorDeArcadia;

namespace MercadorDeArcadia
{
    public class ArmaMagica : ItemMagico
    {
        Cores Cores = new Cores();

        public int Dano;

        public ArmaMagica() =>  Dano = 0;
        
        public ArmaMagica(int Dano, string Nome, int Preco, RaridadeEnum Raridade) : base(Nome, Preco, Raridade)
        {
            SetDano(Dano);            
        }

        public void SetDano(int dano)
        {
            if (dano < 0)
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("ERRO... Dano negativo não é permitido!!!");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else Dano = dano;
        }
        public int GetDano()
        {
            return Dano;
        }

        public override string Especialidade()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"Dano causado por {GetNome()}: {GetDano()}";            
        }
    }
}