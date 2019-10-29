namespace CinemaExplorer.Persisted.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }

        public int DurationTime { get; set; }

        public string Filmmaker { get; set; }

        public float Price { get; set; }
    }
}
