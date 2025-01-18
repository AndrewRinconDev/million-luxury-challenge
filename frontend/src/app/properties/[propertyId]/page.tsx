'use client';
import { useEffect, useState } from 'react';
import { useParams } from 'next/navigation'

import { getPropertyById } from '../services/property.service';
import propertyModel from '../models/property.model';
import './page.style.css';
import Link from 'next/link';

function propertyDetailPage() {
  const [propertyData, setPropertyData] = useState<null | propertyModel>(null);
  const {propertyId} = useParams();

  const fetchProperty = async () => {
    const property = await getPropertyById(propertyId);
    setPropertyData(property);
    console.log(property);
  };

  useEffect(() => {
    // fetch property data
    fetchProperty();
  }, []);

  return (
  <section className="property-detail-page-section">
    <div className="back-button-container">
      <Link href="/">{'⬅️ Back'}</Link>
    </div>
    <div>
      <h1>Property Detail</h1>
      {propertyData && (
        <div>
          <h2>{propertyData.name}</h2>
          <p>{propertyData.address}</p>
          <p>{propertyData.price}</p>
        </div>
      )}
    </div>
  </section>
  )
}

export default propertyDetailPage;
