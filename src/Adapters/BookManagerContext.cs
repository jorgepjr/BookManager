﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Adapters;
public class BookManagerContext : DbContext
{
    public BookManagerContext(DbContextOptions<BookManagerContext> contextOptions): base(contextOptions) { }

    public DbSet<Book> Books { get; set; }
}
