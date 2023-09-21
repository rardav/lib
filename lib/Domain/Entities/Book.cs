namespace lib.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }

        public List<Copy> Copies { get; set; } = new List<Copy>();
    }
}
 