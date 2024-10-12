using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.Recipe.Add_Recipe.Commands;
using FoodRecipe.Features.Recipe.GetRecipeById;

namespace FoodRecipe.Features.Recipe.DeleteRecipe.Commands
{
    public record DeleteRecipeCommand(int id) : IRequest<ResultDTO>;
    public class DeleteRecipeCommandHandler : BaseRequestHandler<Data.Models.Recipe, DeleteRecipeCommand, ResultDTO>
    {
        public DeleteRecipeCommandHandler(RequestParameters<Data.Models.Recipe> requestParameters) : base(requestParameters)
        {
            
        }
        public override async Task<ResultDTO> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ResultDTO.Failure("Invalid RecipeID!");
            }

            _repository.Delete(request.id);
            return ResultDTO.Success("Deleted");
        }
    }
}
