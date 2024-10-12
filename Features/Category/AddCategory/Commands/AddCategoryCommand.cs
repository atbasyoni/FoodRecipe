using MediatR;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using FoodRecipe.Data.Repositories;

namespace FoodRecipe.Features.Category.AddCategory.Commands
{
    public record AddCategoryCommand(AddCategoryDTO AddCategoryDTO) : IRequest<ResultDTO>;

    public class AddCategoryCommandHandler : BaseRequestHandler<Data.Models.Category, AddCategoryCommand, ResultDTO>
    {
        public AddCategoryCommandHandler(RequestParameters<Data.Models.Category> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.AddCategoryDTO.MapOne<Data.Models.Category>();
            category = await _repository.AddAsync(category);

            return ResultDTO.Success(category);

        }
    }
}
