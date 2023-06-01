using Refit;

namespace WebAppBootstrap.Weathers;

public interface IWeatherApi
{
    [Get("/data/2.5/weather?lat={lat}&lon={lon}&appid={key}&lang=fr&units=metric")]
    public Task<GetWeatherResult> GetWeatherAsync([AliasAs("lat")] double lat, [AliasAs("lon")] double lon, [AliasAs("key")] string key);
}