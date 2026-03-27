import React, { useState } from "react";

export interface NavPillButtonProps {
  label: string;
  active?: boolean;
  className?: string;
  onClick?: () => void;
  icon?: string; // Bootstrap or custom icon class
  iconPosition?: "start" | "end";
}

export const NavPillButton: React.FC<NavPillButtonProps> = ({
  label,
  active = false,
  className = "",
  onClick,
  icon,
  iconPosition = "start",
}) => {
  return (
    <button
      className={[
        "nav-link btn btn-sm btn-icon p-2 d-flex align-items-center justify-content-center w-auto",
        active ? "active" : "",
        className,
      ]
        .filter(Boolean)
        .join(" ")}
      type="button"
      role="tab"
      aria-selected={active ? "true" : "false"}
      onClick={onClick}
    >
      {icon && iconPosition === "start" && <i className={`${icon} me-1`} />}
      {label}
      {icon && iconPosition === "end" && <i className={`${icon} ms-1`} />}
    </button>
  );
};


export interface NavPillItem {
  label: string;
  value: string; // identifier for this tab
  icon?: string;
  iconPosition?: "start" | "end";
}

export interface NavPillsProps {
  items: NavPillItem[];
  defaultActive?: string; // which tab starts active
  onChange?: (value: string) => void;
  id?: string;
  className?: string;
}

const NavPills: React.FC<NavPillsProps> = ({
  items,
  defaultActive,
  onChange,
  id = "nav-pills-tab",
  className = "",
}) => {
  const [active, setActive] = useState<string>(
    defaultActive || (items.length > 0 ? items[0].value : "")
  );

  const handleClick = (value: string) => {
    setActive(value);
    if (onChange) onChange(value);
  };

  return (
    <ul
      className={[
        "nav nav-pills border d-inline-flex w-100 p-1 rounded bg-light todo-tabs",
        className,
      ]
        .filter(Boolean)
        .join(" ")}
      id={id}
      role="tablist"
    >
      {items.map((item, idx) => (
        <li key={idx} className="nav-item me-1" role="presentation">
          <NavPillButton
            label={item.label}
            active={active === item.value}
            onClick={() => handleClick(item.value)}
            icon={item.icon}
            iconPosition={item.iconPosition}
          />
        </li>
      ))}
    </ul>
  );
};

export default NavPills;
