import React, { useMemo } from "react";
import Chart from "react-apexcharts";
import type { ApexOptions } from "apexcharts";
import { formatCurrency } from "../../../utils/formatters"; // ✅ adjust path

export interface DonutChartProps {
  labels: string[];
  series: number[];
  height?: number;
  colors?: string[];
  showLegend?: boolean;
  showTotal?: boolean;
  fractionDigits?: number;
  title?: string;
}

const DonutChart: React.FC<DonutChartProps> = ({
  labels,
  series,
  height = 320,
  colors = ["#7539FF", "#F0EAFC", "#2ECC71", "#FF9F43", "#EA5455"],
  showLegend = true,
  showTotal = true,
  fractionDigits = 0,
  title,
}) => {
  // unique id for CSS targeting
  const chartId = useMemo(() => `donut-${Math.random().toString(36).substring(2, 9)}`, []);
  const legendColor = "#000000";
  const total = series.reduce((sum, val) => sum + val, 0);

  const options: ApexOptions = {
    chart: {
      type: "donut",
      fontFamily: "Poppins, sans-serif",
      toolbar: { show: false },
      foreColor: legendColor,
    },
    labels,
    colors,
    legend: {
      show: showLegend,
      position: "bottom",
      fontSize: "14px",
      labels: { colors: legendColor },
    },
    dataLabels: {
      enabled: true,
      formatter: (val: number) => `${val.toFixed(1)}%`,
      style: { colors: [legendColor] },
    },
    tooltip: {
      theme: "dark", // ✅ Dark background (white text by default)
      y: {
        formatter: (val: number) => formatCurrency(val, fractionDigits),
      },
    },
    plotOptions: {
      pie: {
        donut: {
          size: "65%",
          labels: {
            show: showTotal,
            name: { show: true, fontSize: "16px", offsetY: 10, color: legendColor },
            value: {
              show: true,
              fontSize: "18px",
              fontWeight: 600,
              color: legendColor,
              formatter: (val) => formatCurrency(parseFloat(val), fractionDigits),
            },
            total: {
              show: true,
              label: title || "Total",
              fontSize: "16px",
              fontWeight: 600,
              color: legendColor,
              formatter: () => formatCurrency(total, fractionDigits),
            },
          },
        },
      },
    },
  };

  return (
    <div id={chartId}>
      <style>{`
        /* ✅ Keep legend text black */
        #${chartId} .apexcharts-legend-text {
          color: ${legendColor} !important;
          fill: ${legendColor} !important;
        }

        /* ✅ Ensure tooltip text stays white (in case theme override fails) */
        #${chartId} .apexcharts-tooltip-text,
        #${chartId} .apexcharts-tooltip-title,
        #${chartId} .apexcharts-tooltip-series-group span {
          color: #ffffff !important;
          fill: #ffffff !important;
        }
      `}</style>

      <Chart options={options} series={series} type="donut" height={height} />
    </div>
  );
};

export default DonutChart;
