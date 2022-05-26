using Dapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ManagePerson.Commands
{
    public class UpdateGivenById : IRequest<int>
    {
        public Guid personId { get; set; }

        [Required]
        public string Given { get; set; }

        public class UpdateGivenByIdHandler : IRequestHandler<UpdateGivenById, int>
        {
            private readonly IConfiguration configuration;
            public UpdateGivenByIdHandler(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<int> Handle(UpdateGivenById command, CancellationToken cancellationToken)
            {
                var sql = "Update dbo.HumanNames set Given = @Given Where PersonId = @PersonId";
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