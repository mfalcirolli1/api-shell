using APIShell.Domain.Shell.Model;
using APIShell.Infrastructure.ORM.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace APIShell.Infrastructure.ORM
{
    public class ShellContext : DbContext
    {
        private IConfiguration configuration;

        public ShellContext()
        {

        }

        public ShellContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<ShellModel> ShellRepository { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = FromBase64ToString(configuration.GetConnectionString("LOCAL_DB"));
                //var connectionString = FromBase64ToString("ZGF0YSBzb3VyY2U9KGxvY2FsZGIpXE1TU1FMTG9jYWxEQjtpbml0aWFsIGNhdGFsb2c9TUZBTENJUk9MTEkwMTtpbnRlZ3JhdGVkIHNlY3VyaXR5PVRydWU7TXVsdGlwbGVBY3RpdmVSZXN1bHRTZXRzPVRydWU7QXBwPUVudGl0eUZyYW1ld29yaw==");

                optionsBuilder.UseSqlServer(connectionString, sql =>
                {
                    sql.CommandTimeout(180);
                    sql.MigrationsHistoryTable("EFMigration_Shell");
                });
            }

            optionsBuilder.UseLazyLoadingProxies(false);
            optionsBuilder.EnableSensitiveDataLogging(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShellMapping());
        }

        public string FromBase64ToString(string base64Encoded)
        {
            byte[] data = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(data);
        }
    }
}
