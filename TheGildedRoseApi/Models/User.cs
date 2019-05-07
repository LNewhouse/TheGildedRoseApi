using System.Collections.Generic;

namespace TheGildedRoseApi.Models
{
    /// <summary>
    /// Information needed to document a user
    /// </summary>
    public class User
    {
        #region Properties

        public int AccountBalance { get; set; }

        public int UserId { get; set; }

        public UserLogin UserLogin { get; set; }

        #endregion
    }

    public static class UserExtensions
    {
        #region Public Properties

        /// <summary>
        /// Builds the Gilded Rose's sample user list
        /// </summary>
        /// <returns></returns>
        public static List<User> GenerateSampleUsers()
        {
            List<User> usersList = new List<User>();

            usersList.Add(new User { UserId = 1, UserLogin = new UserLogin { Username = "ValeeraSanguinar", Password = "BloodElf" }, AccountBalance = 1500 });

            usersList.Add(new User { UserId = 2, UserLogin = new UserLogin { Username = "UtherLightBringer", Password = "Paladin" }, AccountBalance = 25000 });

            usersList.Add(new User { UserId = 3, UserLogin = new UserLogin { Username = "Thrall", Password = "PoorOrc" }, AccountBalance = 5 });

            usersList.Add(new User { UserId = 4, UserLogin = new UserLogin { Username = "Test", Password = "password" }, AccountBalance = 5000000 });

            usersList.Add(new User { UserId = 5, UserLogin = new UserLogin { Username = "Test123", Password = "password123" }, AccountBalance = 0 });

            return usersList;
        }

        #endregion
    }
}
