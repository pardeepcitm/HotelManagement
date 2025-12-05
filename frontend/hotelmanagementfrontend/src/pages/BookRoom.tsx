import React, { useState } from 'react'
import { BookingForm, BookingResponse } from '../types/interfaces'

import { createRoomBooking } from './../apis/bookingService'

const BookRoom: React.FC = () => {
  const [form, setForm] = useState<BookingForm>({
    checkIn: '',
    checkOut: '',
    roomType: 'Standard',
    guestEmail: '',
  })

  const [response, setResponse] = useState<BookingResponse | null>(null)
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>,
  ) => {
    // Destructuring for cleaner state update
    const { name, value } = e.target
    setForm((prevForm) => ({ ...prevForm, [name]: value }))
  }

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setLoading(true)
    setError(null)
    setResponse(null)

    try {
      const data = await createRoomBooking(form)
      setResponse(data)
    } catch (err) {
      setError(
        err instanceof Error
          ? err.message
          : 'Something went wrong during booking.',
      )
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="mx-auto max-w-md rounded-md bg-white p-6 shadow">
      <h1 className="mb-6 text-center text-2xl font-bold">Book a Room</h1>

      <form onSubmit={handleSubmit} className="flex flex-col gap-4">
        <div>
          <label className="mb-1 block font-medium">Guest Email</label>
          <input
            type="email"
            name="guestEmail"
            value={form.guestEmail}
            onChange={handleChange}
            required
            className="w-full rounded border border-gray-300 px-3 py-2 focus:border-purple-500 focus:outline-none focus:ring"
          />
        </div>

        {/* Check-In */}
        <div>
          <label className="mb-1 block font-medium">Check-In</label>
          <input
            type="date"
            name="checkIn"
            value={form.checkIn}
            onChange={handleChange}
            required
            className="w-full rounded border border-gray-300 px-3 py-2 focus:border-purple-500 focus:outline-none focus:ring"
          />
        </div>

        {/* Check-Out */}
        <div>
          <label className="mb-1 block font-medium">Check-Out</label>
          <input
            type="date"
            name="checkOut"
            value={form.checkOut}
            onChange={handleChange}
            required
            className="w-full rounded border border-gray-300 px-3 py-2 focus:border-purple-500 focus:outline-none focus:ring"
          />
        </div>

        {/* Room Type */}
        <div>
          <label className="mb-1 block font-medium">Room Type</label>
          <select
            name="roomType"
            value={form.roomType}
            onChange={handleChange}
            className="w-full rounded border border-gray-300 px-3 py-2 focus:border-purple-500 focus:outline-none focus:ring">
            <option value="Standard">Standard</option>
            <option value="Deluxe">Deluxe</option>
          </select>
        </div>

        <button
          type="submit"
          disabled={loading}
          className="mt-4 rounded bg-purple-600 py-2 font-semibold text-white transition-colors hover:bg-purple-700">
          {loading ? 'Booking...' : 'Book Room'}
        </button>
      </form>

      {/* Display booking response */}
      {response && (
        <div className="mt-4 space-y-1 rounded bg-green-100 p-4 text-green-800">
          <p>
            <strong>Booking Number:</strong> {response.bookingNumber}
          </p>
          <p>
            <strong>Guest Email:</strong> {response.guestEmail}
          </p>
          <p>
            <strong>Check-In:</strong> {response.checkIn.split('T')[0]}
          </p>
          <p>
            <strong>Check-Out:</strong> {response.checkOut.split('T')[0]}
          </p>
          <p>
            <strong>Room Type:</strong> {response.roomType}
          </p>
          <p>
            <strong>Total Price:</strong> SEK {response.totalPrice}
          </p>
        </div>
      )}

      {error && (
        <div className="mt-4 rounded bg-red-100 p-3 text-red-700">{error}</div>
      )}
    </div>
  )
}

export default BookRoom
