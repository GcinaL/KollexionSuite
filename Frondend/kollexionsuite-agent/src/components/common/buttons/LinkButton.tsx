import React from "react";
import { Link } from "react-router-dom";
import "./buttons.scss";

export interface LinkButtonProps {
  href?: string;
  label: string;
  variant?: "primary" | "light" | "secondary" | "success" | "danger"  | "link" | "none"; // bootstrap variants
  block?: boolean; // full width
  underline?: boolean;
  icon?: string; // pass className for icon (like "isax isax-add-circle5")
  iconPosition?: "start" | "end";
  modalTarget?: string; // pass modal id like "#add_modal"
  className?: string;
}

const LinkButton: React.FC<LinkButtonProps> = ({
  href = "#",
  label,
  variant = "none",
  block = false,
  underline = false,
  icon,
  iconPosition = "start",
  modalTarget,
  className = ""
}) => {
const classes = [
  "btn",
  variant === "none" ? "text-secondary" : `btn-${variant}`,
  block ? "w-100" : "",
  underline ? "text-decoration-underline" : "",
  className,
]
    .filter(Boolean)
    .join(" ");

  const attrs: Record<string, string> = {};
  if (modalTarget) {
    attrs["data-bs-toggle"] = "modal";
    attrs["data-bs-target"] = modalTarget;
  }

  return (
    <Link to={href} className={classes} {...attrs}>
      {icon && iconPosition === "start" && <i className={`${icon} me-1`}></i>}
      {label}
      {icon && iconPosition === "end" && <i className={`${icon} ms-1`}></i>}
    </Link >
  );
};

export default LinkButton;
