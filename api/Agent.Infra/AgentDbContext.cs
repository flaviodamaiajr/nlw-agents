using Agent.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agent.Infra
{
    public class AgentDbContext(DbContextOptions<AgentDbContext> options) : DbContext(options)
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomQuestion> RoomQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgentDbContext).Assembly);
        }
    }
}
