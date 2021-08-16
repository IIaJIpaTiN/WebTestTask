using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserList.Models;

namespace ReactTest.Models
{
    public static class UserConverter
    {
        public static User ToUser(UserFromClient userFromClien)
        {
            User user = new User();
            user.Id = userFromClien.Id;
            user.Mail = userFromClien.Mail;
            user.Name = userFromClien.Name;
            user.Password = userFromClien.Password;
            user.Birthday = userFromClien.Birthday;

            user.Image = new Byte[userFromClien.DateUrl.Length];
            var date = userFromClien.DateUrl.Split(',');
            user.Image = Convert.FromBase64String(FixBase64ForImage(date[1]));
            user.ImageHeader = date[0];

            return user;
        }

        public static UserFromClient ToClientUser(User user)
        {
            UserFromClient clientUser = new UserFromClient();
            clientUser.Id = user.Id;
            clientUser.Mail = user.Mail;
            clientUser.Name = user.Name;
            clientUser.Password = user.Password;
            clientUser.Birthday = user.Birthday;
            clientUser.DateUrl = user.ImageHeader + ',' + Convert.ToBase64String(user.Image);

            return clientUser;
        }

        private static string FixBase64ForImage(string image)
        {
            StringBuilder sbText = new StringBuilder(image, image.Length);
            sbText.Replace("\r\n", String.Empty);
            sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }
    }
}
