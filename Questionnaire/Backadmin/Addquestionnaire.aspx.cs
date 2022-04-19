﻿using QuestionManagers;
using QuestionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire.Backadmin
{
    public partial class Addquestionnaire : System.Web.UI.Page
    {
        private static QuestionnaireManager _quesMgr = new QuestionnaireManager();
        private QuestionDetailModel questionDetail = new QuestionDetailModel();
        private QuestionModel question = new QuestionModel();
        private static List<QuestionDetailModel> _questionDetail;
        private static Guid _questionID;
        private bool isCreateMode;
        protected void Page_Load(object sender, EventArgs e)
        {
            string QusetionnaireID = Request.QueryString["quesID"];
            if (string.IsNullOrWhiteSpace(QusetionnaireID))
            {
                isCreateMode = true;
                HttpContext.Current.Session.Remove("quesID");
            }
            else if (Guid.TryParse(QusetionnaireID, out _questionID))
            {
                isCreateMode = false;
                initEditMode(_questionID);
                HttpContext.Current.Session["quesID"] = _questionID;
            }
            else
                Response.Redirect("List.aspx");
        }
        #region /*分頁切換*/
        protected void LinkQuestionnaire_Click(object sender, EventArgs e)
        {
            this.ChangeStatus(PageStatus.Questionnaire);
        }
        protected void LinkQuestions_Click(object sender, EventArgs e)
        {
            this.ChangeStatus(PageStatus.Questions);
        }
        protected void LinkFillQuestions_Click(object sender, EventArgs e)
        {
            this.ChangeStatus(PageStatus.FillQuestions);
        }
        protected void LinkTotal_Click(object sender, EventArgs e)
        {
            this.ChangeStatus(PageStatus.Total);
        }
        private void ChangeStatus(PageStatus Status)
        {
            this.LinkQuestionnaire.Enabled = (Status != PageStatus.Questionnaire);
            this.LinkQuestions.Enabled = (Status != PageStatus.Questions);
            this.LinkFillQuestions.Enabled = (Status != PageStatus.FillQuestions);
            this.LinkTotal.Enabled = (Status != PageStatus.Total);

            this.panQuestionnaire.Visible = (Status == PageStatus.Questionnaire);
            this.panQuestions.Visible = (Status == PageStatus.Questions);
            this.panFillQuestions.Visible = (Status == PageStatus.FillQuestions);
            this.panTotal.Visible = (Status == PageStatus.Total);
        }
        private enum PageStatus
        {
            //問卷
            Questionnaire,
            //問題
            Questions,
            //填寫資料
            FillQuestions,
            //資料統計
            Total
        }
        #endregion

        #region /*問卷Questionnaire*/
        private void initEditMode(Guid quesID)
        {
            QuestionModel question = _quesMgr.GetQuestionnaire(quesID);
            this.txtTitle.Text = question.quesTitle;
            this.txtBody.Text = question.quesBody;
            this.txtStart.Text = question.quesstart.ToString();
            this.txtEnd.Text = question.quesend.ToString();
        }
        protected void Cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("allquestionnaires.aspx");
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            QuestionModel question = new QuestionModel()
            {
                quesID = Guid.NewGuid(),
                quesstart = Convert.ToDateTime(this.txtStart.Text),
                quesend = Convert.ToDateTime(this.txtEnd.Text),
                quesTitle = this.txtTitle.Text.Trim(),
                quesBody = this.txtBody.Text.Trim()
            };
            if (this.checUse.Checked == false)
            {
                question.Type = StateType.關閉;
            }
            else
            {
                question.Type = StateType.已啟用;
            }

            if (isCreateMode)
            {
                question.quesID = Guid.NewGuid();
                _quesMgr.CreateQuestionnaire(question);
            }
            else
            {
                question.quesID = _questionID;
                _quesMgr.UpdateQuestionnaire(question);
            }
            HttpContext.Current.Session["quesID"] = question.quesID;
        }
        #endregion

        #region /*問題Questions*/
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            QuestionDetailModel questionDetail = new QuestionDetailModel()
            {
                quesID = _questionID,
                quesDetailID = Guid.NewGuid(),
                quesDetailTitle = this.txtTitle1.Text.Trim(),
                quesDetailBody = this.txtAnswer.Text.Trim(),
                quesDetailType = (QuestionType)Convert.ToInt32(this.droptype.SelectedValue)
            };
            if (this.checMust.Checked == false)
            {
                questionDetail.quesDetailMustKeyIn = QuestionMustFill.不是必填;
            }
            else
            {
                questionDetail.quesDetailMustKeyIn = QuestionMustFill.必填;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnquescancle_Click(object sender, EventArgs e)
        {
        }

        protected void btnquessave_Click(object sender, EventArgs e)
        {
            int questionNumber = 1;
            foreach (QuestionDetailModel questionDetail in _questionDetail)
            {
                questionDetail.quesDetailNo = questionNumber;
                _quesMgr.CreateQuestionDetail(questionDetail);

                questionNumber++;
            }
            Response.Redirect("allquestionnaire.aspx");
        }
        #endregion

        #region /*填寫資料FillQuestions*/
        protected void btnsavefile_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}