using PharmacyApi.Models;
using System.Linq.Expressions;

namespace PharmacyApi.Infrastructures.Interfaces
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineModel>> GetAllMedicinesAsync(Expression<Func<MedicineModel, bool>>? predicate = null);

        Task<MedicineModel> CreateMedicineAsync(MedicineModel medicine);

        Task<MedicineModel> UpdateMedicineAsync(long id, MedicineModel medicine);

        Task<bool> DeleteMedicineAsync(long id);
    }
}