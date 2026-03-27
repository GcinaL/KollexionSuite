import React, { createContext, useContext, useState, type ReactNode } from "react";
import { Offcanvas } from "react-bootstrap";

interface OffcanvasState {
  title?: string;
  content?: ReactNode;
  placement?: "start" | "end" | "top" | "bottom";
}

interface OffcanvasContextValue {
  open: (options: OffcanvasState) => void;
  close: () => void;
}

const OffcanvasContext = createContext<OffcanvasContextValue | null>(null);

export const OffcanvasProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [show, setShow] = useState(false);
  const [state, setState] = useState<OffcanvasState>({
    title: "",
    content: null,
    placement: "end",
  });

  const open = (options: OffcanvasState) => {
    setState(options);
    setShow(true);
  };

  const close = () => setShow(false);

  return (
    <OffcanvasContext.Provider value={{ open, close }}>
      {children}

      <Offcanvas
        show={show}
        onHide={close}
        placement={state.placement}
        backdrop
        scroll
      >
        <Offcanvas.Header closeButton className="border-bottom">
          <Offcanvas.Title className="fs-16 fw-semibold">{state.title}</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>{state.content}</Offcanvas.Body>
      </Offcanvas>
    </OffcanvasContext.Provider>
  );
};

export function useOffcanvas(): OffcanvasContextValue {
  const ctx = useContext(OffcanvasContext);
  if (!ctx) throw new Error("useOffcanvas must be used within OffcanvasProvider");
  return ctx;
}
