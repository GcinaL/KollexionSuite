import Card from "../../../components/common/cards/Card";
import { type TableColumn } from "react-data-table-component";
import Button from "../../../components/common/buttons/Button";
import DataTable from "../../../components/common/tables/DataTable";

interface IConsent {
  id: string;
  givenAt: string;
  channel: string;
  purpose: string;
  isGranted: "Yes" | "No";
  expiryAt?: string;
  source: string;
}

const columns: TableColumn<IConsent>[] = [
  { name: "Given At", selector: (row) => row.givenAt },
  { name: "Channel", selector: (row) => row.channel },
  { name: "Purpose", selector: (row) => row.purpose },
  { name: "Granted", selector: (row) => row.isGranted },
  { name: "Expiry", selector: (row) => row.expiryAt || "-" },
  { name: "Source", selector: (row) => row.source },
];

const data: IConsent[] = [
  { id: "1b2d439f-a2c1-4b51-acd3-51f938495afb", givenAt: "2025-10-20", channel: "SMS", purpose: "Collections", isGranted: "Yes", expiryAt: "2026-10-20", source: "Agent" },
  { id: "9c524670-2fe3-42c5-bee9-22a835a53892", givenAt: "2025-10-10", channel: "Email", purpose: "Marketing", isGranted: "No", source: "Portal" },
  { id: "ad7cb910-e21d-4b95-b051-cb4e93e67aa5", givenAt: "2025-10-22", channel: "WhatsApp", purpose: "Collections", isGranted: "Yes", expiryAt: "2025-12-31", source: "Imported" }
];

export default function Consents() {
  return (
    <Card
      title="Consents"
      actions={<Button label="Add Consent" icon="isax isax-add" />}
    >
      <DataTable<IConsent>
        columns={columns}
        data={data}
        showPagination={false}
        rowActionItems={[
          {
            label: "Edit",
            icon: "isax isax-edit",
            onClick: (r) => alert("Edit " + r.id),
          },
          {
            label: "Delete",
            icon: "isax isax-trash",
            onClick: (r) => alert("Delete " + r.id),
          },
          {
            label: "Show Record Id",
            icon: "isax isax-hashtag",
            onClick: (r) => alert("Record Id " + r.id),
          },
        ]}
      />
    </Card>
  );
}
