import React, {
  createContext,
  useContext,
  useEffect,
  useMemo,
  useState,
} from "react";

type SidebarContextType = {
  // desktop
  isMini: boolean;
  toggleSidebar: () => void;

  // mobile
  isMobileOpen: boolean;
  toggleMobile: () => void;   // ✅ make sure this exists in the type
  openMobile: () => void;
  closeMobile: () => void;
};

const SidebarContext = createContext<SidebarContextType | undefined>(undefined);

export const SidebarProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  // default mini
  const [isMini, setIsMini] = useState<boolean>(() => {
    const saved = localStorage.getItem("sidebarMode");
    return saved ? saved === "mini" : true;
  });

  // mobile drawer
  const [isMobileOpen, setIsMobileOpen] = useState(false);

  const toggleSidebar = () => {
    setIsMini((prev) => {
      const next = !prev;
      localStorage.setItem("sidebarMode", next ? "mini" : "expand");
      return next;
    });
  };

  // ✅ mobile controls (including toggleMobile)
  const toggleMobile = () => setIsMobileOpen((prev) => !prev);
  const openMobile = () => setIsMobileOpen(true);
  const closeMobile = () => setIsMobileOpen(false);

  // keep body classes in sync with your SCSS
  useEffect(() => {
    const body = document.body;
    body.classList.toggle("mini-sidebar", isMini);
    body.classList.toggle("expand-menu", !isMini);
    body.classList.toggle("slide-nav", isMobileOpen);
  }, [isMini, isMobileOpen]);

  // ESC closes mobile
  useEffect(() => {
    const onKey = (e: KeyboardEvent) => {
      if (e.key === "Escape") closeMobile();
    };
    window.addEventListener("keydown", onKey);
    return () => window.removeEventListener("keydown", onKey);
  }, []);

  const value = useMemo(
    () => ({
      isMini,
      toggleSidebar,
      isMobileOpen,
      toggleMobile,   // ✅ provided here
      openMobile,
      closeMobile,
    }),
    [isMini, isMobileOpen]
  );

  return <SidebarContext.Provider value={value}>{children}</SidebarContext.Provider>;
};

export const useSidebar = () => {
  const ctx = useContext(SidebarContext);
  if (!ctx) throw new Error("useSidebar must be used within <SidebarProvider>");
  return ctx;
};
