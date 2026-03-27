import React from "react";
import "./forminput.scss";

export interface FormInputProps {
  label?: string;
  type?: "text" | "textarea" | "number" | "email" | "password" | "date" | "datetime-local";
  value?: string | number;
  placeholder?: string;
  onChange?: (value: string) => void;
  className?: string;
  id?: string;
  name?: string;
  readOnly?: boolean;
  required?: boolean;
  min?: number | string;
  max?: number | string;
  step?: number;
}

const FormInput: React.FC<FormInputProps> = ({
  label,
  type = "text",
  value,
  placeholder,
  onChange,
  className = "",
  id,
  name,
  readOnly = false,
  required = false,
  min,
  max,
  step,
}) => {
  return (
    <div className="mb-3">
      {label && (
        <label htmlFor={id} className="form-label">
          {label} {required && <span className="text-danger">*</span>}
        </label>
      )}
      {type == "textarea" ? 
      <textarea
        id={id}
        name={name}
      
        placeholder={placeholder}
        className={["form-control", className].filter(Boolean).join(" ")}
        readOnly={readOnly}
        required={required}
        rows={3}
        onChange={(e) => onChange && onChange(e.target.value)}
      >
        {value ?? ""}
      </textarea>
      :
      <input
        type={type}
        id={id}
        name={name}
        value={value ?? ""}
        placeholder={placeholder}
        className={["form-control", className].filter(Boolean).join(" ")}
        readOnly={readOnly}
        required={required}
        min={min}
        max={max}
        step={step}
        onChange={(e) => onChange && onChange(e.target.value)}
      ></input>
}
    </div>
  );
};

export default FormInput;
