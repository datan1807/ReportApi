namespace Api.Global
{
    public static class Constants
    {
        public class Role
        {
            public const int ADMIN = 1;
            public const int STAFF = 2;
            public const int TEACHER = 3;
            public const int STUDENT = 4;
        }
        public class STATUS
        {
            public static string ACTIVE = "Active";
            public static string INACTIVE = "Inactive";
            public static string SUCCESS = "success";
            public static string FAILURE = "fail";
            public static string ERROR = "error";
        }
    }
}
