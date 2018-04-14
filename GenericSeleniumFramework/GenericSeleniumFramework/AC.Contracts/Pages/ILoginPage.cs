using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The login page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface ILoginPage : IPageBase
    {
        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void LoginUser(UserLogin user);

        /// <summary>
        /// Gets the alert box message.
        /// </summary>
        /// <returns></returns>
        string GetAlertBoxMessage();
    }
}