using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Manufacturing.Common.Infrastructure.Converters;

public class StringListConverter : ValueConverter<ICollection<string>, string>
{
    public StringListConverter ()
         : base(list => JsonConvert.SerializeObject(list), s => JsonConvert.DeserializeObject<ICollection<string>>(s))
    {
    }
}
