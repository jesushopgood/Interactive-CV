/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useLayoutEffect, useRef, useState } from "react";
import { layoutEvents } from "../../event-bus/layoutEvents";
import { useStore } from "../../state";

export interface Position2D {
  top: number;
  left: number;
}

type XPosDefault = "center" | "right";

export function useAnnotation(xPosDefault: XPosDefault  = "center", offsetX: number = 0, offsetY: number = 0) {
  const targetElementRef = useRef<HTMLDivElement>(null);
  const [targetCentre, setTargetCentre] = useState<Position2D>({
    top: 0,
    left: 0,
  });

  const [boundingRect, setBoundingRect] = useState<DOMRect | null>(null);
  const showAnnotations = useStore(x => x.showAnnotations);

  const updatePosition = () => {
    if (targetElementRef.current) {
      const rect = targetElementRef.current.getBoundingClientRect();

      setBoundingRect(rect);
      setTargetCentre({
        top: rect.top + rect.height / 2 + offsetY,
        left: rect.left + rect.width / (xPosDefault  === "center" ? 2 : 1) + offsetX,
      });
    }
  };

  const recalc = () => {
    updatePosition();
    setTimeout(() => layoutEvents.emit("recalc:complete"), 0);
  };

  useEffect(() => {
    const handler = () => recalc();
    layoutEvents.on("typewriter:done", handler);

    return () => layoutEvents.off("typewriter:done", handler);
  }, []);

  useLayoutEffect(() => {
    if (showAnnotations) {
      updatePosition();
    }

    window.addEventListener("resize", updatePosition);
    window.addEventListener("scroll", updatePosition);

    return () => {
      window.removeEventListener("resize", updatePosition);
      window.removeEventListener("scroll", updatePosition);
    };
  }, [showAnnotations]);

  return { targetElementRef, targetCentre, boundingRect, recalc };
}