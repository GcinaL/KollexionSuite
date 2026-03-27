import { useState } from "react";
import { Link } from "react-router-dom";
import { useSidebar } from './SidebarContext';

export interface IMenuItem {
  label: string;
  icon?: string;
  link?: string;
  children?: IMenuItem[];
}

export interface IMenuItemProps {
  item: IMenuItem;
  depth?: number;
}

export default function MenuItem({ item, depth = 0 }: IMenuItemProps) {
  const [open, setOpen] = useState(false);
  const hasChildren = !!item.children && item.children.length > 0;

  const { closeMobile } = useSidebar(); // ✅ get from context

  const handleClick = (e: React.MouseEvent) => {
    if (hasChildren) {
      e.preventDefault();
      setOpen(!open);
    } else {
      // ✅ Close sidebar automatically on mobile after clicking a link
      closeMobile();
    }
  };

  return (
    <li className={`${hasChildren ? "submenu" : ""}`}>
      <Link
  to={hasChildren ? "#" : item.link || "#"}
  className={open ? "active" : ""}
  onClick={handleClick}
>
  {item.icon ? (
    <>
      <i className={item.icon}></i>
      <span>{item.label}</span>
    </>
  ) : (
    item.label
  )}
  {hasChildren && <span className="menu-arrow"></span>}
</Link>
      {hasChildren && (
        <ul style={{ display: open ? "block" : "none" }}>
          {item.children!.map((child, idx) => (
            <MenuItem key={idx} item={child} depth={depth + 1} />
          ))}
        </ul>
      )}
    </li>
  );
}
