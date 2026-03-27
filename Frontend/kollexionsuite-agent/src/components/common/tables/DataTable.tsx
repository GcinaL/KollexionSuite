import React, { useState, useMemo } from "react";
import DataTableBase, { type TableColumn } from "react-data-table-component";
import "./datatable.scss"; // ✅ Bootstrap pagination look
import ActionMenu, { type ActionItem } from "./ActionMenu";

export interface RowActionItem<T> extends ActionItem<T> {}

interface DataTableProps<T> {
  columns: TableColumn<T>[];
  data: T[];
  selectableRows?: boolean;
  searchable?: boolean;
  showPagination?: boolean;
  onRowSelect?: (rows: T[]) => void;
  rowsPerPageOptions?: number[];
  showRowActions?: boolean;
  rowActionItems?: RowActionItem<T>[];
}

export default function DataTable<T extends object>({
  columns,
  data,
  selectableRows = false,
  searchable = false,
  showPagination = true,
  onRowSelect,
  rowsPerPageOptions = [5, 10, 25, 50, 100, 200],
  rowActionItems = [],
}: DataTableProps<T>) {
  const [filterText, setFilterText] = useState("");

  // ✅ Filter data
  const filteredItems = useMemo(
    () =>
      data.filter((item) =>
        JSON.stringify(item).toLowerCase().includes(filterText.toLowerCase())
      ),
    [data, filterText]
  );

   // ✅ Conditionally add ActionMenu column
  const finalColumns = useMemo(() => {
    if (!rowActionItems.length) return columns;

    const actionColumn: TableColumn<T> = {
      name: "",
      width: "60px",
      cell: (row: T) => (
        <div className="text-center">
          <ActionMenu row={row} items={rowActionItems} />
        </div>
      ),
      ignoreRowClick: true,
      allowOverflow: true,
      button: true,
    };

    return [...columns, actionColumn];
  }, [columns, rowActionItems]);

  const paginationOptions = {
    rowsPerPageText: "Rows per page",
    rangeSeparatorText: "of",
  };

  return (
    <>
      {searchable && (
        <div className="mb-3 d-flex justify-content-between align-items-center">
          <input
            type="text"
            className="form-control w-auto"
            placeholder="Search"
            value={filterText}
            onChange={(e) => setFilterText(e.target.value)}
            style={{ minWidth: "250px" }}
          />
        </div>
      )}

      <div className="dataTable-wrapper dataTable-pagination text-dark">
        <DataTableBase
          columns={finalColumns}
          data={filteredItems}
          pagination={showPagination}
          paginationPerPage={rowsPerPageOptions[0]}
          paginationRowsPerPageOptions={rowsPerPageOptions}
          paginationComponentOptions={paginationOptions}
          striped={false}
          responsive
          selectableRows={selectableRows}
          onSelectedRowsChange={(state) => onRowSelect?.(state.selectedRows)}
        />
      </div>
    </>
  );
}
