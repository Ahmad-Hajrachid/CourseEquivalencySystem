﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseEquivalencySite.Models;

namespace CourseEquivalencySite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CourseEquivalencySite.Models.Course> Course { get; set; }
        public DbSet<CourseEquivalencySite.Models.Institution>  institutions { get; set; }
        public DbSet<CourseEquivalencySite.Models.Major>  majors { get; set; }
        public DbSet<CourseEquivalencySite.Models.Users>   users{ get; set; }
    }
}
