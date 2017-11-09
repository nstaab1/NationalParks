using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL dal;

        public SurveyController(ISurveyDAL surveyDAL)
        {
            this.dal = surveyDAL;
        }


        // GET: Survey
        [HttpGet]
        public ActionResult Survey()
        {
            return View("Survey");
        }

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            dal.SaveNewSurvey(survey);
            return RedirectToAction("SurveyResult");
        }

        public ActionResult SurveyResult()
        {
            SurveyResultVM model = new SurveyResultVM();
            model.ListAllSurveys = dal.GetAllSurveys();
            model.TotalSurveys = dal.SurveyCount();
            return View("SurveyResult", model);
        }
    }
}
