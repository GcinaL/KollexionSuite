import { useState } from 'react';
import Card from '../../../components/common/cards/Card'
import NavPills, { type NavPillItem } from '../../../components/common/navigation/NavPills';
import TotalLabel from '../components/TotalLabel'
import DropdownLink from '../../../components/common/dropdowns/DropdownLink';
import type { CaseItem } from '../components/CaseList';
import CaseList from '../components/CaseList';

function AssignedCases() {
  const [sortBy, setSortBy] = useState("Date");
  const [sortOrder, setSortOrder] = useState("Descending");

  return (
    <>
      <Card
        title="Assigned Cases"
        actions={
          <>
            <TotalLabel title="Total" value={20} />
            <TotalLabel title="Actioned" value={5} />
            <TotalLabel title="Outstanding" value={15} showBorder={false} />
          </>
        }>
        <>
          <div className="row">
            <div className="col-md-8">
              <div className="flex-wrap row-gap-3 mb-3">
                <div className='row d-flex align-items-center '>
                  <div className='col-auto d-none d-lg-block'><h6 className="me-2 fs-14 fw-normal">View :</h6></div>
                   <div className='col col-xl-8 col-lg-10'>
                    <NavPills
                  items={tabs}
                  defaultActive="all"
                  onChange={(selected) => console.log("Selected tab:", selected)}
                />
                   </div>
                </div>
              
                
              </div>
            </div>
            <div className='col-md-4 '>
              <div className='row mb-3 mt-2'>
                <div className='col text-sm-start text-md-end'>
                  <DropdownLink
                    label="Sort By :"
                    options={["Date", "Case Number", "Debtor"]}
                    selected={sortBy}
                    onSelect={setSortBy}
                  />
                  <span className='m-1'></span>
                   <DropdownLink
                    options={["Descending", "Ascending"]}
                    selected={sortOrder}
                    onSelect={setSortOrder}
                  />
                </div>
              </div>

            </div>
          </div>
          <div className="list-group list-group-flush border-bottom pb-2">
            <CaseList
              items={cases}
              onEdit={(id) => alert(`Edit case ${id}`)}
              onDelete={(id) => alert(`Delete case ${id}`)}
              onView={(id) => alert(`View case ${id}`)}
            />
          </div>
        </>
      </Card>
    </>
  )
}

export default AssignedCases

const tabs: NavPillItem[] = [
  { label: "All", value: "all" },
  { label: "Re-assigned", value: "Reassigned"},
  { label: "In progress", value: "Inprogress" },
  { label: "On hold", value: "Onhold"},
  { label: "Actioned", value: "action" }
];

const cases: CaseItem[] = [
  {
    id: "A5S47-4DLV2-DKVHY-525D8",
    debtor: "Lunga Dlamini",
    idnumber: 9311156240089,
    caseno: "250100001",
    accountdesc: "Foshini Group Clothing Account",
    date: new Date("2025-10-14"),
    status: "Onhold",
    avatars: [
      { image: "/assets/img/profiles/avatar-01.jpg", link: "/user/1" },
      { image: "/assets/img/profiles/avatar-02.jpg", link: "/user/2" },
      { image: "/assets/img/profiles/avatar-03.jpg", link: "/user/3" },
    ],
  },
  {
    id: "B7X92-3PKT1-QWE89-771C2",
    debtor: "Nomsa Nkosi",
    idnumber: 8809235100081,
    caseno: "250100002",
    accountdesc: "Capitec Bank Personal Loan",
    date: new Date("2025-10-12"),
    status: "Assigned",
    avatars: [
      { image: "/assets/img/profiles/avatar-04.jpg", link: "/user/4" },
      { image: "/assets/img/profiles/avatar-05.jpg", link: "/user/5" },
    ],
  },
  {
    id: "C4P16-7ZQV9-KJU34-918D3",
    debtor: "Thabo Mokoena",
    idnumber: 9003156021083,
    caseno: "250100003",
    accountdesc: "MTN Mobile Contract",
    date: new Date("2025-10-10"),
    status: "Actioned",
    avatars: [
      { image: "/assets/img/profiles/avatar-06.jpg", link: "/user/6" },
      { image: "/assets/img/profiles/avatar-07.jpg", link: "/user/7" },
    ],
  },
  {
    id: "D9K41-1MNL3-ZYX89-112A9",
    debtor: "Sibongile Khumalo",
    idnumber: 8510070270082,
    caseno: "250100004",
    accountdesc: "Ackermans Retail Account",
    date: new Date("2025-10-09"),
    status: "Reassigned",
    avatars: [
      { image: "/assets/img/profiles/avatar-08.jpg", link: "/user/8" },
      { image: "/assets/img/profiles/avatar-09.jpg", link: "/user/9" },
      { image: "/assets/img/profiles/avatar-10.jpg", link: "/user/10" },
    ],
  },
  {
    id: "E8L33-9TRC7-QAZ12-334B7",
    debtor: "Kagiso Mthembu",
    idnumber: 9402115140085,
    caseno: "250100005",
    accountdesc: "Standard Bank Credit Card",
    date: new Date("2025-10-08"),
    status: "Inprogress",
    avatars: [
      { image: "/assets/img/profiles/avatar-02.jpg", link: "/user/2" },
      { image: "/assets/img/profiles/avatar-03.jpg", link: "/user/3" },
    ],
  },
  {
    id: "F1R27-2BVY5-HGF43-992F5",
    debtor: "Andile Zulu",
    idnumber: 9704235180087,
    caseno: "250100006",
    accountdesc: "Truworths Store Account",
    date: new Date("2025-10-05"),
    status: "Closed",
    avatars: [
      { image: "/assets/img/profiles/avatar-11.jpg", link: "/user/11" },
      { image: "/assets/img/profiles/avatar-12.jpg", link: "/user/12" },
    ],
  },
  {
    id: "G3V52-5KPL6-DFR90-778D1",
    debtor: "Lebogang Molefe",
    idnumber: 9211185230081,
    caseno: "250100007",
    accountdesc: "Mr Price Home Furniture Account",
    date: new Date("2025-10-03"),
    status: "Actioned",
    avatars: [
      { image: "/assets/img/profiles/avatar-04.jpg", link: "/user/4" },
      { image: "/assets/img/profiles/avatar-06.jpg", link: "/user/6" },
    ],
  },
];



/*const { showToast } = useToast();

 const handleSimple = () => {
   showToast("Hello, world! This is the Primary toast message.", "primary");
 };

 const handleSuccess = () => {
   showToast("Saved successfully ✅", "success");
 };

 const handleCaseToast = () => {
   showToast(
     <p>
       Case <b>122358</b> has been reassigned to you.
     </p>,
     "primary",
     {
       autohide: false,
       actions: (
         <>
           <Button
             label="Accept"
             variant="success"
             size="sm"
             className="me-2"
             onClick={() => alert("Accepted ✅")}
           />
           <Button
             label="Decline"
             variant="danger"
             size="sm"
             className="me-2"
             onClick={() => alert("Declined ❌")}
           />
           <Button
             label="View Case"
             variant="light"
             size="sm"
             onClick={() => alert("Viewing case 📂")}
           />
         </>
       ),
     }
   );
 };*/