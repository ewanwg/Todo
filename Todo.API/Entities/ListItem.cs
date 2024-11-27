namespace Todo.API.Entities
{
    public class ListItem
    {
        public int Id { get; set; }
        public int ListTitleId { get; set; }
        public required string Item { get; set; }
        public bool IsComplete { get; set; }

        public required ListTitle ListTitle { get; set; } // Navigation property
    }
}
