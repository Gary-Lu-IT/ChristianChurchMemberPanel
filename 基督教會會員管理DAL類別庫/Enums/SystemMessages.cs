using System.Reflection;

namespace ChristianChurchMemberDAL.Enums
{
    /// <summary>自訂訊息屬性</summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DataTypeAttribute : Attribute
    {
        public string Description { get; }

        public DataTypeAttribute(string description)
        {
            Description = description;
        }
    }
    /// <summary>統整過之系統訊息</summary>
    public enum SystemMessage
    {
        /// <summary>成功</summary>
        Success=1
    }
    /// <summary>Enum 擴充方法：取得 DataType 屬性的描述文字</summary>
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                DataTypeAttribute attribute =
                    (DataTypeAttribute)Attribute.GetCustomAttribute(field, typeof(DataTypeAttribute));

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }
            return value.ToString();
        }
    }

    /// <summary>本系統自訂錯誤</summary>
    public class ChurchMemberException : Exception
    {
        public SystemMessage ErrorCode { get; set; }

        /// <summary>錯誤碼</summary>
        public int Code => (int)ErrorCode;

        /// <summary>建構函式</summary>
        public ChurchMemberException(SystemMessage errorCode)
            : base(errorCode.GetDescription())  // 使用擴充方法取得訊息
        {
            ErrorCode = errorCode;
        }
    }
}