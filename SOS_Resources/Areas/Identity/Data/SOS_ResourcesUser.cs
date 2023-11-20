using Microsoft.AspNetCore.Identity;

namespace SOS_ResourcesUser.Areas.Identity.Data;

public class SOS_ResourcesUser : IdentityUser
{
    [PersonalData]
    public string? Name { get; set; }
    [PersonalData]
    public DateTime DOB { get; set; }
}