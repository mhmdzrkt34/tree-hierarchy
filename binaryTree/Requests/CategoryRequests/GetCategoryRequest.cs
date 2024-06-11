using System.ComponentModel.DataAnnotations;

namespace binaryTree.Requests.CategoryRequests
{
    public class GetCategoryRequest
    {
        [Required]
        public string CategoryId { get; set; }
    }
}
