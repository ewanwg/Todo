using Todo.API.Entities;

namespace Todo.API.DTOs
{
    public class ListTitleMapper
    {
        public static ListTitleDTO MapToDTO(ListTitle listTitle)
        {
            var listItems = new List<ListItemDTO>();
            foreach (var item in listTitle.Items) 
            {
                listItems.Add(ListItemMapper.MapToDTO(item));
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
