using ChristianChurchMemberDAL.SQLiteDapper;

namespace ChristianChurchMemberLogic.SQLiteLayer
{
    /// <summary>SQLite資料庫進出對外API</summary>
    public class SQLiteGate
    {
        /// <summary>
        /// 取得SQLite資料庫連線字串
        /// </summary>
        /// <returns>SQLite資料庫連線字串</returns>
        private static string GetConnectionString()
        {
            return "Data Source=ChristianChurchMember.db;Version=3;";
        }
        #region STATUSES 系統自訂狀態
        /// <summary>取得系統自訂狀態</summary>
        /// <param name="ItemCategoryName">系統狀態值類別名</param>
        /// <returns></returns>
        public IEnumerable<Statuses> GetStatuses(string ItemCategoryName = "")
        {
            var db = new SQLiteLayer(GetConnectionString());
            return db.GetAllStatuses(ItemCategoryName);
        }
        /// <summary>新增系統自訂狀態</summary>
        /// <param name="status"></param>
        public void AddStatus(Statuses status)
        {
            var db = new SQLiteLayer(GetConnectionString());
            if(db.GetStatusByIds(status.ITEMNAME,status.ITEMVALUE) != null)
            {
                throw new ArgumentException("狀態已存在，請勿重複新增。", nameof(status));
            }
            db.InsertStatus(status);
        }
        #endregion
    }
}
