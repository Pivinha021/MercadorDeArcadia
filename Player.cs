using System.Security.Cryptography.X509Certificates;

namespace ComercianteDeArcadia
{
    public class Player
    {
        Cores Cores = new Cores();
        public static int Posicao = 1;
        public int Moedas;
        public List<ItemMagico> Inventario = new List<ItemMagico>();

        public Player()
        {
            SetMoedas(0);
        }
        public Player(int moedas)
        {
            SetMoedas(moedas);
        }

        public void SetMoedas(int moedas)
        {
            if (moedas < 0) Console.WriteLine("ERRO... Moedas negativas não são permitidas!!!");
            else Moedas = moedas;
        }
        public int GetMoedas()
        {
            return Moedas;
        }

        public void AddItemInventario(ItemMagico item)
        {
            if (item != null)
            {
                SetMoedas(Moedas - item.Preco);
                Inventario.Add(item);
            }
            else;
        }          
            

        public void MostrarInventario()
        {
            Posicao = 1;
            Console.WriteLine("=== Inventário do Player ===");
            foreach (ItemMagico item in Inventario)
            {
                Cores.ColorirRaridade(item.Raridade);
                Console.Write($"\n{Posicao}° Item:"); Console.Write(item);
                Cores.Colorir(CoresEnum.Padrao);

                Posicao++;
            }
        }

        public ItemMagico VenderItem(int pos)
        {
            
        
            if (pos < 0 || pos >= Inventario.Count)
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Item Não encontrado...");
                Cores.Colorir(CoresEnum.Padrao);
                return null;
            }

            ItemMagico item = Inventario[pos];
            Inventario.RemoveAt(pos);
            SetMoedas(Moedas += item.Preco);
            return item;
        } 
    }
}
