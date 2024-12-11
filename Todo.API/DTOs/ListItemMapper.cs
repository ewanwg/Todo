using Todo.API.Entities;

namespace Todo.API.DTOs
{
    public class ListItemMapper
    {
        public static ListItemDTO MapToDTO(ListItem listItem)
        {
            return new ListItemDTO
            {
                Id = listItem.Id,
                Item = listItem.Item,
                IsComplete = listItem.IsComplete
            };
        }
    }
}
