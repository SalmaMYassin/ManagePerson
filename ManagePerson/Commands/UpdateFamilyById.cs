using Dapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ManagePerson.Commands
{
    public class UpdateFamilyById : IRequest<int>
    {
        public Guid personId { get; set; }

        [Required]
        public string Family { get; set; }

        public class UpdateFamilyByIdHandler : IRequestHandler<UpdateFamilyById, int>
        {
            private readonly IConfiguration configuration;
            public UpdateFamilyByIdHandler(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<int> Handle(UpdateFamilyById command, CancellationToken cancellationToken)
            {
                var sql = "Update dbo.HumanNames set Family = @Family Where PersonId = @PersonId";
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return result;
                    }
                
            }
        }
    }
}