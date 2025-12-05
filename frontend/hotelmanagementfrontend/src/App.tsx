import React from 'react'
import {
  BrowserRouter as Router,
  Routes,
  Route,
  NavLink,
} from 'react-router-dom'

import BookRoom from './pages/BookRoom'
import GetBooking from './pages/GetBooking'

const App: React.FC = () => {
  return (
    <Router>
      <div className="min-h-screen bg-gray-50">
        {/* Navbar */}
        <nav className="flex gap-4 bg-white px-6 py-4 shadow-md">
          <NavLink
            to="/"
            className={({ isActive }) =>
              `text-lg font-semibold ${isActive ? 'text-purple-600' : 'text-gray-700'}`
            }>
            BookRoom
          </NavLink>
          <NavLink
            to="/get-booking"
            className={({ isActive }) =>
              `text-lg font-semibold ${isActive ? 'text-purple-600' : 'text-gray-700'}`
            }>
            GetBooking
          </NavLink>
        </nav>

        {/* Page content */}
        <main className="p-6">
          <Routes>
            <Route path="/" element={<BookRoom />} />
            <Route path="/get-booking" element={<GetBooking />} />
          </Routes>
        </main>
      </div>
    </Router>
  )
}

export default App
