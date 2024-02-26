using System.ComponentModel.Design;
using System.Security.Cryptography;

class Program() {
    static Random random = new Random();

      public static void Main(string[] args) {
        int randomNum = random.Next(1,100);
        int num = 0;

        Console.WriteLine("Hadaj cislo od 1 do 100");
        Core(num, randomNum);
    } 

     private static void Core(int num, int randomNum) {
        int pocetHadani = 0;
        while (randomNum != num) {
            num = Convert.ToInt32(Console.ReadLine());
            

            if (num < randomNum) {
                Console.WriteLine("vacsie");
                pocetHadani++;
            }
            if (num > randomNum) {
                Console.WriteLine("mensie");
                pocetHadani++;

            }
            if (num == randomNum) { 
                Console.WriteLine("uhadol si, pocet hadani: " + pocetHadani);    
            }
        }
    }
}