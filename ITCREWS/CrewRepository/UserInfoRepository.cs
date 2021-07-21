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
    public class UserInfoRepository : ISignRepository
    {
        private IDBContext dBContext;
        public UserInfoRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<bool> Insert(UserInfoModel userInfoModel)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_login_Password", userInfoModel.Password);
                    param.Add("param_login_Email", userInfoModel.Email);
                    param.Add("param_login_Type", userInfoModel.Type);
                    param.Add("param_login_ActiveFlag", 0);
                    param.Add("param_login_AuthCode", userInfoModel.AuthCode);



                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.InsertUserLoginInfo),
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

        public async Task<bool> Delete(long userNo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Edit(UserInfoModel userInfoModel)
        {
            return true;
        }

        public async Task<UserInfoModel> Get(string userId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_userId", userId);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.GetIDMatchPW),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<UserInfoModel>(mySqlConnection, command);
                    return  result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
            return new UserInfoModel();
        }

        public async Task<bool> CheckDuplicateEmail(string Email)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_email", Email);
                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.CheckDuplicateEmail),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<bool>(mySqlConnection, command);

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return false;
            }
           
        }

        public async Task<bool> CheckEmailAuth(string email ,string authCode)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_subject_AuthCode", authCode);
                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.CheckEmailAuthCode),
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

        public async Task<string> GetEmailAuth(string email)
        {
            
                try
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                    {
                        var param = new DynamicParameters();
                        param.Add("param_email", email);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.GetEmailAuth),
                                                                                    param,
                                                                                    commandType: CommandType.StoredProcedure);

                        var result = await SqlMapper.QueryFirstOrDefaultAsync<string>(mySqlConnection, command);
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    return null;
                }
            
        }
        public async Task<bool> UpdateEmailAuthFlag(string email, string authCode)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_email", email);
                    param.Add("param_userInfo_AuthCode", authCode);
                    param.Add("param_userInfo_emailFlag", true);


                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.UpdateEmailAuthFlag),
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
