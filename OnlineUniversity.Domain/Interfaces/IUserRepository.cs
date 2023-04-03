using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Create(IdentityUser user);
        IdentityUser GetById(string id);
    }
}
