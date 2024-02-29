using System.ComponentModel.Design;
using System.Security.Cryptography;
public class Program {
    
    private static Random random = new Random();
    private int pocetHadani;
    private int num;
    private int randomNum = random.Next(1,100);
    
    public static void Main() {
        new Program();
    }
    public Program() {
        Console.WriteLine("Hadaj cislo od 1 do 100");
        Core();
    }

     private void Core() {
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