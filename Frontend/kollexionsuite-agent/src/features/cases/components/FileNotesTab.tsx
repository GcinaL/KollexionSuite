import Card from "../../../components/common/cards/Card";
import DataTable from "../../../components/common/tables/DataTable";
import { type TableColumn } from "react-data-table-component";
import AccountOverview from "./AccountOverview";
import { useState } from "react";
import Button from "../../../components/common/buttons/Button";
import Modal from "../../../components/common/modals/Modal";
import FormInput from "../../../components/common/forms/FormInput";

interface FileNote {
  date: string;
  capturedBy: string;
  type: string;
  remarks: string;
}

export default function FileNotesTab() {
  const columns: TableColumn<FileNote>[] = [
    {name: "Captured",selector: (row) => row.date},
    {name: "Captured By",selector: (row) => row.capturedBy},
    {name: "Type",selector: (row) => row.type},
    {name: "Remarks",selector: (row) => row.remarks, wrap: true},
  ];

  const data: FileNote[] = [
    { date: "2025-10-20", capturedBy: "Lunga Dlamini", type: "DRM", remarks: "Contacted debtor." },
    { date: "2025-10-19", capturedBy: "Sarah Nkosi", type: "SMS", remarks: "Sent reminder SMS." },
    { date: "2025-10-18", capturedBy: "Thabo Mokoena", type: "Email", remarks: "Emailed settlement." },
  ];

  const [showModal, setShowModal] = useState(false);

  const [formData, setFormData] = useState({
  caseId: "A5S47-4DLV2-DKVHY-525D8",
  type: "DRM",
  remarks: "",
});

const handleChange = (key: string, value: string) => {
  setFormData(prev => ({
    ...prev,
    [key]: value,
  }));
};

  return (
    <>
    <div className="row">
      <div className="col-lg-8 d-flex">
        <Card title="File Notes" actions={<Button label="Add New" variant="none" icon="isax isax-add" onClick={() => setShowModal(true)} />} >
          <DataTable<FileNote> columns={columns} data={data} />
        </Card>
      </div>
       <div className="col-lg-4 d-flex">
        <AccountOverview />
       </div>
    </div>
    <form>
    <Modal show={showModal} onHide={() => setShowModal(false)} title="Add File Note"
    children={
          <div className="mb-3">
            <FormInput type="textarea" id="remarks" label="Remarks" placeholder="Enter remarks" onChange={(val) => handleChange("remarks", val)} value={formData.remarks}/>
          </div>
    }
    footer={<>
      <Button label="Cancel" variant="light" className="me-2" onClick={() => setShowModal(false)} />
      <Button submit label="Save Note" icon="fa-regular fa-floppy-disk" iconPosition="start" variant="primary" onClick={() => setShowModal(false)} />
    </>}
   />
  </form>
    </>
  );
}
