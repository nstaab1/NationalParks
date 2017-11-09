using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyResultVM
    {
        public List<SurveyResult> ListAllSurveys { get; set; }
        public double TotalSurveys { get; set; }


        public double ToPercent()
        {
            double percent = 0;
            int votes = 0;

            votes = ListAllSurveys[0].NumberOfVotes;
            percent = votes / TotalSurveys;

            return (percent * 100);
        }

    }
}