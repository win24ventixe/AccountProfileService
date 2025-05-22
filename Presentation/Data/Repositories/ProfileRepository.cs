using Presentation.Data.Entities;

namespace Presentation.Data.Repositories;

public interface IProfileRepository : IBaseRepository<ProfileEntity>
{
}

public class ProfileRepository(DataContext context) : BaseRepository<ProfileEntity>(context), IProfileRepository
{  
}

