using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memory;

        public SampleDataAccess(IMemoryCache memory)
        {
            _memory = memory;
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new();

            output.Add(new EmployeeModel { FirstName = "Refaat", LastName = "Elabd", });
            output.Add(new EmployeeModel { FirstName = "Rabia", LastName = "Elabed", });
            output.Add(new EmployeeModel { FirstName = "Fatema", LastName = "Tarek", });

            Thread.Sleep(3000);
            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new();

            output.Add(new EmployeeModel { FirstName = "Refaat", LastName = "Elabd", });
            output.Add(new EmployeeModel { FirstName = "Rabia", LastName = "Elabed", });
            output.Add(new EmployeeModel { FirstName = "Fatema", LastName = "Tarek", });

            await Task.Delay(3000);
            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {

            List<EmployeeModel> output;
            output = _memory.Get<List<EmployeeModel>>("employee");
    
            if(output is null)
            {
                output = await GetEmployeesAsync();
                _memory.Set("employee", output, TimeSpan.FromMinutes(1));
            }

            return output;
        }
    }
}
