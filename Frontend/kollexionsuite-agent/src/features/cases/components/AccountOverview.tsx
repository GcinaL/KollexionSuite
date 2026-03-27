import Card from "../../../components/common/cards/Card";
import FormDataTable from "../../../components/common/tables/FormDataTable";

const data = [
    { cells: [{ label: "Loan Description", value: "GETBUCKS 21A" }] },
    { cells: [{ label: "Credit Provider", value: "GETBUCKS FINANCE" }] },
    { cells: [{ label: "Status", value: "Soft Collections", fontBold: true }] },
    { cells: [{ label: "Status Date", value: "2025-10-22 12:00" }] },
    { cells: [{ label: "Principal Debt", value: "2200.0000" }] },
    { cells: [{ label: "Minimum Installment", value: "R200.0000" }] },
    { cells: [{ label: "Recommended Installment", value: "R300.0000" }] },
    { cells: [{ label: "Current Balance", value: "R2500.0000", fontBold: true }] },
    { cells: [{ label: "Interest", value: "R0.0000" }] },
    { cells: [{ label: "Charges", value: "R0.0000" }] },
    { cells: [{ label: "Last Payment Date", value: "2025-10-31" }] },
    { cells: [{ label: "Last Payment Amount", value: "R200.0000" }] },
];

export default function AccountOverview() {
    return (
        <Card title="Account Overview">
            <FormDataTable rows={data} />
        </Card>
    );
}