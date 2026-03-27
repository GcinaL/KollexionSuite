import React from "react";
import IconButton from "../../../components/common/buttons/IconButton";

export interface PhoneItem {
  number: string;
  type?: string; // e.g. Mobile, Work, Home
  status: string;
  contacted?: boolean;
  isCalling?: boolean;
  onCall?: (number: string) => void;
}

export interface PhoneListProps {
  title?: string;
  phones?: PhoneItem[];
  disableAll?: boolean; // ✅ new prop
}

const PhoneList: React.FC<PhoneListProps> = ({
  phones,
  disableAll = false,
}) => {
  return (
    <div className="table-responsive">
      <table className="table">
        <thead >
          <th className="pb-2 text-dark">Number</th>
          <th className="pb-2 text-dark">Status</th>
          <th colSpan={2} className="pb-2 text-dark">Contacted</th>
        </thead>
        <tbody>
          {phones && phones.map((phone, index) => (
            <tr>
              <td className="px-0 text-dark"><h6 className="fs-14 fw-semibold">{phone.number}</h6>
                <p className="fs-14 mb-0">
                  <i className="isax isax-mobile me-1"></i>
                  {phone.type || "Mobile"}
                </p>
              </td>
              <td className="px-0 text-dark">
                {phone.status}
              </td>
              <td className="px-0 text-dark">
                {phone.contacted ? "Yes" : "No"}
              </td>
              <td className="px-0 text-end">
                {phone.isCalling ? (
                  <span className="fs-13 text-muted">
                    <i>Calling...</i>
                  </span>
                ) : (
                  <IconButton
                    icon="isax isax-call"
                    rounded
                    variant="success"
                    onClick={() => phone.onCall?.(phone.number)}
                    disabled={disableAll && !phone.isCalling}
                  />
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default PhoneList;
