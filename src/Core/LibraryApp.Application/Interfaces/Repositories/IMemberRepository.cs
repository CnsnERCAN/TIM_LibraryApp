using LibraryApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Repositories
{
    public interface IMemberRepository : IGenericRepositoryAsync<Member>
    {
    }
}
