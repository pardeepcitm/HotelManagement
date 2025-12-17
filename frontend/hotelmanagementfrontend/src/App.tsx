import React from 'react'
import {
  BrowserRouter as Router,
  Routes,
  Route,
  NavLink,
} from 'react-router-dom'

import BookRoom from './pages/BookRoom'
import GetBooking from './pages/GetBooking'
import HeaderBar from './pages/header/HeaderBar'

const App: React.FC = () => {
  return (
    <div>
      <HeaderBar></HeaderBar>
    </div>
    /* <Router>
      <div className="min-h-screen bg-gray-50">
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
        <main className="p-6">
          <Routes>
            <Route path="/" element={<BookRoom />} />
            <Route path="/get-booking" element={<GetBooking />} />
          </Routes>
        </main>
      </div>
    </Router>*/
  )
}
export default App
