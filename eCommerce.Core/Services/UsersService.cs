using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository,
        IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null) {
            return null;
        }

        //return new AuthenticationResponse(
        //    user.UserID, user.Email, user.PersonName, user.Gender, "token", true);
        return _mapper.Map<AuthenticationResponse>(user) with { Token = "token", Success = true };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //ApplicationUser? user = new ()
        //{
        //    Email = registerRequest.Email,
        //    Password = registerRequest.Password,
        //    PersonName = registerRequest.PersonName,
        //    Gender = registerRequest.Gender.ToString(),
        //};

        ApplicationUser? user = _mapper.Map<ApplicationUser>(registerRequest);

        ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

        if (registeredUser == null)
        {
            return null;
        }

        //return new AuthenticationResponse(
        //    registeredUser.UserID, 
        //    registeredUser.Email, 
        //    registeredUser.PersonName, 
        //    registeredUser.Gender, 
        //    "token", 
        //    true);
        return _mapper.Map<AuthenticationResponse>(user) with { Token = "token", Success = true };
    }
}
