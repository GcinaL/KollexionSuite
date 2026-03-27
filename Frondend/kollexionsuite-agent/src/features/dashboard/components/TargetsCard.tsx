// src/components/common/cards/AnalyticsCard.tsx
import React from "react";
import Card from '../../../components/common/cards/Card'
import BarChart, { type BarChartProps } from "../../../components/common/charts/BarChart";
import LinkButton from "../../../components/common/buttons/LinkButton";

export interface StatItem {
  label: string;
  value: string | number;
  color?: "primary" | "success" | "danger" | "warning" | "info" | "dark";
}

export interface LegendItem {
  label: string;
  color: string; // CSS class or hex color
}

export interface TargetsCardProps {
  title: string;
  filterOptions?: string[];
  stats: StatItem[];
  legend?: LegendItem[];
  chart?: Omit<BarChartProps, "id"> & { id?: string }; 
  // You can pass any BarChart props (categories, series, colors, etc.)
}

const TargetsCard: React.FC<TargetsCardProps> = ({
  title,
  stats,
  legend,
  chart,
}) => {
  return (
    <Card title={title} actions={  <LinkButton label="More Details" />}>

      {/* Stats + Legend */}
      <div className="d-flex align-items-center justify-content-between flex-wrap gap-3">
        {/* Stats */}
        <div className="d-flex align-items-center flex-wrap gap-3">
          {stats.map((stat, idx) => (
            <div key={idx}>
              <p className="fs-13 mb-1">{stat.label}</p>
              <h6 className={`fs-14 fw-semibold text-${stat.color || "dark"}`}>
                {stat.value}
              </h6>
            </div>
          ))}
        </div>

        {/* Legend */}
        {legend && (
          <div className="d-flex align-items-center gap-2">
            {legend.map((item, idx) => (
              <p
                key={idx}
                className="fs-13 text-dark d-flex align-items-center mb-0"
              >
                <i
                  className={`fa-solid fa-circle fs-12 me-1 text-${item.color}`}
                ></i>
                {item.label}
              </p>
            ))}
          </div>
        )}
      </div>

      {/* Chart */}
      {chart && (
        <BarChart
          {...chart}
        />
      )}
    </Card>
  );
};

export default TargetsCard;
