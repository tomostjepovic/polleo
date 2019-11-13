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
