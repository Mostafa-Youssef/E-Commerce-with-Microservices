﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetRunBasics.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the api: {message.ReasonPhrase}");
            }

            var dataAsString = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
