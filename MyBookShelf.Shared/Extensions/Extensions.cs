using System;

namespace MyBookShelf.Shared.Extensions
{
    internal static class Extensions
    {
        #region NotEmptyStringOrDBNull

        public static object NotEmptyStringOrDBNull(this string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return DBNull.Value;
            return data;
        }

        #endregion
    }
}
