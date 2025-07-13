using Agent.Domain.Exceptions;

namespace Agent.Domain.Entities
{
    public class AudioChunk : BaseEntity
    {
        public Guid RoomId { get; private set; }
        public string Transcription { get; private set; }
        public float[] Embeddings { get; private set; } // Vector with 768 dimensions

        protected AudioChunk() { }

        public AudioChunk(Guid roomId, string transcription, float[] embeddings)
        {
            if (embeddings == null || embeddings.Length != 768)
                throw new DomainException("Embeddings must have exactly 768 dimensions.");

            RoomId = roomId;
            Transcription = transcription ?? throw new ArgumentNullException(nameof(transcription));
            Embeddings = embeddings;
        }
    }
}
