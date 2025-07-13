using Agent.Domain.Entities;
using Agent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agent.Infra.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AgentDbContext _dbContext;

        public RoomRepository(AgentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Room>> GetRoomsAsync()
        {
            return await _dbContext.Rooms
                                   .Include(q => q.RoomQuestions)
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<Guid> CreateAsync(Room room)
        {
            try
            {
                await _dbContext.Rooms.AddAsync(room);
                await _dbContext.SaveChangesAsync();
                
                return room.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
