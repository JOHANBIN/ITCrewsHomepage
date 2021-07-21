using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DBHelper
    {
        public enum StoredProcedures
        {
            LoadSubjectInfoPageByDesc,
            LoadSubjectInfoPageByTitle,
            CreateSubjectInfo,
            UpdateSubjectInfo,
            DeleteSubjectInfo,
            LoadSubjectInfo,
            LoadSubecjtFt,
            UsertSubjectFtReadCount,
            UsertSubjectFtFavCount,
            CheckDuplicateEmail,
            GetIDMatchPW,
            GetEmailAuth,
            UpdateEmailAuthFlag,
            InsertUserLoginInfo,
            UpdateUserLoginInfo,
            DeleteUserLoginInfo,
            CheckEmailAuthCode,
            LoadReplies,
            LoadReply,
            LoadReplyCount,
            DeleteReply,
            UpdateReply,
            CreateReply,

            CreateMenuSet,
            DeleteMenuSet,
            LoadMenuSets,
            LoadMenuSet,
            UpdateMenuSet,

            Max
        };

        public static string[] StoredProceduresName = new string[(int)StoredProcedures.Max]
        {
            "load_subject_info_page_by_desc",
            "load_subject_info_page_by_title",
            "create_subject_info",
            "update_subject_info",
            "delete_subject_info",
            "load_subject_info",
            "load_subject_ft",
            "upsert_subect_ft_read_count",
            "upsert_subect_ft_fav_count",
            "check_duplicate_email",
            "get_id_match_pw",
            "get_email_auth",
            "update_email_auth_flag",
            "insert_user_login_Info",
            "update_user_login_info",
            "delete_user_login_info",
            "check_email_authcode",
            "load_replies",
            "load_reply",
            "load_reply_count",
            "delete_reply",
            "update_reply",
            "create_reply",

            "create_memu_set",
            "delete_memu_set",
            "load_menu_sets",
            "load_menu_set",
            "update_menu_set"
        };
        public static string GetStoredProceduresName(StoredProcedures sp)
        {
            return StoredProceduresName[(int)sp];
        }
    }
}
