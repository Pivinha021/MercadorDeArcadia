using MercadorDeArcadia;
using System.ComponentModel.Design;
using System.Data;

namespace MercadorDeArcadia
{

    public class Program
    {
        public static int VenderOuNao;
        public static int Comprar;
        public static int Menu;
        public static void Main(string[] args)
        {            
            LojaArcadiana LojaArcadiana = new LojaArcadiana();
            Player player = new Player(500);
            Cores Cores = new Cores();
            ItemMagico Adaga = new ArmaMagica(15, "Adaga", 20, RaridadeEnum.Epico);    
            ItemMagico ArmaduraDeFerro = new ArmaduraMagica(30, "Armadura de Ferro", 80, RaridadeEnum.Raro); 
            ItemMagico PocaoCuraBasica = new PocaoMagica("Regeneração Basica", "Poção de Cura", 35, RaridadeEnum.Comum); 
            ItemMagico GrimorioArcano = new GrimorioMagico("Grimório do Arcano", 200, RaridadeEnum.Lendario, "Aumenta o poder mágico");
            ItemMagico TochaBasica = new ArtefatoMagico("Tocha Básica", 10, RaridadeEnum.Comum, "Ilumina áreas escuras");
            ItemMagico EspadaFlamejante = new ArmaMagica(40, "Espada Flamejante", 120, RaridadeEnum.Epico);
            ItemMagico ArmaduraDeHercules = new ArmaduraMagica(150, "Armadura de Hércules", 300, RaridadeEnum.Lendario);
            ItemMagico PocaoDeFuria = new PocaoMagica("Aumento de Força/Adrenalina/Resistencia por 5 minutos", "Fúria do Berserker", 50, RaridadeEnum.Raro);
            ItemMagico GrimorioClerical = new GrimorioMagico("Grimório Clerical", 150, RaridadeEnum.Epico, "Ivoca um circulo de Regeneração Intermediaria");
            ItemMagico AmuletoDoMauOlhado = new ArtefatoMagico("Amuleto do Mau Olhado", 450, RaridadeEnum.Lendario, "Deixa quem estiver no seu campo de visao enfraquecido");
            ItemMagico Excalibur = new ArmaMagica(400, "Excalibur", 500, RaridadeEnum.Lendario);            

            LojaArcadiana.AddItem(Adaga);
            LojaArcadiana.AddItem(ArmaduraDeFerro);
            LojaArcadiana.AddItem(PocaoCuraBasica);
            LojaArcadiana.AddItem(GrimorioArcano);
            LojaArcadiana.AddItem(TochaBasica);
            LojaArcadiana.AddItem(EspadaFlamejante);
            LojaArcadiana.AddItem(ArmaduraDeHercules);
            LojaArcadiana.AddItem(PocaoDeFuria);
            LojaArcadiana.AddItem(GrimorioClerical);
            LojaArcadiana.AddItem(AmuletoDoMauOlhado);
            LojaArcadiana.AddItem(Excalibur);

            while (true)
            {
                Console.Clear();                

                Console.WriteLine("+--------------------------------------------------------------------+");
                Console.WriteLine("| | WELCOME |            SHOP OF THE ARCADIA             | WELCOME | |");
                Console.WriteLine("+--------------------------------------------------------------------+");
                Console.WriteLine("|   (1) = Catálogo | (2) = Vender | (3) = Inventario | (0) = Sair    |");
                Console.WriteLine("+--------------------------------------------------------------------+");
                string Escolha = Console.ReadLine();

                if (!int.TryParse(Escolha, out Menu))
                {
                    Cores.Colorir(CoresEnum.Vermelho);
                    Console.WriteLine("Erro!!...Escolha invalida Tente Novamente...\n");
                    Cores.Colorir(CoresEnum.Padrao);

                    Console.WriteLine("\nPrecione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }
                else Menu = int.Parse(Escolha);

                Console.Clear();
                switch (Menu)
                {

                    case 1:
                        
                        // Ver catálogo da loja

                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

                        Console.WriteLine("===========|Catalogo de Itens Mágicos:|========================================================");
                        LojaArcadiana.MostrarCatalogo();
                        Console.WriteLine("===============================================================================================");
                       Console.WriteLine($" Moedas de ouro: {player.GetMoedas()} |Digite 0 para Sair|");
                        Console.WriteLine("+--------------------------------------------------------+");
                        Console.WriteLine("|       Escolha o item que deseja digitando o ID         |");
                        Console.WriteLine("+--------------------------------------------------------+");                        
                        
                        Console.WriteLine("Digite:"); int.TryParse(Console.ReadLine(), out Comprar);                        
                      
                        switch (Comprar)
                        {
                            case 0:
                                Cores.Colorir(CoresEnum.Ciano);
                                Console.WriteLine("Compra cancelada.");
                                Cores.Colorir(CoresEnum.Padrao);
                                break;
                            default:
                                ItemMagico itemComprado = LojaArcadiana.ComprarItem(Comprar, player.Moedas);

                                if (itemComprado != null)
                                {
                                    player.AddItemInventario(itemComprado);
                                }
                                break;
                        }                       


                        break;
                    case 2:
                        
                        // Vender item mágico

                        Console.WriteLine("===========|Venda de Itens Mágicos:|========================================================");
                        player.MostrarInventario();
                        Console.WriteLine("============================================================================================");
                    Console.WriteLine("\n\n+---------------------------------------+");
                        Console.WriteLine("|Digite a posição do item ou 0 para sair|");
                        Console.WriteLine("+---------------------------------------+");
                        Console.WriteLine("Escolha um item para vender:");
                        int.TryParse(Console.ReadLine(), out VenderOuNao);
                        VenderOuNao -= 1;
                        switch (VenderOuNao)
                        {
                            case -1:
                                Cores.Colorir(CoresEnum.Ciano);
                                Console.WriteLine("Venda cancelada.");
                                Cores.Colorir(CoresEnum.Padrao);
                                break;

                            default: LojaArcadiana.VenderItem(player.VenderItem(VenderOuNao));  break;

                        }
                        break;
                    case 3:
                        
                        // Ver inventário do player

                        player.MostrarInventario();

                        break;
                    case 0:

                        // Sair da loja (Fecha o programa)

                        Cores.Colorir(CoresEnum.Ciano);
                        Console.WriteLine("Obrigado por visitar a Loja de Arcadia!! VOLTE SEMPRE!!!!");
                        Cores.Colorir(CoresEnum.Padrao);
                        return;

                    default: 

                        // Mostra tela de erro

                        Cores.Colorir(CoresEnum.Vermelho);
                        Console.WriteLine("Erro!!...Escolha invalida Tente Novamente...\n");
                        Console.WriteLine("VOCE DEVE ESCOLHER ENTRE AS 4 OPÇÕES NO MENU!!!");
                        Cores.Colorir(CoresEnum.Padrao);

                        break;                    
                }
                Console.WriteLine("\nPrecione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}