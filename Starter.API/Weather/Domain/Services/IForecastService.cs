using WAW.API.Weather.Domain.Models;
using WAW.API.Weather.Domain.Services.Communication;

namespace WAW.API.Weather.Domain.Services;

public interface IForecastService {
  Task<IEnumerable<Forecast>> ListAll();
  Task<ForecastResponse> Create(Forecast forecast);
  Task<ForecastResponse> Update(long id, Forecast forecast);
  Task<ForecastResponse> Delete(long id);
}
