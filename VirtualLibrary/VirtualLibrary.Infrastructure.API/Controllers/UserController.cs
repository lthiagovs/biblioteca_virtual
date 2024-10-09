using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Infrastructure.API.Interfaces;

namespace VirtualLibrary.Infrastructure.API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }


    }
}
