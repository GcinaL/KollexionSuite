import React from "react";
import { Link } from "react-router-dom";

export interface DropdownItem {
  label: string;
  href?: string;
  icon?: string;
  onClick?: () => void;
}

export interface DropdownButtonProps {
  label: string;
  variant?: "primary" | "light" | "secondary" | "success" | "danger" | "none";
  block?: boolean; // full width
  underline?: boolean;
  icon?: string; // icon class e.g. "isax isax-add-circle5"
  iconPosition?: "start" | "end";
  className?: string;
  items: DropdownItem[];
  align?: "start" | "end" | "both"; // dropdown alignment
}

/**
 * DropdownButton component styled like Button/LinkButton, using <Link> for navigation
 */
const DropdownButton: React.FC<DropdownButtonProps> = ({
  label,
  variant = "none",
  block = true,
  underline = false,
  icon,
  iconPosition = "start",
  className = "",
  items,
  align = "start",
}) => {
  // ✅ Classes for styling consistency
  const classes = [
    "btn",
    variant === "none" ? "text-secondary" : `btn-outline-${variant}`,
    block ? "w-100" : "",
    underline ? "text-decoration-underline" : "",
    "dropdown-toggle",
    "btn-wave",
    className,
  ]
    .filter(Boolean)
    .join(" ");

  // ✅ Modal attributes
  const attrs: Record<string, string> = { "data-bs-toggle": "dropdown" };

  // ✅ Dropdown alignment class
  const alignClass =
    align === "both"
      ? "dropdown-menu-start dropdown-menu-end"
      : `dropdown-menu-${align}`;

  return (
    <div className="dropdown d-inline-block">
      <Link to="#" className={classes} role="button" {...attrs} >
        {icon && iconPosition === "start" && <i className={`${icon} me-1`} />}
        {label}
        {icon && iconPosition === "end" && <i className={`${icon} ms-1`} />}
      </Link>

      <ul className={`dropdown-menu ${alignClass}`} >
        {items.map((item, idx) => (
          <li key={idx}>
            <Link
              to={item.href || "#"}
              className="dropdown-item d-flex align-items-center"
              onClick={item.onClick}
            >
              {item.icon && <i className={`${item.icon} me-2`} />}
              {item.label}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default DropdownButton;
