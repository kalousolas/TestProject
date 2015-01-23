namespace TestData.Entities
{
    public class DBMain
    {
        private static NorthwindEntities __db;

        private static bool IsDbRefreshNeed { get; set; }

        public static NorthwindEntities DB
        {
            get
            {
                if (IsDbRefreshNeed)
                {
                    RefreshDbAllEntity();
                }
                return __db ?? (__db = new NorthwindEntities());
            }
        }

        public static void RefreshDbAllEntity()
        {
            __db = new NorthwindEntities();
            IsDbRefreshNeed = false;
        }
    }
}