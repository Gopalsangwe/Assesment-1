import axios from "axios";

const API_URL = "https://localhost:5001/Commision";

export interface CommissionCalculationRequest {
  localSalesCount: number;
  foreignSalesCount: number;
  averageSaleAmount: number;
}

export interface CommissionCalculationResponse {
  avalphaLocal: number;
  avalphaForeign: number;
  avalphaTotal: number;
  competitorLocal: number;
  competitorForeign: number;
  competitorTotal: number;
}

export async function calculateCommission(
  data: CommissionCalculationRequest
): Promise<CommissionCalculationResponse> {
  const response = await axios.post<CommissionCalculationResponse>(API_URL, data);
  return response.data;
}
