import { Route, Routes } from "react-router-dom";
import Layout from "../components/layout/Layout";
import DashboardPage from "../features/dashboard/pages/DashboardPage";
import AssignedCases from "../features/cases/pages/AssignedCases";
import Case from "../features/cases/pages/Case";


export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<DashboardPage />}/>
         <Route path="dashboard" element={<DashboardPage />} />
        <Route path="cases">
          <Route path="assigned" element={<AssignedCases />}/>
          <Route path=":routeid" element={<Case />}/>
        </Route>
      </Route>
    </Routes>
  );
}
