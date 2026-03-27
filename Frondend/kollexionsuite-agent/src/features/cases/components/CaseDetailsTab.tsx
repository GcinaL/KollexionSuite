import Card from '../../../components/common/cards/Card'
import DonutChart from '../../../components/common/charts/DonutChart';
import FormDataTable from '../../../components/common/tables/FormDataTable';

export default function CaseDetailsTab() {
  const labels = ["Paid", "Outstanding"];
  const series = [3500, 1200];
  return (
    <div className='row'>
      <div className='col-lg-8 d-flex'>
        <Card title="Case File Details">
          <FormDataTable rows={clientDetails} />
        </Card>
      </div>
      <div className='col-lg-4 d-flex'>
        <Card title="Payment Progress">
          <DonutChart
            labels={labels}
            series={series}
            colors={["#2ECC71", "#bbb5c9"]}
            title="Amount"
          />
        </Card>
      </div>
    </div>

  )
}

const clientDetails = [
  {
    cells: [
      { label: "Client", value: "Madibane Technologies (Pty) Ltd" },
      { label: "Unit Name", value: "Madibane Technologies (Pty) Ltd" },
    ],
  },
  {
    cells: [
      { label: "Client Reference", value: "MDL-0015458" },
      { label: "Unit Reference", value: "FED-02145888" },
    ],
  },
  {
    cells: [
      { label: "Status", value: "Soft Collections" },
      { label: "Status Date", value: "2025-10-22 12:00" },
    ],
  },
  {
    cells: [
      { label: "Cient Installment", value: "0.0000" }
    ],
  },
  {
    cells: [
      { label: "Client Book ID", value: "Soft Collections" },
      { label: "Handover Date", value: "2025-10-22 12:45:16" },
    ],
  },
  {
    cells: [
      { label: "Unit Grouping", value: "Madibane Technologies (Pty) Ltd" },
      { label: "Client Reference2", value: "MDL-0015458" },
    ],
  },
  {
    cells: [
      { label: "Loan Description", value: "GETBUCKS 21A", fontBold: true },
      { label: "Loan Date", value: "02 Jan 2025", fontBold: true },
    ],
  },
  {
    cells: [
      { label: "Reason", value: "RPC", fontBold: true },
      { label: "Last Payment Date", value: "Not Available" },
    ],
  },
  {
    cells: [
      { label: "Minimum Installment", value: "R200.0000" },
      { label: "Recommended Installment", value: "R300.0000" },
    ],
  },
  {
    cells: [
      { label: "Pay Date", value: "0" },
      { label: "Credit Provider", value: "GETBUCKS FINANCE" },
    ],
  },
  {
    cells: [
      { label: "Client Interest", value: "0" },
      { label: "Principal Debt", value: "0.0000" },
    ],
  },
];

