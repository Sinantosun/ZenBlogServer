using FluentValidation;
using MediatR;

namespace ZenBlog.Application.Behaviros
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(
                      validators.Select(v => v.ValidateAsync(context,cancellationToken)));

                var failtures = validationResult.Where(result => result is not null).SelectMany(x=>x.Errors.ToList());

                if (failtures.Any())
                {
                    var errorDetails = failtures.GroupBy(x => x.PropertyName).ToDictionary(x => x.Key, x => x.Select(t => t.ErrorMessage).ToArray()).ToList();

                    throw new ValidationException(failtures);
                }   
            }
            return await next(cancellationToken);
        }
    }
}
