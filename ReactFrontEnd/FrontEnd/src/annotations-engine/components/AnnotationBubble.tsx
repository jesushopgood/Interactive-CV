import {useEffect, useRef, useState } from "react";
import React from "react";
import type { Position2D } from "../hooks/useAnnotation";
import { useStore } from "../../state";

interface AnnotationBubbleProps {
  children: React.ReactNode;
  centre: Position2D;
  arrowDirection?: "top" | "right" | "bottom" | "left";
}

export const AnnotationBubble = React.memo(function AnnotationBubble({
  children,
  centre,
  arrowDirection = "left",
}: AnnotationBubbleProps) {

  const showAnnotations = useStore(x => x.showAnnotations);
  const ref = useRef<HTMLDivElement>(null);

  const [pos, setPos] = useState({ top: 0, left: 0 });

  useEffect(() => {
    if (!ref.current) return;

    const bubbleRect = ref.current.getBoundingClientRect();

    // Align bubble's vertical center to centre.top
    const top = centre.top - bubbleRect.height / 2;

    // Horizontal position (centre.left already includes offsetX)
    const left = centre.left;

    setPos({ top, left });
  }, [centre]);

  return (
    showAnnotations && (
      <div
        ref={ref}
        className="annotation-bubble position-fixed"
        style={{
          top: pos.top,
          left: pos.left,
        }}
      >
        <div className={`bubble bubble-arrow-${arrowDirection}`}>
          {children}
        </div>
      </div>
    )
  );
});
