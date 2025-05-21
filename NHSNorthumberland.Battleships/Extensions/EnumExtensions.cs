using System.Reflection;

namespace NHSNorthumberland.Battleships.Extensions
{
    internal static class EnumExtensions
    {
        public static T? GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memberInfo = type.GetMember(enumVal.ToString());
            return memberInfo.First().GetCustomAttribute<T>();
        }
    }
}
