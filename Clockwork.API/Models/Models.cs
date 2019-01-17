using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Models
{
    public class ClockworkContext : DbContext
    {
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .\\SQLSERVER; Database = TestDB; Trusted_Connection = True; ");
        }
    }

    public class CurrentTimeQuery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrentTimeQueryId { get; set; }
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
        public string Timezone { get; set; }
        public DateTime TimezoneTime { get; set; }
    }
}
