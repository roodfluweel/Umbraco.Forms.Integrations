﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Umbraco.Cms.Integrations.Authorization.Core.Models.Dtos;
using Umbraco.Cms.Integrations.Authorization.Core.Interfaces;
using Umbraco.Forms.Integrations.Crm.Hubspot.OAuthProxy.Configuration;

namespace Umbraco.Forms.Integrations.Crm.Hubspot.OAuthProxy.Services
{
    public class HubspotService: IAuthorizationService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;

        private readonly Settings _settings;

        public HubspotService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;

            _configuration = configuration;

            _settings = new Settings();
            _configuration.GetSection("HubspotSettings").Bind(_settings);
        }

        public async Task<ResponseDto> ProcessAsync(HttpContent content)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            var response = await client.PostAsync(_settings.AuthEndpoint, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            return new ResponseDto
            {
                StatusCode = (int)response.StatusCode,
                ContentType = response.Content.Headers.ContentType?.ToString(),
                ContentLength = response.Content.Headers.ContentLength,
                Content = responseContent
            };
        }

        public HttpContent GetContent(IFormCollection form)
        {
            var dictionary = form.ToDictionary(x => x.Key, x => x.Value.ToString());

            dictionary.Add("client_secret", _settings.ClientSecret);

            return new FormUrlEncodedContent(dictionary);
        }
    }
}
