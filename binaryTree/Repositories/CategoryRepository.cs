using AutoMapper;
using binaryTree.data;
using binaryTree.DTOS;
using binaryTree.models;
using binaryTree.Requests.CategoryRequests;
using Microsoft.EntityFrameworkCore;

namespace binaryTree.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public CategoryRepository(AppDbContext context,IMapper mapper) {


            _context = context;
            _mapper = mapper;
                
                }
        public async  Task<Dictionary<string, object>> AddCategory(AddCategoryRequest request)
        {
            try
            {

                Category? category = await _context.Categories.Where(i => i.name == request.name).FirstOrDefaultAsync();


                if (category != null)
                {


                    return new Dictionary<string, object>
                    {

                        {"status","conflict" },
                        {"message","this category already exists" }
                    };
                }
                if (request.parent_id != null)
                {
                    Category parentCategory=await _context.Categories.Where(i => i.id == request.parent_id).FirstOrDefaultAsync();

                    if (parentCategory == null)
                    {

                        return new Dictionary<string, object>
                    {

                        {"status","not found" },
                        {"message","there is no parent  category with this id" }
                    };


                    }

                    await _context.Categories.AddAsync(new Category
                    {
                        name = request.name,
                        parent_id = request.parent_id,
                    });

                    await _context.SaveChangesAsync();

                    return new Dictionary<string, object>
                    {

                        {"status","success" },
                        {"message","CategoryAdded Success" }
                    };



                }

    
                    await _context.Categories.AddAsync(new Category
                    {
                        name = request.name,
                        parent_id = request.parent_id,
                    });

                    await _context.SaveChangesAsync();

                    return new Dictionary<string, object>
                    {

                        {"status","success" },
                        {"message","CategoryAdded Success" }
                    };


                


            }catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Dictionary<string, object>> GetCategory(GetCategoryRequest request)
        {
            try
            {

                Category? category = await _context.Categories.Include(i => i.subCategories).FirstOrDefaultAsync(j => j.id == request.CategoryId);

                if (category == null)
                {

                    return new Dictionary<string, object>()
                    {

                        {"status","not found" },

                        { "message","there is no category with this id"}
                    };
                }
                await LoadSubCategories(category);
                CategoryDto categorydto=_mapper.Map<CategoryDto>(category);


                    return new Dictionary<string, object>()
                    {

                        {"status","success" },

                        { "message",categorydto}
                    };




            }
            catch(Exception ex)
            {

                throw;
            }
        }

        private async Task LoadSubCategories(Category category)
        {
            foreach (var subCategory in category.subCategories)
            {
                await _context.Entry(subCategory).Collection(c => c.subCategories).LoadAsync();
                LoadSubCategories(subCategory);
            }
        }
    }
}
