import Link from "next/link";

import IPropertyCardProps from "./propertyCard.interface";
import "./propertyCard.style.css";

function PropertyCard({ property }: IPropertyCardProps) {
  return (
    <div className="property-card">
      <div className="property-image">
        <img src={property.propertyImages[0].file} alt={property.propertyImages[0].idPropertyImage} />
      </div>
      <div className="property-info">
        <h3 className="text-lg font-bold">{property.name}</h3>
        <p>{property.address}</p>
        <p className="text-green-600 font-bold">${property.price.toLocaleString()}</p>
        <Link className="property-button" href={`properties/${property.idProperty}`}>View Details</Link>
      </div>
    </div>
  );
}

export default PropertyCard;