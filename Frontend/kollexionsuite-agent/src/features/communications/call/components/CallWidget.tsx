import { useState, useEffect } from "react";
import "./callWidget.scss";
import CircleButton from "../../../../components/common/buttons/CircleButton";

type CallType = "idle" | "incoming" | "outgoing";

interface CallWidgetProps {
  callerNumber?: string; // for incoming/outgoing
  type?: CallType;       // default = idle
}

export default function CallWidget({ callerNumber, type = "idle" }: CallWidgetProps) {
  const [isOpen, setIsOpen] = useState<boolean>(false);
  const [currentType, setCurrentType] = useState<CallType>(type);
  const [numberToDial, setNumberToDial] = useState<string>("");

  // Restore widget open/close state
  useEffect(() => {
    const savedState = localStorage.getItem("callWidgetOpen");
    if (savedState) setIsOpen(savedState === "true");
  }, []);

  // Save widget state
  useEffect(() => {
    localStorage.setItem("callWidgetOpen", String(isOpen));
  }, [isOpen]);

  // Handle dialing a number
  const handleDial = () => {
    if (!numberToDial.trim()) return;
    setCurrentType("outgoing");
  };

  // End call → back to idle
  const handleEndCall = () => {
    setCurrentType("idle");
    setNumberToDial("");
  };

  return (
    <div className="call-widget-container">
      {/* Floating Toggle Button */}
      {!isOpen && (
        <CircleButton variant="success" size="md" ariaLabel="Open Call Widget" tooltip="Open Call Widget" onClick={() => setIsOpen(true)}>
          <i className="isax isax-call fs-24 m-10"></i>
        </CircleButton>
      )}

      {/* Popup */}
      {isOpen && (
        <div className="call-popup card shadow-lg">
          <div className="call-popup-header d-flex justify-between align-items-center">
            <h6 className="mb-0">Call Widget</h6>
            <button
              className="btn btn-sm btn-light"
              onClick={() => setIsOpen(false)}
            >
              ✖
            </button>
          </div>

          <div className="card-body text-center d-flex flex-column justify-content-center">
            {/* 🔹 IDLE → Dial a number */}
            {currentType === "idle" && (
              <>
                <h5>Dial a Number</h5>
                <input
                  type="tel"
                  className="form-control mb-3"
                  placeholder="Enter phone number"
                  value={numberToDial}
                  onChange={(e) => setNumberToDial(e.target.value)}
                />
                <button
                  className="btn btn-success w-100"
                  onClick={handleDial}
                  disabled={!numberToDial.trim()}
                >
                  <i className="ti ti-phone fs-20 me-2"></i> Call
                </button>
              </>
            )}

            {/* 🔹 INCOMING CALL */}
            {currentType === "incoming" && (
              <>
                <div className="voice-call-img mb-3">
                  <img
                    src="/assets/img/users/user-01.jpg"
                    className="img-fluid rounded-circle"
                    alt="caller"
                  />
                </div>
                <h5>{callerNumber ?? "Unknown Caller"}</h5>
                <p>Calling you...</p>
                <div className="d-flex align-items-center justify-content-center gap-2">
                  <button className="btn btn-success call-item">
                    <i className="ti ti-phone fs-20"></i>
                  </button>
                  <button className="btn btn-danger call-item" onClick={handleEndCall}>
                    <i className="ti ti-phone-off fs-20"></i>
                  </button>
                </div>
              </>
            )}

            {/* 🔹 OUTGOING CALL */}
            {currentType === "outgoing" && (
              <>
                <div className="voice-call-img mb-3">
                  <img
                    src="/assets/img/users/user-01.jpg"
                    className="img-fluid rounded-circle"
                    alt="caller"
                  />
                </div>
                <h5>{numberToDial || callerNumber}</h5>
                <p>Calling...</p>
                <div className="d-flex align-items-center justify-content-center flex-wrap gap-2">
                  <button className="btn btn-light call-item">
                    <i className="ti ti-video fs-20"></i>
                  </button>
                  <button className="btn btn-light call-item">
                    <i className="ti ti-microphone fs-20"></i>
                  </button>
                  <button className="btn btn-danger call-item" onClick={handleEndCall}>
                    <i className="ti ti-phone-off fs-20"></i>
                  </button>
                  <button className="btn btn-light call-item">
                    <i className="ti ti-user-plus fs-20"></i>
                  </button>
                  <button className="btn btn-light call-item">
                    <i className="ti ti-volume fs-20"></i>
                  </button>
                </div>
              </>
            )}
          </div>
        </div>
      )}
    </div>
  );
}
