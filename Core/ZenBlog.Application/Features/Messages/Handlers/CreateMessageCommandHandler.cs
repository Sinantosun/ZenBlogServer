﻿using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Handlers;

public class CreateMessageCommandHandler(IRepository<Message> _repository,IMapper _mapper,IUnitOfWork _unitofWork) : IRequestHandler<CreateMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<Message>(request);
        await _repository.CreateAsync(message);
        await _unitofWork.SaveChangeAsync();
        return BaseResult<object>.Success("Kayıt Eklendi...!");
    }
}
