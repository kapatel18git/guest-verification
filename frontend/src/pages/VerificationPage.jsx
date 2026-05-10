import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import VerificationForm from '../components/VerificationForm'
import { useVerification } from '../hooks/useVerification'

export default function VerificationPage() {
  const navigate = useNavigate()
  const { verify, loading, error } = useVerification()
  const [apiError, setApiError] = useState('')

  const handleVerification = async (mobileNumber) => {
    setApiError('')
    try {
      await verify(mobileNumber)
      navigate('/success', { state: { mobileNumber } })
    } catch (err) {
      setApiError(err.message || 'Your mobile number is not in our guest list. Please contact the organizer.')
    }
  }

  return (
    <div className="min-h-screen flex items-center justify-center p-4">
      <div className="bg-white rounded-2xl shadow-2xl p-8 w-full max-w-md">
        <h1 className="text-3xl font-bold text-center mb-2 text-gray-800">
          Guest Verification
        </h1>
        <p className="text-center text-gray-600 mb-8">
          Enter your mobile number to verify your invitation
        </p>

        <VerificationForm onSubmit={handleVerification} isLoading={loading} />

        {apiError && (
          <div className="mt-4 p-4 bg-red-100 border border-red-400 text-red-700 rounded-lg">
            {apiError}
          </div>
        )}

        <div className="mt-8 pt-8 border-t border-gray-200">
          <p className="text-xs text-gray-500 text-center">
            We only collect your mobile number for verification purposes. Your data is secure.
          </p>
        </div>
      </div>
    </div>
  )
}
