
using Microsoft.Build.Framework.Profiler;
using Presentation.Data.Entities;
using Presentation.Data.Repositories;
using Presentation.Models;

namespace Presentation.Services;

public interface IAccountProfileService
{
    Task<ProfileResult> CreateProfileAsync(CreateProfileRequest request);
    Task<ProfileResult<Profile?>> GetProfileAsync(string profileId);
    Task<ProfileResult<IEnumerable<Profile>>> GetProfilesAsync();
}

public class AccountProfileService(IProfileRepository profileRepository) : IAccountProfileService
{
    private readonly IProfileRepository _profileRepository = profileRepository;

    public async Task<ProfileResult> CreateProfileAsync(CreateProfileRequest request)
    {
        try
        {
            var profileEntity = new ProfileEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            var result = await _profileRepository.AddAsync(profileEntity);
            return result.Success
                    ? new ProfileResult { Success = true }
                    : new ProfileResult { Success = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new ProfileResult { Success = false, Error = ex.Message };
        }
    }
    public async Task<ProfileResult<IEnumerable<Profile>>> GetProfilesAsync()
    {
        var result = await _profileRepository.GetAllAsync();
        var profiles = result.Result?.Select(x => new Profile
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
        });
        return new ProfileResult<IEnumerable<Profile>> { Success = true, Result = events };
    }

    public async Task<ProfileResult<Profile?>> GetProfileAsync(string profileId)
    {
        var result = await _profileRepository.GetAsync(x => x.Id == profileId);
        if (result.Success && result.Result != null)
        {
            var currentProfile = new Profile
            {
                Id = result.Result.Id,
                FirstName = result.Result.FirstName,
                LastName = result.Result.LastName,
            };
            return new ProfileResult<Profile?> { Success = true, Result = currentProfile };
        }
        return new ProfileResult<Profile?> { Success = false, Error = result.Error };
    }

}
