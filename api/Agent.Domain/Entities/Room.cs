namespace Agent.Domain.Entities
{
    public sealed class Room : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public IList<RoomQuestion>? RoomQuestions { get; private set; }

        protected Room() { }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
