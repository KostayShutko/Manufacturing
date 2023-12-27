using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Manufacturing.Common.Infrastructure.Converters;

public class EnumListConverter<T> : ValueConverter<IEnumerable<T>, string>
    where T : Enum
{
    public EnumListConverter() : base(
        list => JsonConvert.SerializeObject(list.Select(item => item.ToString()).ToList()),
        json => JsonConvert
            .DeserializeObject<IEnumerable<string>>(json)
            .Select(item => (T)Enum.Parse(typeof(T), item)).ToList())
    {
    }
}
