using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http.HttpResults;
using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<JwtDTO?> Login(LoginRequestDTO request)
        {
            //TODO: Change to automapper

            User? user = await _userService.GetByUsername(request.Username);

            if (user != null)
            {

                //Hash password + salt using ID
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: request.Password,
                salt: BitConverter.GetBytes(user.Id),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

                if(user.Password.Equals(hashed)) 
                    return new JwtDTO(_jwtService.GenerateToken(user.Id, request.Username));

                return null;
            }

            return null;
        }

        public async Task<JwtDTO?> Register(RegisterRequestDTO request)
        {
            //TODO: Change to automapper

            User? user = new User(0, request.Username, request.Password, new List<Training>());

            int id = _userService.GetMaxId().Result + 1;
            user.Id = id;

            //Hash password + salt using ID
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: user.Password,
            salt: BitConverter.GetBytes(id),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            user.Password = hashed;

            user = await _userService.AddUser(user);

            if (user != null)
                return new JwtDTO(_jwtService.GenerateToken(user.Id, request.Username));
            else
                return null;
        }
    }
}
