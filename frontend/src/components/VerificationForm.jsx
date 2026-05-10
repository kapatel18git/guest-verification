import { useState } from 'react'

export default function VerificationForm({ onSubmit, isLoading }) {
  const [mobileNumber, setMobileNumber] = useState('')
  const [error, setError] = useState('')

  const handleChange = (e) => {
    const value = e.target.value.replace(/\D/g, '')
    setMobileNumber(value)
    setError('')
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    
    if (!mobileNumber) {
      setError('Please enter a mobile number')
      return
    }

    if (mobileNumber.length < 10) {
      setError('Mobile number must be at least 10 digits')
      return
    }

    onSubmit(mobileNumber)
  }

  return (
    <form onSubmit={handleSubmit} className="w-100">
      <div className="form-group">
        <label htmlFor="mobile" className="form-label">
          <i className="bi bi-telephone-fill me-2"></i> Mobile Number
        </label>
        <input
          id="mobile"
          type="tel"
          value={mobileNumber}
          onChange={handleChange}
          placeholder="Enter your 10-digit mobile number"
          className="form-control form-control-lg"
          disabled={isLoading}
          maxLength="15"
        />
        {error && (
          <div className="alert alert-danger mt-2 py-2 px-3 mb-0">
            <i className="bi bi-exclamation-circle me-2"></i>
            {error}
          </div>
        )}
      </div>

      <button
        type="submit"
        disabled={isLoading}
        className="btn btn-primary btn-lg w-100 mt-4"
      >
        {isLoading ? (
          <>
            <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
            Verifying...
          </>
        ) : (
          <>
            <i className="bi bi-check-circle me-2"></i>Verify
          </>
        )}
      </button>
    </form>
  )
}
