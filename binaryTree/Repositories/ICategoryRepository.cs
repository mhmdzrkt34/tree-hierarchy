using binaryTree.models;
using binaryTree.Requests.CategoryRequests;

namespace binaryTree.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Dictionary<string, object>> AddCategory(AddCategoryRequest request);

        public Task<Dictionary<string, object>> GetCategory(GetCategoryRequest request);
    }
}
