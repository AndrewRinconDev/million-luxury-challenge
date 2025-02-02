﻿using Domain.Entities;

namespace Domain.Intefaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
        Task<Property?> GetPropertyByIdAsync(string id);
        Task CreateAsync(Property property);
    }
}
