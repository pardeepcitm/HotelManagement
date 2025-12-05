export interface BookingForm {
  checkIn: string
  checkOut: string
  roomType: 'Standard' | 'Deluxe'
  guestEmail: string
}

export interface BookingResponse {
  bookingNumber: string
  guestEmail: string
  checkIn: string
  checkOut: string
  roomType: string
  totalPrice: number
}

export interface Booking {
  bookingNumber: string
  roomNumber: string | null
  guestEmail: string
  checkIn: string
  checkOut: string
  roomType: string
  totalPrice: number
  isCheckedOut: boolean
}
