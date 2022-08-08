using Shared;

namespace ResponseAPI.Service
{
    public class ResponseService
    {
        public async Task<PasswordResponse> GeneratePassword(PasswordRequest passwordRequest)
        {
            string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercaseLetters = "abcdefghijklmnopqrstyvwxyz";
            string numbers = "0123456789";
            string specialCharacters = "!?#$%&*+-/<=>@()[]{}|~";

            string passwordPool = null;
            string password = null;

            if (passwordRequest.Uppercase == true)
                passwordPool += uppercaseLetters;
            if (passwordRequest.Lowercase == true)
                passwordPool += lowercaseLetters;
            if (passwordRequest.Numbers == true)
                passwordPool += numbers;
            if (passwordRequest.SpecialCharacters == true)
                passwordPool += specialCharacters;

            Random random = new Random();

            if (passwordPool != null)
            {
                for (var i = 0; i < passwordRequest.Length; i++)
                {
                    password += passwordPool[random.Next(passwordPool.Length)];
                }
            }

            return new PasswordResponse
            {
                Password = password,
                Length = passwordRequest.Length,
                Uppercase = passwordRequest.Uppercase,
                Lowercase = passwordRequest.Lowercase,
                Numbers = passwordRequest.Numbers,
                SpecialCharacters = passwordRequest.SpecialCharacters
            };
        }
    }
}
