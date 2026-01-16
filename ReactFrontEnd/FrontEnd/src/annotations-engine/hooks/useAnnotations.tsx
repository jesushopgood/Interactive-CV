import { useContext } from "react";
import { AnnotationContext } from "../context/AnnotationContext";

export default function useAnnotations() {
  const ctx = useContext(AnnotationContext);
  if (!ctx) {
    throw new Error("useAnnotations must be used within an AnnotationProvider");
  }

  return ctx;
}