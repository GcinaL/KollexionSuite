import React from "react";
import { OverlayTrigger, Tooltip } from "react-bootstrap";
import type { Column } from "../../../components/common/tables/BasicTable";
import { formatCurrency } from "../../../utils/formatters";
import LinkButton from "../../../components/common/buttons/LinkButton";
import Card from "../../../components/common/cards/Card";
import BasicTable from "../../../components/common/tables/BasicTable";
import { Link } from "react-router-dom";

export interface CaseItem {
  name: string;    // e.g. "25010001"
  status: string;  // e.g. "Broken PTP"
  amount: number;  // now a decimal value, not string
}

interface CasesCardProps {
  title?: string;
  data: CaseItem[];
}

const CasesCard: React.FC<CasesCardProps> = ({ title = "Assigned Cases", data }) => {
  const columns: Column[] = [
    {
      key: "customer",
      label: "",
      render: (row: CaseItem) => (
        <div>
          <h6 className="fs-14 fw-medium mb-1">
            <Link to="customer-details.html">{row.name}</Link>
          </h6>
          <p className="fs-13">{row.status}</p>
        </div>
      ),
    },
    {
      key: "amount",
      label: "",
      render: (row: CaseItem) => (
        <>
          <p className="mb-1">Amount</p>
          <h6 className="fs-14 fw-semibold">{formatCurrency(row.amount)}</h6>
        </>
      ),
    },
    {
      key: "actions",
      label: "",
      render: () => (
        <div className="d-flex align-items-center justify-content-end gap-2">
          <OverlayTrigger
            placement="top"
            overlay={<Tooltip id="tooltip-view-case">View Case File</Tooltip>}
          >
            <Link
              to="#"
              className="btn btn-icon btn-sm btn-light"
              data-bs-toggle="modal"
              data-bs-target="#add_ledger"
            >
              <i className="isax isax-eye"></i>
            </Link>
          </OverlayTrigger>
        </div>
      ),
    },
  ];

  return (
    <Card title={title} actions={<LinkButton label="View All" href="/cases/asigned" />}>
      <BasicTable
        columns={columns}
        data={data}
        hideHeader={true}
        bordered={false}
        striped={false}
        hover={false}
        className="table-borderless custom-table"
      />
    </Card>
  );
};

export default CasesCard;
