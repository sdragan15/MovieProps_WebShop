using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.User
{
    public class FacebookUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public FacebookPicture Picture { get; set; }
    }

    public class FacebookPicture
    {
        public FacebookPictureData Data { get; set; }
    }

    public class FacebookPictureData
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }
    }
}
