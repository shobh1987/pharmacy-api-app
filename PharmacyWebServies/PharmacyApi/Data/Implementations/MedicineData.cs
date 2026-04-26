using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Memory;
using PharmacyApi.Data.Interfaces;
using PharmacyApi.Models;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace PharmacyApi.Data.Implementations
{
    public class MedicineData : IMedicineData
    {
        private readonly IMemoryCache _memoryCache;
        private const string key = "medicine";

        public MedicineData(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private IEnumerable<MedicineModel> GetAll()
        {
            _memoryCache.TryGetValue(key, out object? cached);
            return cached as IEnumerable<MedicineModel> ?? Enumerable.Empty<MedicineModel>();
        }

        public async Task<IEnumerable<MedicineModel>> GetAllMedicinesAsync(Expression<Func<MedicineModel, bool>>? predicate = null)
        {
            var medicines = GetAll();
            if (predicate != null)
            {
                var filtered = medicines.AsQueryable().Where(predicate).ToList();
                return await Task.FromResult<IEnumerable<MedicineModel>>(filtered.Where(x => !x.IsDeleted));
            }

            return await Task.FromResult(medicines);
        }

        public async Task<MedicineModel?> GetByIdAsync(long id)
        {
            var list = GetAll();
            var item = list.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult<MedicineModel?>(item);
        }

        public async Task<MedicineModel> CreateAsync(MedicineModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var list = GetAll().ToList();
            entity.CreatedBy = 1;
            entity.Id = entity.SetId();
            list.Add(entity);
            _memoryCache.Set(key, list);

            return await Task.FromResult(entity);
        }

        public async Task<MedicineModel> UpdateAsync(long id, MedicineModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var list = GetAll().ToList();
            var existing = list.FindIndex((x) => entity.Id == x.Id);
            if (existing > -1)
            {
                var model = list[existing];
                model.Price = entity.Price;
                model.Name = entity.Name;
                model.Notes = entity.Notes;
                model.Quantity = entity.Quantity;
                model.UpdatedDate = DateTime.UtcNow;
                model.UpdatedBy = 1;
                list[existing] = model;
            }
            _memoryCache.Set(key, list);

            return await Task.FromResult(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _memoryCache.TryGetValue(key, out object? cached);
            var list = GetAll().ToList();
            var existing = list.FindIndex((x) => x.Id == id);
            if (existing > -1)
            {
                var model = list[existing];
                model.IsDeleted = true;
                model.DeletedAt = DateTime.UtcNow;
                model.DeletedBy = 1;
                list[existing] = model;
            }
            _memoryCache.Set(key, list);

            return await Task.FromResult(existing > -1);
        }


    }
}
