using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CleanArhcitecture.Application.Features.ProductFetures.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger) => _logger = logger;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        #region Request
        _logger.LogInformation($"Handeling {typeof(TRequest).Name}");
        Type type = request.GetType();
        IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
        foreach (PropertyInfo prop in props)
        {
            object propValue = prop.GetValue(request, null);
            _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
        }
        #endregion

        var response = await next();

        #region Response
        _logger.LogInformation($"Handled {typeof(TResponse).Name}");
        #endregion
        return response;
    }
}
