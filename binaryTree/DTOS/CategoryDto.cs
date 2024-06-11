using binaryTree.models;

namespace binaryTree.DTOS
{
    public class CategoryDto
    {
        public string id { get; set; }

        public string name { get; set; }

        public List<CategoryDto> subCategories { get; set; }





        


        public string? parent_id { get; set; }



        public DateTime time { get; set; }
    }
}
