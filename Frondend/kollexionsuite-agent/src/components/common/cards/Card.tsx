import React from "react";

interface CardProps {
  title?: string | React.ReactNode
  titleMargin?: string;
  titleComponent?: React.ReactNode; // e.g. badge, tab switcher, etc.
  actions?: React.ReactNode;        // buttons, links, dropdowns, etc.
  flexFill?: boolean;               // optional flex-fill
  children: React.ReactNode;
  className?:string;
  overflow?:boolean
}

export default function Card({
  title,
  titleMargin = "2",
  titleComponent,
  actions,
  flexFill = true,
  children,
  className = "",
  overflow = false
}: CardProps) {
  return (
    <div className={`card ${flexFill ? "flex-fill" : ""} ${className}`}>
      <div className="card-body">
        {(title || titleComponent || actions) && (
          <div className={`d-flex align-items-center justify-content-between gap-2 flex-wrap mb-${titleMargin}`}>
            <div className="d-flex align-items-center gap-2">
              {title && <h6 className="mb-0 fs-16 fw-semibold">{title}</h6>}
              {titleComponent}
            </div>
            <div className="d-flex align-items-center gap-2">{actions}</div>
          </div>
        )}
        <div className={`pb-1 ${overflow ? 'overflow-x-auto' : ''}`}>
            {children}
        </div>
       
      </div>
    </div>
  );
}
