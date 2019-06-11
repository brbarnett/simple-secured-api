using System.Collections.Generic;
using System.Threading.Tasks;

namespace Legacy.Platform.Api.Services
{
    public interface IValuesService
    {
        void CreateValue(string value);

        IEnumerable<string> GetAllValues();

        string GetValueByIndex(int index);
    }
}