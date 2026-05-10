import { useLocation, useNavigate } from 'react-router-dom'

export default function SuccessPage() {
  const location = useLocation()
  const navigate = useNavigate()
  const mobileNumber = location.state?.mobileNumber

  return (
    <div className="min-h-screen flex items-center justify-center p-4">
      <div className="bg-white rounded-2xl shadow-2xl p-8 w-full max-w-md text-center">
        <div className="mb-6">
          <div className="inline-flex items-center justify-center w-20 h-20 bg-green-100 rounded-full">
            <svg
              className="w-10 h-10 text-green-600"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d="M5 13l4 4L19 7"
              />
            </svg>
          </div>
        </div>

        <h1 className="text-3xl font-bold text-gray-800 mb-2">Verified!</h1>
        <p className="text-gray-600 mb-2">
          Your mobile number has been verified successfully
        </p>
        {mobileNumber && (
          <p className="text-sm text-gray-500 mb-6">
            Number: {mobileNumber}
          </p>
        )}

        <button
          onClick={() => navigate('/')}
          className="w-full bg-gradient-to-r from-blue-500 to-purple-600 text-white font-bold py-3 rounded-lg hover:shadow-lg transition"
        >
          Verify Another Guest
        </button>

        <p className="mt-6 text-xs text-gray-500">
          Thank you for verifying. You're all set for the event!
        </p>
      </div>
    </div>
  )
}
