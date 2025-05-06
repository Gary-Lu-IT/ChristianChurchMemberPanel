namespace ChristianChurchMemberDAL.SQLiteDapper
{
    /// <summary>
    /// 活動資料
    /// </summary>
    public class ActivityBasis
    {
        /// <summary>
        /// 活動ID
        /// </summary>
        public int ACTIVITYID { get; set; }
        /// <summary>
        /// 活動資料設定ID
        /// </summary>
        public int ACTIVITYSETTINGID { get; set; }
        /// <summary>
        /// 開始日期時間
        /// </summary>
        public DateTime STARTDATETIME { get; set; }
        /// <summary>
        /// 結束日期時間
        /// </summary>
        public DateTime ENDDATETIME { get; set; }
        /// <summary>
        /// 主持人或講員
        /// </summary>
        public string TEACHER { get; set; } = string.Empty;
    }
    /// <summary>
    /// 活動資料設定
    /// </summary>
    public class ActivitySetting
    {
        /// <summary>
        /// 活動設定ID
        /// </summary>
        public int ACTIVITYSETTINGID { get; set; }
        /// <summary>
        /// 活動名稱
        /// </summary>
        public string NAME { get; set; } = null!;
        /// <summary>
        /// 是否定期舉行 (ONCE:僅一次,DAILY:每日,WEEK:每周,MONTH:每月,YEAR:每年)
        /// </summary>
        public string IS_RECURRING { get; set; } = null!;
        /// <summary>
        /// 舉辦日(ONCE填完整日期,WEEK填入星期幾,MONTH填入日期,YEAR填入幾月幾日,DAILY不適用)
        /// </summary>
        public string HOLDDAY { get; set; } = null!;
        /// <summary>
        /// 開始時間
        /// </summary>
        public string START_TIME { get; set; } = null!;
        /// <summary>
        /// 結束時間
        /// </summary>
        public string END_TIME { get; set; } = null!;
    }
    /// <summary>
    /// 小組成員資料
    /// </summary>
    public class GroupMembers
    {
        /// <summary>
        /// 小組ID
        /// </summary>
        public string GROUPID { get; set; } = null!;
        /// <summary>
        /// 小組成員ID
        /// </summary>
        public string MEMBERID { get; set; } = null!;
        /// <summary>
        /// 加入時間
        /// </summary>
        public DateTime JOINDATE { get; set; }
        /// <summary>
        /// 小組成員層級
        /// </summary>
        public int GROUPMEMBERLEVEL { get; set; }
    }
    /// <summary>
    /// 小組資料
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// 小組ID
        /// </summary>
        public string GROUPID { get; set; } = null!;
        /// <summary>
        /// 小組名稱
        /// </summary>
        public string GROUPNAME { get; set; } = null!;
        /// <summary>
        /// 組長會員ID
        /// </summary>
        public string GROUPMANAGER { get; set; } = null!;
    }
    /// <summary>
    /// 會員資料
    /// </summary>
    public class Members
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        public string MEMBERID { get; set; } = null!;
        /// <summary>
        /// 會員姓名
        /// </summary>
        public string MEMBERNAME { get; set; } = null!;
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BIRTHDAY { get; set; }
        /// <summary>
        /// 住家郵遞區號
        /// </summary>
        public int? ZIPCODE { get; set; }
        /// <summary>
        /// 住家地址
        /// </summary>
        public string HOMEADDRESS { get; set; } = string.Empty;
        /// <summary>
        /// 住家電話
        /// </summary>
        public string HOMETEL { get; set; } = string.Empty;
        /// <summary>
        /// 手機號碼
        /// </summary>
        public string MOBILETEL { get; set; } = string.Empty;
        /// <summary>
        /// 電子郵件信箱
        /// </summary>
        public string EMAIL { get; set; } = string.Empty;
        /// <summary>
        /// 信仰層級
        /// </summary>
        public int BELIEFSTATUS { get; set; }
        /// <summary>
        /// 登入密碼
        /// </summary>
        public string LOGINPASSWORD { get; set; } = string.Empty;
        /// <summary>
        /// 性別 1男0女
        /// </summary>
        public int SEX { get; set; }
    }
    /// <summary>
    /// 狀態表
    /// </summary>
    public class Statuses
    {
        /// <summary>
        /// 狀態ID
        /// </summary>
        public string ITEMNAME { get; set; } = null!;
        /// <summary>
        /// 狀態值
        /// </summary>
        public string ITEMVALUE { get; set; } = null!;
        /// <summary>
        /// 狀態描述
        /// </summary>
        public string ITEMDESCRIPTION { get; set; } = null!;
        /// <summary>
        /// 套用此設定值的會員是否有系統管理員權限(部分類別不適用)
        /// </summary>
        public int ADMINPOWER { get; set; }
    }
}