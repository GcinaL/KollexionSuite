export interface TotalLabelProps {
  title: string;
  value: string | number | React.ReactNode;
  showBorder?: boolean; // optional, if you want to override styling
}

const TotalLabel: React.FC<TotalLabelProps> = ({ title, value, showBorder=true }) => {
  return (
    <p className={`mb-0 fw-semibold ${showBorder && "me-3 pe-3 border-end"} fs-14 `}>
      {title} : <span className="text-dark">{value}</span>
    </p>
  );
};

export default TotalLabel;