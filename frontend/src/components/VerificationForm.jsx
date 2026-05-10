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
    <form onSubmit={handleSubmit} className="w-full">
      <div className="mb-4">
        <label htmlFor="mobile" className="block text-sm font-medium text-gray-700 mb-2">
          Mobile Number
        </label>
        <input
          id="mobile"
          type="tel"
          value={mobileNumber}
          onChange={handleChange}
          placeholder="Enter your mobile number"
          className="w-full px-4 py-3 border-2 border-gray-300 rounded-lg focus:outline-none focus:border-blue-500 transition"
          disabled={isLoading}
        />
        {error && <p className="text-red-500 text-sm mt-2">{error}</p>}
      </div>

      <button
        type="submit"
        disabled={isLoading}
        className="w-full bg-gradient-to-r from-blue-500 to-purple-600 text-white font-bold py-3 rounded-lg hover:shadow-lg transition disabled:opacity-50 disabled:cursor-not-allowed"
      >
        {isLoading ? 'Verifying...' : 'Verify'}
      </button>
    </form>
  )
}
