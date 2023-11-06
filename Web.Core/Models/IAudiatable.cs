using Web.Core.Models.User;

namespace Web.Core.Models
{
    /// <summary>
    /// An entity that keeps track of who created it and when as well
    /// as who updated it and when.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// The user that created the entity
        /// </summary>
        ApplicationUser CreatedBy { get; set; }

        /// <summary>
        /// When the entity was created
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The user that updated the entity
        /// </summary>
        ApplicationUser UpdatedBy { get; set; }

        /// <summary>
        /// When the entity was last updated
        /// </summary>
        DateTimeOffset UpdatedAt { get; set; }
    }
}
