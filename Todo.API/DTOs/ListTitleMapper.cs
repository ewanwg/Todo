using Todo.API.Entities;

namespace Todo.API.DTOs
{
    public class ListTitleMapper
    {
        public static ListTitleDTO MapToDTO(ListTitle listTitle)
        {
            return new ListTitleDTO
            {
                Id = listTitle.Id,
                Title = listTitle.Title
            };
        }
    }
}
