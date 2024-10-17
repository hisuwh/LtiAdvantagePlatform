namespace LtiAdvantagePlatform.Data;

using Microsoft.AspNetCore.Identity;

public class AdvantagePlatformUser : IdentityUser
{
    public Course Course { get; set; }
    
    public Platform Platform { get; set; }
    
    public ICollection<Person> People { get; set; }
    
    public ICollection<Tool> Tools { get; set; }
}
