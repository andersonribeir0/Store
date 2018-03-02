using System.Threading.Tasks;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;

namespace Store.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersResult(string document);
        GetByIdQueryResult GetById(string id);
    }
}