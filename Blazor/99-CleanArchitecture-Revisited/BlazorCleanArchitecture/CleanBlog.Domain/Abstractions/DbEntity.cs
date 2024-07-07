namespace CleanBlog.Domain.Abstractions
{
    public abstract class DbEntity
    {
        private int id;
        private DateTime? dateLastUpdated;

        public virtual int Id 
        {
            get => id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Id must be greater than 0");
                }

                id = value;
            }
        }

        public virtual DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual DateTime? DateLastUpdated 
        {
            get => dateLastUpdated;
            set
            {
                if (value < DateCreated)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), 
                        "The updated date must be after the creation date");
                }

                dateLastUpdated = value;
            }
        }

        public virtual bool IsSoftDeleted { get; set; }
    }
}
