import React, { useState } from "react";
import { OverlayTrigger, Tooltip } from "react-bootstrap";

export interface TabItem {
  id: string; // Unique tab ID
  title: string; // Tab label
  content: React.ReactNode; // Tab content
  disabled?: boolean; // Optional: disable this tab
  toolTip?: string;
}

export interface NavTabsProps {
  tabs: TabItem[];
  defaultActiveId?: string;
  justified?: boolean;
  type?: "default" | "bordered" | "pills";
  className?: string;
}

const NavTabs: React.FC<NavTabsProps> = ({
  tabs,
  defaultActiveId,
  justified = false,
  type = "default",
  className = "",
}) => {
  const [activeTab, setActiveTab] = useState<string>(
    defaultActiveId || tabs[0]?.id
  );

  let cssClass = "nav nav-tabs mb-3";

  if(type === "bordered")
  {
    cssClass = "nav-tabs nav-bordered";
  }
  else if(type === "pills")
  {
    cssClass = "nav-pills bg-nav-pills";
  }
  else
  {
    cssClass = "nav-tabs";
  }

  return (
    <div className="row">
         <div className="col-12">
      <ul className={`nav mb-3 ${cssClass} ${justified ? "nav-justified" : ""} `}>
        {tabs.map((tab) => (
          <li className="nav-item" key={tab.id}>
            <OverlayTrigger overlay={<Tooltip id={`tooltip-tab-${tab.id}`}>View {tab.toolTip ?? tab.title}</Tooltip>}>
            <button
              className={`${className} nav-link rounded-0 ${
                activeTab === tab.id ? "active" : ""
              }`}
              onClick={() => !tab.disabled && setActiveTab(tab.id)}
              disabled={tab.disabled}
              style={{ cursor: tab.disabled ? "not-allowed" : "pointer" }}
            >
              {tab.title}
            </button>
            </OverlayTrigger>
          </li>
        ))}
      </ul>
      <div className="tab-content">
        {tabs.map((tab) => (
          <div
            key={tab.id}
            id={tab.id}
            className={`tab-pane fade ${
              activeTab === tab.id ? "show active" : ""
            }`}
          >
            {tab.content}
          </div>
        ))}
      </div>
    </div>
     </div>
  );
};

export default NavTabs;
