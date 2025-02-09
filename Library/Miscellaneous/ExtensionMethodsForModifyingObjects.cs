namespace Library.Miscellaneous
{
    public static class ExtensionMethodsForModifyingObjects
    {
        public static T With<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
    }
}
