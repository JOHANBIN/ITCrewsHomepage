using CrewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Models
{
    public class CommonResponse : ICommonResponse
    {
        public string ErrorDesc { get; set; }
    }

    public class SignUpResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class EditReplyResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class DeleteReplyResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class ChangePasswordResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class SignOutResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class CreateSubjectResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class EditSubjectResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class DeleteSubjectResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class ForgotPasswordResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class SignInResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class GetMenuListResponse : ICommonResponse
    {
        public List<MenuModel> MenuList { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class CreateMenuResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class GetSubjectListResponse : ICommonResponse
    {
        public List<SubjectInfoModel> SubjectList { get; set; } = new List<SubjectInfoModel>();

        public int CurrentPageIndex { get; set; }

        public long TotalCount { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class GetSubjectResponse : ICommonResponse 
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
        public long SubjId { get; set; }
        public string Title { get; set; }

        public string Desc { get; set; }

        public string AuthorId { get; set; }

        public long AuthorNo { get; set; }

        public DateTime ChgDate { get; set; }

        public string AuthorImg { get; set; }

        public List<ReplyModel> ReplyList { get; set; }
    }

    public class CreateReplyResponse : ICommonResponse
    {
        public long ReplyId { get; set; }
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class CheckEmailAuthResponse : ICommonResponse
    {
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class CheckDuplicateEmailResponse : ICommonResponse
    {
        public bool IsSuccess { get; set; }
        public string Result { get; set; }
        public string ErrorDesc { get; set; }
    }

}
