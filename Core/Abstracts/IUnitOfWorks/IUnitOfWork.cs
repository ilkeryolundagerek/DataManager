using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IUnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task CommitAsync();
    }
}
