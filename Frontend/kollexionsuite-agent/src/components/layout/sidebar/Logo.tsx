import logo from "../../../assets/img/logo.svg";
import logoWhite from "../../../assets/img/logo-white.svg";
import logoSmall from "../../../assets/img/logo-small.svg";
import logoSmallWhite from "../../../assets/img/logo-small-white.svg";

export default function Logo() {
  return (
    <div className="sidebar-logo">
          <a href="/" className="logo logo-normal">
            <img src={logo} alt="Logo" />
          </a>
          <a href="/" className="logo-small">
            <img src={logoSmall} alt="Logo Small" />
          </a>
          <a href="/" className="dark-logo">
            <img src={logoWhite} alt="Dark Logo" />
          </a>
          <a href="/" className="dark-small">
            <img src={logoSmallWhite} alt="Dark Small Logo" />
          </a>

          <a id="toggle_btn" href="#">
            <i className="isax isax-menu-1"></i>
          </a>
        </div>
  )
}