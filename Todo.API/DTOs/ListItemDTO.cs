using Todo.API.Entities;

namespace Todo.API.DTOs
{
    public class ListItemDTO
    {
        public int Id { get; set; }
        public int ListTitleId { get; set; }
        public required string Item { get; set; }
        public bool IsComplete { get; set; }

        public static ListItemDTO MapToDTO(ListItem listItem)
        {
            return new ListItemDTO
            {
                Id = listItem.Id,
                ListTitleId = listItem.ListTitleId,
                Item = listItem.Item,
                IsComplete = listItem.IsComplete
            };
        }
    }
}
