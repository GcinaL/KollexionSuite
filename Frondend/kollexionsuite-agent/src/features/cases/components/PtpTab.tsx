import Card from "../../../components/common/cards/Card";
import { type TableColumn } from "react-data-table-component";
import AccountOverview from "./AccountOverview";
import Button from "../../../components/common/buttons/Button";
import DataTable from "../../../components/common/tables/DataTable";
import LinkButton from "../../../components/common/buttons/LinkButton";

interface IPTPs {
    id: string
    dateCaptured: string;
    amount: number;
    firstDueAt: string;
    nextPmtDate: string;
    status: string;
}

const columns: TableColumn<IPTPs>[] = [
    { name: "Date Captured", selector: (row) => row.dateCaptured },
    { name: "Amount", selector: (row) => row.amount },
    { name: "First Due At", selector: (row) => row.firstDueAt },
    { name: "Next Pmt Date", selector: (row) => row.nextPmtDate },
    { name: "Status", selector: (row) => row.status },
];

const data: IPTPs[] = [
    { id: "b6e5ga2a-9a1c-4a1a-8b33-3f04d45b61b0", dateCaptured: "2025-10-23", amount: 2500, firstDueAt: "2025-10-30", nextPmtDate: "2025-10-30", status: "Pending" },
    { id: "b6e5ga2f-9a1c-4a54-3b11-4504d41b6458", dateCaptured: "2025-10-15", amount: 1800, firstDueAt: "2025-10-25", nextPmtDate: "2025-10-25", status: "Cancelled" },
];

export default function PtpTab() {

    return (
        <div className="row">
            <div className="col-lg-8 d-flex">
                <Card title="Promise to Pay" actions={<Button label="Add New" icon="isax isax-add" />}>
                    <DataTable<IPTPs>
                        columns={columns}
                        data={data}
                        rowActionItems={[
                            { label: "Edit", icon: "isax isax-edit", onClick: (r) => alert("Edit " + r.id) },
                            { label: "Delete", icon: "isax isax-trash", onClick: (r) => alert("Delete " + r.id) },
                            { label: "Show Record Id", icon: "isax isax-hashtag", onClick: (r) => alert("Record Id " + r.id) },
                        ]}
                    />
                </Card>
            </div>
            <div className="col-lg-4 d-flex">
                <AccountOverview />
            </div>
        </div>
    );
}