using Agent.Domain.Entities;

namespace Agent.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<ICollection<Room>> GetRoomsAsync();
        Task<Guid> CreateAsync(Room room);
    }
}
