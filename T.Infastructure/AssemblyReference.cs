using System.Reflection;

namespace T.Infastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assemply = typeof(AssemblyReference).Assembly;
    }
}