import { Dispatch, SetStateAction } from "react";

interface IPropertyFiltersProps {
  filter: Record<string, any>;
  setFilter: Dispatch<SetStateAction<any>>;
  getFilteredProperties: () => Promise<void>;
}

export default IPropertyFiltersProps;