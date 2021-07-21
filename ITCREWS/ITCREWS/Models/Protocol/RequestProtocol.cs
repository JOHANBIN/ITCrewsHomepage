using CrewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Shared.SystemEnums;

namespace ITCREWS.Models
{
    public class SignUp : ICommonRequest
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public bool CheckEmail { get ; set; }
    }
    public class SignOut : ICommonRequest
    {
        public string UserId { get; set; }
    }
    public class EditReply : ICommonRequest
    {
        [Required]
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Desc { get; set; }
    }
    public class CreateReply : ICommonRequest
    {
        [Required]
        public long SubjectId { get; set; }
        [Required]
        public long ParentId { get; set; }

        public long UserId { get; set; }

        public string Desc { get; set; }
    }

    public class ChangePassword : ICommonRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class CreateSubject : ICommonRequest
    {
        public string Title { get; set; }

        public string Desc { get; set; }

        public BoardType Type { get; set; }

    }
    public class EditSubject : ICommonRequest
    {
        [Required]
        public long SubjId { get; set; } = -1;
        public string Title { get; set; }

        public string Desc { get; set; }

    }
    public class DeleteSubject : ICommonRequest
    {
        [Required]
        public long SubjId { get; set; }
    }
    public class SignIn : ICommonRequest
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserId { get; set; }

    }
    public class ForgotPassword : ICommonRequest
    {
        [Required]
        public string Email { get; set; }
    }
    public class GetSubject : ICommonRequest
    {
        [Required]
        public long SubjId { get; set; }
    }
    public class GetMenuList : ICommonRequest
    {
        [Required]
        public string Type { get; set; }
    }
    public class CreateMenu : ICommonRequest
    { }


    public class GetSubjectList : ICommonRequest
    {
        [Required]
        public BoardType Type { get; set; }
        [Required]
        public int PageIndex { get; set; }
        [Required]
        public SubjectQueryModel Query { get; set; } = new SubjectQueryModel();

    }
    public class DeleteReply : ICommonRequest
    {
        [Required]
        public long Id { get; set; }
    }
    public class CheckEmailAuth : ICommonRequest
    {
        [Required]
        public string AuthCode { get; set; }
        [Required]
        public string Email { get; set; }
    }
    public class CheckDuplicateEmail : ICommonRequest
    {
        [Required]
        public string Email { get; set; }
    }
    

}
