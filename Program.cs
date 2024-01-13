int easy = 8;
int medium = 6;
int hard = 4;
int cheater = int.MaxValue;

Console.WriteLine("Welcome to the guessing game!");
string choice = null;

while (choice != "0")
{
    Console.WriteLine($@"Choose your difficulty:
        0. Exit
        1. Easy
        2. Medium
        3. Hard
        4. Cheater");
    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("Thanks for visiting!");
    }
    else if (choice == "1")
    {
        GuessingGame(easy);
    }
    else if (choice == "2")
    {
        GuessingGame(medium);
    }
    else if (choice == "3")
    {
        GuessingGame(hard);
    }
    else if (choice == "4")
    {
        GuessingGame(cheater);
    }
}

void GuessingGame(int tries)
{
    Random random = new Random();
    int secretNumber = random.Next(1, 101);
    Console.WriteLine($"\nYou have {tries} attempts. Guess away!");
    bool correctGuess = false;
    for (int i = 1; i <= tries; i++)
    {
        int triesLeft = tries - i; // calculates how many tries left
            
        Console.WriteLine("\nGuess:");
        int guess = int.Parse(Console.ReadLine());

        if (guess == secretNumber)
        {
            Console.WriteLine("\nWoah! You guessed the secret number correctly!");
            correctGuess = true; // if true, no display 
            break; // boot user out of loop
        }
        else
        {
            int diff = Math.Abs(secretNumber - guess); // returns absolute value
            if (diff <= 5) // if guess is too low or too high vs random number
            {
                if (guess < secretNumber)
                {
                    Console.WriteLine($"So close, a little too low.. ({triesLeft} tries left)");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine($"Close, a little too high.. ({triesLeft} tries left)");
                }
            }
            else
            {
                Console.WriteLine($"\nNot the number I was looking for, try again. ({triesLeft} tries left)");
            }
        }
    }

    if (!correctGuess) // if attempt limit was reached with no guess, if false then display message
    {
        Console.WriteLine($"\nSorry, you've tried too many times. The correct number was {secretNumber}!");
    }
}