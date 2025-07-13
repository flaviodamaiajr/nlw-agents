using Agent.Domain.Entities;
using Agent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agent.Infra.Persistence.Repositories
{
    public class RoomQuestionRepository : IRoomQuestionRepository
    {
        private readonly AgentDbContext _dbContext;

        public RoomQuestionRepository(AgentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoomQuestion> CreateAsync(RoomQuestion roomQuestion)
        {
            try
            {
                await _dbContext.RoomQuestions.AddAsync(roomQuestion);
                await _dbContext.SaveChangesAsync();

                return roomQuestion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ICollection<RoomQuestion>> GetQuestionsByRoomIdAsync(Guid roomId)
        {
            return await _dbContext.RoomQuestions
                                    .Include(x => x.Room)
                                    .AsNoTracking()
                                    .Where(r => r.RoomId == roomId)
                                    .ToListAsync();
        }
    }
}
