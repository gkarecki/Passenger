using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository,IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new Exception("Invalid credentials");
            }
            
            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(Guid userId,string email, string username, string fullName, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: '{email} already exists.");
            }
            
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            user = new User(userId, email, username, fullName, hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}
