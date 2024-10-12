using MediatR;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Data.Models;
using FoodRecipe.Data.Repositories;

namespace FoodRecipe.Common
{
    public class RequestParameters <T> where T : BaseModel
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }
        public IRepository<T> Repository { get; set; }

        public RequestParameters(IMediator mediator,
            UserState userState
            , IRepository<T> repository
            )
        {
            Mediator = mediator;
            UserState = userState;
            Repository = repository;
        }
    }
}
