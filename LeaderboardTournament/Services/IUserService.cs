public interface IUserService
{
    Task<User> CreateUserAsync(string username);
    Task<User> UpdateProgressAsync(string userId, int levels);
    Task<User> GetUserAsync(string userId);
}