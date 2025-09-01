
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialByIdQueryHandler(IRepository<Social> _repository, IMapper _mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetSocialByIdQueryResult>.NotFound();
            }
            var social = _mapper.Map<GetSocialByIdQueryResult>(value);
            return BaseResult<GetSocialByIdQueryResult>.Success(social);
        }
    }
}
