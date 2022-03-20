using ClaySmartLock.Model.Configuration;
using ClaySmartLock.Model.Contract.DoorIOTClient;
using ClaySmartLock.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    // Mock client
    public class DoorIOTClient : IDoorIOTClient
    {
        static HttpClient client = new HttpClient();

        private readonly IOptions<ClayAppConfiguration> _configuration;

        public DoorIOTClient(IOptions<ClayAppConfiguration> configuration)
        {
            _configuration = configuration;
        }

        public async Task<DoorIOTClientUnLockResponse> UnLockDoor(DoorIOTClientUnLockRequest request)
        {
            string endpoint = _configuration.Value.Endpoints.DoorIOTUnLockService;
            HttpResponseMessage httpResponse = await client.PostAsJsonAsync(endpoint, request);
            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsAsync<DoorIOTClientUnLockResponse>();
        }

        public async Task<DoorIOTClientLockResponse> LockDoor(DoorIOTClientLockRequest request)
        {
            string endpoint = _configuration.Value.Endpoints.DoorIOTLockService;
            HttpResponseMessage httpResponse = await client.PostAsJsonAsync(endpoint, request);
            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsAsync<DoorIOTClientLockResponse>();
        }

    }
}
