using ASPNETLab2.Models;

namespace ASPNETLab2.Services
{
    public class AboutMeService
    {
        private readonly IConfiguration _configuration;

        public AboutMeService (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AboutMe GetUserInfo()
        {
            var userInfo = new AboutMe
            {
                Name = _configuration["UserInfo:Name"],
                Age = int.Parse(_configuration["UserInfo:Age"]),
                Occupation = _configuration["UserInfo:Occupation"],
                Hobbie = _configuration["UserInfo:Hobbie"]
            };

            return userInfo;
        }
    }
}
