using System.Net.Http.Headers;

class main
{
    static HttpClient client = new HttpClient();
    static User user = new User();
    static Display display = new Display();

    static async Task CreateUserAsync(NewUser user)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/users/create", user);
        response.EnsureSuccessStatusCode();
    }

    static async Task<string> RequestTokenAsync(User user)
    {
        string token = null;
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/users/login", user);
        var fields = await response.Content.
            ReadAsAsync<Dictionary<string,string>>();
        if (fields["code"] == "Success")
        {
            token = fields["accessToken"];
        }
        return token;
    }

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
        while(option != "3")
        {
            if(option == "1")
            {
                user.username = display.GetUsername();
                user.password = display.GetPassword();
            }
            else if(option == "2")
            {
                NewUser newUser = new NewUser();
                newUser.username = display.GetUsername();
                newUser.email = display.GetEmail();
                newUser.password = display.GetPassword();
                await CreateUserAsync(newUser);
                user.username = newUser.username;
                user.password = newUser.password;
            }
            
            string token = await RequestTokenAsync(user);
            if(token is null)
            {
                display.LoginError();
            }
            else
            {
                display.ConfirmLogin(token);
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue(token);
            }
            option = display.WelcomeScreen();
        }
        Console.Clear();
    }
}