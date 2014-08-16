
namespace AgileZenApi.Models
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user name of the user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The email address of the user
        /// </summary>
        public string Email { get; set; }
    }
}
