﻿using System.Threading.Tasks;

namespace Blog.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
