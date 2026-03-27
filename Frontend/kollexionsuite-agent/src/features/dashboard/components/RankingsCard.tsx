import React from "react";
import Card from "../../../components/common/cards/Card";
import { formatCurrency } from "../../../utils/formatters";
import { Link } from "react-router-dom";

export interface RankingItem {
  id: string;
  customerName: string;
  avatar: string;
  position: number; // ranking position (1, 2, 3...)
  amount: number; // e.g., total collections
  link?: string;
}

export interface RankingsCardProps {
  title?: string;
  caption?: string;
  rankings: RankingItem[];
}

const RankingsCard: React.FC<RankingsCardProps> = ({
  title = "Rankings",
  caption,
  rankings,
}) => {
  return (
    <Card title={title} actions={caption ? <span>{caption}</span> : undefined}>
      {rankings.map((r, idx) => (
        <div
          key={r.id}
          className={`d-flex align-items-center justify-content-between ${
            idx !== rankings.length - 1 ? "border-bottom pb-3 mb-3" : ""
          }`}
        >
          {/* Left: Avatar + Name */}
          <div className="d-flex align-items-center">
            <Link
              to={r.link || "customer-details.html"}
              className="avatar avatar-lg flex-shrink-0 me-2"
            >
              <img src={r.avatar} className="rounded-circle" alt={r.customerName} />
            </Link>
            <div>
              <h6 className="fs-14 fw-semibold mb-1">
                <Link to={r.link || "customer-details.html"}>{r.customerName}</Link>
              </h6>
              <p className="fs-13">{formatCurrency(r.amount)}</p>
            </div>
          </div>

          {/* Right: Position */}
          <div className="text-end">
            <label className="fw-semibold fs-16 text-dark mb-0">#{r.position}</label>
          </div>
        </div>
      ))}
    </Card>
  );
};

export default RankingsCard;
