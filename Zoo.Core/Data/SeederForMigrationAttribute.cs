using System;

namespace Zoo.Core.Data
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class SeederForMigrationAttribute : Attribute
    {
        public string MigrationName => MigrationType.Name;

        public Type MigrationType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SeederForMigrationAttribute(Type migrationType)
        {
            MigrationType = migrationType;
        }
    }
}