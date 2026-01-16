import { useContext } from "react";
import { GlobalComponentContext } from "./GlobalComponentContext";

export default function useGlobalComponentContext() {
  const ctx = useContext(GlobalComponentContext);

  if (!ctx) {
    throw new Error("useComponentRegistration must be used within an ComponentRegistrationContext");
  }

  return ctx;
}