namespace Todo.API.DTOs
{
    public class ListItemDTO
    {
        public int Id { get; set; }
        public required string Item { get; set; }
        public bool IsComplete { get; set; }
    }
}
