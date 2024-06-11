using System.ComponentModel.DataAnnotations;

namespace binaryTree.Requests.CategoryRequests
{
    public class AddCategoryRequest
    {

        public string? parent_id {  get; set; }
        [Required]
        public string name { get; set; }



    }
}
