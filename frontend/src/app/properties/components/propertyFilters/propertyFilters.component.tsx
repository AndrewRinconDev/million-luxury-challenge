
import IPropertyFiltersProps from "./propertyFilters.interface";

function PropertyFilters({
  filter,
  setFilter,
  getFilteredProperties,
}: IPropertyFiltersProps) {
  const clearHandler = () => {
    setFilter({ name: "", address: "", minPrice: "", maxPrice: "" })
  }
  
  return (
    <div className="w-full md:w-64 p-4">
      <h2 className="text-xl font-bold mb-4">Filters</h2>
      <input
        type="text"
        placeholder="Name"
        value={filter.name}
        onChange={(e) => setFilter({ ...filter, name: e.target.value })}
        className="mb-2 p-2 border border-gray-300 rounded"
      />
      <input
        type="text"
        placeholder="Address"
        value={filter.address}
        onChange={(e) => setFilter({ ...filter, address: e.target.value })}
        className="mb-2 p-2 border border-gray-300 rounded"
      />
      <input
        type="number"
        placeholder="Min Price"
        value={filter.minPrice}
        onChange={(e) =>
          setFilter({
            ...filter,
            minPrice: Number(e.target.value),
          })
        }
        className="mb-2 p-2 border border-gray-300 rounded"
      />
      <input
        type="number"
        placeholder="Max Price"
        value={filter.maxPrice}
        onChange={(e) =>
          setFilter({
            ...filter,
            maxPrice: Number(e.target.value),
          })
        }
        className="mb-2 p-2 border border-gray-300 rounded"
      />
      <button
        onClick={clearHandler}
        className="bg-gray-300 text-gray-800 p-2 rounded w-full"
      >
        Reset
      </button>
      <button
        onClick={getFilteredProperties}
        className="bg-blue-500 text-white p-2 rounded w-full"
      >
        Filter
      </button>
    </div>
  );
}

export default PropertyFilters;
