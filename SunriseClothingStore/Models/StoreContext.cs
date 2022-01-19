﻿using Microsoft.EntityFrameworkCore;

namespace SunriseClothingStore.Models;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    
}