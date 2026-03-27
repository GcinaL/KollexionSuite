import React from "react";
import defaultImage from "../../../assets/img/user-default.jpg"
import LinkButton from "../../../components/common/buttons/LinkButton";
import DropdownButton from "../../../components/common/dropdowns/DropdownButton";
import "./cases.scss";
import Button from "../../../components/common/buttons/Button";
import { useOffcanvas } from "../../../components/common/canvas/OffcanvasContext";
import PhoneDialerPanel from "./PhoneDialerPanel";

export interface CaseHeadingProps {
    caseNo: string;
    debtor: string;
    status: string;
    creditor: string
}

const CaseHeading: React.FC<CaseHeadingProps> = ({
    caseNo,
    debtor,
    status = "Open",
    creditor
}) => {

    const { open } = useOffcanvas();

    return (
        <>
        <div className="row">
            <div className="col-12">
                <div className="card bg-light case-details-bg" >
                     <LinkButton label="Back to Cases" variant="link" className="me-1 position-absolute top-0 end-0 m-3 pt-0 pe-3 mt-2 z-1 border-0" href="/cases/assigned" icon="fa fa-arrow-left" />
                    <div className="card-body position-relative">
                        {/* Top Section */}
                        <div className="d-flex align-items-center justify-content-between flex-wrap gap-3">
                            {/* Avatar + Info */}
                            <div className="d-flex align-items-center justify-content-between flex-wrap gap-3">
                                <div className="avatar avatar-xxl rounded-circle flex-shrink-0">
                                    <img
                                        src={defaultImage}
                                        alt={debtor}
                                        className="img-fluid rounded-circle border border-white border-2"
                                    />
                                </div>
                                <div>
                                    <p className="text-primary fs-14 fw-medium mb-1">Case No.: {caseNo}</p>
                                    <h5 className="mb-2 d-flex align-items-center">
                                        {debtor}
                                        <span className={`badge badge-soft-${status === 'Open' ? 'success' : 'danger'} fs-12 d-inline-flex align-items-center ms-3`}>
                                            <i className="fas fa-circle fs-6 me-1"></i>
                                            Case {status}
                                        </span>
                                    </h5>
                                    <p className="fs-14 fw-regular mb-0">
                                        <i className="isax isax-bank fs-14 me-1 text-gray-9"></i>
                                        {creditor}
                                    </p>
                                </div>
                            </div>
                            <div className="pt-2">
                                <Button label="Start Calling" className="me-1" icon="isax isax-call" variant="success"
                                onClick={() =>
                                     open({
                                        title: "Phone Dailer",
                                        content:(
                                      <PhoneDialerPanel />
                                        ),
                                        placement: "end",
                                    })
                                }/>
                              <DropdownButton
                                label="Options"
                                className="btn-outline-dark bg-white"
                                items={headingMenuItems}
                                />
                            </div>

                        </div>


                    </div>
                </div>
            </div>
        </div>
</>
    );
};

export default CaseHeading;

 const headingMenuItems = [
    { label: "Create Payment Arrangement", href: "#", icon:"isax isax-card-add"},
    { label: " Record Refusal of Payment", href: "#", icon:"isax isax-shield-cross"},
    { label: "Add Contact", href: "#", icon:"isax isax-mobile"},
    { label: "Add File Note", href: "#", icon:"isax isax-note-favorite"},
    { label: "Send Banking Details", href: "#", icon:"isax isax-bank"},
    { label: "Send Case Details", href: "#", icon:"isax isax-briefcase"},
  ];