import React from 'react'

export default function Search() {
  return (
     <div className="sidebar-search">
          <div className="input-icon-end position-relative">
            <input type="text" className="form-control" placeholder="Search" />
            <span className="input-icon-addon">
              <i className="isax isax-search-normal"></i>
            </span>
          </div>
        </div>
  )
}