using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkWeather
    {
        //Park properties
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string ParkState { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public decimal MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        //Weather properties
        public List<Weather> FiveDayForecast { get; set; }
        public bool isFahrenheit;


        public ParkWeather(Park p, List<Weather> w)
        {
            this.ParkCode = p.ParkCode;
            this.ParkName = p.ParkName;
            this.ParkState = p.ParkState;
            this.Acreage = p.Acreage;
            this.ElevationInFeet = p.ElevationInFeet;
            this.MilesOfTrail = p.MilesOfTrail;
            this.NumberOfCampsites = p.NumberOfCampsites;
            this.Climate = p.Climate;
            this.YearFounded = p.YearFounded;
            this.AnnualVisitorCount = p.AnnualVisitorCount;
            this.InspirationalQuote = p.InspirationalQuote;
            this.InspirationalQuoteSource = p.InspirationalQuoteSource;
            this.ParkDescription = p.ParkDescription;
            this.EntryFee = p.EntryFee;
            this.NumberOfAnimalSpecies = p.NumberOfAnimalSpecies;
            this.FiveDayForecast = w;
        }

        public string Preparation()
        {
            string suggestion = "";

            switch (FiveDayForecast[0].Forecast)
            {
                case "rain":
                    suggestion += "Pack rain gear and wear waterproof shoes. ";
                    break;

                case "thunderstorms":
                    suggestion += "Seek shelter and avoid hiking on exposed ridges. ";
                    break;

                case "sunny":
                    suggestion += "Pack sunblock. ";
                    break;

                case "snow":
                    suggestion += "Pack snowshoes. ";
                    break;
            }


            if (FiveDayForecast[0].High > 75)
            {
                suggestion += "Bring an extra gallon of water. ";
            }
            if (FiveDayForecast[0].Low <= 20)
            {
                suggestion += "There is a danger of exposure to frigid temperatures. ";
            }
            if (FiveDayForecast[0].High - FiveDayForecast[0].Low >= 20)
            {
                suggestion += "Make sure to wear breathable layers. ";
            }

            return suggestion;

        }



        public int ToCelsiusHigh(int forecastDay)
        {
            double output = ((FiveDayForecast[forecastDay].High - 32) * 5) / 9;
            return (int)output;
        }

        public int ToCelsiusLow(int forecastDay)
        {
            double output = ((FiveDayForecast[forecastDay].Low - 32) * 5) / 9;
            return (int)output;
        }
    }
}