import React from "react";

export interface DropdownLinkProps {
  label?: string;                 // Optional prefix text e.g. "Sort By :"
  options: string[];              // List of dropdown options
  selected: string;               // Currently selected option
  onSelect: (option: string) => void;  // Callback when user selects an option
  alignEnd?: boolean;         // Optional alignment flag (default true)
  className?: string;             // Optional class for outer div
}

const DropdownLink: React.FC<DropdownLinkProps> = ({
  label,
  options,
  selected,
  onSelect,
  alignEnd = true,
  className = "",
}) => {
  return (
    <div className={`d-inline-flex align-items-center ${className}`}>
      {label && <span className="me-2">{label}</span>}
      <div className="dropdown">
        <a
          href="javascript:void(0);"
          className="dropdown-toggle fs-14 btn btn-outline-white d-inline-flex align-items-center border-0 bg-transparent p-0 text-dark fw-normal"
          data-bs-toggle="dropdown"
        >
          {selected}
        </a>
        <ul
          className={`dropdown-menu p-3 ${alignEnd ? "dropdown-menu-end" : ""}`}
        >
          {options.map((option) => (
            <li key={option}>
              <a
                href="javascript:void(0);"
                className={`dropdown-item rounded-1 ${
                  option === selected ? "active" : ""
                }`}
                onClick={() => onSelect(option)}
              >
                {option}
              </a>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default DropdownLink;
