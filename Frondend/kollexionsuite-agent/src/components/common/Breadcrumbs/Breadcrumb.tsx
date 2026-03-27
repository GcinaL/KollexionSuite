import type { ReactNode } from "react";

interface BreadcrumbProps {
  title: string;
  children?: ReactNode;
}

export default function Breadcrumb({ title, children }: BreadcrumbProps) {
  return (
    <div className="d-flex d-block align-items-center justify-content-between flex-wrap gap-3 mb-3">
      <div>
        <h6>{title}</h6>
      </div>
      <div className="d-flex my-xl-auto right-content align-items-center flex-wrap gap-2">
        {children}
      </div>
    </div>
  );
}
