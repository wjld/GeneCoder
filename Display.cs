class Display
{
    readonly string[] valid3 = {"1","2","3"};
    readonly string[] valid2 = {"1","2"};

    public string WelcomeScreen()
    {
        string option = "";
        while(!valid3.Contains(option))
        {
            Console.Clear();
            Console.WriteLine("Welcome to the GeneCoder Api!\n");
            Console.WriteLine("Enter a number to select an option:");
            Console.WriteLine("1 - Log in");
            Console.WriteLine("2 - Create user");
            Console.WriteLine("3 - Quit\n");
            option = Console.ReadLine();
        }
        return option;
    }

    public string GetUsername()
    {
        string username = string.Empty;
        while(username == string.Empty)
        {
            Console.Clear();
            Console.WriteLine("Enter your username (must not be empty):");
            username = Console.ReadLine();
        }
        return username;
    }

    public string GetPassword()
    {
        string password = string.Empty;
        while(password.Length < 8)
        {
            Console.Clear();
            Console.WriteLine("Enter your password (at least 8 characters):");
            password = Console.ReadLine();
        }
        return password;
    }

    public string GetEmail()
    {
        string email = string.Empty;
        while(email == string.Empty)
        {
            Console.Clear();
            Console.WriteLine("Enter your email (must not be empty):");
            email = Console.ReadLine();
        }
        return email;
    }
}