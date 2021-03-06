﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
namespace FinalExam
{
    class Cities
    {
        static async Task<string[]> MainAsync(String text)
        {


            var client = new HttpClient();
            String[] output = new String[50];

            Console.WriteLine("letter");
            String input = "http://cs.newpaltz.edu/~plotkinm/2012Grad/Final/api/Cities.php?term=" + text;
            try
            {
                HttpResponseMessage response = await client.GetAsync(input);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                output = JsonConvert.DeserializeObject<string[]>(responseBody);


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return output;
            //client.Dispose(true);


        }
    }
}
