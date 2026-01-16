import React from "react";

interface AnnotationDotProps {
  top: number;
  left: number;
  size?: number;
  color?: string;
  visible?: boolean;
}

export const AnnotationDot = React.memo(function AnnotationDot({top, left, size = 10, color = "red", visible = true}: AnnotationDotProps)
{
  if (!visible) return null;

  return (
    <div
      style={{
        position: "fixed",
        top,
        left,
        width: size,
        height: size,
        backgroundColor: color,
        borderRadius: "50%",
        transform: "translate(-50%, -50%)",
        pointerEvents: "none", // ensures it never blocks clicks
        zIndex: 9999,
      }}
    />
  );
});
