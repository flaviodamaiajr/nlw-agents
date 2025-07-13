using Agent.Domain.Entities;

namespace Agent.Domain.Interfaces
{
    public interface IRoomQuestionRepository
    {
        Task<ICollection<RoomQuestion>> GetQuestionsByRoomIdAsync(Guid roomId);
        Task<RoomQuestion> CreateAsync(RoomQuestion roomQuestion);

    }
}
