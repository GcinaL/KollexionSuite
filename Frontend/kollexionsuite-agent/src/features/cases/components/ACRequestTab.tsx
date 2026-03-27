import Card from "../../../components/common/cards/Card";
import { type TableColumn } from "react-data-table-component";
import Button from "../../../components/common/buttons/Button";
import DataTable from "../../../components/common/tables/DataTable";
import { formatCurrency, formatDate, formatPercentage } from "../../../utils/formatters";
import SmallTitle from "../../../components/common/labels/SmallTitle";
import FormDataTable from "../../../components/common/tables/FormDataTable";

interface IACRequests {
    id: string
    dateCaptured: string;
    installment: string;
    firstInstDate: string;
    mode: string;
    bank: string;
    accountNumber: string;
    accountType: string;
    debitDay: string;
    replyString: string;
}

const columns: TableColumn<IACRequests>[] = [
    { name: "Date Captured", selector: (row) => row.dateCaptured },
    { name: "Installment", selector: (row) => row.installment },
    { name: "1st Inst Date.", selector: (row) => row.firstInstDate },
    { name: "Mode", selector: (row) => row.mode },
    { name: "Bank", selector: (row) => row.bank },
    { name: "Acc No.", selector: (row) => row.accountNumber },
    { name: "Acc Type", selector: (row) => row.accountType },
    { name: "Debit Day", selector: (row) => row.debitDay },
    { name: "Reply String", selector: (row) => row.replyString },
];

const data: IACRequests[] = [
    { id: "b6e5fa2a-9a1c-4a1a-8b33-3f04d45b61b0", dateCaptured: "2025-10-28", installment: formatCurrency(1500), firstInstDate: "2025-11-01", mode: "EFT", bank: "FNB", accountNumber: "62234567890", accountType: "Cheque", debitDay: "01", replyString: "Authenticated by the debtor (AAUT)" },
];

export default function ACRequestTab() {

    return (
        <>
            <Card title="Automated Collection Requests" actions={<Button label="Create New" icon="isax isax-add" />}>
                <DataTable<IACRequests>
                    columns={columns}
                    data={data}
                    showPagination={false}
                    rowActionItems={[
                        { label: "Modify Request", icon: "isax isax-edit", onClick: (r) => alert("Modify " + r.id) },
                        { label: "Cancel Request", icon: "isax isax-forbidden", onClick: (r) => alert("Cancel " + r.id) },
                        { label: "Show Record Id", icon: "isax isax-eye", onClick: (r) => alert("Record Id " + r.id) },
                    ]}
                />
            </Card>
            <div className="row">
                <div className="col-lg-8">
                    <Card title="Financial Details">
                        <FormDataTable rows={financialDetails} />
                    </Card>
                </div>
                <div className="col-lg-4">
                    <Card title="Sheriff Details" >
                        <FormDataTable rows={sheriffDetails} />
                    </Card>
                </div>
            </div>
        </>
    );
}

const financialDetails = [
    {
        cells: [
            { label: "Debit Amount", value: formatCurrency(54000), fontBold: true },
            { label: "Generated Consent Amount", value: formatCurrency(1600) },
        ],
    },
    {
        cells: [
            { label: "Pre-legal Interest Rate", value: formatPercentage(0.1) },
            { label: "Balance", value: formatCurrency(51200) },
        ],
    },
    {
        cells: [
            { label: "Legal Interest Rate", value: formatPercentage(0) },
            { label: "CostCap", value: formatCurrency(0) },
        ],
    },
    {
        cells: [
            { label: "CostCap Remaining", value: formatPercentage(0) },
            { label: "Date Account Opened", value: formatDate(new Date("2019-08-14")) },
        ],
    },
    {
        cells: [
            { label: "Last Payment Date", value: formatDate(new Date("2024-11-25")) },
            { label: "Last Payment Amount", value: formatCurrency(1600) },
        ],
    }
    ,
    {
        cells: [
            { label: "Original Loan Date", value: formatDate(new Date("2019-08-14")) },
            { label: "Original Loan Amount", value: formatCurrency(132238) },
        ],
    }
];

const sheriffDetails = [
    {
        cells: [
            { label: "Sheriff Name", value: "n/a", fontBold:true},
        ],
    },
    {
        cells: [
            { label: "Contact Person", value: "n/a" },
        ],
    },
    {
        cells: [
            { label: "Telephone Number 1", value: "n/a" },
        ],
    },
    {
        cells: [
            { label: "Telephone Number 2", value: "n/a" },
        ],
    },
    {
        cells: [
            { label: "Cellphone Number", value: "n/a" },
        ],
    },
    {
        cells: [
            { label: "Email", value: "n/a" },
        ],
    },
];