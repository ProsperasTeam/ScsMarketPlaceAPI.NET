namespace Lenders.Common
{
    public static class Extensions
    {        
        public static bool IsNullOrDefault<T>(this T value)
        {
            return object.Equals(value, default(T));
        }        
    }
}
