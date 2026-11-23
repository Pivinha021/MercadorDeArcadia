using ComercianteDeArcadia;

namespace ComercianteDeArcadia
{
    public class ArmaduraMagica : ItemMagico
    {
        Cores Cores = new Cores();

        public int Defesa;

        public ArmaduraMagica() =>  Defesa = 0;
        
        public ArmaduraMagica(int Defesa, string Nome, int Preco, RaridadeEnum Raridade) : base(Nome, Preco, Raridade)
        {
            SetDefesa(Defesa);
        }
        public void SetDefesa(int defesa)
        {
            if (defesa < 0)
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Erro... A defesa da armadura não pode ser menor que zero!!!");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else Defesa = defesa;
        }
        public int GetDefesa()
        {
            return Defesa;
        }

        public override string Especialidade()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"Defesa Concedida pela Armadura: {GetDefesa()}";            
        }
    }
}