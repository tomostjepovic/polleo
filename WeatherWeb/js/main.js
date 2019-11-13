  var app = new Vue({
    el: '#app',
    data: {
        appName: "Polleo weather",
        forecasts: [],
        userInputCoordinates: "40.730610, -73.935242",
        loadingInProgress: false
    },
    methods: {
        getForecasts: function () {
            this.loadingInProgress = true;
            this.forecasts = [];
            var coord = this.userInputCoordinates.split(',');

            var latitude = coord[0];
            var longitude = coord[1];

            if (coord.length != 2) {
                alert("Upisane koordinate nisu u ispravnom formatu.");
                this.loadingInProgress = false;
                return;
            }
            var jqxhr = $.get(PolleoSettings.apiUrl + "/api/weather-forecast?latitude=" + latitude + "&longitude=" + longitude, function(result) {
                app.forecasts = result;

                const max = app.forecasts.reduce(function(prev, current) {
                    return (prev.Temperature > current.Temperature) ? prev : current
                }) //returns object

                max.IsHottest = true;
                $("#locations-container").removeClass('hidden');
              })
                .fail(function(result) {
                    if (result.status === 404){
                        alert("Servis za dohvat prognoze nije dostupan. Molim obratite se administratoru sustava.");
                        return;
                    }
        
                    alert("Dogodila se nepredviđena greška u dohvatu prognoze. Molim obratite se administratoru sustava.");
                }).always(function(){
                    app.loadingInProgress = false;
                });
        }
    }
  });

$("#weather-formd" ).submit(function( event ) {
    event.preventDefault();

    var coordinates = $("#coordinates").val();

    var coord = coordinates.split(',');

    var latitude = coord[0];
    var longitude = coord[1];

    if (coord.length != 2) {
        alert("Upisane koordinate nisu u ispravnom formatu.");
        return;
    }

    var $submitButton = $("#show-forecast-btn");
    $submitButton.button('loading');

    
  });

  app.message = "Test";
