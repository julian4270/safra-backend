using Safrasas.Api.Models;
using Safrasas.Application.Interfaces;
using Safrasas.Core.Entities;
using Safrasas.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Safrasas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : BaseApiController
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ===[ Constructor ]=================================================================
        public ClientsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        [HttpGet]
        [Route("Get_All_SAFRA_Clients")]
        public async Task<ApiResponse<List<Clients>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<Clients>>();

            try
            {
                var data = await _unitOfWork.Clients.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpGet("Get_By {id} SAFRA_Client")]
        public async Task<ApiResponse<Clients>> GetById(int id)
        {
            var apiResponse = new ApiResponse<Clients>();

            try
            {
                var data = await _unitOfWork.Clients.GetByIdAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }
            return apiResponse;
        }

        [HttpGet]
        [Route("Download_CSV_Registers")]
        public async Task<ApiResponse<Clients>> DownloadCSV(string CSVpath)
        {
            var apiResponse = new ApiResponse<List<Clients>>();
            String DownloadCSV = null;
            try {
                var data = await _unitOfWork.Clients.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception e)
            {
                apiResponse.Success = false;
                apiResponse.Message = e.Message;
                Logger.Instance.Error("Exception:", e);
            }
            return null;
        }


        [HttpPost]
        [Route("Add_SAFRA_Client")]
        public async Task<ApiResponse<string>> Add(Clients Client)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Clients.AddAsync(Client);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpPost]
        [Route("Add_CSV_Register_Client")]
        public async Task<ApiResponse<string>> AddCSV(Clients Client)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Clients.AddAsync(Client);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpPut]
        [Route("Update_SAFRA_Client")]
        public async Task<ApiResponse<string>> Update(Clients Client)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Clients.UpdateAsync(Client);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpDelete]
        [Route("Delete_SAFRA_Client")]
        public async Task<ApiResponse<string>> Delete(int id)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Clients.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }
    }
    #endregion
}
