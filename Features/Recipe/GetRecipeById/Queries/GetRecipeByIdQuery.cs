using MediatR;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Repositories;

namespace FoodRecipe.Features.Recipe.GetRecipeById.Queries
{
    public record GetRecipeByIdQuery(int id) : IRequest<ResultDTO>;
    public class GetRecipeByIdQueryHandler : BaseRequestHandler<Data.Models.Recipe, GetRecipeByIdQuery, ResultDTO>
    {
        public GetRecipeByIdQueryHandler(RequestParameters<Data.Models.Recipe> requestParameters, IRepository<Data.Models.Recipe> repository) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ResultDTO.Failure("Invalid RecipeID!");
            }

            var recipe = await _repository.GetByIDAsync(request.id);
            var mappedRecipe = recipe.MapOne<RecipeReturnDTO>();
            return ResultDTO.Success(mappedRecipe);
        }
    }
}
