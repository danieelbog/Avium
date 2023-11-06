namespace Web.App.Core.Web.Core.Models
{
    /// <summary>
    /// Base Model that contains a generic property that represents the ID.
    /// </summary>
    /// <remarks>
    /// All Entity Models that represent a database table should inherit from this class
    /// </remarks>
    /// <typeparam name="TId">The Type of the primary key</typeparam>
    public interface IModel<TId>
    {
        #region Public Properties

        /// <summary>
        /// The primary key property
        /// </summary>
        TId Id { get; set; }

        #endregion
    }
}
