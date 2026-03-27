import React from "react";
import Chart from "react-apexcharts";
import type { ApexOptions } from "apexcharts";
import { formatCurrency } from "../../../utils/formatters"; // ✅ adjust path to where you saved formatCurrency

export type BarChartMode = "grouped" | "stacked" | "progress";

export interface BarChartSeries {
  name: string;
  data: number[];
}

export interface BarChartProps {
  categories: string[];
  series: BarChartSeries[];
  height?: number;
  colors?: string[];
  mode?: BarChartMode;
  baselineValue?: number;
  showLegend?: boolean;
  fractionDigits?: number; // ✅ how many decimals to show in tooltip
}

const BarChart: React.FC<BarChartProps> = ({
  categories,
  series,
  height = 350,
  colors = ["#7539FF", "#F0EAFC"],
  mode = "grouped",
  baselineValue = 100,
  showLegend,
  fractionDigits = 0, // default to no cents
}) => {
  let chartSeries = series;
  let stacked = false;

  // Progress Mode
  if (mode === "progress") {
    chartSeries = [
      {
        name: "Outstanding",
        data: Array(categories.length).fill(baselineValue),
      },
      ...series,
    ];
    stacked = true;
    colors = colors.length >= 2 ? colors : ["#7539FF", "#F0EAFC"];
  }

  // Stacked Mode
  if (mode === "stacked") {
    stacked = true;
  }

  const options: ApexOptions = {
    chart: {
      type: "bar",
      stacked,
      toolbar: { show: false },
      fontFamily: "Poppins, sans-serif",
    },
    plotOptions: {
      bar: {
        horizontal: false,
        borderRadius: 5,
        columnWidth: "40%",
      },
    },
    colors: colors,
    dataLabels: { enabled: false },
    stroke: { show: false },
    grid: { borderColor: "#E2E4E6", strokeDashArray: 5 },
    xaxis: { categories },
    yaxis: { min: 0 },
    legend: {
      show: showLegend !== undefined ? showLegend : mode !== "progress",
    },
    tooltip: {
      y: {
        formatter: (val: number) => formatCurrency(val, fractionDigits), // ✅ use your formatter
      },
    },
  };

  return <Chart options={options} series={chartSeries} type="bar" height={height} />;
};

export default BarChart;