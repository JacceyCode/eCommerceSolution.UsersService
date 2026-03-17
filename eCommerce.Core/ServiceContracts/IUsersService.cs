using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;


/// <summary>
/// Contract for users service that contains usecases for users
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle user login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle user registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
