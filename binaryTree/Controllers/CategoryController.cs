using binaryTree.Repositories;
using binaryTree.Requests.CategoryRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace binaryTree.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private readonly ICategoryRepository _categoryRepository;


        public CategoryController(ICategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;   
        }

        [HttpPost]


        public async Task<IActionResult> AddCategory(AddCategoryRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);
                }


                Dictionary<string,object> responce=await _categoryRepository.AddCategory(request);

                if (responce["status"] == "conflict")
                {

                    return BadRequest(409);
                }


                return Ok(responce);


            }catch (Exception ex)
            {

                return BadRequest(500);
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetCategory([FromQuery] GetCategoryRequest request)
        {


            try
            {if(!ModelState.IsValid) { 
                
                return BadRequest(ModelState);
                        
                        }





                Dictionary<string, object> responce = await _categoryRepository.GetCategory(request);

                return Ok(responce);


            }catch(Exception ex)
            {

                return BadRequest(500);
            }
        }

    }
}
