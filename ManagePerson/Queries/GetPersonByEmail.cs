using Dapper;
using ManagePerson.Models;
using MediatR;
using System.Data.SqlClient;

namespace ManagePerson.Queries
{
    public record Response
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Given { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    };
    public class GetPersonByEmail: IRequest<Response>
    {
        private string email;

        public GetPersonByEmail(string email)
        {
            this.email = email;
        }

        
        public class GetPersonByEmailHandler : IRequestHandler<GetPersonByEmail, Response>
        {
            private readonly IConfiguration _configuration;
            public GetPersonByEmailHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<Response> Handle(GetPersonByEmail query, CancellationToken cancellationToken)
            {
                var sql = "SELECT HN.name AS Name, HN.family AS Family, HN.given AS Given, CP.value AS Email, PH.phone AS Phone "  
                            + "FROM dbo.Persons P "
                            + "JOIN dbo.ContactPoints CP "
                            + "ON P.Id = CP.PersonId "
                            + "JOIN(SELECT value as phone, PersonId "
                            + "FROM dbo.ContactPoints CP "
                            + "WHERE PersonId = (SELECT PersonId FROM dbo.ContactPoints "
                            + "WHERE value = @Email) and System = 'Phone') AS PH "
                            + "ON P.Id = PH.PersonId "
                            + "LEFT JOIN dbo.HumanNames HN on P.id = HN.PersonId "
                            + "WHERE CP.value = @Email; ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Person>(sql, new { Email = query.email });
                    var person = result.First();
                    return new Response { Name = person.Name , 
                        Family = person.Family,
                        Given=person.Given,
                        Email=person.Email,
                        Phone=person.Phone};
                    //return result.First();
                    
                }
            }
        }
    }
}
