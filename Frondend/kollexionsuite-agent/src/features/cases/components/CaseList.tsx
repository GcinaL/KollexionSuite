import React from "react";
import { formatDate } from "../../../utils/formatters";
import "./cases.scss"
import Button from "../../../components/common/buttons/Button";
import { Link } from "react-router-dom";

export interface Avatar {
  image: string;
  link: string;
  alt?: string;
}

export interface CaseItem {
  id: string;
  debtor: string;
  idnumber: number;
  caseno: string;
  accountdesc: string;
  date: Date;
  status: string;
  avatars: Avatar[];
}

export interface CaseListProps {
  items: CaseItem[];
  onEdit?: (id: string) => void;
  onDelete?: (id: string) => void;
  onView?: (id: string) => void;
  className?: string;
}

const CaseList: React.FC<CaseListProps> = ({
  items,
  className = "",
}) => {
  return (
    <div className={`case-list ${className}`}>
      {items.map((item) => (
        <Link to={item.status === "Reassigned"? "" : `/cases/${item.id}`}
          key={item.id}
          className={`list-group-item ${item.status === "Reassigned" ? "list-group-item-warning fw-bold" : ""} border rounded mb-2 p-3`}
        >
          <div className="row align-items-center row-gap-3">
            {/* Left Section */}
            <div className="col-lg-6 col-md-7">
              <div className="row  align-items-center">
                <div className="col-auto">
                  <div className="d-flex flex-wrap row-gap-3">
                    <span className="me-2 d-flex align-items-center">
                      <i className="ti ti-grid-dots text-dark"></i>
                    </span>
                    <div className="strike-info">
                      <h4 className="fs-16 fw-semibold mb-0">
                        {item.debtor} <span className="fw-normal fs-14 ms-1">|<span className="ms-1">{item.idnumber}</span></span>
                      </h4>
                      <small>{item.accountdesc}</small>
                    </div>
                  </div>
                </div>
                <div className="col text-end">
                  <h5 className="fs-14 fw-semibold ms-3">
                    {item.caseno}
                  </h5>
                </div>
              </div>

            </div>

            {/* Right Section */}
            <div className="col-lg-6 col-md-5">
              <div className="d-flex align-items-center justify-content-md-end flex-wrap row-gap-3">
                <small className="text-dark me-3">
                  {item.status === "Reassigned" ? (
                    <>
                      <Button label="Accept" variant="success" className="btn-sm me-1" onClick={() => alert("Button clicked!")} />
                      <Button label="Decline" variant="danger" className="btn-sm me-1" onClick={() => alert("Button clicked!")} />
                    </>
                  ) : (
                    <>
                      <i className="isax isax-calendar me-1"></i>
                      {formatDate(item.date)}
                    </>
                  )}
                </small>
                <span
                  className={`badge badge-soft-${getStatusClr(item.status) || "danger"} d-inline-flex align-items-center me-3`}
                >
                  <i className="fas fa-circle fs-6 me-1"></i>
                  {item.status}
                </span>
                <div className="d-flex align-items-center">
                  <div className="avatar-list-stacked avatar-group-sm">
                    {item.avatars.map((avatar, idx) => (
                      <Link
                        key={idx}
                        to={avatar.link}
                        className="avatar avatar-rounded"
                      >
                        <img
                          className="border border-white"
                          src={avatar.image}
                          alt={avatar.alt || "avatar"}
                        />
                      </Link>
                    ))}
                  </div>
                </div>
              </div>
            </div>
          </div>
        </Link>
      ))}
    </div>
  );
};

export default CaseList;

const getStatusClr = (status: string): string => {
  let statusColor = "danger";

  if (status === "Reassigned" || status === "Inprogress") {
    statusColor = "warning";
  } else if (status === "Assigned") {
    statusColor = "dark";
  } else if (status === "Actioned") {
    statusColor = "success";
  }

  return statusColor;
};

