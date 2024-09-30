namespace UserAccessWatcherSystem.Entities
{

    public class UserAccessData
    {
        public UserAccess[] data { get; set; }
    }

    public class UserAccess
    {
        public string username { get; set; }
        public DateTime access_date { get; set; }

        public UserAccess(string username, DateTime access_date)
        {
            this.username = username;
            this.access_date = access_date;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not UserAccess) return false;

            var other = obj as UserAccess;

            return username.Equals(other?.username);
        }

        public override int GetHashCode()
        {
            return username.GetHashCode();
        }

        public override string ToString()
        {
            return $"{username} - {access_date:dd/MM/yyyy HH:mm:ss}s";
        }
    }
}
