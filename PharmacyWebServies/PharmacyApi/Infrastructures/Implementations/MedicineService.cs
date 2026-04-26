using PharmacyApi.Data.Interfaces;
using PharmacyApi.Infrastructures.Interfaces;
using PharmacyApi.Models;
using System.Linq.Expressions;

namespace PharmacyApi.Infrastructures.Implementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineData _medicineData;
        public MedicineService(IMedicineData medicineData) { _medicineData = medicineData; }

        public async Task<IEnumerable<MedicineModel>> GetAllMedicinesAsync(Expression<Func<MedicineModel, bool>>? predicate = null)
        {
            return await _medicineData.GetAllMedicinesAsync(predicate);
        }

        public async Task<MedicineModel> CreateMedicineAsync(MedicineModel medicine)
        {
            return await _medicineData.CreateAsync(medicine);
        }

        public async Task<MedicineModel> UpdateMedicineAsync(long id, MedicineModel medicine)
        {
            return await _medicineData.UpdateAsync(id, medicine);
        }

        public async Task<bool> DeleteMedicineAsync(long id)
        {
            return await _medicineData.DeleteAsync(id);
        }


    }
}
