using Microsoft.EntityFrameworkCore;

namespace TheUKTories.Services.Data.EFCore
{
    /// <summary>
    ///     Provides paginated access to items in the database through EF Core.
    ///     
    ///     IQueryable<typeparamref name="T"/> items = from c in _context.Table select c;
    ///     var pagesize = config.GetValue("DefaultPageSize");
    ///     items = await PaginatedList<typeparamref name="T"/>.CreateAsync(items.AsNoTracking,
    ///         pageIndex ?? 1, pagesize);
    /// </summary>
    /// <typeparam name="T">Model from EFCore.Models</typeparam>
    /// <example>
    /// <code>
    ///     IQueryable<typeparamref name="T"/> items = from c in _context.Table select c;
    ///     var pagesize = config.GetValue("DefaultPageSize")
    ///     items = await PaginatedList<typeparamref name="T"/>.CreateAsync(items.AsNoTracking,
    ///         pageIndex ?? 1, pagesize);
    /// </code>
    /// </example>
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
