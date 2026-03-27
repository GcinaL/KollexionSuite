import React from "react";
import "./buttons.scss";

type Variant =
  | "primary"
  | "secondary"
  | "success"
  | "danger"
  | "warning"
  | "info"
  | "light"
  | "dark";


export interface IconButtonProps
  extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  icon: string;                 // e.g. "feather-download"
  variant?: Variant;            // Bootstrap color
  soft?: boolean;               // btn-soft-*
  outline?: boolean;            // btn-outline-*
  rounded?: boolean;            // rounded
  pill?: boolean;               // rounded-pill
  ariaLabel?: string;           // for icon-only accessibility
  className?: string;
  children?: React.ReactNode;   // optional text label
  disabled?: boolean;
}

const IconButton: React.FC<IconButtonProps> = ({
  icon,
  variant = "success",
  soft = false,
  outline = false,
  rounded = false,
  pill = false,
  ariaLabel,
  className = "",
  disabled = false,
  children,
  type = "button",
  ...rest
}) => {

  // Priority: outline > soft > solid
  const styleClass = outline
    ? `btn-outline-${variant}`
    : soft
    ? `btn-soft-${variant}`
    : `btn-${variant}`;

  const shapeClass = [
    pill ? "rounded-pill" : "",
    !pill && rounded ? "rounded" : "",
  ]
    .filter(Boolean)
    .join(" ");

  const classes = [
    "btn",
    "btn-icon",
    styleClass,
    shapeClass,
    className,
  ]
    .filter(Boolean)
    .join(" ");

  return (
    <button
      type={type}
      className={classes}
      aria-label={ariaLabel || (typeof children === "string" ? children : undefined)}
      disabled={disabled}
      {...rest}
    >
      <i className={icon} />
      {children ? <span className="ms-2">{children}</span> : null}
    </button>
  );
};

export default IconButton;
