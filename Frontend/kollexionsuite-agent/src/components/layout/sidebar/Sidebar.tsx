import SidebarLogo from "./Logo";
import Search from "./Search";
import Menu from "./Menu";
import SimpleBar from "simplebar-react";
import { useSidebar } from './SidebarContext';
import { useEffect, useMemo, useState } from 'react';
import './sidebar.scss';

export default function Sidebar() {
   const { isMini, toggleSidebar, isMobileOpen, openMobile, closeMobile } = useSidebar();

   // ✅ Track whether we are hovering (desktop only)
  const [hovering, setHovering] = useState(false);

   // Desktop media query (matches your SCSS breakpoint 992px)
  const mql = useMemo(() => window.matchMedia("(min-width: 992px)"), []);

  // ✅ When mini + desktop + hovering => add expand-menu; otherwise remove it.
  useEffect(() => {
    const body = document.body;
    const shouldExpand = isMini && mql.matches && hovering;
    body.classList.toggle("expand-menu", shouldExpand);
    // Clean up on unmount or when conditions change
    return () => body.classList.remove("expand-menu");
  }, [isMini, hovering, mql]);

  // If viewport changes (resize), recompute hover expansion immediately
  useEffect(() => {
    const handler = () => {
      // If leaving desktop while hovering, ensure expand-menu is removed
      if (!mql.matches) {
        document.body.classList.remove("expand-menu");
        setHovering(false);
      }
    };
    mql.addEventListener?.("change", handler);
    return () => mql.removeEventListener?.("change", handler);
  }, [mql]);

  return (
    <>
    {/* ✅ Mobile overlay (your SCSS already styles .sidebar-overlay.opened) */}
      {isMobileOpen && <div className="sidebar-overlay opened" onClick={closeMobile} />}
    <div className="two-col-sidebar" id="two-col-sidebar"
     // ✅ Hover to expand (desktop only)
        onMouseEnter={() => mql.matches && isMini && setHovering(true)}
        onMouseLeave={() => setHovering(false)}
    >
      <div className="twocol-mini">
        {/* Add Button */}
        <div className="dropdown">
          <a
            className="btn btn-primary bg-gradient btn-sm btn-icon rounded-circle d-flex align-items-center justify-content-center"
            data-bs-toggle="dropdown"
            href="#"
            role="button"
            data-bs-display="static"
            data-bs-reference="parent"
          >
            <i className="isax isax-add"></i>
          </a>
          <ul className="dropdown-menu dropdown-menu-start">
            <li>
              <a href="/add-invoice" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-document-text-1 me-2"></i>Invoice
              </a>
            </li>
            <li>
              <a href="/expenses" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-money-send me-2"></i>Expense
              </a>
            </li>
            <li>
              <a href="/add-credit-notes" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-money-add me-2"></i>Credit Notes
              </a>
            </li>
            <li>
              <a href="/add-debit-notes" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-money-recive me-2"></i>Debit Notes
              </a>
            </li>
            <li>
              <a href="/add-purchases-orders" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-document me-2"></i>Purchase Order
              </a>
            </li>
            <li>
              <a href="/add-quotation" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-document-download me-2"></i>Quotation
              </a>
            </li>
            <li>
              <a href="/add-delivery-challan" className="dropdown-item d-flex align-items-center">
                <i className="isax isax-document-forward me-2"></i>Delivery Challan
              </a>
            </li>
          </ul>
        </div>

        {/* Mini Sidebar Menu */}
        <ul className="menu-list">
          <li>
            <a href="/account-settings" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-title="Settings">
              <i className="isax isax-setting-25"></i>
            </a>
          </li>
          <li>
            <a href="#" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-title="Documentation">
              <i className="isax isax-document-normal4"></i>
            </a>
          </li>
          <li>
            <a href="#" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-title="Changelog">
              <i className="isax isax-cloud-change5"></i>
            </a>
          </li>
          <li>
            <a href="/login">
              <i className="isax isax-login-15"></i>
            </a>
          </li>
        </ul>
      </div>

      {/* Main Sidebar */}
      <div className="sidebar" id="sidebar-two">
       <SidebarLogo/>
        <Search/>
        {/* Menu */}
        <SimpleBar className="sidebar-inner">
          <Menu />
        </SimpleBar>
      </div>
    </div>
    </>
  );
}
