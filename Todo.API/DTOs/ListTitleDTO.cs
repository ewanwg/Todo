namespace Todo.API.DTOs
{
    public class ListTitleDTO
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public List<ListItemDTO> ListItems { get; set; }
    }
}
