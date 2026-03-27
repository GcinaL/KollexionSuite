export const formatNumber = (value: number, locale: string = "en-ZA"): string => {
  return value.toLocaleString(locale);
};

/**
 * Format a number as currency
 */
export const formatCurrency = (
  value: number,
  fractionDigits: number = 2,
  locale: string = "en-ZA",
  currency: string = "ZAR"
): string => {
  return new Intl.NumberFormat(locale, {
    style: "currency",
    currency,
    minimumFractionDigits: fractionDigits,
    maximumFractionDigits: fractionDigits,
  }).format(value);
};


export const formatDate = (
  date: Date,
  format: string = "dd-MM-yyyy",
  locale: string = "en-ZA"
): string => {
  const options: Intl.DateTimeFormatOptions = {
    year: "numeric",
    month: "short",
    day: "2-digit",
  };

  const parts = new Intl.DateTimeFormat(locale, options).formatToParts(date);

  const lookup: Record<string, string> = {};
  parts.forEach(({ type, value }) => {
    lookup[type] = value;
  });

  // Map to handle formatting tokens
  return format
    .replace(/dd/g, lookup.day || "")
    .replace(/MM/g, String(date.getMonth() + 1).padStart(2, "0"))
    .replace(/MMM/g, lookup.month || "")
    .replace(/yyyy/g, lookup.year || "")
    .replace(/yy/g, lookup.year ? lookup.year.slice(-2) : "");
};

/**
 * Format a number as percentage (e.g. 0.1234 → "12.34%")
 */
export const formatPercentage = (
  value: number,
  fractionDigits: number = 2,
  locale: string = "en-ZA"
): string => {
  return new Intl.NumberFormat(locale, {
    style: "percent",
    minimumFractionDigits: fractionDigits,
    maximumFractionDigits: fractionDigits,
  }).format(value);
};