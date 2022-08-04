using Fathym;
using Fathym.API.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fathym.LCU.Services.API
{
    public abstract class LCUPersonasAPIController : FathymAPIController, IDisposable
    {
        #region Fields
        protected readonly IConfiguration config;

        protected readonly List<IDisposable> disposables;
        #endregion

        #region Constructors
        public LCUPersonasAPIController(ILogger logger, IConfiguration config)
            : base(logger)
        {
            this.config = config;

            disposables = new List<IDisposable>();
        }
        #endregion

        #region API Methods
        public virtual void Dispose()
        {
            disposables.Each(d => d.Dispose());
        }
        #endregion

        #region Helpers
        #endregion
    }
}
