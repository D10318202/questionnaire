﻿using QuestionManagers;
using QuestionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.API
{
    /// <summary>
    /// QuestionAnswerHandler 的摘要描述
    /// </summary>
    public class QuestionAnswerHandler : IHttpHandler  ,System.Web.SessionState.IRequiresSessionState
    {
        private static QuestionnaireManager _quesMgr = new QuestionnaireManager();
        public void ProcessRequest(HttpContext context)
        {
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                 Guid.TryParse(context.Request.QueryString["quesID"], out Guid QuesID))
            {
                //string name = context.Request.Form["Name"];
                //string phone = context.Request.Form["Phone"];
                //string email = context.Request.Form["Email"];
                //string age = context.Request.Form["Age"];
                string accountarr = context.Request.Form["Profile"];
                string[] accountArr = accountarr.Split(';');
                if (accountArr.Length != 4 || !int.TryParse(accountArr[2], out int phone) || accountArr[2].Length < 10 || !int.TryParse(accountArr[1], out int age) || (age < 1 || age > 150) || !accountArr[3].Contains("@"))
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("errorinput");
                    return;
                }
                AccountInfoModel accountInfoModel = new AccountInfoModel()
                {
                    AccountID = Guid.NewGuid(),
                    Name = accountArr[0].Trim(),
                    Age = accountArr[1].Trim(),
                    Phone = accountArr[2].Trim(),                    
                    Email = accountArr[3].Trim(),
                    quesID = QuesID
                };
                
                HttpContext.Current.Session["personInfo"] = accountInfoModel;
                string quesans = context.Request.Form["Answer"];
                if (string.IsNullOrWhiteSpace(quesans))
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("noAnswer");
                    return;
                }
                string[] AnswerArr = quesans.Trim().Split(' ');
                List<QuestionAnswerModel> questionAnswers = new List<QuestionAnswerModel>();
                foreach (string item in AnswerArr)
                {
                    string[] answer = item.Split('_');

                    QuestionAnswerModel questionAnswerModel = new QuestionAnswerModel()
                    {
                        AccountID = accountInfoModel.AccountID,
                        quesID = QuesID,
                        quesNumber = Convert.ToInt32(answer[0].Replace('Q', '0')),
                        Answer = answer[1]
                    };
                    questionAnswers.Add(questionAnswerModel);
                }
                HttpContext.Current.Session["peopleAnswer"] = questionAnswers;
                context.Response.ContentType = "text/plain";
                context.Response.Write("success");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}