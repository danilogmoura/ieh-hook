using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.IO;
    // using System.Net.Http.Headers;
    // using System.Threading;
    // using System.Threading.Tasks;
    //
    // namespace System.Net.Http
    // {
    //     /// <summary>Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</summary>
    //     // Token: 0x02000015 RID: 21
    //     public partial class HttpClient : HttpMessageInvoker
    //     {
    //         /// <summary>Send a POST request to the specified Uri as an asynchronous operation.</summary>
    //         /// <param name="requestUri">The Uri the request is sent to.</param>
    //         /// <param name="content">The HTTP request content sent to the server.</param>
    //         /// <returns>The task object representing the asynchronous operation.</returns>
    //         /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
    //         /// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    //         // Token: 0x060000DD RID: 221 RVA: 0x00003E7F File Offset: 0x0000207F
    //         public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
    //         {
    //             return this.SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)
    //             {
    //                 Content = content
    //             });
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(HttpClient), "PostAsync", typeof(string), typeof(HttpContent))]
    public static class HttpClient_PostAsync
    {
        private static bool Prefix(string requestUri, HttpContent content, ref Task<HttpResponseMessage> __result)
        {
            __result = Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            return false;
        }
    }
}