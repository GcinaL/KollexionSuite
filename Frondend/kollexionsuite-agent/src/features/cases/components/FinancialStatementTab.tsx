import Card from "../../../components/common/cards/Card";
import DataTable from "../../../components/common/tables/DataTable";
import { type TableColumn } from "react-data-table-component";
import DropdownButton, { type DropdownItem } from "../../../components/common/dropdowns/DropdownButton";
import AccountOverview from "./AccountOverview";
import Modal from "../../../components/common/modals/Modal";
import { useState } from "react";
import defaultImage from "../../../assets/img/user-default.jpg"
import { formatCurrency } from "../../../utils/formatters";

interface IFinancialStatement {
    id: string;
    dateCaptured: string;
    originalDate: string;
    transactionType: string;
    credit: number;
    debit: number;
    balance: number;
    interest: number;
    charges: number;
    notes: string;
}

const columns: TableColumn<IFinancialStatement>[] = [
    { name: "Captured", selector: (row) => row.dateCaptured },
    { name: "Orig Date", selector: (row) => row.originalDate },
    { name: "Trans Type", selector: (row) => row.transactionType },
    { name: "Credit", selector: (row) => row.credit },
    { name: "Debit", selector: (row) => row.debit },
    { name: "Balance", selector: (row) => row.balance },
    { name: "Interest", selector: (row) => row.interest },
    { name: "Charges", selector: (row) => row.charges },
    { name: "Notes", selector: (row) => row.notes },
];

const data: IFinancialStatement[] = [
    { id: "b6e5fa2f-9a1c-4a1a-8b33-3f04d41b61b0", dateCaptured: "2025-10-22", originalDate: "2025-10-21", transactionType: "DTTAKEON", credit: 0, debit: 0, balance: 2500, interest: 0, charges: 0, notes: "Opening balance" },
    { id: "b7d2e0de-03d8-4e59-9f50-933bb8e3b8b6", dateCaptured: "2025-10-23", originalDate: "2025-10-23", transactionType: "PAYMENT", credit: 500, debit: 0, balance: 2000, interest: 0, charges: 0, notes: "Payment received via EFT" },
    { id: "c1a1a7dc-3e50-40f5-8ef2-0b17a4e02cb7", dateCaptured: "2025-10-24", originalDate: "2025-10-24", transactionType: "INTEREST", credit: 0, debit: 50, balance: 2050, interest: 50, charges: 0, notes: "Monthly interest applied" },
    { id: "a92b52f0-524b-470c-8d30-7685281de53e", dateCaptured: "2025-10-25", originalDate: "2025-10-25", transactionType: "CHARGE", credit: 0, debit: 100, balance: 2150, interest: 0, charges: 100, notes: "Late payment penalty" },
    { id: "9d7f0cf2-df55-4d42-9a9c-22036c790c5e", dateCaptured: "2025-10-26", originalDate: "2025-10-26", transactionType: "PAYMENT", credit: 300, debit: 0, balance: 1850, interest: 0, charges: 0, notes: "Payment via debit order" },
    { id: "ccf3c351-0839-4b4e-8f1a-77a678f6bcd3", dateCaptured: "2025-10-27", originalDate: "2025-10-27", transactionType: "INTEREST", credit: 0, debit: 40, balance: 1890, interest: 40, charges: 0, notes: "Daily interest adjustment" },
    { id: "ba51909d-d218-49eb-b520-2bcf5d8c3ff8", dateCaptured: "2025-10-28", originalDate: "2025-10-28", transactionType: "PAYMENT", credit: 700, debit: 0, balance: 1190, interest: 0, charges: 0, notes: "Payment from employer" },
    { id: "b0a5243b-019d-4e76-87b4-424c282d90ef", dateCaptured: "2025-10-29", originalDate: "2025-10-29", transactionType: "CHARGE", credit: 0, debit: 30, balance: 1220, interest: 0, charges: 30, notes: "Service fee" },
    { id: "ff2534ad-1422-4707-b728-b9cf8c54fc2a", dateCaptured: "2025-10-30", originalDate: "2025-10-30", transactionType: "INTEREST", credit: 0, debit: 25, balance: 1245, interest: 25, charges: 0, notes: "Accrued interest" },
    { id: "ed1a32cf-77b8-4b2e-9a7a-d9e20679df19", dateCaptured: "2025-10-31", originalDate: "2025-10-31", transactionType: "PAYMENT", credit: 200, debit: 0, balance: 1045, interest: 0, charges: 0, notes: "Final payment for month" },
];


export default function FinancialStatementTab() {
    const [showModal, setShowModal] = useState(false);

    const menuItems: DropdownItem[] = [
    { label: "View Ledger", href: "#", icon: "fa-regular fa-file-text", onClick:(()=>setShowModal(true)) },
    { label: "Download", href: "#", icon: "fa fa-download" },
    { label: "Email Statement to Debtor", href: "#", icon: "fa-regular fa-paper-plane" },
];

    return (
        <>
            <div className="row">
                <div className="col-lg-8 d-flex">
                    <Card title="Financial Statement" actions={<DropdownButton label="Options" items={menuItems} />}>
                        <DataTable<IFinancialStatement> columns={columns} data={data}
                            rowActionItems={[
                                { label: "Show Record Id", icon: "isax isax-hashtag", onClick: (r) => alert("Record Id " + r.id) },
                            ]}
                        />
                    </Card>
                </div>
                <div className="col-lg-4 d-flex">
                    <AccountOverview />
                </div>
            </div>
            <Modal size="xl" show={showModal} onHide={() => setShowModal(false)} title="Case Ledger"
                children={
                    <>
                    <div className="row">
                            <div className="col-md-12">
                                <div className="mb-2">
                                     <div className="d-flex align-items-center justify-content-end">
                                        <div className="d-flex align-items-center gap-2">
                                                <a href="javascript:void(0);" className="btn btn-outline-white btn-sm d-flex align-items-center fw-semibold"><i
														className="isax isax-export-1 me-1"></i>Print</a>
                                                <a href="javascript:void(0);" className="btn btn-outline-white btn-sm d-flex align-items-center fw-semibold"><i
														className="isax isax-export-1 me-1"></i>Download</a>
                                            </div>
                                     </div>
                                </div>
                            </div>
                             <div className="col-md-12">
                                    <div className="mb-3">
                                        <div className="supplier-details d-flex align-items-center justify-content-between mb-3">
                                            <div className="d-flex align-items-center">
                                                <div className="avatar avatar-lg border border-dashed bg-light me-3 flex-shrink-0">
                                                   <img
                                        src={defaultImage}
                                        alt="Debtor"
                                        className="img-fluid rounded-circle border border-white border-2"
                                    />
                                                </div>
                                                <div className="d-inline-flex flex-column align-items-start">
                                                    <h6 className="fw-semibold fs-14">Mitchel Johnson</h6>
                                                    <p>Case No.: 202510000025</p>
                                                </div>
                                            </div>
                                            <div>
                                                <div className="p-1 bg-white rounded d-flex align-items-center fw-semibold text-gray-9">
                                                    Closing Balance : {formatCurrency(400)}
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                                <div className="col-md-12">
                                    <DataTable<IFinancialStatement> columns={columns} data={data} showPagination={false}
                                        rowActionItems={[
                                            { label: "Show Record Id", icon: "isax isax-hashtag", onClick: (r) => alert("Record Id " + r.id) },
                                        ]}
                        />
                                </div>
                    </div>
             
                    </>
                }
            />
        </>
    );
}

