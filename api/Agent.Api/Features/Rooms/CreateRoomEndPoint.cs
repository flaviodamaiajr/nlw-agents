using Agent.Application.DTOs.Room;
using Agent.Application.Interfaces;
using FastEndpoints;
using System.Net;

namespace Agent.Api.Features.Rooms
{
    public class CreateRoomEndPoint : Endpoint<CreateRoomRequest, CreateRoomResponse>
    {
        private readonly IRoomService _roomService;

        public CreateRoomEndPoint(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public override void Configure()
        {
            Post("/api/room/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateRoomRequest req, CancellationToken ct)
        {
            var room = await _roomService.CreateAsync(new CreateRoomDTO(req.Name, req.Description));

            await SendAsync(new CreateRoomResponse()
            {
                RoomId = room.Id
            }, (int)HttpStatusCode.Created, ct);
        }
    }
}
