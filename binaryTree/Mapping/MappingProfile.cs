using AutoMapper;
using binaryTree.DTOS;
using binaryTree.models;

namespace binaryTree.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Category, CategoryDto>();
        }
    }
}
