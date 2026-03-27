import React from "react";

interface GlobalOffcanvasProps {
  id?: string;
  title?: string;
  placement?: "start" | "end" | "top" | "bottom";
  children?: React.ReactNode;
  size?: "sm" | "md" | "lg" | "xl";
}

/**
 * Global reusable offcanvas component.
 * - Use Bootstrap's JS API or data attributes to toggle it.
 * - Can be mounted anywhere; Bootstrap handles animations & backdrop.
 * - Doesn't interfere with dropdowns or modals.
 */
const GlobalOffcanvas: React.FC<GlobalOffcanvasProps> = ({
  id = "global-offcanvas",
  title = "Title",
  placement = "end",
  size,
  children,
}) => {
  const sizeClass =
    size === "sm"
      ? "offcanvas-sm"
      : size === "md"
      ? "offcanvas-md"
      : size === "lg"
      ? "offcanvas-lg"
      : size === "xl"
      ? "offcanvas-xl"
      : "";

  return (
    <div
      className={`offcanvas offcanvas-${placement} offcanvas-offset ${sizeClass}`}
      tabIndex={-1}
      id={id}
      aria-labelledby={`${id}-label`}
    >
      <div className="offcanvas-header d-block pb-0">
        <div className="border-bottom d-flex align-items-center justify-content-between pb-3">
          <h6 className="offcanvas-title" id={`${id}-label`}>
            {title}
          </h6>
          <button
            type="button"
            className="btn-close btn-close-modal custom-btn-close"
            data-bs-dismiss="offcanvas"
            aria-label="Close"
          >
            <i className="fa-solid fa-x"></i>
          </button>
        </div>
      </div>
      <div className="offcanvas-body pt-3">{children}</div>
    </div>
  );
};

export default GlobalOffcanvas;
