import { useState } from 'react'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import VerificationPage from './pages/VerificationPage'
import SuccessPage from './pages/SuccessPage'

function App() {
  return (
    <Router>
      <div className="min-vh-100 d-flex flex-column">
        <Routes>
          <Route path="/" element={<VerificationPage />} />
          <Route path="/success" element={<SuccessPage />} />
        </Routes>
      </div>
    </Router>
  )
}

export default App
