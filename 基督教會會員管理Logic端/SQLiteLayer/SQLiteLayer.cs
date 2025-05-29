using System.Data.SQLite;
using ChristianChurchMemberDAL.SQLiteDapper;
using Dapper;

namespace ChristianChurchMemberLogic.SQLiteLayer
{
    internal class SQLiteLayer
    {
        private readonly string _connectionString;

        public SQLiteLayer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        // ACTIVITYBASIS CRUD Operations
        public IEnumerable<ActivityBasis> GetAllActivityBasis()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<ActivityBasis>("SELECT * FROM ACTIVITYBASIS");
            }
        }

        public ActivityBasis GetActivityBasisById(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<ActivityBasis>("SELECT * FROM ACTIVITYBASIS WHERE ACTIVITYID = @Id", new { Id = id });
            }
        }

        public void InsertActivityBasis(ActivityBasis activity)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO ACTIVITYBASIS (ACTIVITYSETTINGID, STARTDATETIME, ENDDATETIME, TEACHER) VALUES (@ACTIVITYSETTINGID, @STARTDATETIME, @ENDDATETIME, @TEACHER)", activity);
            }
        }

        public void UpdateActivityBasis(ActivityBasis activity)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE ACTIVITYBASIS SET ACTIVITYSETTINGID = @ACTIVITYSETTINGID, STARTDATETIME = @STARTDATETIME, ENDDATETIME = @ENDDATETIME, TEACHER = @TEACHER WHERE ACTIVITYID = @ACTIVITYID", activity);
            }
        }

        public void DeleteActivityBasis(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM ACTIVITYBASIS WHERE ACTIVITYID = @Id", new { Id = id });
            }
        }

        // ACTIVITY_SETTING CRUD Operations
        public IEnumerable<ActivitySetting> GetAllActivitySettings()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<ActivitySetting>("SELECT * FROM ACTIVITY_SETTING");
            }
        }

        public ActivitySetting GetActivitySettingById(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<ActivitySetting>("SELECT * FROM ACTIVITY_SETTING WHERE ACTIVITYSETTINGID = @Id", new { Id = id });
            }
        }

        public void InsertActivitySetting(ActivitySetting setting)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO ACTIVITY_SETTING (NAME, IS_RECURRING, HOLDDAY, START_TIME, END_TIME) VALUES (@NAME, @IS_RECURRING, @HOLDDAY, @START_TIME, @END_TIME)", setting);
            }
        }

        public void UpdateActivitySetting(ActivitySetting setting)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE ACTIVITY_SETTING SET NAME = @NAME, IS_RECURRING = @IS_RECURRING, HOLDDAY = @HOLDDAY, START_TIME = @START_TIME, END_TIME = @END_TIME WHERE ACTIVITYSETTINGID = @ACTIVITYSETTINGID", setting);
            }
        }

        public void DeleteActivitySetting(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM ACTIVITY_SETTING WHERE ACTIVITYSETTINGID = @Id", new { Id = id });
            }
        }

        // GROUPMEMBERS CRUD Operations
        public IEnumerable<GroupMembers> GetAllGroupMembers()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<GroupMembers>("SELECT * FROM GROUPMEMBERS");
            }
        }

        public GroupMembers GetGroupMemberByIds(string groupId, string memberId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<GroupMembers>("SELECT * FROM GROUPMEMBERS WHERE GROUPID = @GroupId AND MEMBERID = @MemberId", new { GroupId = groupId, MemberId = memberId });
            }
        }

        public void InsertGroupMember(GroupMembers member)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO GROUPMEMBERS (GROUPID, MEMBERID, JOINDATE, GROUPMEMBERLEVEL) VALUES (@GROUPID, @MEMBERID, @JOINDATE, @GROUPMEMBERLEVEL)", member);
            }
        }

        public void UpdateGroupMember(GroupMembers member)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE GROUPMEMBERS SET JOINDATE = @JOINDATE, GROUPMEMBERLEVEL = @GROUPMEMBERLEVEL WHERE GROUPID = @GROUPID AND MEMBERID = @MEMBERID", member);
            }
        }

        public void DeleteGroupMember(string groupId, string memberId)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM GROUPMEMBERS WHERE GROUPID = @GroupId AND MEMBERID = @MemberId", new { GroupId = groupId, MemberId = memberId });
            }
        }

        // GROUPS CRUD Operations
        public IEnumerable<Groups> GetAllGroups()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Groups>("SELECT * FROM GROUPS");
            }
        }

        public Groups GetGroupById(string id)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<Groups>("SELECT * FROM GROUPS WHERE GROUPID = @Id", new { Id = id });
            }
        }

        public void InsertGroup(Groups group)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO GROUPS (GROUPID, GROUPNAME, GROUPMANAGER) VALUES (@GROUPID, @GROUPNAME, @GROUPMANAGER)", group);
            }
        }

        public void UpdateGroup(Groups group)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE GROUPS SET GROUPNAME = @GROUPNAME, GROUPMANAGER = @GROUPMANAGER WHERE GROUPID = @GROUPID", group);
            }
        }

        public void DeleteGroup(string id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM GROUPS WHERE GROUPID = @Id", new { Id = id });
            }
        }

        // MEMBERS CRUD Operations
        public IEnumerable<Members> GetAllMembers()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Members>("SELECT * FROM MEMBERS");
            }
        }

        public Members GetMemberById(string id)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<Members>("SELECT * FROM MEMBERS WHERE MEMBERID = @Id", new { Id = id });
            }
        }

        public void InsertMember(Members member)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO MEMBERS (MEMBERID, MEMBERNAME, BIRTHDAY, ZIPCODE, HOMEADDRESS, HOMETEL, MOBILETEL, EMAIL, BELIEFSTATUS, LOGINPASSWORD, SEX) VALUES (@MEMBERID, @MEMBERNAME, @BIRTHDAY, @ZIPCODE, @HOMEADDRESS, @HOMETEL, @MOBILETEL, @EMAIL, @BELIEFSTATUS, @LOGINPASSWORD, @SEX)", member);
            }
        }

        public void UpdateMember(Members member)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE MEMBERS SET MEMBERNAME = @MEMBERNAME, BIRTHDAY = @BIRTHDAY, ZIPCODE = @ZIPCODE, HOMEADDRESS = @HOMEADDRESS, HOMETEL = @HOMETEL, MOBILETEL = @MOBILETEL, EMAIL = @EMAIL, BELIEFSTATUS = @BELIEFSTATUS, LOGINPASSWORD = @LOGINPASSWORD, SEX = @SEX WHERE MEMBERID = @MEMBERID", member);
            }
        }

        public void DeleteMember(string id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM MEMBERS WHERE MEMBERID = @Id", new { Id = id });
            }
        }

        // STATUSES CRUD Operations
        public IEnumerable<Statuses> GetAllStatuses(string ItemCategoryName = "")
        {
            using (var connection = GetConnection())
            {
                if (string.IsNullOrEmpty(ItemCategoryName))
                {
                    return connection.Query<Statuses>("SELECT * FROM STATUSES");
                }
                return connection.Query<Statuses>("SELECT * FROM STATUSES WHERE ITEMNAME = @ItemCategoryName", new { ItemCategoryName });
            }
        }

        public Statuses? GetStatusByIds(string itemName, string itemValue)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<Statuses>("SELECT * FROM STATUSES WHERE ITEMNAME = @ItemName AND ITEMVALUE = @ItemValue", new { ItemName = itemName, ItemValue = itemValue });
            }
        }

        public void InsertStatus(Statuses status)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO STATUSES (ITEMNAME, ITEMVALUE, ITEMDESCRIPTION, ADMINPOWER) VALUES (@ITEMNAME, @ITEMVALUE, @ITEMDESCRIPTION, @ADMINPOWER)", status);
            }
        }

        public void UpdateStatus(Statuses status)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE STATUSES SET ITEMDESCRIPTION = @ITEMDESCRIPTION, ADMINPOWER = @ADMINPOWER WHERE ITEMNAME = @ITEMNAME AND ITEMVALUE = @ITEMVALUE", status);
            }
        }

        public void DeleteStatus(string itemName, string itemValue)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM STATUSES WHERE ITEMNAME = @ItemName AND ITEMVALUE = @ItemValue", new { ItemName = itemName, ItemValue = itemValue });
            }
        }
    }
}
