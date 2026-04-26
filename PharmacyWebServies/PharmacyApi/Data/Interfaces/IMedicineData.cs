using PharmacyApi.Models;
using System.Linq.Expressions;

namespace PharmacyApi.Data.Interfaces
{
    public interface IMedicineData: IBaseData<MedicineModel>
    {
        Task<IEnumerable<MedicineModel>> GetAllMedicinesAsync(Expression<Func<MedicineModel, bool>>? predicate = null);
    }
}
