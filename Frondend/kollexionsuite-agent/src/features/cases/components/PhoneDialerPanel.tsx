import React, { useState } from "react";
import PhoneList, { type PhoneItem } from "./PhoneList";

export default function PhoneDialerPanel() {
  const [phones, setPhones] = useState<PhoneItem[]>([
    { number: "+27821234567", type: "Mobile", status:"Added" },
    { number: "+27119876543", type: "Work", status:"Voicemail" },
    { number: "+27134567890", status:"Hungup", contacted:true },
  ]);

  const [activeCall, setActiveCall] = useState<string | null>(null);

  const handleCall = (number: string) => {
    console.log("Calling:", number);
    setActiveCall(number);
    setTimeout(() => setActiveCall(null), 3000);
  };

  const updatedPhones = phones.map((p) => ({
    ...p,
    isCalling: activeCall === p.number,
    onCall: handleCall,
  }));

  return <PhoneList phones={updatedPhones} disableAll={!!activeCall} />;
}
