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
    public class SubjecFtRepository : ISubjectFtRepository
    {
        private IDBContext dBContext;
        public SubjecFtRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<SubjectFtModel> Get(long subjectId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", subjectId);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadSubecjtFt),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<SubjectFtModel>(mySqlConnection, command);
                    if (result == null)
                    {
                        result = new SubjectFtModel
                        {
                            SubjectId = subjectId
                        };
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpsertFavCount(long subjectId, int updateCount)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", subjectId);
                    param.Add("param_update_value", updateCount);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.UsertSubjectFtFavCount),
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

        public async Task<bool> UpsertReadCount(long subjectId, int updateCount)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_id", subjectId);
                    param.Add("param_update_value", updateCount);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.UsertSubjectFtReadCount),
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
    }
}
