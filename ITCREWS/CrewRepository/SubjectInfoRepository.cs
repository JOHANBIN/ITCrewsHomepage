using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CrewModel;
using CrewModel.Interface;
using CrewRepository.Interface;
using Dapper;
using MySql.Data.MySqlClient;
using Shared;

namespace CrewRepository
{
    public class SubjectInfoRepository : ISubjectInfoRepository
    {
        private IDBContext dBContext;
        public SubjectInfoRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<bool> Create(SubjectInfoModel model)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_type", model.Type);
                    param.Add("param_desc", model.Desc);
                    param.Add("param_title", model.Title);
                    param.Add("param_chg_user_no", model.UserNo);
                    param.Add("param_change_date_time", model.ChangeDateTime);
                    param.Add("param_active_flag", "T");

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.CreateSubjectInfo),
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
        public async Task<bool> Delete(long subjId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subj_id", subjId);
                    param.Add("param_active_flag", "F");

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.DeleteSubjectInfo),
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
        public async Task<bool> Edit(SubjectInfoModel model)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", model.Id);
                    param.Add("param_desc", model.Desc);
                    param.Add("param_title", model.Title);
                    param.Add("param_chg_user_no", model.UserNo);
                    param.Add("param_change_date_time", model.ChangeDateTime);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.UpdateSubjectInfo),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.ExecuteAsync(mySqlConnection, command);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                //Logger 필요함
                return false;
            }
        }

        public async Task<Tuple<long, List<SubjectInfoModel>>> Get(int pageIndex, string type, int row, string searchWord)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_page", pageIndex);
                    param.Add("param_row", row);
                    param.Add("param_type", type);
                    param.Add("param_search_word", searchWord);
                    param.Add("param_total", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadSubjectInfoPageByDesc),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryAsync<SubjectInfoModel>(mySqlConnection, command);
                    var totalCount = param.Get<long>("param_total");
                    return Tuple.Create(totalCount, result.ToList());
                }
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }

        public async Task<SubjectInfoModel> Get(long subjId)
        {
            try
            {
                using(MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", subjId);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadSubjectInfo),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<SubjectInfoModel>(mySqlConnection, command);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }
    }
}
