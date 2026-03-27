import { Modal as RBModal } from "react-bootstrap";
import React from "react";
import "./modal.scss"; // ✅ attach your styling

export interface IModalProps {
  show: boolean;
  onHide: () => void;
  title?: React.ReactNode;
  size?: "sm" | "lg" | "xl";
  centered?: boolean;
  footer?: React.ReactNode;
  children: React.ReactNode;
  backdrop?: boolean | "static";
}

const Modal: React.FC<IModalProps> = ({
  show,
  onHide,
  title,
  size,
  centered = true,
  footer,
  children,
  backdrop = true,
}) => {
  return (
    <RBModal
      show={show}
      onHide={onHide}
      size={size}
      centered={centered}
      backdrop={backdrop}
      animation={true}
      className="cf-modal custom-fade-down"
    >
      {title && (
        <RBModal.Header>
          <RBModal.Title>{title}</RBModal.Title>
          <button
    type="button"
    className="btn-close btn-close-modal custom-btn-close"
    aria-label="Close"
    onClick={onHide}
  >
    <i className="fa-solid fa-x"></i>
  </button>
        </RBModal.Header>
      )}

      <RBModal.Body>{children}</RBModal.Body>

      {footer && <RBModal.Footer>{footer}</RBModal.Footer>}
    </RBModal>
  );
};

export default Modal;
