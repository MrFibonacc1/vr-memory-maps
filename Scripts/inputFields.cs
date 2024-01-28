using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class InputFields : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCam;
    
    public TMP_InputField inputFieldTMP;

    public TextMeshPro textMeshPro1;
    public TextMeshPro textMeshPro2;
    public TextMeshPro textMeshPro3;
    public TextMeshPro textMeshPro4;
    public TextMeshPro textMeshPro5;

    private const string cohereApiKey = "Dbcj1hgn35J590T2MhcQz9ysFYqIeOIiKBdMuYGn";  // Replace with your actual Cohere API key
    private const string cohereApiUrl = "https://api.cohere.ai/v1/chat";

    // This method will be called when the input field ends editing
    public async void OnEnd()
    {
        print("Ended");
        
        string inputFieldText = inputFieldTMP.text;
        if (textMeshPro1 != null)
        {
            await SummarizeAndDisplay(textMeshPro1,inputFieldText);
        }

string response = textMeshPro1.text;
print(response);
string[] lines = response.Split('\n');
string line1 = lines[0];
string line2 = lines[2];
string line3 = lines[4];
string line4 = lines[6];
string line5 = lines[8];
string line6 = lines[10];
string line7 = lines[12];
string line8 = lines[14];
if (textMeshPro1 != null) textMeshPro1.text = line2;
if (textMeshPro2 != null) textMeshPro2.text = line3;
if (textMeshPro3 != null) textMeshPro3.text = line4;
if (textMeshPro4 != null) textMeshPro4.text = line5;
if (textMeshPro5 != null) textMeshPro5.text = line6;

//        if (textMeshPro1 != null)
//        {
//            textMeshPro1.text = response;
//        }

// Repeat for other TextMeshPro fields...

if (!player.activeInHierarchy)
{
    player.SetActive(true);
}
if (!playerCam.activeInHierarchy)
{
    playerCam.SetActive(true);
}
    }

    private async Task SummarizeAndDisplay(TextMeshPro textMeshPro, String theme)
    {
        var input = new SummarizeInput
        {
            message = $"Give me 10 interesting facts with dates in chronological order about {theme} and label them by number 1 to number 5 in chronological order starting from number 1",
            connectors = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "id", "web-search" } },
            }
        };

        var json = JsonUtility.ToJson(input);

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(cohereApiUrl),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", "Bearer " + cohereApiKey },
                },
                Content = new StringContent(json)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();

                var data = JsonUtility.FromJson<SummarizeOutput>(body);

                if (textMeshPro != null)
                {
                    textMeshPro.text = data.text;
                }
            }
        }
    }




    [Serializable]
    public class SummarizeInput
    {
        public string message;
        public List<Dictionary<string, string>> connectors = new List<Dictionary<string, string>>();
    }

    [Serializable]
    public class SummarizeOutput
    {
        public string text;
    }
}