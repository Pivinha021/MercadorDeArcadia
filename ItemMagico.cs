namespace MercadorDeArcadia
{

    public class ItemMagico
    {
        Cores Cores = new Cores();

        public int Id = 0;
        public static int ProximoId = 1;

        public string Nome;
        public int Preco;
        public RaridadeEnum Raridade;

        public ItemMagico()
        {
            Nome = "Desconhecido";
            Preco = 0;
            Raridade = RaridadeEnum.Comum;
            Id = ProximoId++;
        }

        public ItemMagico(string nome, int preco, RaridadeEnum Raridade)
        {
            SetNome(nome);
            SetPreco(preco);
            SetRaridade(Raridade);
            SetId(ProximoId++);
        }
        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Erro... O nome do item mágico não pode ser vazio!!!");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else Nome = nome;
        }
        public string GetNome()
        {
            return Nome;
        }
        public void SetPreco(int preco)
        {
            if (preco <= 0)
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Erro!!.... O preço deve ser maior que zero.");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else
            {
                Preco = preco;
            }

            switch (Raridade)
            {
                case RaridadeEnum.Comum:         Preco *= 1;                  break;
                case RaridadeEnum.Raro:          Preco *= 2;                  break;
                case RaridadeEnum.Epico:         Preco *= 3;                  break;
                case RaridadeEnum.Lendario:      Preco *= 4;                  break;
                default: 
                    Cores.Colorir(CoresEnum.Vermelho);    
                    Console.WriteLine("Erro...Raridade Invalida!!!");
                    Cores.Colorir(CoresEnum.Padrao);
                    break;
            }
        }
        public int GetPreco()
        {
            return Preco;
        }
        public void SetRaridade(RaridadeEnum raridade)
        {
            Raridade = raridade;
        }
        public RaridadeEnum GetRaridade()
        {
            return Raridade;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetProximoId(int proximoId)
        {
            ProximoId = proximoId;
        }
        public int GetProximoId()
        {
            return ProximoId;
        }

        public virtual string Especialidade()
        {
            return "";
        }

        public string ItemCatalogado()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"[{GetId()}] {GetNome()} - {GetRaridade()}";
        }

        public override string ToString()
        {
            Cores.ColorirRaridade(GetRaridade());
            return $"====================================================================================\n" +
                   $"     ITEM MAGICO                       \n" +
                   $"  Nome: {GetNome()}                    \n" +
                   $"  Preço: {GetPreco()} moedas de ouro   \n" +
                   $"  Raridade: {GetRaridade()}            \n" +
                   $"  ID: {GetId()}                        \n" +
                   $"  {Especialidade()}                    \n" +
                   $"====================================================================================";                   
        }
    }
}