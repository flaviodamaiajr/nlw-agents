using Agent.Application.DTOs.Room;
using Agent.Application.Interfaces;
using Agent.Domain.Entities;
using Agent.Domain.Interfaces;

namespace Agent.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomDTO> CreateAsync(CreateRoomDTO createRoomRequest)
        {
            var room = new Room(createRoomRequest.Name, createRoomRequest.Description);

            await _roomRepository.CreateAsync(room);

            return new RoomDTO(room.Name, room.Description)
            {
                Id = room.Id,
                CreatedAt = room.CreatedAt
            };
        }

        public async Task<ICollection<RoomDTO>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetRoomsAsync();

            return [.. rooms.Select(r => new RoomDTO(r.Name,
                                                           r.Description,
                                                           RoomQuestions: r.RoomQuestions?.Select(q => new RoomQuestionsDTO(q.Question, q.Answer) {
                                                               Id = r.Id,
                                                               CreatedAt = r.CreatedAt
                                                           }).ToList() ?? []){
                Id = r.Id,
                CreatedAt = r.CreatedAt
            })];
        }
    }
}
