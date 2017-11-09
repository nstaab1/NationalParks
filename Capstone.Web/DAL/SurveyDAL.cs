using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        private string aName = ConfigurationManager.ConnectionStrings["park"].ConnectionString;
        private string SQL_GetAllSurveys = "select park.parkName, survey_result.parkCode, count(*) as 'num' from survey_result join park on park.parkCode = survey_result.parkCode group by park.parkName, survey_result.parkCode order by count(park.parkName) DESC;";
        private string SQL_SaveNewSurvey = "insert into survey_result values(@parkCode, @emailAddress, @state, @activityLevel);";
        private string SQL_TotalSurveys = "select count(survey_result.surveyId) as 'count' from survey_result;";



        public List<SurveyResult> GetAllSurveys()
        {
            //List<Survey> output = new List<Survey>();
            List<SurveyResult> output = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(aName))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllSurveys, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SurveyResult s = new SurveyResult();
                        s.ParkName = Convert.ToString(reader["parkName"]);
                        s.ParkCode = Convert.ToString(reader["parkCode"]);
                        s.NumberOfVotes = Convert.ToInt32(reader["num"]);
                        output.Add(s);
                    }
                }
            }
            catch
            {
                throw;
            }
            return output;


        }

        public bool SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(aName))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SaveNewSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    int rowsAffect = cmd.ExecuteNonQuery();
                    return (rowsAffect > 0);
                }
            }
            catch
            {
                throw;
            }

        }

        public double SurveyCount()
        {
            double output = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(aName))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_TotalSurveys, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int temp = Convert.ToInt32(reader["count"]);
                        output = (double)temp;
                    }
                }
            }
            catch
            {
                throw;
            }
            return output;
        }
    }
}