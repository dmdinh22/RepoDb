﻿using System.Data;
using System.Data.Common;

namespace RepoDb.UnitTests.CustomObjects
{
    public class CustomDbCommand : DbCommand
    {
        public CustomDbCommand()
        {
            DbParameterCollection = new CustomDbParameterCollection();
        }
        public override string CommandText { get; set; }
        public override int CommandTimeout { get; set; }
        public override CommandType CommandType { get; set; }
        public override bool DesignTimeVisible { get; set; }
        public override UpdateRowSource UpdatedRowSource { get; set; }
        protected override DbConnection DbConnection { get; set; }
        protected override DbParameterCollection DbParameterCollection { get; }
        protected override DbTransaction DbTransaction { get; set; }
        public override void Cancel()
        {
        }
        public override int ExecuteNonQuery()
        {
            return default(int);
        }
        public override object ExecuteScalar()
        {
            return null;
        }
        public override void Prepare()
        {
        }
        protected override DbParameter CreateDbParameter()
        {
            return new CustomDbParameter();
        }
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return null;
        }
    }
}
