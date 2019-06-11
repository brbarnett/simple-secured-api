using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legacy.Platform.Core.Exceptions;

namespace Legacy.Platform.Api.Services
{
    public class ValuesService : IValuesService
    {
        private List<string> _values = new List<string> { "value0", "value1" };

        public void CreateValue(string value)
        {
            if(this._values.Contains(value)) throw new ConflictException("Created value must be unique");
            
            this._values.Add(value);
        }

        public IEnumerable<string> GetAllValues()
        {
            return this._values.ToList();
        }

        public string GetValueByIndex(int index)
        {
            var values = this._values.ToArray();
            if (index < 0 || index >= values.Length) throw new EntityNotFoundException($"Value does not exist at index {index}");

            return values[index];
        }
    }
}