using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParksDAL
    {
        List<Park> GetAllParks();
        Park GetAPark(string parkID);
        List<Weather> GetParkWeather(string parkID);

    }
}
