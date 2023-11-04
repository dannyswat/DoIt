using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Core.Repositories;

public interface IUnitOfWork
{
    void BeginTransaction();

    void Commit();

    void Rollback();
}
