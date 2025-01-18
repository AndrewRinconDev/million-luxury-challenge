'use client'
import { useState, useEffect } from "react";

import { getAllProperties } from "./properties/services/property.service";
import propertyModel from "./properties/models/property.model";
import PropertyFilters from "./properties/components/propertyFilters/propertyFilters.component";
import PropertyCard from "./properties/components/propertyCard/propertyCard.component";

export default function PropertiesPage() {
  const [properties, setProperties] = useState<propertyModel[]>([]);
  const [filter, setFilter] = useState({
    name: "",
    address: "",
    minPrice: '',
    maxPrice: '',
  });

  const getFilteredProperties = async () => {
    const currentProperties = await getAllProperties(filter);
    setProperties(currentProperties);
  };

  useEffect(() => {
    getFilteredProperties();
  }, []);

  return (
    <div className="flex flex-col md:flex-row">
      <PropertyFilters filter={filter} setFilter={setFilter} getFilteredProperties={getFilteredProperties} />
      <div className="flex-1 p-4 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
        {properties.map((property) => (
          <PropertyCard key={property.idProperty} property={property} />
        ))}
      </div>
    </div>
  );
}
