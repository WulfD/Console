﻿using System.Net.Http.Headers;
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync(
         "http://localhost:5289/getfile");

    Console.Write(json);
}

string command = Console.ReadLine();

switch(command)
{
    case "getfile":
        Console.WriteLine("Befehl wird ausgeführt");
        await ProcessRepositoriesAsync(client);
        break;

    default:
        Console.WriteLine("Unbekannter Befehl");
        break;
}

Console.ReadLine();