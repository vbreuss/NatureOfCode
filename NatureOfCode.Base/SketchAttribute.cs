namespace NatureOfCode.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SketchAttribute : Attribute
    {
        public string? Description { get; set; }
    }
}
