using Azure;

using Azure.AI.OpenAI;

using System.Diagnostics;

public class Program
{

    public static async Task Main(string[] args)
    {
        string response = "";
        String OpenAIUrl2 = "https://arabtesting3.openai.azure.com/";
        String OpenAIKey2 = "299533e86a414e8a8ba4728bb2155891";
        string SystemMessage = "You are an AI assistant that helps people find information about ADHD.  For anything other than ADHD, respond with 'I can only answer questions about ADHD.'";
        Console.WriteLine("If You Want to end the conversation write 'Exit");
        
        while (true)
        {
            Console.Write("User : ");
            String input = Console.ReadLine();
            if (input.Equals("Exit"))
            {
                Console.WriteLine("GoodBye!");
                break;
            }
         
        

            OpenAIClient client = new OpenAIClient(
                new Uri(OpenAIUrl2!),
                new AzureKeyCredential(OpenAIKey2!));

            ChatCompletionsOptions options = new ChatCompletionsOptions();
            options.Temperature = (float)0.7;
            options.MaxTokens = 800;
            options.NucleusSamplingFactor = (float)0.95;
            options.FrequencyPenalty = 0;
            options.PresencePenalty = 0;
            options.Messages.Add(new ChatMessage(ChatRole.System, SystemMessage));
        
        
            options.Messages.Add(new ChatMessage(ChatRole.Assistant, input));

            Response<ChatCompletions> resp = await client.GetChatCompletionsAsync(
                    "ai_bot"!,
                    options);

            ChatCompletions completions = resp.Value;

            response = completions.Choices[0].Message.Content;

            Console.WriteLine("Doctor : "+response);
        }
        
        
    }
}

