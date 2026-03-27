import { useState } from 'react';
import CaseHeading from '../../cases/components/CaseHeading'
import PhoneListComponent from '../../cases/components/PhoneList';
import NavTabs from '../../../components/common/navigation/NavTabs';
import DebtorDetailsComponent from '../../cases/components/DebtorDetails';

export default function CallCenterCase() {

  return (
    <>
        <CaseHeading
          caseNo="202510000025"
          debtor="Robert George"
          status="Active"
          creditor="Foshini Group Clothing Account"
        />
        <NavTabs type='pills' defaultActiveId="debtorDetails" className='fw-semibold'
        tabs={
          [
            {
              id: "debtorDetails",
              title: "Debtor Details",
              content: (
               <DebtorDetailsComponent/>
              ),
            },
            {
              id: "drm",
              title: "DRM's",
              content: (
                <p className="mb-0">
                  Welcome to the dashboard! Access key metrics, recent updates, and quick links to manage your activity.
                </p>
              ),
            },
          ]
        }
        />
    </>
  )
}


function CasePhoneList() {
  const [phones, setPhones] = useState([
    { id: "1", number: "+27715390177", type: "Mobile", isCalling: false },
    { id: "2", number: "+27824401990", type: "Work", isCalling: false },
  ]);

  // 🔹 Check if any call is active
  const isAnyCalling = phones.some((p) => p.isCalling);

  const handleCall = (number: string) => {
    setPhones((prev) =>
      prev.map((p) =>
        p.number === number ? { ...p, isCalling: true } : { ...p, isCalling: false }
      )
    );
    console.log(`Calling ${number}...`);

    // Simulate call end after 3s
    setTimeout(() => {
      setPhones((prev) => prev.map((p) => ({ ...p, isCalling: false })));
    }, 3000);
  };

  return (
    <PhoneListComponent
      phones={phones.map((p) => ({ ...p, onCall: handleCall }))}
      disableAll={isAnyCalling} // 🔹 new prop
    />
  );
}
