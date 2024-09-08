
namespace VirtualPet {
    internal class Program {
        private static Pet myPet;
        private static int inputParsed;
        private static string input;
        static void Main(string[] args) {
            myPet = new Pet();

            myPet.FeedPet += Feed;
            myPet.PlayWithPet += Play;
            myPet.PutToSleep += Sleep;

            while (inputParsed != 5) {
                PromptUser();
                HandleInput();
            }
        }

        public static void PromptUser() {
            Console.WriteLine("Enter a number corresponding to your preferred action:");
            Console.WriteLine($"1. Name/Rename Pet\n" +
                $"2. Feed {myPet.Name}\n" +
                $"3. Play with {myPet.Name}\n" +
                $"4. Put {myPet.Name} to sleep\n" +
                $"5. Exit\n");

            input = Console.ReadLine();

            int.TryParse(input, out inputParsed);

        }

        public static void HandleInput() { //This method determines which event will be raised
            switch (inputParsed) {
                case 1: Rename();
                    break;
                case 2: 
                    myPet.FeedCaller(myPet);
                    break;
                case 3:
                    myPet.PlayCaller(myPet);
                    break;
                case 4:
                    myPet.SleepCaller(myPet);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine($"\"{input}\" is not a valid input. Please enter a valid input\n");
                    return;
            }
            DisplayVitals();
            Console.WriteLine();
        }
        private static void DisplayVitals() {
            Console.WriteLine($"{myPet.Name}'s vitals:\n" +
                $"Happiness Level: {myPet.HappinessLevel}\n" +
                $"Hunger Level: {myPet.HungerLevel}\n" +
                $"Energy Level: {myPet.EnergyLevel}");

            if (myPet.HappinessLevel < 50)
                Console.WriteLine($"{myPet.Name} is getting bored, you should play with them");
            if (myPet.HungerLevel > 50)
                Console.WriteLine($"{myPet.Name} is getting hungry, you should feed them");
            if (myPet.EnergyLevel < 50)
                Console.WriteLine($"{myPet.Name} is getting tired, you should put them to bed soon");
        }

        public static void Rename() {
            Console.WriteLine("What would you like to name your pet?");
            myPet.Name = Console.ReadLine();
            Console.WriteLine($"Your pet's name is now {myPet.Name}!");
        }
        public static void Feed(Pet myPet) { // event handler to feed pet
            myPet.HungerLevel -= 10;
            myPet.HappinessLevel += 10;
            Console.WriteLine($"You fed {myPet.Name}!");
        }

        public static void Play(Pet myPet) { // event handler to play with pet
            myPet.EnergyLevel -= 10;
            myPet.HappinessLevel += 10;
            Console.WriteLine($"You played with {myPet.Name}!");
        }

        public static void Sleep(Pet myPet) { // event handler to put pet to sleep
            myPet.HappinessLevel -= 5;
            myPet.EnergyLevel += 10;
            Console.WriteLine($"{myPet.Name} had a nice nap!");
        }
    }
}
