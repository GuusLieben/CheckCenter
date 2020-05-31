using System;
using System.Collections.Generic;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CheckCenter.ApplicationInterface.Identity
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/session")]
    public class IdentityController : ControllerBase {
        private static readonly List<string> SessionsAlive = new List<string>();

        private readonly IIdentityRepository _identityRepository;
        
        public IdentityController(IIdentityRepository identityRepository) {
            _identityRepository = identityRepository;
        }

        [HttpPost("auth")]
        public ActionResult Login([FromBody] User user) {
            if (_identityRepository.ValidateLogin(user)) {
                var token = _identityRepository.CreateToken(user);
                return Ok(new { token });
            }

            return Ok();
        }
        
        [HttpPost]
        public ActionResult SessionCheckin([FromQuery] string user) {
            if (!(SessionsAlive.Contains(user))) SessionsAlive.Add(user);
            return Ok();
        }

        [HttpDelete]
        public ActionResult SessionCheckout([FromQuery] string user)
        {
            SessionsAlive.Remove(user);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetActiveUsers()
        {
            var users = new List<User>();
            SessionsAlive.ForEach(u => {
                var user = _identityRepository.GetUser(u);
                user.Password = null;
                users.Add(user);
            });
            return Ok(users);
        }
    }
}
