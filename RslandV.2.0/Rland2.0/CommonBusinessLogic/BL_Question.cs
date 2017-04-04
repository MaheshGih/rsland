using Rland2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rland2._0.AdminBusinessLogic;


namespace Rland2._0.CommonBusinessLogic
{
    public class BL_Question : BL_Base
    {
        private ResLandEntities context;
        public BL_Question()
        {
            context = new ResLandEntities();
        }
        public List<SecurityQuestion> GetQuestions()
        {

            var dbQuestions = context.QUESTION_LKUP.Where(x => x.IS_DELETED == "N").ToList();
            List<SecurityQuestion> questions = new List<SecurityQuestion>();

            foreach (var dbQuestion in dbQuestions)
            {
                SecurityQuestion question = new SecurityQuestion()
                {
                    Id = dbQuestion.ID,
                    Question = dbQuestion.QUESTION.ToUpper(),
                };

                questions.Add(question);
            }
            return questions;

        }

        public void AddSecurityQuestions(HomeModel homemodel)
        {

            var rlUser = context.RL_USERS.FirstOrDefault(x => x.ID == homemodel.rluserModel.Id);

            rlUser.QNO_1 = homemodel.questionAnswersModel.Question;
            rlUser.ANS_1 = homemodel.questionAnswersModel.Answer;
            rlUser.CR_BY = UserName;
            rlUser.STAT = "ACTIVE";
            rlUser.IS_DELETED = "N";
            context.SaveChanges();
        }
    }
}