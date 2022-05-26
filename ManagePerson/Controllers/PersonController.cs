using ManagePerson.Commands;
using ManagePerson.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ManagePerson.Controllers
{
    public class PersonController : BaseController
    { 
        [HttpGet("/person/{Email}")]
        public async Task<IActionResult> GetPersonByEmail(string Email) => Ok(await Mediator.Send(new GetPersonByEmail(Email)));

        [HttpPost(nameof(UpdateFamily))]
        public async Task<IActionResult> UpdateFamily(UpdateFamilyById command) => Ok(await Mediator.Send(command));

    }
}