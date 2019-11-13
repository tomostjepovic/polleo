# Polleo Weather

Polleo Weather je aplikacija namjenjena za usporedbu vremenske prognoze trenutne lokacije korisnika sa lokacijom koju korisnik unese.
Repozitorij sadrži dva projekta, WeatherWeb (mini SPA aplikacija) te WeatherApi (.NET WebApi).

# Postavljanje developerske okoline
## Frontend: WeatherWeb
Frontend je statička SPA aplikacija napisana u HTML/JS/CSS. Spaja se na API preko HTTP protokola. 
Potrebno je podesiti URL do API-ja, i to u datoteci `WeatherWeb\js\settings.js`:

```javascript
var PolleoSettings = {
    apiUrl: "{API_URL}"
};
```
Za uređivanje koda dovoljan je bilo koji tekstualni editor, npr:
* Visual Studio Code
* Notepad++
* Sublime Text 

## Backend: WeatherApi
Backend je .NET WebApi aplikacija pisana u C#. Za host-anje se preporuča IIS.
Podatke o vremenskoj prognozi dohvaća sa [OpenWeather] (https://openweathermap.org/). Pošto je korišten dependeny injection, jednostavno se može zamijeniti servis za dohvat prognoze sa nekim drugim. Potrebno je napraviti novi servis, naslijediti interface `IForecastService`  te podesiti datoteku `WatherApi\App_Start\WebApiConfig.cs` (nije potrebno raditi nikakve druge izmjene u kodu):
 ```csharp
container.RegisterType<IForecastService, {NEW_FORECAST_SERVICE}>(new HierarchicalLifetimeManager());
```
