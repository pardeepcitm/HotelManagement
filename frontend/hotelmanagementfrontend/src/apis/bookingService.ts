import apiClient from './apiClient'
import axios, { AxiosError } from 'axios'
import { Booking, BookingForm, BookingResponse } from '../types/interfaces'

const BOOKING_ENDPOINT = '/Roombooking'
const CHECKOUT_ENDPOINT = '/RoomCheckout'

export async function fetchAllBookings(): Promise<Booking[]> {
  try {
    const response = await apiClient.get<Booking[]>(BOOKING_ENDPOINT)
    return response.data
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(`Failed to fetch bookings: ${error.message}`)
    }
    throw new Error('An unknown error occurred while fetching bookings.')
  }
}

export async function checkoutRoom(bookingNumber: string): Promise<void> {
  try {
    await apiClient.post(`${CHECKOUT_ENDPOINT}/${bookingNumber}`)
  } catch (error) {
    if (axios.isAxiosError(error)) {
      const status = error.response?.status
      const errorMessage = error.response?.data?.title || error.message
      throw new Error(`Checkout failed (Status ${status}): ${errorMessage}`)
    }
    throw new Error('An unknown error occurred during checkout.')
  }
}

export async function createRoomBooking(
  formData: BookingForm,
): Promise<BookingResponse> {
  try {
    const response = await apiClient.post<BookingResponse>(
      BOOKING_ENDPOINT,
      formData,
    )

    return response.data
  } catch (error) {
    if (axios.isAxiosError(error)) {
      const axiosError = error as AxiosError<{
        status: number
        title: string
        detail: string
      }>

      const status = axiosError.response?.status || -1
      if (status === -1) {
        throw new Error(
          `Network Error: Could not connect to the booking service.`,
        )
      }
      const errorData = axiosError.response?.data

      const messageFromBackend =
        errorData?.detail || errorData?.title || axiosError.message

      throw new Error(
        `Booking failed (Status ${status}): ${messageFromBackend}`,
      )
    }

    throw new Error('An unknown network error occurred.')
  }
}
