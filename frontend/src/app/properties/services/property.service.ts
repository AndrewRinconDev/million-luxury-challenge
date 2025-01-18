import { API_BASE_URL } from "@/constants/global";

import propertyModel from "../models/property.model";

const apiUrl = `${API_BASE_URL}/Property`;

export const getAllProperties = async (filters: any): Promise<propertyModel[]> => {
  const query = new URLSearchParams(filters).toString();
  const response = await fetch(`${apiUrl}?${query}`);
  if (!response.ok) {
    throw new Error("Network response was not ok");
  }
  return response.json();
};

export const getPropertyById = async (id?: string | string[]): Promise<propertyModel> => {
  const response = await fetch(`${apiUrl}/${id}`);
  if (!response.ok) {
    throw new Error("Network response was not ok");
  }
  return response.json();
};

export const createProperty = async (property: any): Promise<any> => {
  const response = await fetch(apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(property),
  });
  if (!response.ok) {
    throw new Error("Network response was not ok");
  }
  return response.json();
};
