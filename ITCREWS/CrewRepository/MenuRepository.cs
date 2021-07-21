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
    public class MenuRepository : IMenuRepository
    {
        private IDBContext dBContext;
        public MenuRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<bool> Create(MenuModel menuModel, long userId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_seq_no", menuModel.MenuId);
                    param.Add("param_type", menuModel.Type);
                    param.Add("param_depth_1", menuModel.Title);
                    param.Add("param_depth_2", menuModel.SubTitle);
                    param.Add("param_parent_id", menuModel.ParentId);
                    param.Add("param_url", menuModel.Url);
                    param.Add("param_change_user_no", userId);
                    param.Add("param_change_date_time", DateTime.Now);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.CreateMenuSet),
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

        public async Task<bool> Delete(long seqNo)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_seq_no", seqNo);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.DeleteMenuSet),
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
        public async Task<bool> Update(MenuModel menuModel, long userId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_seq_no", menuModel.MenuId);
                    param.Add("param_type", menuModel.Type);
                    param.Add("param_depth_1", menuModel.Title);
                    param.Add("param_depth_2", menuModel.SubTitle);
                    param.Add("param_parent_id", menuModel.ParentId);
                    param.Add("param_url", menuModel.Url);
                    param.Add("param_change_user_no", userId);
                    param.Add("param_change_date_time", DateTime.Now);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.UpdateMenuSet),
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
        public async Task<MenuModel> Get(long seqNo)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_seq_no", seqNo);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadMenuSet),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryFirstOrDefaultAsync<MenuModel>(mySqlConnection, command);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<MenuModel>> GetList(string type)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBContext.GetConnString()))
                {
                    var param = new DynamicParameters();
                    param.Add("param_type", type);

                    CommandDefinition command = new CommandDefinition(DBHelper.GetStoredProceduresName(DBHelper.StoredProcedures.LoadMenuSets),
                                                                                param,
                                                                                commandType: CommandType.StoredProcedure);

                    var result = await SqlMapper.QueryAsync<MenuModel>(mySqlConnection, command);
                    return result.ToList();
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
