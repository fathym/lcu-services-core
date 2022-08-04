using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fathym.LCU.Services
{
    public class LCUClient<TOptions>
        where TOptions : LCUClientOptions
    {
        #region Fields
        protected readonly HttpClient httpClient;

        protected readonly ILogger logger;

        protected readonly TOptions options;
        #endregion

        #region Constructors
        public LCUClient(HttpClient httpClient, ILogger logger, IOptions<TOptions> options)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            this.options = options?.Value ?? throw new ArgumentNullException(nameof(options));

            this.httpClient = configureHttpClient(httpClient ?? throw new ArgumentNullException(nameof(httpClient)));
        }
        #endregion

        #region API Methods
        public virtual async Task WithClient(Func<HttpClient, Task> action)
        {
            await action(httpClient);
        }
        #endregion

        #region Helpers
        protected virtual HttpClient configureHttpClient(HttpClient httpClient)
        {
            if (!options.BaseAddress.IsNullOrEmpty())
                httpClient.BaseAddress = new Uri(options.BaseAddress);

            httpClient.DefaultRequestHeaders.Add("User-Agent", GetType().FullName);

            return httpClient;
        }
        #endregion
    }
}
