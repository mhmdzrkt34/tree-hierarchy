using System.ComponentModel.DataAnnotations;

namespace binaryTree.models
{
    public class Category
    {
        [Key]
        public string id {  get; set; }

        public string name { get; set; }

        public List<Category> subCategories { get; set; }


     


        public Category? parentCategory { get; set; }


        public string? parent_id { get; set; }

   

        public DateTime time { get; set; }


        public Category()
        {

            id=Guid.NewGuid().ToString();
            time = DateTime.UtcNow;
        }
    }
}
