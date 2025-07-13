using Agent.Application.DTOs.Room;
using Agent.Application.Interfaces;
using FastEndpoints;
using System.Net;

namespace Agent.Api.Features.Rooms
{
    public class GetRoomsEndPoint : EndpointWithoutRequest<ICollection<RoomDTO>>
    {
        private readonly IRoomService _roomService;

        public GetRoomsEndPoint(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public override void Configure()
        {
            Post("/api/room/list");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var rooms = await _roomService.GetAllAsync();

            await SendAsync(rooms, rooms.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NoContent, ct);
        }

    }
}
