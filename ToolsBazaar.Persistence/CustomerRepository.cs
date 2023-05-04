using System.Net;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Persistence.ErrorHandling;

namespace ToolsBazaar.Persistence
{
public class CustomerRepository : ICustomerRepository
{
    public IEnumerable<Customer> GetAll() => DataSet.AllCustomers;

    public void UpdateCustomerName(int customerId, string name)
    {
        var customer = DataSet.AllCustomers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            throw new HttpNotFoundException(HttpStatusCode.NotFound, string.Format("Customer not found with ID = {0}", customerId));
        }

        customer.UpdateName(name);
    }
}
}