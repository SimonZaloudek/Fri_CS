Console.WriteLine("lukasstarinsky8@gmail.com");
var time = DateTime.Now;
var hour = time.Hour;
if (hour >= 4 && hour <= 8) {
    Console.WriteLine("Good morning");    
} 
if (hour > 8 && hour <= 18) {
    Console.WriteLine("Good day");    
}
if (hour > 18 && hour <= 22) {
    Console.WriteLine("Good evening");    
}
if (hour > 22 && hour < 4) {
    Console.WriteLine("Good night");    
}