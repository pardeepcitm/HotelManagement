import React, { useState, useEffect } from 'react'
import { Booking } from '../types/interfaces'
import { checkoutRoom, fetchAllBookings } from './../apis/bookingService'

const GetBooking: React.FC = () => {
  const [bookings, setBookings] = useState<Booking[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  const handleCheckout = async (bookingNumber: string) => {
    try {
      await checkoutRoom(bookingNumber)

      setBookings((prev) =>
        prev.map((b) =>
          b.bookingNumber === bookingNumber ? { ...b, isCheckedOut: true } : b,
        ),
      )
    } catch (err) {
      const message =
        err instanceof Error ? err.message : 'Failed to process checkout.'
      console.error(message)
      alert(message)
    }
  }

  useEffect(() => {
    const loadBookings = async () => {
      setLoading(true)
      setError(null)
      try {
        const data = await fetchAllBookings()
        setBookings(data)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Something went wrong')
      } finally {
        setLoading(false)
      }
    }

    loadBookings()
  }, [])

  if (loading) return <div>Loading bookings...</div>
  if (error) return <div className="text-red-600">Error: {error}</div>

  return (
    <div className="p-4">
      <h2 className="mb-4 text-xl font-bold">Current Bookings</h2>
      {bookings.length === 0 ? (
        <p>No active bookings found.</p>
      ) : (
        <ul className="space-y-4">
          {bookings.map((booking) => (
            <li
              key={booking.bookingNumber}
              className={`flex items-start justify-between rounded p-3 shadow ${
                booking.isCheckedOut ? 'bg-gray-200 text-gray-500' : 'bg-white'
              }`}>
              {/* === MISSING ELEMENTS ADDED HERE === */}
              <div className="flex flex-col gap-1">
                <p>
                  <strong>Booking:</strong> {booking.bookingNumber}
                </p>
                <p>
                  <strong>Guest:</strong> {booking.guestEmail}
                </p>
                <p>
                  <strong>Room Type:</strong> {booking.roomType} (Room{' '}
                  {booking.roomNumber || 'N/A'})
                </p>
                <p>
                  <strong>Check-In:</strong> {booking.checkIn.split('T')[0]}
                </p>
                <p>
                  <strong>Check-Out:</strong> {booking.checkOut.split('T')[0]}
                </p>
                <p>
                  <strong>Total Price:</strong> SEK{' '}
                  {booking.totalPrice.toFixed(2)}
                </p>
                <p className="mt-2">
                  <strong>Status:</strong>{' '}
                  {booking.isCheckedOut ? 'Checked Out' : 'Active'}
                </p>
              </div>

              {!booking.isCheckedOut && (
                <button
                  onClick={() => handleCheckout(booking.bookingNumber)}
                  className="rounded bg-red-500 px-4 py-2 font-semibold text-white transition-colors hover:bg-red-600">
                  Checkout
                </button>
              )}
            </li>
          ))}
        </ul>
      )}
    </div>
  )
}

export default GetBooking
