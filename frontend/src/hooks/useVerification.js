import { useState } from 'react'
import { verifyGuest } from '../services/api'

export const useVerification = () => {
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState(null)
  const [guestData, setGuestData] = useState(null)

  const verify = async (mobileNumber) => {
    setLoading(true)
    setError(null)
    try {
      const data = await verifyGuest(mobileNumber)
      setGuestData(data)
      return data
    } catch (err) {
      const errorMessage = err.message || 'Verification failed'
      setError(errorMessage)
      throw err
    } finally {
      setLoading(false)
    }
  }

  return { verify, loading, error, guestData }
}
