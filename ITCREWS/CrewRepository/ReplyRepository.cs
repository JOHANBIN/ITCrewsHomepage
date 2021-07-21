using CrewModel;
using CrewModel.Interface;
using CrewRepository.Interface;
using Dapper;
using MySql.Data.MySqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CrewRepository
{
    public class ReplyRepository : IReplyRepository
    {
        private IDBContext dBContext;
        public ReplyRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Tuple<long>> Create(ReplyModel replyModel)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", replyModel.SubjectId);
                    param.Add("param_user_no", replyModel.AuthorNo);
                    param.Add("param_desc", replyModel.Desc);
                    param.Add("param_parent_id", replyModel.ParentId);
                    param.Add("param_created_time", replyModel.ChangeDate);
                    param.Add("param_new_reply_id", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.CreateReply),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.ExecuteAsync(mySqlConnection, command);

                    var newReplyId = param.Get<long>("param_new_reply_id");
                    return Tuple.Create(newReplyId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }

        public async Task<bool> Delete(long replyId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_reply_id", replyId);
                    param.Add("param_active_flag", "F");

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.DeleteReply),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.ExecuteAsync(mySqlConnection, command);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return false;
            }
        }

        public async Task<bool> Edit(ReplyModel replyModel)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_reply_id", replyModel.ReplyId);
                    param.Add("param_desc", replyModel.Desc);
                    param.Add("param_user_no", replyModel.AuthorNo);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.UpdateReply),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.ExecuteAsync(mySqlConnection, command);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return false;
            }
        }
        public async Task<Tuple<int>> GetCount(long subjectId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", subjectId);
                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadReplyCount),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<int>(mySqlConnection, command);
                    return Tuple.Create(result);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }
        public async Task<ReplyModel> Get(long replyId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_reply_id", replyId);
                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadReply),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<ReplyModel>(mySqlConnection, command);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<ReplyModel>> GetList(long subjectId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", subjectId);
                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadReplies),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryAsync<ReplyModel>(mySqlConnection, command);
                    return result.AsList();
                }
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }
    }
}
