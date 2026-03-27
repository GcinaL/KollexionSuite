import logo from "../../../assets/img/logo.svg";
import logoWhite from "../../../assets/img/logo-white.svg";
import flagUs from "/assets/img/flags/us.svg";
import flagDe from "/assets/img/flags/de.svg";
import flagFr from "/assets/img/flags/fr.svg";
import flagAe from "/assets/img/flags/ae.svg";
import ThemeToggle from "./ThemeToggle";
import './header.scss';
import { Link, useLocation } from "react-router-dom";
import { useSidebar } from "../sidebar/SidebarContext";

// src/components/layout/Header.tsx
export default function Header() {

  const avatar = "/assets/img/profiles/avatar-01.jpg";
  const { isMobileOpen, toggleMobile } = useSidebar();

  return (
    <div className="header">
      <div className="main-header">
        {/* Logo */}
        <div className="header-left">
          <Link to="/" className="logo">
            <img src={logo} alt="Logo" />
          </Link>
          <Link to="/" className="dark-logo">
            <img src={logoWhite} alt="Logo" />
          </Link>
        </div>

        {/* Sidebar Menu Toggle Button */}
        <Link
          id="mobile_btn"
          to="#"
          className={`mobile_btn ${isMobileOpen ? "active" : ""}`}
          onClick={(e) => {
            e.preventDefault();
            toggleMobile();
          }}
          aria-expanded={isMobileOpen}
          aria-controls="sidebar-two"
        >
          <span className="bar-icon">
            <span></span>
            <span></span>
            <span></span>
          </span>
        </Link>

        <div className="header-user">
          <div className="nav user-menu nav-list">
            <div className="me-auto d-flex align-items-center" id="header-search">
              {/* Add dropdown */}
              <div className="dropdown me-3">
                <Link
                  className="btn btn-primary bg-gradient btn-xs btn-icon rounded-circle d-flex align-items-center justify-content-center"
                  data-bs-toggle="dropdown"
                  to="#"
                  role="button"
                >
                  <i className="isax isax-add text-white"></i>
                </Link>
                <ul className="dropdown-menu dropdown-menu-start p-2">
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-document-text-1 me-2"></i>Invoice</Link></li>
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-money-send me-2"></i>Expense</Link></li>
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-money-add me-2"></i>Credit Notes</Link></li>
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-money-recive me-2"></i>Debit Notes</Link></li>
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-document me-2"></i>Purchase Order</Link></li>
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-document-download me-2"></i>Quotation</Link></li>
                  <li><Link to="#" className="dropdown-item d-flex align-items-center"><i className="isax isax-document-forward me-2"></i>Delivery Challan</Link></li>
                </ul>
              </div>

              {/* Breadcrumb */}
              <nav aria-label="breadcrumb">
                <ol className="breadcrumb breadcrumb-divide mb-0">
                  <li className="breadcrumb-item d-flex align-items-center">
                    <Link to="/"><i className="isax isax-home-2 me-1"></i>Home</Link>
                  </li>
                  <li className="breadcrumb-item active" aria-current="page">{formatPageName()}</li>
                </ol>
              </nav>
            </div>

            <div className="d-flex align-items-center">
              {/* Search */}
              <div className="input-icon-end position-relative me-2">
                <input type="text" className="form-control" placeholder="Search" />
                <span className="input-icon-addon"><i className="isax isax-search-normal"></i></span>
              </div>

              {/* Language Dropdown */}
              <div className="nav-item dropdown has-arrow flag-nav me-2">
                <Link className="btn btn-menubar" data-bs-toggle="dropdown" to="#" role="button">
                  <img src={flagUs} alt="Language" className="img-fluid" />
                </Link>
                <ul className="dropdown-menu p-2">
                  <li><Link to="#" className="dropdown-item"><img src={flagUs} alt="flag" className="me-2" />English</Link></li>
                  <li><Link to="#" className="dropdown-item"><img src={flagDe} alt="flag" className="me-2" />German</Link></li>
                  <li><Link to="#" className="dropdown-item"><img src={flagFr} alt="flag" className="me-2" />French</Link></li>
                  <li><Link to="#" className="dropdown-item"><img src={flagAe} alt="flag" className="me-2" />Arabic</Link></li>
                </ul>
              </div>

              {/* Notification */}
              <div className="notification_item me-2">
                <Link
                  to="#"
                  className="btn btn-menubar position-relative"
                  id="notification_popup"
                  data-bs-toggle="dropdown"
                  data-bs-auto-close="outside"
                >
                  <i className="isax isax-notification-bing5"></i>
                  <span className="position-absolute badge bg-success border border-white"></span>
                </Link>
                <div className="dropdown-menu p-0 dropdown-menu-end dropdown-menu-lg" style={{ minHeight: 300 }}>
                  <div className="p-2 border-bottom">
                    <div className="row align-items-center">
                      <div className="col"><h6 className="m-0 fs-16 fw-semibold">Notifications</h6></div>
                    </div>
                  </div>
                  <div className="notification-body position-relative z-2 rounded-0" data-simplebar>
                    <div className="dropdown-item notification-item py-2 text-wrap border-bottom" id="notification-1">
                      <div className="d-flex">
                        <div className="me-2 position-relative flex-shrink-0">
                          <img src={'/assets/img/profiles/avatar-05.jpg'} className="avatar-md rounded-circle" alt="User" />
                        </div>
                        <div className="flex-grow-1">
                          <p className="mb-0 fw-semibold text-dark">John Smith</p>
                          <p className="mb-1 text-wrap fs-14">A <span className="fw-semibold">new sale</span> has been recorded.</p>
                          <span className="fs-12"><i className="isax isax-clock me-1"></i>4 min ago</span>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div className="p-2 rounded-bottom border-top text-center">
                    <Link to="/notifications" className="fw-medium fs-14 mb-0">View All</Link>
                  </div>
                </div>
              </div>

              {/* Dark/Light Mode */}
              <ThemeToggle />

              {/* User Dropdown */}
              <div className="dropdown profile-dropdown">
                <Link to="#" className="dropdown-toggle d-flex align-items-center" data-bs-toggle="dropdown" data-bs-auto-close="outside">
                  <span className="avatar online"><img src={avatar} alt="Img" className="img-fluid rounded-circle" /></span>
                </Link>
                <div className="dropdown-menu p-2">
                  <div className="d-flex align-items-center bg-light rounded-1 p-2 mb-2">
                    <span className="avatar avatar-lg me-2">
                      <img src={avatar} alt="img" className="rounded-circle" />
                    </span>
                    <div>
                      <h6 className="fs-14 fw-medium mb-1">Jafna Cremson</h6>
                      <p className="fs-13">Administrator</p>
                    </div>
                  </div>
                  <Link className="dropdown-item d-flex align-items-center" to="/account-settings"><i className="isax isax-profile-circle me-2"></i>Profile Settings</Link>
                  <Link className="dropdown-item d-flex align-items-center" to="/reports"><i className="isax isax-document-text me-2"></i>Reports</Link>
                  <Link className="dropdown-item logout d-flex align-items-center" to="/login"><i className="isax isax-logout me-2"></i>Sign Out</Link>
                </div>
              </div>
            </div>
          </div>
        </div>

        {/* Mobile Menu */}
        <div className="dropdown mobile-user-menu profile-dropdown">
          <Link to="#" className="dropdown-toggle d-flex align-items-center" data-bs-toggle="dropdown" data-bs-auto-close="outside">
            <span className="avatar avatar-md online"><img src={avatar} alt="Img" className="img-fluid rounded-circle" /></span>
          </Link>
          <div className="dropdown-menu p-2 mt-0">
            <Link className="dropdown-item d-flex align-items-center" to="/profile"><i className="isax isax-profile-circle me-2"></i>Profile Settings</Link>
            <Link className="dropdown-item d-flex align-items-center" to="/reports"><i className="isax isax-document-text me-2"></i>Reports</Link>
            <Link className="dropdown-item d-flex align-items-center" to="/account-settings"><i className="isax isax-setting me-2"></i>Settings</Link>
            <Link className="dropdown-item logout d-flex align-items-center" to="/login"><i className="isax isax-logout me-2"></i>Signout</Link>
          </div>
        </div>
      </div>
    </div>
  );
}

const formatPageName = (): string => {
  const location = useLocation();
  const page = location.pathname.split("/").filter(Boolean).shift() || "Dashboard";
  const cleaned = page.replace(/[-_]+/g, " ").replace(/[^a-zA-Z0-9 ]/g, "");

  return cleaned
    .split(" ")
    .filter(Boolean)
    .map(word => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
    .join(" ");
};
