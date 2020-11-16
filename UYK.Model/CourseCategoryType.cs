using UYK.Core.Entities;

namespace UYK.Model
{
    public class CourseCategoryType : Entity<int>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
