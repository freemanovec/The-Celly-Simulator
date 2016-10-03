using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using The_Celly_Simulator;

namespace The_Celly_Simulator
{
    public class Program
    {

        public static List<Cell> cellList = new List<Cell>();

        static void Main(string[] args)
        {
            ProgramStart();
        }
        static void ProgramStart()
        {
            Cell ferda = new Cell(2500d, 2500d, true);
            while (true)
            {
                ferda.Tick();
                Console.ReadKey();
            }
        }
        public static void ShowStatsOfCell(Cell cellToShow)
        {
            Console.WriteLine("--------START-OF-DEBUG-MESSAGE--------");
            Console.Write("   DNA:    ");
            Console.WriteLine(cellToShow.dna);
            Console.Write("   ENERGY: ");
            Console.WriteLine(Math.Round((decimal)cellToShow.energy,2));
            Console.Write("   FOOD:   ");
            Console.WriteLine(Math.Round((decimal)cellToShow.food,2));
            Console.WriteLine("--------END-OF-DEBUG-MESSAGE----------");
        }
        public static void RemoveCellFromList(Cell cellToRemove)
        {
            if (cellList.Contains(cellToRemove))
            {
                //ClearTerminal();
                //Console.Clear();
                Console.WriteLine("--------START-OF-DEBUG-MESSAGE--------");
                Console.WriteLine("Cell deleted");
                Console.Write("   DNA:    ");
                Console.WriteLine(cellToRemove.dna);
                Console.Write("   ENERGY: ");
                Console.WriteLine(Math.Round((decimal)cellToRemove.energy, 2));
                Console.Write("   FOOD:   ");
                Console.WriteLine(Math.Round((decimal)cellToRemove.food, 2));
                Console.WriteLine("--------END-OF-DEBUG-MESSAGE----------");
                cellList.Remove(cellToRemove);
            }
            else
            {
                Console.WriteLine("--------START-OF-DEBUG-MESSAGE--------");
                Console.WriteLine("The requested Cell is not preset");
                Console.WriteLine(" in the cellList!");
                Console.WriteLine("--------END-OF-DEBUG-MESSAGE----------");
            }
        }
        static void ClearTerminal()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("                                                         ");
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
