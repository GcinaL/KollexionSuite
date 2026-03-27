import { useEffect } from "react";

export default function HeaderWrapper({ children }: { children: React.ReactNode }) {
  useEffect(() => {
    // dynamically import so it runs after React mounts the DOM
    import("../../../assets/js/theme-script.js");
  }, []);

  return <>{children}</>;
}
