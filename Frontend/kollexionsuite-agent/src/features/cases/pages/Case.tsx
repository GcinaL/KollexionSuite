import NavTabs from '../../../components/common/navigation/NavTabs';
import FileNotesTab from '../components/FileNotesTab';
import CaseDetailsTab from '../components/CaseDetailsTab';
import CaseHeading from '../components/CaseHeading';
import DebtorDetailsTab from '../../debtor/components/DebtorDetails';
import FinancialStatementTab from '../components/FinancialStatementTab';
import PtpTab from '../components/PtpTab';
import ACRequestTab from '../components/ACRequestTab';
import CampaignsTab from '../components/CampaignsTab';
import RpcTab from '../components/RpcTab';

export default function Case() {
  return (
    <>
        <CaseHeading
          caseNo="202510000025"
          debtor="Robert George"
          status="Open"
          creditor="Foshini Group Clothing Account"
        />
        <NavTabs type='bordered' defaultActiveId="caseDetails" className='fw-semibold'
        tabs={
          [
            {
              id: "caseDetails",
              title: "Case Details",
              content: (
               <CaseDetailsTab/>
              ),
            },
            {
              id: "debtorDetails",
              title: "Debtor Details",
              content: (
               <DebtorDetailsTab/>
              ),
            },
            {
              id: "fileNotes",
              title: "File Notes",
              toolTip: "Case File Notes",
              content: (
               <FileNotesTab/>
              ),
            },
             {
              id: "statement",
              title: "Financial Statement",
              content: (
               <FinancialStatementTab />
              ),
            },
            {
              id: "ptp",
              title: "PTP's",
              toolTip:"Promise to Pay",
              content: (
               <PtpTab />
              ),
            },
            {
              id: "rpc",
              title: "RPC's",
               toolTip:"Right Party Contacts",
              content: (
               <RpcTab />
              ),
            },
            {
              id: "acrequests",
              title: "AC Requests",
              toolTip:"Automated Collection Requests",
              content: (
               <ACRequestTab />
              ),
            },
            {
              id: "campaigns",
              title: "Campaigns",
              toolTip:"SMS & Email Campaigns",
              content: (
               <CampaignsTab />
              ),
            },
          ]
        }
        />
    </>
  )
}


/*function CasePhoneList() {
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
    <PhoneList
      phones={phones.map((p) => ({ ...p, onCall: handleCall }))}
      disableAll={isAnyCalling} // 🔹 new prop
    />
  );
}*/
