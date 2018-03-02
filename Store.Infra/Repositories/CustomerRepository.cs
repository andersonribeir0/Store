using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.ValueObjects;
using Store.Infra.StoreContext.DataContexts;

namespace Store.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDataContext _context;

        public CustomerRepository(StoreDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context.Connection.QueryAsync<bool>("spCheckDocument", new {Document = document},
                commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.Connection
                .QueryAsync<bool>("spCheckEmail", new {Email = email}, commandType: CommandType.StoredProcedure)
                .Result.FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer", new
            {
                customer.Id,
                customer.Name.FirstName,
                customer.Name.LastName,
                Email = customer.Email.Address,
                Document = customer.Document.Number,
                customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.ExecuteAsync("spCreateAddress", new
                {
                    address.Id,
                    CustomerId = customer.Id,
                    address.Number,
                    address.Complement,
                    address.District,
                    address.City,
                    address.Country,
                    address.State,
                    address.Street,
                    address.Type,
                    address.ZipCode,
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public CustomerOrdersCountResult GetCustomerOrdersResult(string document)
        {
            return _context.Connection.QueryAsync<CustomerOrdersCountResult>(@"SELECT Id, FirstName, LastName, Document, count(*) FROM Customer c INNER JOIN Order o ON o.CustomerId = c.Id WHERE c.Document = @document", new
            {
                Document = document
            }).Result.FirstOrDefault();
        }

        public GetByIdQueryResult GetById(string id)
        {
            return _context.Connection.QueryAsync<GetByIdQueryResult>(@"SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Document], [Email] FROM [Customer] WHERE [Id]=@id", new
            {
                id = id
            }).Result.FirstOrDefault();
        }
    }
}