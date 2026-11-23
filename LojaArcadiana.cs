using System.Security.Cryptography.X509Certificates;

namespace ComercianteDeArcadia
{

    public class LojaArcadiana
    {
        Cores Cores = new Cores();
        public int Moedas;

        public List<ItemMagico> Estoque = new List<ItemMagico>();

        public void AddItem(ItemMagico item)
        {
            Estoque.Add(item);
        }

        public void MostrarCatalogo()
        {
            foreach (ItemMagico item in Estoque.OrderBy(i => i.Id))
            {
                Console.WriteLine(item);
            }
            Cores.Colorir(CoresEnum.Padrao);
        }

        public ItemMagico ComprarItem(int id, int Moedas)
        {                
            ItemMagico item = Estoque.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("Item não encontrado.");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else
            {                
                if (Moedas < item.Preco)
                {
                    Cores.Colorir(CoresEnum.Vermelho);
                    Console.WriteLine("Moedas insuficientes para comprar este item.");
                    Cores.Colorir(CoresEnum.Padrao);
                    return null;
                }
                else
                {                   
                    Cores.Colorir(CoresEnum.Ciano);
                    Console.WriteLine($"Item {item.Nome} comprado com sucesso por {item.Preco} moedas de ouro.");
                    Cores.Colorir(CoresEnum.Padrao);
                    Estoque.Remove(item);
                    return item;
                }
            }
            return null;
        }


        public int VenderItem(ItemMagico item)
        {
            Cores.Colorir(CoresEnum.Ciano);

            if (item != null)
            {
                Console.WriteLine($"Item {item.Nome} vendido com sucesso por {item.Preco} moedas de ouro.");
                SetMoedas(item.Preco);
                Estoque.Add(item);                
            }

            Cores.Colorir(CoresEnum.Padrao);
            return Moedas;
        }


        public void SetMoedas(int moedas)
        {
            if(moedas < 0) 
            {
                Cores.Colorir(CoresEnum.Vermelho);
                Console.WriteLine("ERRO... Moedas negativas não são permitidas!!!");
                Cores.Colorir(CoresEnum.Padrao);
            }
            else Moedas = moedas;
        }
        public int GetMoedas()
        {
            return Moedas;
        }

    }
}