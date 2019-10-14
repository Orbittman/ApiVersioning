using System.Linq;

namespace ApiVersioning
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Versioning;

    public class TestVersionSelector : IApiVersionSelector
    {
        readonly ApiVersioningOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="LowestImplementedApiVersionSelector"/> class.
        /// </summary>
        /// <param name="options">The <see cref="ApiVersioningOptions">API versioning options</see> associated with the selector.</param>
        public TestVersionSelector(ApiVersioningOptions options)
        {
            this.options = options;
        }

        /// <summary>
        /// Selects an API version given the specified HTTP request and API version information.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequest">HTTP request</see> to select the version for.</param>
        /// <param name="model">The <see cref="ApiVersionModel">model</see> to select the version from.</param>
        /// <returns>The selected <see cref="ApiVersion">API version</see>.</returns>
        /// <remarks>This method always returns the default <see cref="ApiVersion.Default">API version</see>.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "Validated by a code contract.")]
        public virtual ApiVersion SelectVersion(HttpRequest request, ApiVersionModel model)
        {
            switch (model.ImplementedApiVersions.Count)
            {
                case 0:
                    return options.DefaultApiVersion;
                case 1:
                    var version = model.ImplementedApiVersions[0];
                    return version.Status == null ? version : options.DefaultApiVersion;
            }

            return model.ImplementedApiVersions.Where(v => v.Status == null).Min(v => v) ?? options.DefaultApiVersion;
        }
    }
}
