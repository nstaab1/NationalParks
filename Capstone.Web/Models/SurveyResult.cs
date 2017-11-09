using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public string ParkName { get; set; }
        public string ParkCode { get; set; }
        public int NumberOfVotes { get; set; }
    }
}