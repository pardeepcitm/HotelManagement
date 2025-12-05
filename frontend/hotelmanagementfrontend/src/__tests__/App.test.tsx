import { render, screen } from '@testing-library/react'
import React from 'react'
import { describe, expect, it } from 'vitest'

import App from '../App'

describe('App page', () => {
  it('renders page', () => {
    render(<App />)

    const headingElement = screen.getByText(/GetBooking/i)

    expect(headingElement).toBeInTheDocument()
  })
})
