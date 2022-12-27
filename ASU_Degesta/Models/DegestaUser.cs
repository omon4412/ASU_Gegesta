using Microsoft.AspNetCore.Identity;

namespace ASU_Degesta.Models;

public class DegestaUser : IdentityUser
{
    public string? Name { get; set; }
    public string? Job { get; set; }
}