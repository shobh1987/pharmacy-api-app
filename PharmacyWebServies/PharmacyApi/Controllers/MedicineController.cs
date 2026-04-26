using Microsoft.AspNetCore.Mvc;
using PharmacyApi.Infrastructures.Interfaces;
using PharmacyApi.Models;
using System.Linq.Expressions;

namespace PharmacyApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    public class MedicineController : Controller
    {
        private readonly ILogger<MedicineController> _logger;
        private readonly IMedicineService _medicineService;
        private readonly IConfiguration _configuration;

        public MedicineController(ILogger<MedicineController> logger, IConfiguration configuration, IMedicineService medicineService)
        {
            _logger = logger;
            _configuration = configuration;
            _medicineService = medicineService;
        }

        [HttpGet(Name = "medicine")]
        public async Task<IActionResult> GetAll()
        {
            var param = Request.Query;
            Expression<Func<MedicineModel, bool>>? predicate = null;
            if (param.Any())
            {
                string name = Convert.ToString(param["name"]);
                if (!string.IsNullOrEmpty(name))
                {
                    predicate = m => m.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase);
                }
                long id = Convert.ToInt64(param["id"]);
                if (id > default(long))
                {
                    predicate = m => m.Id.Equals(id);
                }
            }
            var medicines = await _medicineService.GetAllMedicinesAsync(predicate);
            if (!medicines.Any())
                return NotFound("No medicines found.");
            // logic to change Row Color

            return Ok(medicines);
        }

        [HttpPost(Name = "medicine")]
        public async Task<IActionResult> Save([FromBody] MedicineModel model)
        {
            if (model.Validate())
            {
                var medicine = await _medicineService.CreateMedicineAsync(model);
                if (medicine?.Id > 0) return Ok(medicine);
            }
            return Problem("Something went wrong. Please try again");
        }

        [HttpPut(Name = "medicine")]
        public async Task<IActionResult> Update([FromBody] MedicineModel model)
        {
            var medicine = await _medicineService.UpdateMedicineAsync(model.Id, model);
            if (medicine?.Id > 0) return Ok(medicine);
            return Problem("Something went wrong. Please try again");
        }

        [HttpDelete(Name = "medicine")]
        public async Task<IActionResult> Delete([FromQuery] long medicineId)
        {
            var result = await _medicineService.DeleteMedicineAsync(medicineId);
            if (result) return Ok(true);
            return Problem("Something went wrong. Please try again");
        }
    }
}
