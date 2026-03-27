import MenuTitle from './MenuTitle'
import MenuItem, { type IMenuItem } from "./MenuItem";

export default function Menu() {
  return (
    <div id="sidebar-menu" className="sidebar-menu">
      <ul>
        <MenuTitle>Home</MenuTitle>
        <li>
          <ul>
            {
              <MenuItem item={{ label: "Dashboard", icon: "isax isax-element-45", link: "/dashboard" }} />
            }
          </ul>
        </li>
        {/* Agent menu titles */}
        <MenuTitle>Collections</MenuTitle>
        <li>
          <ul>
           {collections.map((item, idx) => (
              <MenuItem key={idx} item={item} />
            ))}
          </ul>
        </li>
        <MenuTitle>Operations</MenuTitle>
        <li>
          <ul>
            {operations.map((item, idx) => (
              <MenuItem key={idx} item={item} />
            ))}
          </ul>
        </li>
        <MenuTitle>Management</MenuTitle>
            <li>
          <ul>
            {management.map((item, idx) => (
              <MenuItem key={idx} item={item} />
            ))}
          </ul>
        </li>
         <MenuTitle>Administration</MenuTitle>
            <li>
          <ul>
            {administration.map((item, idx) => (
              <MenuItem key={idx} item={item} />
            ))}
          </ul>
        </li> 
        <MenuTitle>Help</MenuTitle>
        <li>
          <ul>
            {help.map((item, idx) => (
              <MenuItem key={idx} item={item} />
            ))}
          </ul>
        </li>
      </ul>
    </div>
  )
}

const collections: IMenuItem[] = [
  {
    label: "Cases",
    icon: "isax isax-briefcase5",
    children: [
      { label: "My Cases", link: "/cases/assigned" },
      { label: "All Cases", link: "/cases" },
      { label: "Create Case", link: "/cases/add" },
    ],
  },
  {
    label: "Clients",
    icon: "isax isax-profile-2user5",
  },
  {
    label: "Debtors",
    icon: "isax isax-people5",
     link: "/debtors"
  },
];

const operations: IMenuItem[] = [
  {
    label: "Payments",
    icon: "isax isax-coin-15",
  },
  {
    label: "Disputes",
    icon: "isax isax-message-remove5",
  }
];

const management: IMenuItem[] = [
   {
    label: "File Manager",
    icon: "isax isax-document5",
    children: [
      { label: "Overview", link: "/file-manager" },
      { label: "Proof of Payments", link: "/file-manager/proof-of-payments" },
      { label: "Bank statements", link: "/file-manager/bank-statements" },
      { label: "Handover File Import", link: "/file-manager/handover-file-import" },
    ],
  },
   {
    label: "Campaigns",
    icon: "isax isax-document5",
  },
   {
    label: "Compliance",
    icon: "isax isax-message-remove5",
  },
  {
    label: "Team Performance",
    icon: "isax isax-coin-15",
  },
];

const administration: IMenuItem[] = [
  {
    label: "Communication",
    icon: "isax isax-coin-15",
  },
   {
    label: "Analytics & Reports",
    icon: "isax isax-coin-15",
  },
  {
    label: "Manage Users",
    icon: "isax isax-message-remove5",
  },
  {
    label: "Settings",
    icon: "isax isax-message-remove5",
    children: [
      { label: "Subscriptions", link: "/settings/subscriptions" },
      { label: "Workflow Orchestration", link: "/settings/workflow-orchestration" },
      { label: "Business Rules", link: "/settings/business-rules" },
      { label: "Quality & Monitoring", link: "/settings/quality-and-monitoring" },
      { label: "Health Check", link: "/settings/health-check" },
      { label: "Audit Logs", link: "/settings/audit-logs" },
    ],
  }
];

const help: IMenuItem[] = [
  {
    label: "Documentation",
    icon: "isax isax-coin-15",
  },
  {
    label: "Support",
    icon: "isax isax-message-remove5",
  }
];

