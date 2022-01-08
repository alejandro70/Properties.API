using Properties.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Properties.Model.Services
{
    public interface IUnitOfWork
    {
        IRepository<Property> Properties { get; }
        IRepository<Owner> Owners { get; }
        IRepository<PropertyImage> PropertyImages { get; }
        IRepository<PropertyTrace> PropertyTraces { get; }
        Task CommitAsync();
    }
}
