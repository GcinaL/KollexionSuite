import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";

import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "simplebar-react/dist/simplebar.min.css";
import "bootstrap-daterangepicker/daterangepicker.css";

import "./assets/plugins/fontawesome/css/all.min.css";
import "./assets/css/iconsax.css";
import "./assets/css/style.css";

// DataTables global setup
import $ from "jquery";
import "datatables.net-bs5";
import "datatables.net-responsive-bs5";
import "datatables.net-buttons-bs5";
import "datatables.net-select-bs5";

(window as any).$ = $;
(window as any).jQuery = $;

import { ToastProvider } from "./components/common/notifications/ToastProvider";
import { SidebarProvider } from "./components/layout/sidebar/SidebarContext";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <ToastProvider>
      <SidebarProvider>
      <App />
      </SidebarProvider>
     </ToastProvider>
  </React.StrictMode>
);
