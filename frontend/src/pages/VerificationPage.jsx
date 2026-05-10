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
    <div className="min-vh-100 d-flex align-items-center justify-content-center py-4">
      <div className="w-100 px-3" style={{ maxWidth: '500px' }}>
        {/* Header */}
        <div className="text-center mb-5">
          <div className="mb-3">
            <i className="bi bi-shield-check" style={{ fontSize: '3rem', color: '#009ef7' }}></i>
          </div>
          <h1 className="h2 fw-bold mb-2" style={{ color: '#2d3748' }}>
            Guest Verification
          </h1>
          <p className="text-muted mb-0">
            Enter your mobile number to verify your invitation
          </p>
        </div>

        {/* Card */}
        <div className="card border-0">
          <div className="card-body">
            <VerificationForm onSubmit={handleVerification} isLoading={loading} />

            {/* API Error */}
            {apiError && (
              <div className="alert alert-danger mt-4 mb-0">
                <i className="bi bi-exclamation-triangle-fill me-2"></i>
                {apiError}
              </div>
            )}
          </div>
        </div>

        {/* Footer Info */}
        <div className="text-center mt-5">
          <p className="text-muted small mb-0">
            <i className="bi bi-lock-fill me-2"></i>
            We only collect your mobile number for verification purposes. Your data is secure.
          </p>
        </div>
      </div>
    </div>
  )
}
