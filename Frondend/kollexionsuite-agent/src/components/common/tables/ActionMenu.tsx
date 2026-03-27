// ActionMenu.tsx
import React, { useEffect, useLayoutEffect, useRef, useState } from "react";
import { createPortal } from "react-dom";

export interface ActionItem<T> {
  label: string;
  icon?: string;
  onClick?: (row: T) => void;
  className?: string;
}

interface ActionMenuProps<T> {
  row: T;
  items: ActionItem<T>[];
}

export default function ActionMenu<T>({ row, items }: ActionMenuProps<T>) {
  const [open, setOpen] = useState(false);
  const [pos, setPos] = useState<{ top: number; left: number }>({ top: 0, left: 0 });
  const btnRef = useRef<HTMLButtonElement | null>(null);

  const updatePosition = () => {
    const r = btnRef.current?.getBoundingClientRect();
    if (!r) return;
    // Position the menu just below the trigger, right-aligned to the button
    setPos({ top: r.bottom + window.scrollY, left: r.right + window.scrollX });
  };

  const toggle = () => {
    if (!open) updatePosition();
    setOpen((v) => !v);
  };

  useLayoutEffect(() => {
    if (!open) return;
    updatePosition();
  }, [open]);

  useEffect(() => {
    if (!open) return;
    const onScrollOrResize = () => updatePosition();
    const onDocClick = (e: MouseEvent) => {
      if (!btnRef.current) return;
      if (btnRef.current.contains(e.target as Node)) return; // click on button
      setOpen(false);
    };
    window.addEventListener("scroll", onScrollOrResize, true);
    window.addEventListener("resize", onScrollOrResize);
    document.addEventListener("click", onDocClick);
    return () => {
      window.removeEventListener("scroll", onScrollOrResize, true);
      window.removeEventListener("resize", onScrollOrResize);
      document.removeEventListener("click", onDocClick);
    };
  }, [open]);

  return (
    <>
      <button
        ref={btnRef}
        type="button"
        className="btn btn-outline btn-sm rounded-circle"
        style={{height:"24px", width:"24px", paddingTop:"5px"}}
        onClick={toggle}
        aria-haspopup="menu"
        aria-expanded={open}
      >
        <i className="isax isax-more" />
      </button>

      {open &&
        createPortal(
          <ul
            role="menu"
            className="dropdown-menu show shadow-sm"
            style={{
              position: "absolute",
              top: pos.top,
              left: pos.left,
              transform: "translateX(-100%)", // right align to button
              zIndex: 9999,
            }}
          >
            {items.map((a, i) => (
              <li key={i}>
                <button
                  type="button"
                  className={`dropdown-item d-flex align-items-center ${a.className ?? ""}`}
                  onClick={() => {
                    a.onClick?.(row);
                    setOpen(false);
                  }}
                >
                  {a.icon && <i className={`${a.icon} me-2`} />}
                  {a.label}
                </button>
              </li>
            ))}
          </ul>,
          document.body
        )}
    </>
  );
}
