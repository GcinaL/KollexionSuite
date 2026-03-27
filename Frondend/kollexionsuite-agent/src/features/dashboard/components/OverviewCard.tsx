import Card from "../../../components/common/cards/Card";

interface OverviewItem {
  label: string;
  value: string | number;
  icon: string; // icon class, e.g. "isax isax-document-text-1"
  bgClass: string; // e.g. "bg-primary-subtle"
  textClass: string; // e.g. "text-primary"
}

interface OverviewCardProps {
  title: string;
  icon?: string; // optional title icon
  items: OverviewItem[];
}

export default function OverviewCard({
  title,
  icon = "isax isax-category5",
  items,
}: OverviewCardProps) {
  return (
    <Card flexFill={true} title={<><i className={`${icon} text-default me-2`} /> {title}</>}>
      
      <div className="row g-4">
        {items.map((item, idx) => (
          <div className="col-xl-6" key={idx}>
            <div className="d-flex align-items-center me-2">
              <span
                className={`avatar avatar-44 avatar-rounded ${item.bgClass} ${item.textClass} flex-shrink-0 me-2`}
              >
                <i className={`${item.icon} fs-20`} />
              </span>
              <div>
                <p className="mb-1 text-truncate">{item.label}</p>
                <h6 className="fs-16 fw-semibold mb-0 text-truncate">
                  {item.value}
                </h6>
              </div>
            </div>
          </div>
        ))}
      </div>


    </Card>
  );
}
