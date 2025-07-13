namespace Agent.Api.Features.Rooms
{
    public record CreateRoomRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
