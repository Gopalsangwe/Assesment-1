import axios from 'axios';

const API_BASE_URL = 'https://localhost:5000/commision'; 

export interface CommissionInput {
  localSalesCount: number;
  foreignSalesCount: number;
  averageSaleAmount: number;
}

export interface CommissionResponse {
  avalphaLocal: number;
  avalphaForeign: number;
  avalphaTotal: number;
  competitorLocal: number;
  competitorForeign: number;
  competitorTotal: number;
}

export const calculateCommission = async (data: CommissionInput): Promise<CommissionResponse> => {
  const response = await axios.post(API_BASE_URL, data);
  return response.data;
};
