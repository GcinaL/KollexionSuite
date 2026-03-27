import React from "react";

export interface Column {
  key: string;
  label: string;
  sortable?: boolean;
  className?: string;
  render?: (row: any) => React.ReactNode;
}

export interface BasicTableProps {
  columns: Column[];
  data: any[];
  selectable?: boolean;
  responsive?: boolean;
  bordered?: boolean;
  striped?: boolean;
  hover?: boolean;
  condensed?: boolean;
  className?: string;
  footer?: React.ReactNode;
  hideHeader?: boolean;
}

const BasicTable: React.FC<BasicTableProps> = ({
  columns,
  data,
  selectable = false,
  responsive = true,
  bordered = false,
  striped = false,
  hover = false,
  condensed = false,
  className = "",
  footer,
  hideHeader = false, // NEW
}) => {
  return (
    <div
      className={`table-responsive ${responsive ? "" : "no-filter no-pagination"}`}
    >
      <table
        className={`table table-nowrap ${bordered ? "border" : ""} ${
          striped ? "table-striped" : ""
        } ${hover ? "table-hover" : ""} ${
          condensed ? "table-sm" : ""
        } ${className}`}
      >
        {!hideHeader && (
          <thead className="thead-light">
            <tr>
              {selectable && (
                <th className="no-sort">
                  <div className="form-check form-check-md">
                    <input className="form-check-input" type="checkbox" />
                  </div>
                </th>
              )}
              {columns.map((col) => (
                <th
                  key={col.key}
                  className={`${!col.sortable ? "no-sort" : ""} ${col.className || ""}`}
                >
                  {col.label}
                </th>
              ))}
            </tr>
          </thead>
        )}

        <tbody>
          {data.map((row, i) => (
            <tr key={i}>
              {selectable && (
                <td>
                  <div className="form-check form-check-md">
                    <input className="form-check-input" type="checkbox" />
                  </div>
                </td>
              )}
              {columns.map((col) => (
                <td key={col.key} className={col.className || ""}>
                  {col.render ? col.render(row) : row[col.key]}
                </td>
              ))}
            </tr>
          ))}
        </tbody>

        {footer && <tfoot>{footer}</tfoot>}
      </table>
    </div>
  );
};

export default BasicTable;
