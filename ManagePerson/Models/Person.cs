namespace ManagePerson.Models;

public class Person
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }
    public string? Name { get; set; }

    public string? Family { get; set; }

    public string? Given { get; set; }

    public string? Gender { get; set; }

    public bool IsAdult { get; set; }

    public bool IsArchive { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

}
