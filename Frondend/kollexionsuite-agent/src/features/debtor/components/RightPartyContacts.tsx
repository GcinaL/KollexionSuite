import Card from "../../../components/common/cards/Card";
import { type TableColumn } from "react-data-table-component";
import Button from "../../../components/common/buttons/Button";
import DataTable from "../../../components/common/tables/DataTable";

interface IRightPartyContacts {
    id: string;
    dateCaptured: string;
    type: "mobile"|"home"|"work"|"email";
    Value: string;
    isPrimary: "Yes" | "No";
    verified: "Yes" | "No";
    verifiedAt?: string;
}

const columns: TableColumn<IRightPartyContacts>[] = [
    { name: "Captured", selector: (row) => row.dateCaptured },
    { name: "Type", selector: (row) => row.type },
    { name: "Value", selector: (row) => row.Value },
    { name: "Is Primary", selector: (row) => row.isPrimary },
    { name: "Verified", selector: (row) => row.verified },
    { name: "Verified At", selector: (row) => row.verifiedAt || "-" },
];

const data: IRightPartyContacts[] = [
  { id: "b6e5ga2a-9a1c-4a1a-8b33-3f04d45b61b0", dateCaptured: "2025-10-23", type: "mobile", Value: "0821234567", isPrimary: "Yes", verified: "Yes", verifiedAt: "2025-10-24" },
  { id: "b6e5ga2f-9a1c-4a54-3b11-4504d41b6458", dateCaptured: "2025-10-15", type: "home", Value: "0130123456", isPrimary: "No", verified: "No" },
  { id: "aa31cc89-51b9-4ee4-bf6c-91b86fb4cd11", dateCaptured: "2025-10-21", type: "work", Value: "0219876543", isPrimary: "No", verified: "Yes", verifiedAt: "2025-10-22" },
  { id: "e91f1f20-3c36-4828-9f75-8c57a92c5fa1", dateCaptured: "2025-10-18", type: "email", Value: "john.doe@example.com", isPrimary: "No", verified: "No" },
  { id: "d63bc13e-29f0-48a9-bcd3-fcb2b8d77dc2", dateCaptured: "2025-10-25", type: "mobile", Value: "0715557777", isPrimary: "No", verified: "Yes", verifiedAt: "2025-10-26" },
];

export default function RightPartyContacts() {

    return (
         <Card title="Right Party Contacts" actions={<Button label="Add New" icon="isax isax-add" />}>
                    <DataTable<IRightPartyContacts>
                        columns={columns}
                        data={data}
                        showPagination={false}
                        rowActionItems={[
                            { label: "Edit", icon: "isax isax-edit", onClick: (r) => alert("Edit " + r.id) },
                            { label: "Delete", icon: "isax isax-trash", onClick: (r) => alert("Delete " + r.id) },
                            { label: "Show Record Id", icon: "isax isax-hashtag", onClick: (r) => alert("Record Id " + r.id) },
                        ]}
                    />
                </Card>
    );
}