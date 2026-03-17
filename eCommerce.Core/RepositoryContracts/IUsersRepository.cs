using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Contract to be implemented by UserRepositiry that contains data access logic of Users data in the database.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a user to the database and return same user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);


    /// <summary>
    /// Method to return existing user by their email and password, if not found then return null
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
}
