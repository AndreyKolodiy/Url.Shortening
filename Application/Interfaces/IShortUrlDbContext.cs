using Domain;using Microsoft.EntityFrameworkCore;namespace Application.Interfaces;public interface IShortUrlDbContext{    DbSet<ShortUrl> ShortUrls { get; set; }    Task<int> SaveChangesAsync(CancellationToken cancellationToken);}