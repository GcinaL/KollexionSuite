import React from "react";
import "./buttons.scss";

type Size = "sm" | "md" | "lg";
type Variant =
  | "primary" | "secondary" | "success" | "danger"
  | "warning" | "info" | "light" | "dark" | "outline-primary"
  | "outline-secondary" | "outline-success" | "outline-danger"
  | "outline-warning" | "outline-info" | "outline-light" | "outline-dark";

export interface CircleButtonProps
  extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  size?: Size;
  variant?: Variant;
  /** If true, shows a spinner and disables the button */
  loading?: boolean;
  /** Accessible label (recommended if only showing an icon) */
  ariaLabel?: string;
  /** Optional Bootstrap tooltip text */
  tooltip?: string;
}

const sizeClass: Record<Size, string> = {
  sm: "btn-circle-sm",
  md: "btn-circle-md",
  lg: "btn-circle-lg",
};

export default function CircleButton({
  size = "md",
  variant = "primary",
  loading = false,
  ariaLabel,
  tooltip,
  className,
  children,
  disabled,
  ...btnProps
}: CircleButtonProps) {
  const isDisabled = disabled || loading;

  return (
    <button
      type="button"
      className={[
        "btn",
        `btn-${variant}`,
        "rounded-circle",
        sizeClass[size],
        className ?? "",
      ].join(" ").trim()}
      disabled={isDisabled}
      aria-label={ariaLabel}
      title={tooltip}
      {...btnProps}
    >
      {loading ? (
        <span
          className="spinner-border spinner-border-sm"
          role="status"
          aria-hidden="true"
        />
      ) : (
        children
      )}
    </button>
  );
}
