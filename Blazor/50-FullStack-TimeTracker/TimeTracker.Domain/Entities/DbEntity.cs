namespace TimeTracker.Domain.Entities
{
    public abstract class DbEntity
    {
        private int id;
        private DateTime dateCreated = DateTime.Now;
        private DateTime? dateLastUpdated;

        public virtual int Id
        {
            get => id;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Id must be greater than 0");
                }
                id = value;
            }
        }
        public virtual DateTime DateCreated 
        {
            get => dateCreated;
            set
            {
                dateCreated = value;
            }
        }
        public virtual DateTime? DateLastUpdated 
        { 
            get => dateLastUpdated;
            set
            {
                if (value < DateCreated)
                {
                    throw new Exception("DateLastUpdated must happen after DateCreated");
                }

                dateLastUpdated = value;
            }
        }
        public virtual bool IsSoftDeleted { get; set; }
        public virtual DateTime DateSoftDeleted { get; set; }
    }
}
