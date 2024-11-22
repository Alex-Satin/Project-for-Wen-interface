using ApiClientProject;
using ApiClientProject;


public class Program
{
    public static async Task Main(string[] args)
    {
        var client = new HttpClientWrapper();

        Console.WriteLine("Fetching data using GET...");
        var getResponse = await client.GetAsync<Post>("https://jsonplaceholder.typicode.com/posts");

        if (getResponse.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine($"GET Successful! Received {getResponse.Data?.Count} items.");
        }
        else
        {
            Console.WriteLine($"GET Failed: {getResponse.Message}");
        }

        Console.WriteLine("\nFetching data using POST...");
        var postPayload = new { title = "foo", body = "bar", userId = 1 };
        var postResponse = await client.PostAsync<Post>("https://jsonplaceholder.typicode.com/posts", postPayload);

        if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
        {
            Console.WriteLine($"POST Successful! Created item with ID: {postResponse.Data?.Id}");
        }
        else
        {
            Console.WriteLine($"POST Failed: {postResponse.Message}");
        }
    }
}
