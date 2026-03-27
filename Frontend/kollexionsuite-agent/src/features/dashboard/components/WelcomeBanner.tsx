import "./dashboard.scss"
import BannerImage from "../../../assets/img/icons/dashboard.svg";
import { Link } from "react-router-dom";

export default function WelcomeBanner() {
  return (
    <div className="bg-primary rounded welcome-wrap position-relative mb-3 p-3">
      <div className="row">
        <div className="col-lg-8 col-md-9 col-sm-7">
          <div>
            <h5 className="text-white mb-1">Welcome, Lunga Dlamini</h5>
            <p className="text-white mb-3">
              You have <Link to="/cases/assigned" className="text-white fw-semibold">15 cases</Link> assigned to you for collection.
            </p>
            <div className="d-flex align-items-center flex-wrap gap-3">
              <p className="d-flex align-items-center fs-13 text-white mb-0">
                <i className="isax isax-calendar5 me-1"></i>
                Friday, 24 Mar 2025
              </p>
              <p className="d-flex align-items-center fs-13 text-white mb-0">
                <i className="isax isax-clock5 me-1"></i>
                11:24 AM
              </p>
            </div>
          </div>
        </div>
      </div>

      <div className="position-absolute end-0 top-50 translate-middle-y p-2 d-none d-sm-block">
        <img src={BannerImage} alt="Dashboard Icon" />
      </div>
    </div>
  );
}
