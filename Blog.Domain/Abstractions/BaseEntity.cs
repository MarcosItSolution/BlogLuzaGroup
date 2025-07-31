using System.Text.Json.Serialization;

namespace Blog.Internal.Domains.Core.Abstractions
{
    public abstract class BaseEntity
    {
        public readonly DateTime AppDateTimeNow = DateTime.UtcNow;

        public bool Active { get; private set; } = true;

        [JsonIgnore]
        public int CreatedUser { get; private set; }

        [JsonIgnore]
        public int UpdatedUser { get; private set; }

        [JsonIgnore]
        public int? DeletedUser { get; private set; } = null;
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; } = null;
        [JsonIgnore]
        public bool Deleted { get; private set; } = false;

        public void SetTimeZone(byte utc = 0)
        {
            AppDateTimeNow.AddHours(utc);
        }

        public bool IsValid()
        {
            // Todo: Implementar logica generica de validação
            return true;
        }

        public void IsActive(bool value = true)
        {
            Active = value;
        }

        public void Create()
        {
            CreatedDate = AppDateTimeNow;
            UpdatedDate = CreatedDate;
        }

        public void Create(int value)
        {
            CreatedUser = value;
            UpdatedUser = value;
            CreatedDate = AppDateTimeNow;
            UpdatedDate = CreatedDate;
        }

        public void Update()
        {
            UpdatedDate = AppDateTimeNow;
        }

        public void Update(int value)
        {
            UpdatedUser = value;
            UpdatedDate = AppDateTimeNow;
        }

        public void Delete()
        {
            DeletedDate = AppDateTimeNow;
            Deleted = true;
        }

        public void Delete(int value)
        {
            DeletedUser = value;
            DeletedDate = AppDateTimeNow;
            Deleted = true;
        }

         public void DeleteRestore(int value)
        {
            DeletedUser = null;
            DeletedDate = null;
            Deleted = false;

            Update(value);
        }

    }
}

