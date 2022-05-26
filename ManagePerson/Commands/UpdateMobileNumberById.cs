using Dapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ManagePerson.Commands
{
    public class UpdateMobileById : IRequest<int>
    {
        public Guid personId { get; set; }

        [Required]
        public string Mobile { get; set; }

        public class UpdateMobileByIdHandler : IRequestHandler<UpdateMobileById, int>
        {
            private readonly IConfiguration configuration;
            public UpdateMobileByIdHandler(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<int> Handle(UpdateMobileById command, CancellationToken cancellationToken)
            {
                var sql = "Update dbo.ContactPoints set Value = @Mobile Where PersonId = @PersonId and System = 'Phone'";
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