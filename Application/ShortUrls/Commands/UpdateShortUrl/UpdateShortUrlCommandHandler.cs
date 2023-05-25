using Application.Common.Exceptions;using Application.Interfaces;using MediatR;using Microsoft.EntityFrameworkCore;namespace Application.ShortUrls.Commands.UpdateShortUrl;public class UpdateShortUrlCommandHandler : IRequestHandler<UpdateShortUrlCommand>{    private readonly IShortUrlDbContext _dbContext;    public UpdateShortUrlCommandHandler(IShortUrlDbContext dbContext) =>        _dbContext = dbContext;    public async Task<Unit> Handle(UpdateShortUrlCommand request, CancellationToken cancellationToken)    {        var entity =            await _dbContext.ShortUrls.FirstOrDefaultAsync(shortUrl => shortUrl.Path == request.Path,                cancellationToken);        if (entity == null) { throw new NotFoundException(nameof(ShortUrls), request.Path); }        entity.Destination = request.Destination;        await _dbContext.SaveChangesAsync(cancellationToken);        return Unit.Value;    }}