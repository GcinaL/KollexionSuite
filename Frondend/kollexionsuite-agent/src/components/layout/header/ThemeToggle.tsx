import { useState, useEffect } from "react";

export default function ThemeToggle() {
  const [dark, setDark] = useState(() => {
    return localStorage.getItem("theme") === "dark";
  });

  useEffect(() => {
    document.documentElement.setAttribute("data-bs-theme", dark ? "dark" : "light");
    localStorage.setItem("theme", dark ? "dark" : "light");
  }, [dark]);

  return (
    <div className="me-2 theme-item d-flex align-items-center">
      {/* Show moon when in light mode */}
      {!dark && (
        <a
          href="#"
          onClick={(e) => {
            e.preventDefault();
            setDark(true);
          }}
          className="theme-toggle btn btn-menubar"
        >
          <i className="isax isax-moon"></i>
        </a>
      )}

      {/* Show sun when in dark mode */}
      {dark && (
        <a
          href="#"
          onClick={(e) => {
            e.preventDefault();
            setDark(false);
          }}
          className="theme-toggle btn btn-menubar"
        >
          <i className="isax isax-sun-1"></i>
        </a>
      )}
    </div>
  );
}
