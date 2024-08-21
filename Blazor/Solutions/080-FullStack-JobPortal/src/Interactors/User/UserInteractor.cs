using DataAccess;
using ErrorOr;

namespace Interactors.User;

public sealed class UserInteractor(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;

    public async Task<List<Domain.Models.User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync() ?? [];
    }

    public async Task<ErrorOr<Domain.Models.User>> GetUserByIdAsync(int id)
    {
         Domain.Models.User? user = await _userRepository.GetUserByIdAsync(id);
        if (user is null)
        {
            return Error.NotFound($"User with id {id} does not exist.");
        }
        return user;
    }

    public async Task<ErrorOr<bool>> CreateUserAsync(Domain.Models.User user)
    {
        try
        {
            await _userRepository.CreateUserAsync(user);
            return true;
        }
        catch (Exception e)
        {
            return Error.Failure(e.Message);
        }
    }

    public async Task<ErrorOr<bool>> UpdateUserByIdAsync(Domain.Models.User user)
    {
        try
        {
            await _userRepository.UpdateUserByIdAsync(user);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }

    public async Task<ErrorOr<bool>> DeleteUserByIdAsync(int id)
    {
        try
        {
            await _userRepository.DeleteUserByIdAsync(id);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }
}
