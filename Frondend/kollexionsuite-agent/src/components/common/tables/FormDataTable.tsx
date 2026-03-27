import React from "react";

export interface FormDataCell {
  label: string;
  value?: string | number | React.ReactNode;
  isTitle?: boolean;
  fontBold?: boolean;
  colSpan?: number;
  nowrap?: boolean
  valueType?: "currency"|"percentage"|"date"
}

export interface FormDataRow {
  cells: FormDataCell[];
}

export interface FormDataTableProps {
  rows: FormDataRow[];
  className?: string;
}


const FormDataTable: React.FC<FormDataTableProps> = ({
  rows,
  className = "",
}) => {
  return (
    <div className="" >
    <table className={`table table-nowrap mb-0 table-borderless ${className}`}>
      <tbody>
        {rows.map((row, rowIdx) => (
          <tr key={rowIdx} className="align-items-center">
            {row.cells.map((cell, cellIdx) =>
              cell.isTitle ? (
                <td
                  key={cellIdx}
                  colSpan={2}
                  className="fw-semibold text-dark p-0 py-1 text-start align-top"
                >
                  {cell.label}
                </td>
              ) : (
                <React.Fragment key={cellIdx}>
                  <td className="text-start text-wrap p-0 pb-1 pe-1">{cell.label}:</td>
                  <td colSpan={cell.colSpan ?? cell.colSpan} className={`text-start ${cell.nowrap ? "": "text-wrap"} p-0 pb-1 pe-2 text-dark pb-1 ${cell.fontBold && 'fw-semibold'} `}>
                    {cell.value || ""}
                  </td>
                </React.Fragment>
              )
            )}
          </tr>
        ))}
      </tbody>
    </table>
    </div>
  );
};

export default FormDataTable;