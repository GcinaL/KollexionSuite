import React from 'react'

export default function MenuTitle({ children }: { children: string }) {
  return (
    <li className="menu-title">
        <span>{children}</span>
    </li>
  )
}