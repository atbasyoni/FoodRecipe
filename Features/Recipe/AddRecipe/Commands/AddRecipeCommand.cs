using MediatR;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;

namespace FoodRecipe.Features.Recipe.Add_Recipe.Commands
{
    public record AddRecipeCommand(AddRecipeDTO AddRecipeDTO) : IRequest<ResultDTO>;
    public class AddRecipeCommandHandler : BaseRequestHandler<Data.Models.Recipe, AddRecipeCommand, ResultDTO>
    {
        public AddRecipeCommandHandler(RequestParameters<Data.Models.Recipe> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = request.AddRecipeDTO.MapOne<Data.Models.Recipe>();
            await _repository.AddAsync(recipe);

            return ResultDTO.Success(recipe);
        }
    }
}
