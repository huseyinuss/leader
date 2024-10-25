public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(string username)
    {
        return await _userRepository.CreateUserAsync(username);
    }

    public async Task<User> UpdateProgressAsync(string userId, int levels)
    {
        return await _userRepository.UpdateProgressAsync(userId, levels);
    }

    public async Task<User> GetUserAsync(string userId)
    {
        return await _userRepository.GetUserAsync(userId);
    }
}