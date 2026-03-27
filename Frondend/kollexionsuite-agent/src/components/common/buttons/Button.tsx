import React from "react";
import "./buttons.scss";

export interface ButtonProps {
  label?: string;
  submit?: boolean;
  variant?: "primary" | "light" | "secondary" | "success" | "danger" | "none"; // Bootstrap variants
  block?: boolean; // full width
  underline?: boolean;
  icon?: string; // pass className for icon (like "isax isax-add-circle5")
  iconPosition?: "start" | "end";
  modalTarget?: string; // pass modal id like "#add_modal"
  className?: string;
  onClick?: (e: React.MouseEvent<HTMLButtonElement>) => void;
  disabled?: boolean;
  dataBsToggle?:string;
  dataBsTarget?:string;
}

const Button: React.FC<ButtonProps> = ({
  label,
  submit = false,
  variant = "none",
  block = false,
  underline = false,
  icon,
  iconPosition = "start",
  dataBsToggle,
  dataBsTarget,
  className = "",
  onClick,
  disabled = false,
}) => {
  const classes = [
    "btn",
    variant === "none" ? "text-secondary pe-1 ps-1" : `btn-${variant}`,
    block ? "w-100" : "",
    underline ? "text-decoration-underline" : "",
    className,
  ]
    .filter(Boolean)
    .join(" ");

  const attrs: Record<string, string> = {};
  if (dataBsToggle && dataBsTarget) {
    attrs["data-bs-toggle"] = {dataBsToggle}+"";
    attrs["data-bs-target"] = {dataBsTarget}+"";
  }

  return (
    <button
      type={submit ? "submit" : "button"}
      className={classes}
      onClick={onClick}
      disabled={disabled}
      {...attrs}
    >
      {icon && iconPosition === "start" && <i className={`${icon}`} />}
      {label && <span className="ps-1 pe-1">{label}</span>}
      {icon && iconPosition === "end" && <i className={`${icon}`} />}
    </button>
  );
};

export default Button;
