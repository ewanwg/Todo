using Todo.API.Entities;

namespace Todo.API.DTOs
{
    public class ListTitleDTO
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required List<ListItemDTO> ListItems { get; set; }

        public static ListTitleDTO MapToDTO(ListTitle listTitle)
        {
            var listItems = new List<ListItemDTO>();
            foreach (var item in listTitle.Items)
            {
                listItems.Add(ListItemDTO.MapToDTO(item));
            }

            return new ListTitleDTO
            {
                Id = listTitle.Id,
                Title = listTitle.Title,
                ListItems = listItems
            };
        }
    }
}
