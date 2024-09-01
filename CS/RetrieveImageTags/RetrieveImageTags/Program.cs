using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

class Program
{
    private const string endpoint = "https://akkiaiservices.cognitiveservices.azure.com/"; 
    private const string apiKey = "yoursubscriptionkey";

    static async Task Main(string[] args)
    {
        ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
              { Endpoint = endpoint };


        string imageFilePath = "../../../../../../Images/Akki.jpg"; 

        using (var stream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
        {
            try
            {
                List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                {
                    VisualFeatureTypes.Tags
                };

                var response = await client.AnalyzeImageInStreamAsync(stream, visualFeatures: features);
                var tags = response.Tags;

                Console.WriteLine("Tags:");
                foreach (var tag in tags)
                {
                    Console.WriteLine($"- {tag.Name} (Confidence: {tag.Confidence:P2})");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        Console.ReadKey();
    }
}