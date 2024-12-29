namespace MetalArchivesApi.Model;

public enum ReleaseType
{
    Demo,
    [EnumString("Full-length")]
    Fulllength,
    Single,
    Video,
    Split,
    Collaboration,
    Live,
    Compilation,
    BoxedSet,
    EP,
    [EnumString("Split video")]
    Splitvideo,


}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
sealed class EnumStringAttribute : Attribute
{
    public string StringValue { get; }

    public EnumStringAttribute(string stringValue)
    {
        StringValue = stringValue;
    }
}
