import Sidebar from './sidebar/Sidebar'
import Header from './header/Header'
import HeaderWrapper from './header/HeaderWrapper'
import './layout.scss';
import CallWidget from '../../features/communications/call/components/CallWidget';
import { Outlet } from "react-router-dom";


export default function Layout() {
  return (
      <div className="main-wrapper flex">
        <HeaderWrapper>
          <Header />
        </HeaderWrapper>
        <Sidebar />
        <div className="page-wrapper">
          <div className="content">
           <Outlet/>
            <CallWidget type="idle" />
          </div>
          
        </div>
        
      </div>
  )
}