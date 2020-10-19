using UYK.Core.Entities;

namespace UYK.Model
{
    public class About : Entity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string image { get; set; }
    }
}
