import { useLocation, useNavigate } from 'react-router-dom'

export default function SuccessPage() {
  const location = useLocation()
  const navigate = useNavigate()
  const mobileNumber = location.state?.mobileNumber

  return (
    <div className="min-vh-100 d-flex align-items-center justify-content-center py-4">
      <div className="w-100 px-3" style={{ maxWidth: '500px' }}>
        {/* Success Icon */}
        <div className="text-center mb-4">
          <div className="d-inline-flex align-items-center justify-content-center rounded-circle mb-3" 
               style={{ width: '80px', height: '80px', backgroundColor: 'rgba(80, 205, 137, 0.15)' }}>
            <i className="bi bi-check-circle-fill" style={{ fontSize: '2.5rem', color: '#50cd89' }}></i>
          </div>
        </div>

        {/* Card */}
        <div className="card border-0">
          <div className="card-body text-center">
            <h1 className="h2 fw-bold mb-2" style={{ color: '#2d3748' }}>
              Verified!
            </h1>
            <p className="text-muted mb-3">
              Your mobile number has been verified successfully
            </p>
            
            {mobileNumber && (
              <div className="alert alert-info mb-4">
                <strong>Mobile Number:</strong> {mobileNumber}
              </div>
            )}

            <button
              onClick={() => navigate('/')}
              className="btn btn-primary btn-lg w-100 mb-3"
            >
              <i className="bi bi-arrow-repeat me-2"></i>Verify Another Guest
            </button>

            <p className="text-muted small mb-0">
              <i className="bi bi-star-fill me-2" style={{ color: '#ffc700' }}></i>
              Thank you for verifying. You're all set for the event!
            </p>
          </div>
        </div>
      </div>
    </div>
  )
}
