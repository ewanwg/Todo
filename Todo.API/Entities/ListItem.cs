using Todo.API.DTOs;

namespace Todo.API.Entities
{
    public class ListItem
    {
        public int Id { get; set; }
        public int ListTitleId { get; set; }
        public required string Item { get; set; }
        public bool IsComplete { get; set; }

        public ListTitle ListTitle { get; set; } // Navigation property

        public static ListItem MapToEntity(ListItemDTO listItemDTO)
        {
            return new ListItem
            {
                Id = listItemDTO.Id,
                ListTitleId = listItemDTO.ListTitleId,
                Item = listItemDTO.Item,
                IsComplete = listItemDTO.IsComplete
            };
        }
    }
}
