import axios from 'axios'

const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000/api'

const apiClient = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
})

export const verifyGuest = async (mobileNumber) => {
  try {
    const response = await apiClient.post('/guests/verify', {
      mobileNumber: mobileNumber.trim(),
    })
    return response.data
  } catch (error) {
    throw error.response?.data || { message: 'Verification failed. Please try again.' }
  }
}

export const validateMobileNumber = async (mobileNumber) => {
  try {
    const response = await apiClient.get(`/guests/validate/${mobileNumber}`)
    return response.data
  } catch (error) {
    throw error.response?.data || { message: 'Validation failed.' }
  }
}

export default apiClient
