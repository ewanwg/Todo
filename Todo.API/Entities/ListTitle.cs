namespace Todo.API.Entities
{
    public class ListTitle
    {
        public required int Id { get; set; }
        public required string Title { get; set; }

        public required ICollection<ListItem> Items { get; set; } // Navigation property
    }
}
