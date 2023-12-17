using System.ComponentModel.DataAnnotations;

namespace WebFlightInfrastructure.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}