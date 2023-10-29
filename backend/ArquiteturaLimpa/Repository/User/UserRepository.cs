using System.Data;
using System.Data.SqlClient;
using Base;
using Domain.Entities.User;
using PearlCore.ADO.NET;
using PearlCore.UnitOfWork;
using Query.User;
using Repository.User;

namespace Repository
{
    public class UserRepository : DataCommand<UserEntitie>, IUserRepository
    {
        public override string connectionString => ConnectionString.ReturnConnectionString();

        public override IUnitOfWork? unitOfWork { get; set; }

        public UserRepository(IUnitOfWork? unitOfWork = null)
        {
            this.unitOfWork = unitOfWork;
        }
                
        public override List<SqlParameter> GetSqlParameterDelete(long id)
        {
            List<SqlParameter> listsqlParameters = new List<SqlParameter>
            {
                GetSqlParameter("@Id", SqlDbType.BigInt, ParameterDirection.Input, id)
            };
            return listsqlParameters;
        }

        public override List<SqlParameter> GetListSqlParameter(UserEntitie model)
        {
            List<SqlParameter> listsqlParameters = new List<SqlParameter>
            {
                GetSqlParameter("@Id", SqlDbType.BigInt, ParameterDirection.InputOutput, model.Id),
                GetSqlParameter("@Cpf", SqlDbType.BigInt, ParameterDirection.Input, model.Cpf),
                GetSqlParameter("@Name", SqlDbType.NVarChar, ParameterDirection.Input, model.Name),
                GetSqlParameter("@Surname", SqlDbType.NVarChar, ParameterDirection.Input, model.Surname),
                GetSqlParameter("@DisplayName", SqlDbType.NVarChar, ParameterDirection.Input, model.DisplayName),
                GetSqlParameter("@BirthDate", SqlDbType.DateTime, ParameterDirection.Input, model.BirthDate),
                GetSqlParameter("@Email", SqlDbType.NVarChar, ParameterDirection.Input, model.Email),
                GetSqlParameter("@Password", SqlDbType.NVarChar, ParameterDirection.Input, model.Password),
                GetSqlParameter("@ImageProfile", SqlDbType.NVarChar, ParameterDirection.Input, model.ImageProfile),
                GetSqlParameter("@IdTypeProfile", SqlDbType.BigInt, ParameterDirection.Input, model.IdTypeProfile),
                GetSqlParameter("@IdTypeRaceColor", SqlDbType.BigInt, ParameterDirection.Input, model.IdTypeRaceColor),
                GetSqlParameter("@IdTypeSex", SqlDbType.BigInt, ParameterDirection.Input, model.IdTypeSex)
            };
            return listsqlParameters;
        }

        public override UserEntitie GetObject(DataTableReader dataTableReader)
        {
            var model = new UserEntitie();
            model.Id = ConvertToInt64(dataTableReader["Id"]);
            model.Cpf = ConvertToInt64(dataTableReader["Cpf"]);
            model.Name = ConvertToString(dataTableReader["Name"]);
            model.Surname = ConvertToString(dataTableReader["Surname"]);
            model.DisplayName = ConvertToString(dataTableReader["DisplayName"]);
            model.BirthDate = ConvertToDateTime(dataTableReader["BirthDate"]);
            model.Email = ConvertToString(dataTableReader["Email"]);
            model.Password = ConvertToString(dataTableReader["Password"]);
            model.ImageProfile = ConvertToString(dataTableReader["ImageProfile"]);
            model.IdTypeProfile = ConvertToInt32(dataTableReader["IdTypeProfile"]);
            model.IdTypeRaceColor = ConvertToInt32(dataTableReader["IdTypeRaceColor"]);
            model.IdTypeSex = ConvertToInt32(dataTableReader["IdTypeSex"]);
            return model;
        }

        public async Task<ExecutionResult<long>> Save(UserEntitie entitie)
        {
            return await save(CommandType.Text, UserCommandQuerySave.Command(), entitie, "@Id"); 
        }

        public async Task<ExecutionResult<bool>> Update(UserEntitie entitie)
        {
            return await update(CommandType.Text, UserCommandQueryUpdate.Command(), entitie);
        }

        public async Task<ExecutionResult<bool>> Delete(long id)
        {
            return await delete(CommandType.Text, UserCommandQueryDelete.Command(), id);
        }

        public async Task<ExecutionResult<List<UserEntitie>>> FindAll(UserEntitie entitie)
        {
            return await findAll(CommandType.Text, UserCommandQuerySelect.Command(), entitie);
        }

        public async Task<ExecutionResult<UserEntitie>> FindFirst(UserEntitie entitie)
        {
            return await findFirst(CommandType.Text, UserCommandQuerySelect.Command(), entitie);
        }
    }
}
