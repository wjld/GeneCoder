using System.Net.Http.Headers;

class main
{
    static HttpClient client = new HttpClient();
    static User user = new User();
    static Display display = new Display();

    static void Main()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    static async Task RunAsync()
    {
        client.BaseAddress = new Uri("https://gene.lacuna.cc/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        string option = display.WelcomeScreen();
        Console.Clear();
    }
}