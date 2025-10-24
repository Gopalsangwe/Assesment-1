import axios from 'axios';

const API_URL = process.env.REACT_APP_API_URL;

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
  const response = await axios.post(`${API_URL}/commission`, data);
  return response.data;
};
