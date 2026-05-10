import { useState } from 'react'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import VerificationPage from './pages/VerificationPage'
import SuccessPage from './pages/SuccessPage'
import './App.css'

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<VerificationPage />} />
        <Route path="/success" element={<SuccessPage />} />
      </Routes>
    </Router>
  )
}

export default App
