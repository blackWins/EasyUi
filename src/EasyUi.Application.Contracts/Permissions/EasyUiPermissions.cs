namespace EasyUi.Permissions;

public static class EasyUiPermissions
{
    public const string GroupName = "EasyUi";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Tags
    {
        public const string Default = GroupName + ".Tags";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class TagAttribute
    {
        public const string Default = GroupName + ".TagAttribute";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
