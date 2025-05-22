﻿using Microsoft.EntityFrameworkCore;
using Presentation.Data.Entities;

namespace Presentation.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AddressInfoEntity> AddressInfos { get; set; }
    public DbSet<AddressTypeEntity> AddressTypes { get; set; }
    public DbSet<ContactInfoEntity> ContactInfos { get; set; }
    public DbSet<ContactTypeEntity> ContactTypes { get; set; }
    public DbSet<ProfileEntity> Profiles { get; set; }
}
