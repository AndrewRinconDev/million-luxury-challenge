// {
//   "idProperty": "67898fc11c4a87d0d8ee8162",
//   "name": "9605 Verlaine Ct",
//   "address": "Henderson, NV 89012",
//   "price": 4935000,
//   "codeInternational": "4808",
//   "year": 2023,
//   "owner": {
//     "idOwner": null,
//     "name": "Grace L Wilson",
//     "address": "Henderson, NV 89412",
//     "photo": "https://randomuser.me/api/portraits/women/34.jpg",
//     "birthday": "2025-01-16T22:46:05.994Z"
//   },
//   "propertyImages": [
//     {
//       "idPropertyImage": null,
//       "file": "https://static2.mansionglobal.com/production/media/article-images/bb36cf30e6a20588f5bfe75687cd2ba4/large_beijing_1rs.jpg",
//       "enable": true
//     }
//   ],
//   "propertyTraces": [
//     {
//       "idPropertyTrace": null,
//       "dateSale": "2025-01-10T22:46:05.994Z",
//       "name": "First seller",
//       "value": 4995000,
//       "tax": "5181"
//     }
//   ]
// }
export interface ownerModel {
  idOwner: string;
  name: string;
  address: string;
  photo: string;
  birthday: string;
}

export interface propertyImageModel {
  idPropertyImage: string;
  file: string;
  enable: boolean;
}

export interface propertyTraceModel {
  idPropertyTrace: string;
  dateSale: string;
  name: string;
  value: number;
  tax: string;
}

interface propertyModel {
  idProperty: string;
  name: string;
  address: string;
  price: number;
  codeInternational: string;
  year: number;
  owner: ownerModel;
  propertyImages: propertyImageModel[];
  propertyTraces: propertyTraceModel[];
}

export default propertyModel;