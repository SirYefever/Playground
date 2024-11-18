using System.Runtime.Serialization;

namespace Playground2.Entity;

public enum Gender
{
    [EnumMember( Value = "Male" )]
    Male,
    [EnumMember( Value = "Female" )]
    Female
}