using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interface
{
    public interface IRepository<T, T1> where T : class where T1 : Infrastructure.OperationDetails
    {
        IEnumerable<T> Read();
        T1 Create(T item);
        T1 Delete(int id);
        T1 Update(T item);
    }
}
