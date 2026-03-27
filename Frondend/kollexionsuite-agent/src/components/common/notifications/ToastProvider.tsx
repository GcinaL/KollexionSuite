import React, { createContext, useContext, useState, type ReactNode } from "react";
import { Toast, ToastContainer } from "react-bootstrap";

export type ToastVariant =
    | "primary"
    | "success"
    | "danger"
    | "warning"
    | "info"
    | "light"
    | "dark";

interface ToastMessage {
    id: number;
    message: ReactNode;
    variant: ToastVariant;
    autohide: boolean;
    delay: number;
    actions?: ReactNode;
}

interface ToastContextProps {
    showToast: (
        message: ReactNode,
        variant?: ToastVariant,
        options?: { autohide?: boolean; delay?: number; actions?: ReactNode }
    ) => void;
}

const ToastContext = createContext<ToastContextProps | undefined>(undefined);

export const ToastProvider = ({ children }: { children: ReactNode }) => {
    const [toasts, setToasts] = useState<ToastMessage[]>([]);

    const showToast = (
        message: ReactNode,
        variant: ToastVariant = "primary",
        options: { autohide?: boolean; delay?: number; actions?: ReactNode } = {}
    ) => {
        setToasts((prev) => [
            ...prev,
            {
                id: Date.now(),
                message,
                variant,
                autohide: options.autohide ?? true,
                delay: options.delay ?? 4000,
                actions: options.actions,
            },
        ]);
    };

    const removeToast = (id: number) => {
        setToasts((prev) => prev.filter((t) => t.id !== id));
    };

    return (
        <ToastContext.Provider value={{ showToast }}>
            {children}
            <ToastContainer
                className="p-3"
                position="top-end"
                style={{ zIndex: 1055 }}
            >
                {toasts.map((toast) => (
                    <Toast
                        key={toast.id}
                        bg={toast.variant}
                        onClose={() => removeToast(toast.id)}
                        delay={toast.delay}
                        autohide={toast.autohide}
                        className="text-white border-0 mb-3 align-items-center fade show"
                    >
                        <div className="d-flex">
                            <Toast.Body>
                                {toast.message}
                                {toast.actions && (
                                    <div className="mt-2 pt-2 border-top d-flex">{toast.actions}</div>
                                )}
                            </Toast.Body>
                            {/* ✅ Close button exactly like Bootstrap docs */}
                            <button
                                type="button"
                                className="btn-close btn-close-white me-2 m-auto"
                                aria-label="Close"
                                onClick={() => removeToast(toast.id)}
                            />
                        </div>
                    </Toast>

                ))}
            </ToastContainer>
        </ToastContext.Provider>
    );
};

export const useToast = () => {
    const ctx = useContext(ToastContext);
    if (!ctx) {
        throw new Error("useToast must be used inside ToastProvider");
    }
    return ctx;
};
